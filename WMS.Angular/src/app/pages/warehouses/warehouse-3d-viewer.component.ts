import { 
  AfterViewInit, 
  Component, 
  EventEmitter,
  ElementRef, 
  Input,
  OnChanges,
  OnDestroy, 
  Output,
  ViewChild, 
  ChangeDetectorRef,
  HostListener,
  SimpleChanges,
  inject
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Warehouse3DViewerService, Rack3D, Bin3D, BinInventoryItem, sumBinInventoryCbm } from './warehouse-3d-viewer.service';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { BinSummaryDto, WarehouseDetailsDto } from '../../api/generated/models';
import { Api } from '../../api/generated/api';
import { updateBin3DLocation } from '../../api/generated/fn/wms-api/update-bin-3-d-location';
import { CreateCheckInModalComponent } from '../check-in/components/create/create-check-in-modal.component';
import { CreatePickOrderModalComponent } from '../pick-order/create-pick-order-modal.component';
import { ReceivingCreateComponent } from '../receiving/create/receiving-create.component';
import { 
  LucideAngularModule, 
  Warehouse, 
  Box, 
  RefreshCw, 
  RotateCcw, 
  Info, 
  Maximize2, 
  Minimize2, 
  X,
  AlertCircle,
  Smartphone,
  LogOut,
  ChevronRight,
  PackageCheck,
  PackageX
} from 'lucide-angular';
import * as THREE from 'three';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';

interface CollisionBox {
  minX: number;
  maxX: number;
  minZ: number;
  maxZ: number;
}

interface BinVisualDimensions {
  width: number;
  height: number;
  depth: number;
}

export interface BinWorldPosition {
  positionX: number;
  positionY: number;
  positionZ: number;
  rotationY: number;
}

export interface EmptySpotPointer {
  clientX: number;
  clientY: number;
  position: BinWorldPosition;
}

@Component({
  selector: 'app-warehouse-3d-viewer',
  standalone: true,
  imports: [
    CommonModule,
    LucideAngularModule,
    CreateCheckInModalComponent,
    CreatePickOrderModalComponent,
    ReceivingCreateComponent,
  ],
  templateUrl: './warehouse-3d-viewer.component.html'
})
export class Warehouse3DViewerComponent implements AfterViewInit, OnDestroy, OnChanges {
  readonly WarehouseIcon = Warehouse;
  readonly BoxIcon = Box;
  readonly RefreshIcon = RefreshCw;
  readonly ResetIcon = RotateCcw;
  readonly InfoIcon = Info;
  readonly MaximizeIcon = Maximize2;
  readonly MinimizeIcon = Minimize2;
  readonly XIcon = X;
  readonly AlertIcon = AlertCircle;
  readonly SmartphoneIcon = Smartphone;
  readonly LogoutIcon = LogOut;
  readonly ChevronRightIcon = ChevronRight;
  readonly PackageCheckIcon = PackageCheck;
  readonly PackageXIcon = PackageX;

  @ViewChild('viewerContainer', { static: true }) viewerContainer!: ElementRef<HTMLDivElement>;
  @ViewChild('joystickStick') joystickStick!: ElementRef<HTMLDivElement>;

  racks: Rack3D[] = [];
  standaloneBins: Bin3D[] = [];
  selectedWarehouse: WarehouseDetailsDto | null = null;
  isLoading = true;
  isLoadingInventory = false;
  error = '';
  showInfo = true;
  hoveredBin: Bin3D | null = null;
  selectedBin: Bin3D | null = null;
  selectedBinItems: BinInventoryItem[] = [];
  selectedBinQrUrl = '';
  totalBins = 0;
  totalRacks = 0;
  totalBays = 0;
  totalLevels = 0;
  isFullscreen = false;
  isMobileDevice = false;
  isFlying = false;
  isCheckInOpen = false;
  isPickOrderOpen = false;
  isReceivingCreateOpen = false;
  isLocalBinMoveActive = false;
  binMoveError = '';

  // First-Person Player Physics & Controls State
  private playerPos = new THREE.Vector3(0, 1.8, 45); // Height = 1.8m (Eye level)
  private playerVelocityY = 0;
  private isGrounded = true;
  private pitch = 0; // Pitch angle (up/down)
  private yaw = -Math.PI / 2; // Yaw angle (left/right)
  private moveForward = false;
  private moveBackward = false;
  private moveLeft = false;
  private moveRight = false;
  private moveUp = false;
  private moveDown = false;
  private isPointerLocked = false;

  // Touch Virtual Joystick State
  touchJoystickActive = false;
  private joystickCenter = { x: 0, y: 0 };
  private joystickVector = { x: 0, y: 0 };
  private activeTouchIdLook: number | null = null;
  private touchLookLast = { x: 0, y: 0 };

  private scene!: THREE.Scene;
  private camera!: THREE.PerspectiveCamera;
  private renderer!: THREE.WebGLRenderer;
  private rackGroup!: THREE.Group;
  private floorZonesGroup!: THREE.Group;
  private raycaster = new THREE.Raycaster();
  private pointer = new THREE.Vector2();
  private animationFrameId = 0;
  private resizeObserver: ResizeObserver | null = null;
  private binMeshes = new Map<number, THREE.Mesh>();
  private qrSpriteMap = new Map<number, THREE.Sprite>();
  private textureLoader = new THREE.TextureLoader();
  private collisionBoxes: CollisionBox[] = [];
  private standaloneBinCollisionBoxes = new Map<number, CollisionBox>();

  @Input() warehouseIdOverride: number | null = null;
  @Input() showStandaloneBins = false;
  @Input() binMoveMode = false;
  @Input() isWarehouse2Layout = false;
  @Output() binSelected = new EventEmitter<Bin3D>();
  @Output() emptySpotChanged = new EventEmitter<EmptySpotPointer | null>();
  @Output() emptySpotClicked = new EventEmitter<BinWorldPosition>();
  @Output() binMoveRequested = new EventEmitter<Bin3D>();
  @Output() binMoveDropped = new EventEmitter<{ binId: number; position: BinWorldPosition }>();
  @Output() binMoveCancelled = new EventEmitter<void>();
  @Output() receivingCreateRequested = new EventEmitter<void>();

  private movingBinOriginalPosition: THREE.Vector3 | null = null;
  private movingBinOriginalRotation = 0;
  private carriedBinForwardOffset = 2.5;
  private carriedBinLateralOffset = 0;
  private receivingActionMesh: THREE.Mesh | null = null;
  private preventPointerLockForNextClick = false;
  private readonly api = inject(Api);

  constructor(
    private warehouse3DService: Warehouse3DViewerService,
    private warehouseService: WarehouseService,
    private cd: ChangeDetectorRef
  ) {
    this.isMobileDevice = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['binMoveMode']) {
      if (this.binMoveMode) {
        this.captureMovingBinPosition();
        if (this.selectedBin) this.removeStandaloneBinCollision(this.selectedBin.id);
      }
      else this.restoreMovingBinPosition();
    }
  }

  ngAfterViewInit(): void {
    if (this.warehouseIdOverride !== null) {
      this.warehouseService.setWarehouse(this.warehouseIdOverride);
    }
    this.initScene();
    void this.loadWarehouseData();
    this.setupResizeObserver();
  }

  ngOnDestroy(): void {
    if (this.animationFrameId) cancelAnimationFrame(this.animationFrameId);
    if (this.resizeObserver) this.resizeObserver.disconnect();
    if (this.renderer) this.renderer.dispose();
    if (this.scene) this.scene.clear();
    this.binMeshes.clear();
    this.qrSpriteMap.clear();
  }

  async loadWarehouseData(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.clearScene();

    try {
      await this.warehouseService.ensureInitialized();
      this.selectedWarehouse = this.warehouseService.activeWarehouse();

      const includeStandaloneBins = this.shouldShowStandaloneBins;
      const data = await this.warehouse3DService.fetchWarehouse3DData(includeStandaloneBins);
      await this.warehouse3DService.preloadBinInventory(data.racks, 8, data.standaloneBins);
      this.racks = data.racks;
      this.standaloneBins = data.standaloneBins;
      this.totalRacks = data.racks.length;
      this.totalBays = data.racks.reduce((sum, rack) => sum + rack.bays.length, 0);
      this.totalLevels = data.racks.reduce(
        (sum, rack) => sum + rack.bays.reduce((baySum, bay) => baySum + bay.levels.length, 0),
        0
      );
      this.totalBins = data.racks.reduce(
        (sum, rack) => sum + rack.bays.reduce(
          (baySum, bay) => baySum + bay.levels.reduce((levelSum, level) => levelSum + level.bins.length, 0),
          0
        ),
        0
      ) + data.standaloneBins.length;

      if (this.isWarehouse2Layout) {
        this.buildWarehouse2FloorPlan();
      } else {
        this.buildFloorPlanZones();
        this.buildFloorPlanRacks(data.racks);
      }
      if (includeStandaloneBins) this.buildStandaloneBins(data.standaloneBins);

      setTimeout(() => {
        this.resize();
        this.resetPlayerPosition();
      }, 0);
    } catch (err: any) {
      console.error('Failed to load warehouse 3D data:', err);
      this.error = err?.message || 'Unable to load warehouse structure. Please try again.';
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  get shouldShowStandaloneBins(): boolean {
    return this.showStandaloneBins || this.selectedWarehouse?.id === 1;
  }

  get isMovingBin(): boolean {
    return this.binMoveMode || this.isLocalBinMoveActive;
  }

  get selectedBinTotalCbm(): number {
    return sumBinInventoryCbm(this.selectedBinItems);
  }

  completeBinMove(position: BinWorldPosition): void {
    const bin = this.selectedBin;
    const mesh = bin ? this.binMeshes.get(bin.id) : undefined;
    if (!bin || !mesh) return;

    mesh.position.set(position.positionX, position.positionY, position.positionZ);
    mesh.rotation.y = position.rotationY;
    bin.location3D = {
      ...bin.location3D,
      positionX: position.positionX,
      positionY: position.positionY,
      positionZ: position.positionZ,
      rotationY: position.rotationY,
    };
    this.setStandaloneBinCollision(bin, mesh);
    this.movingBinOriginalPosition = null;
    this.movingBinOriginalRotation = position.rotationY;
  }

  addCreatedStandaloneBin(bin: Bin3D): void {
    if (!bin.location3D) {
      throw new Error(`Created bin ${bin.id} has no 3D location.`);
    }
    if (this.binMeshes.has(bin.id)) return;

    const dimensions = this.getBinVisualDimensions(bin);
    const mesh = this.createBinMesh(bin, dimensions.width, dimensions.height, dimensions.depth);
    mesh.userData['standaloneBinDimensions'] = dimensions;
    mesh.position.set(
      bin.location3D.positionX ?? 0,
      dimensions.height / 2,
      bin.location3D.positionZ ?? 0
    );
    mesh.rotation.y = bin.location3D.rotationY ?? 0;
    this.rackGroup.add(mesh);
    this.binMeshes.set(bin.id, mesh);
    this.standaloneBins.push(bin);
    this.totalBins += 1;
    this.attachCornerQrBadge(mesh, bin, dimensions.width, dimensions.height, dimensions.depth);
    if (this.isMovingBin && this.selectedBin?.id === bin.id) {
      this.removeStandaloneBinCollision(bin.id);
    } else {
      this.setStandaloneBinCollision(bin, mesh);
    }
    this.binSelected.emit(bin);
    void this.selectBin(bin, mesh);
  }

  exitNavigation(): void {
    this.moveForward = false;
    this.moveBackward = false;
    this.moveLeft = false;
    this.moveRight = false;
    this.moveUp = false;
    this.moveDown = false;
    this.touchJoystickActive = false;
    this.joystickVector = { x: 0, y: 0 };
    if (document.pointerLockElement === this.renderer?.domElement) {
      document.exitPointerLock();
    }
  }

  private initScene(): void {
    const container = this.viewerContainer.nativeElement;
    const width = container.clientWidth || 1000;
    const height = container.clientHeight || 600;

    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0x0f172a);
    this.scene.fog = new THREE.Fog(0x0f172a, 60, 160);

    this.camera = new THREE.PerspectiveCamera(60, width / height, 0.1, 1000);

    this.renderer = new THREE.WebGLRenderer({ antialias: true, powerPreference: 'high-performance' });
    this.renderer.setPixelRatio(Math.min(window.devicePixelRatio, this.isMobileDevice ? 1.5 : 2));
    this.renderer.setSize(width, height);
    this.renderer.shadowMap.enabled = !this.isMobileDevice; // Optimize mobile performance
    if (!this.isMobileDevice) {
      this.renderer.shadowMap.type = THREE.PCFSoftShadowMap;
    }
    this.renderer.domElement.classList.add('viewer-canvas');
    container.appendChild(this.renderer.domElement);

    const ambientLight = new THREE.AmbientLight(0xffffff, 0.6);
    this.scene.add(ambientLight);

    const mainLight = new THREE.DirectionalLight(0xffffff, 1.0);
    mainLight.position.set(30, 60, 40);
    if (!this.isMobileDevice) {
      mainLight.castShadow = true;
      mainLight.shadow.mapSize.set(1024, 1024);
    }
    this.scene.add(mainLight);

    // Ground Floor
    const groundGeometry = new THREE.PlaneGeometry(
      this.isWarehouse2Layout ? 96 : 120,
      this.isWarehouse2Layout ? 72 : 120
    );
    const groundMaterial = new THREE.MeshStandardMaterial({
      color: this.isWarehouse2Layout ? 0x73777a : 0x1e293b,
      roughness: 0.8,
    });
    const ground = new THREE.Mesh(groundGeometry, groundMaterial);
    ground.rotation.x = -Math.PI / 2;
    ground.receiveShadow = !this.isMobileDevice;
    this.scene.add(ground);

    if (!this.isWarehouse2Layout) {
      const grid = new THREE.GridHelper(120, 60, 0x334155, 0x1e293b);
      grid.position.y = 0.02;
      this.scene.add(grid);
    }

    this.floorZonesGroup = new THREE.Group();
    this.scene.add(this.floorZonesGroup);

    this.rackGroup = new THREE.Group();
    this.scene.add(this.rackGroup);

    // Event listeners for Desktop Pointer Lock & Mouse Look
    const canvas = this.renderer.domElement;
    canvas.addEventListener('click', () => {
      if (this.preventPointerLockForNextClick) {
        this.preventPointerLockForNextClick = false;
        return;
      }
      if (!this.isMobileDevice && !this.isPointerLocked) {
        canvas.requestPointerLock();
      }
    });

    document.addEventListener('pointerlockchange', () => {
      this.isPointerLocked = document.pointerLockElement === canvas;
    });

    document.addEventListener('mousemove', (e) => {
      if (this.isPointerLocked) {
        const sensitivity = 0.002;
        this.yaw -= e.movementX * sensitivity;
        this.pitch -= e.movementY * sensitivity;
        this.pitch = Math.max(-Math.PI / 2.2, Math.min(Math.PI / 2.2, this.pitch));
      }
    });

    canvas.addEventListener('pointerdown', this.onCanvasPointerDown.bind(this));
    canvas.addEventListener('pointermove', this.onCanvasPointerMove.bind(this));
    canvas.addEventListener('pointerleave', () => this.emptySpotChanged.emit(null));
    canvas.addEventListener('contextmenu', this.onCanvasContextMenu.bind(this));

    this.animate();
  }

  // Keyboard Controls
  @HostListener('window:keydown', ['$event'])
  onKeyDown(event: KeyboardEvent): void {
    const target = event.target as HTMLElement | null;
    const editing = target?.isContentEditable ||
      ['INPUT', 'TEXTAREA', 'SELECT'].includes(target?.tagName ?? '');
    if (editing) return;

    if (this.isMovingBin) {
      switch (event.code) {
        case 'Escape':
          event.preventDefault();
          this.cancelStandaloneBinMove();
          return;
        case 'Enter':
          event.preventDefault();
          this.dropMovingBin();
          return;
        case 'KeyR':
          event.preventDefault();
          this.rotateMovingBin();
          return;
        case 'ArrowUp':
          event.preventDefault();
          this.nudgeCarriedBin(0.25, 0);
          return;
        case 'ArrowDown':
          event.preventDefault();
          this.nudgeCarriedBin(-0.25, 0);
          return;
        case 'ArrowLeft':
          event.preventDefault();
          this.nudgeCarriedBin(0, -0.25);
          return;
        case 'ArrowRight':
          event.preventDefault();
          this.nudgeCarriedBin(0, 0.25);
          return;
      }
    } else if (this.shouldShowStandaloneBins && event.code === 'KeyM' && !event.repeat && this.selectedBin &&
      (this.selectedBin.rack ?? '').toLowerCase() === 'standalone') {
      event.preventDefault();
      this.requestStandaloneBinMove(this.selectedBin);
      return;
    }

    switch (event.code) {
      case 'KeyW': case 'ArrowUp': this.moveForward = true; break;
      case 'KeyS': case 'ArrowDown': this.moveBackward = true; break;
      case 'KeyA': case 'ArrowLeft': this.moveLeft = true; break;
      case 'KeyD': case 'ArrowRight': this.moveRight = true; break;
      case 'KeyF':
        if (!event.repeat) this.toggleFlight();
        break;
      case 'Space':
        event.preventDefault();
        if (this.isFlying) this.moveUp = true;
        else this.triggerJump();
        break;
      case 'ShiftLeft': case 'ShiftRight':
        if (this.isFlying) this.moveDown = true;
        break;
    }
  }

  @HostListener('window:keyup', ['$event'])
  onKeyUp(event: KeyboardEvent): void {
    switch (event.code) {
      case 'KeyW': case 'ArrowUp': this.moveForward = false; break;
      case 'KeyS': case 'ArrowDown': this.moveBackward = false; break;
      case 'KeyA': case 'ArrowLeft': this.moveLeft = false; break;
      case 'KeyD': case 'ArrowRight': this.moveRight = false; break;
      case 'Space': this.moveUp = false; break;
      case 'ShiftLeft': case 'ShiftRight': this.moveDown = false; break;
    }
  }

  @HostListener('window:blur')
  onWindowBlur(): void {
    this.moveForward = false;
    this.moveBackward = false;
    this.moveLeft = false;
    this.moveRight = false;
    this.moveUp = false;
    this.moveDown = false;
  }

  toggleFlight(): void {
    this.isFlying = !this.isFlying;
    this.playerVelocityY = 0;
    this.moveUp = false;
    this.moveDown = false;
    this.cd.markForCheck();
  }

  setFlightVerticalDirection(direction: 'up' | 'down', isPressed: boolean): void {
    if (direction === 'up') this.moveUp = isPressed && this.isFlying;
    else this.moveDown = isPressed && this.isFlying;
  }

  triggerJump(): void {
    if (!this.isFlying && this.isGrounded) {
      this.playerVelocityY = 6.0; // Jump force
      this.isGrounded = false;
    }
  }

  // Mobile Touch Controls Implementation
  onTouchJoystickStart(event: TouchEvent): void {
    event.preventDefault();
    const touch = event.changedTouches[0];
    this.touchJoystickActive = true;
    this.joystickCenter = { x: touch.clientX, y: touch.clientY };
    this.updateJoystickPosition(touch.clientX, touch.clientY);
  }

  onTouchJoystickMove(event: TouchEvent): void {
    if (!this.touchJoystickActive) return;
    event.preventDefault();
    const touch = event.changedTouches[0];
    this.updateJoystickPosition(touch.clientX, touch.clientY);
  }

  onTouchJoystickEnd(event: TouchEvent): void {
    this.touchJoystickActive = false;
    this.joystickVector = { x: 0, y: 0 };
    if (this.joystickStick) {
      this.joystickStick.nativeElement.style.transform = `translate(0px, 0px)`;
    }
  }

  private updateJoystickPosition(clientX: number, clientY: number): void {
    const dx = clientX - this.joystickCenter.x;
    const dy = clientY - this.joystickCenter.y;
    const maxRadius = 40;
    const distance = Math.hypot(dx, dy);
    const angle = Math.atan2(dy, dx);

    const clampedDist = Math.min(distance, maxRadius);
    const stickX = Math.cos(angle) * clampedDist;
    const stickY = Math.sin(angle) * clampedDist;

    if (this.joystickStick) {
      this.joystickStick.nativeElement.style.transform = `translate(${stickX}px, ${stickY}px)`;
    }

    this.joystickVector = {
      x: stickX / maxRadius,
      y: stickY / maxRadius
    };
  }

  onTouchLookStart(event: TouchEvent): void {
    const touch = event.changedTouches[0];
    this.activeTouchIdLook = touch.identifier;
    this.touchLookLast = { x: touch.clientX, y: touch.clientY };
  }

  onTouchLookMove(event: TouchEvent): void {
    if (this.activeTouchIdLook === null) return;
    for (let i = 0; i < event.changedTouches.length; i++) {
      const touch = event.changedTouches[i];
      if (touch.identifier === this.activeTouchIdLook) {
        const dx = touch.clientX - this.touchLookLast.x;
        const dy = touch.clientY - this.touchLookLast.y;
        this.yaw -= dx * 0.005;
        this.pitch -= dy * 0.005;
        this.pitch = Math.max(-Math.PI / 2.2, Math.min(Math.PI / 2.2, this.pitch));
        this.touchLookLast = { x: touch.clientX, y: touch.clientY };
        break;
      }
    }
  }

  onTouchLookEnd(event: TouchEvent): void {
    for (let i = 0; i < event.changedTouches.length; i++) {
      if (event.changedTouches[i].identifier === this.activeTouchIdLook) {
        this.activeTouchIdLook = null;
        break;
      }
    }
  }

  private buildFloorPlanZones(): void {
    this.collisionBoxes = [];
    this.standaloneBinCollisionBoxes.clear();

    const perimeterMaterial = new THREE.MeshStandardMaterial({
      color: 0x64717b,
      roughness: 0.8,
    });
    const addPerimeterWall = (
      width: number,
      height: number,
      depth: number,
      x: number,
      y: number,
      z: number
    ): void => {
      const wall = new THREE.Mesh(
        new THREE.BoxGeometry(width, height, depth),
        perimeterMaterial
      );
      wall.position.set(x, y, z);
      wall.castShadow = !this.isMobileDevice;
      wall.receiveShadow = !this.isMobileDevice;
      this.floorZonesGroup.add(wall);
    };

    const wallHeight = 18;
    const wallCenterY = wallHeight / 2;
    addPerimeterWall(1.5, wallHeight, 104, -51, wallCenterY, 0);
    addPerimeterWall(1.5, wallHeight, 104, 51, wallCenterY, 0);
    addPerimeterWall(104, wallHeight, 1.5, 0, wallCenterY, -51);
    addPerimeterWall(42, wallHeight, 1.5, -31, wallCenterY, 51);
    addPerimeterWall(42, wallHeight, 1.5, 31, wallCenterY, 51);
    this.addConcreteRoof(104, 104, 18);

    // 1. Office / Comfort Room Zone (Bottom Left)
    const officeGeo = new THREE.BoxGeometry(22, 4, 18);
    const officeMat = new THREE.MeshStandardMaterial({ color: 0x334155, roughness: 0.7, transparent: true, opacity: 0.85 });
    const officeMesh = new THREE.Mesh(officeGeo, officeMat);
    officeMesh.position.set(-36, 2, 32);
    this.floorZonesGroup.add(officeMesh);
    this.addZoneLabel('OFFICE / COMFORT ROOM', -36, 4.5, 32);
    this.addCollisionBox(-47, -25, 23, 41);

    // 2. Receiving Area (Bottom-Center)
    const receivingGeo = new THREE.PlaneGeometry(16, 12);
    const receivingMat = new THREE.MeshBasicMaterial({ color: 0x3b82f6, side: THREE.DoubleSide, transparent: true, opacity: 0.25 });
    const receivingMesh = new THREE.Mesh(receivingGeo, receivingMat);
    receivingMesh.rotation.x = -Math.PI / 2;
    receivingMesh.position.set(-8, 0.05, 30);
    this.floorZonesGroup.add(receivingMesh);
    this.addZoneLabel('RECEIVING AREA', -8, 0.2, 30);

    // 3. Outgoing Area (Bottom-Right Center)
    const outgoingGeo = new THREE.PlaneGeometry(16, 12);
    const outgoingMat = new THREE.MeshBasicMaterial({ color: 0x10b981, side: THREE.DoubleSide, transparent: true, opacity: 0.25 });
    const outgoingMesh = new THREE.Mesh(outgoingGeo, outgoingMat);
    outgoingMesh.rotation.x = -Math.PI / 2;
    outgoingMesh.position.set(16, 0.05, 30);
    this.floorZonesGroup.add(outgoingMesh);
    this.addZoneLabel('OUTGOING AREA', 16, 0.2, 30);

    // 4. Weighing Scale
    const scaleGeo = new THREE.BoxGeometry(5, 0.2, 4);
    const scaleMat = new THREE.MeshStandardMaterial({ color: 0xf59e0b, metalness: 0.5 });
    const scaleMesh = new THREE.Mesh(scaleGeo, scaleMat);
    scaleMesh.position.set(-8, 0.1, 42);
    this.floorZonesGroup.add(scaleMesh);

    // 5. Loading and Unloading Bay
    const bayGeo = new THREE.PlaneGeometry(45, 4);
    const bayMat = new THREE.MeshBasicMaterial({ color: 0xeab308, side: THREE.DoubleSide, transparent: true, opacity: 0.35 });
    const bayMesh = new THREE.Mesh(bayGeo, bayMat);
    bayMesh.rotation.x = -Math.PI / 2;
    bayMesh.position.set(4, 0.06, 46);
    this.floorZonesGroup.add(bayMesh);
    this.addZoneLabel('LOADING & UNLOADING BAY', 4, 0.2, 46);

    const receivingPad = new THREE.Mesh(
      new THREE.BoxGeometry(6, 0.65, 2.4),
      new THREE.MeshStandardMaterial({
        color: 0x059669,
        roughness: 0.35,
        emissive: 0x064e3b,
        emissiveIntensity: 0.8,
      })
    );
    receivingPad.position.set(-8, 0.34, 24);
    receivingPad.userData['type'] = 'receiving-create';
    this.floorZonesGroup.add(receivingPad);
    this.receivingActionMesh = receivingPad;
    this.addZoneLabel('CREATE RECEIVING', -8, 1.3, 24);

    // 6. Stand-alone Bin Area (Bottom Right)
    const palletZoneGeo = new THREE.PlaneGeometry(14, 10);
    const palletZoneMat = new THREE.MeshBasicMaterial({ color: 0x0ea5e9, side: THREE.DoubleSide, transparent: true, opacity: 0.16 });
    const palletZoneMesh = new THREE.Mesh(palletZoneGeo, palletZoneMat);
    palletZoneMesh.rotation.x = -Math.PI / 2;
    palletZoneMesh.position.set(38, 0.05, 36);
    this.floorZonesGroup.add(palletZoneMesh);
    this.addZoneLabel('STAND-ALONE BIN AREA', 45, 0.2, 36);

    // 7. Fire Exit (Top Left)
    const exitGeo = new THREE.BoxGeometry(4, 4, 0.4);
    const exitMat = new THREE.MeshStandardMaterial({ color: 0xef4444 });
    const exitMesh = new THREE.Mesh(exitGeo, exitMat);
    exitMesh.position.set(-46, 2, -48);
    this.floorZonesGroup.add(exitMesh);
    this.addZoneLabel('FIRE EXIT', -46, 4.5, -48);

    // Outer Warehouse Perimeter Walls Collision Boundaries
    this.addCollisionBox(-52, 52, -52, -50); // Back Wall
    this.addCollisionBox(-52, -10, 50, 52);  // Front wall, left of loading entrance
    this.addCollisionBox(10, 52, 50, 52);    // Front wall, right of loading entrance
    this.addCollisionBox(-52, -50, -52, 52); // Left Wall
    this.addCollisionBox(50, 52, -52, 52);   // Right Wall
  }

  private addConcreteRoof(width: number, depth: number, undersideY: number): void {
    const thickness = 1.2;
    const roof = new THREE.Mesh(
      new THREE.BoxGeometry(width, thickness, depth),
      new THREE.MeshStandardMaterial({
        color: 0x9ca3a3,
        roughness: 0.92,
        metalness: 0.02,
      })
    );
    roof.position.set(0, undersideY + thickness / 2, 0);
    roof.receiveShadow = !this.isMobileDevice;
    roof.castShadow = !this.isMobileDevice;
    this.floorZonesGroup.add(roof);
  }

  private buildWarehouse2FloorPlan(): void {
    this.collisionBoxes = [];
    this.standaloneBinCollisionBoxes.clear();

    const floorGrid = new THREE.GridHelper(96, 48, 0x8b8e8e, 0x797d7d);
    floorGrid.position.y = 0.04;
    this.floorZonesGroup.add(floorGrid);

    const wallMaterial = new THREE.MeshStandardMaterial({ color: 0x64717b, roughness: 0.8 });
    const addWall = (width: number, height: number, depth: number, x: number, y: number, z: number): void => {
      const wall = new THREE.Mesh(new THREE.BoxGeometry(width, height, depth), wallMaterial);
      wall.position.set(x, y, z);
      wall.castShadow = !this.isMobileDevice;
      wall.receiveShadow = !this.isMobileDevice;
      this.floorZonesGroup.add(wall);
    };

    addWall(1, 12, 72, -48, 6, 0);
    addWall(1, 12, 72, 48, 6, 0);
    addWall(96, 12, 1, 0, 6, -36);
    addWall(36, 12, 1, -30, 6, 36);
    addWall(36, 12, 1, 30, 6, 36);
    this.addConcreteRoof(96, 72, 12);
    this.addCollisionBox(-49, -47, -36, 36);
    this.addCollisionBox(47, 49, -36, 36);
    this.addCollisionBox(-48, 48, -37, -35);
    this.addCollisionBox(-48, -18, 35, 37);
    this.addCollisionBox(18, 48, 35, 37);

    const yellowMaterial = new THREE.LineDashedMaterial({
      color: 0xfacc15,
      dashSize: 0.8,
      gapSize: 0.55,
    });
    const addAisleLine = (start: THREE.Vector3, end: THREE.Vector3): void => {
      const line = new THREE.Line(
        new THREE.BufferGeometry().setFromPoints([start, end]),
        yellowMaterial
      );
      line.computeLineDistances();
      this.floorZonesGroup.add(line);
    };
    for (const x of [-16, 16]) {
      addAisleLine(new THREE.Vector3(x, 0.08, -31), new THREE.Vector3(x, 0.08, 31));
    }
    for (const z of [-9, 9]) {
      addAisleLine(new THREE.Vector3(-44, 0.08, z), new THREE.Vector3(44, 0.08, z));
    }

    const elevator = new THREE.Mesh(
      new THREE.BoxGeometry(10, 4, 9),
      new THREE.MeshStandardMaterial({ color: 0x475569, roughness: 0.75 })
    );
    elevator.position.set(-40, 2, -28);
    this.floorZonesGroup.add(elevator);
    this.addZoneLabel('ELEVATOR', -40, 4.5, -28);
    this.addCollisionBox(-46, -34, -33, -23);

    const loadingMat = new THREE.MeshStandardMaterial({
      color: 0xfacc15,
      roughness: 0.65,
      emissive: 0x3d3200,
    });
    const loadingMark = new THREE.Mesh(new THREE.BoxGeometry(12, 0.08, 1.2), loadingMat);
    loadingMark.position.set(0, 0.06, 35);
    this.floorZonesGroup.add(loadingMark);
    this.addZoneLabel('ACCESS / LOADING', 0, 0.25, 40);

    const receivingButton = new THREE.Mesh(
      new THREE.BoxGeometry(6, 0.65, 2.4),
      new THREE.MeshStandardMaterial({
        color: 0x059669,
        roughness: 0.35,
        emissive: 0x064e3b,
        emissiveIntensity: 0.8,
      })
    );
    receivingButton.position.set(0, 0.34, 31);
    receivingButton.userData['type'] = 'receiving-create';
    receivingButton.castShadow = !this.isMobileDevice;
    receivingButton.receiveShadow = !this.isMobileDevice;
    this.floorZonesGroup.add(receivingButton);
    this.receivingActionMesh = receivingButton;
    this.addZoneLabel('CREATE RECEIVING', 0, 1.3, 31);
  }

  private buildFloorPlanRacks(racks: Rack3D[]): void {
    const palletRackPositions = [
      { x: -42, z: 2, rotateY: Math.PI / 2 },
      { x: 0, z: -42, rotateY: 0 },
      { x: 42, z: 2, rotateY: Math.PI / 2 }
    ];
    const crossDockPositions = [
      { x: -18, z: 6, rotateY: 0 },
      { x: 0, z: 6, rotateY: 0 },
      { x: 18, z: 6, rotateY: 0 },
      { x: 0, z: 16, rotateY: 0 }
    ];
    let fallbackPalletIndex = 0;

    racks.forEach((rack, idx) => {
      const rackNameLower = (rack.name ?? '').toLowerCase();

      if (rack.isMetalShelving) {
        const shelfNumber = Number(rackNameLower.match(/metal\s*shelv(?:ing)?\s*(\d+)/)?.[1] ?? 1);
        const shelfMesh = this.createMetalShelvingMesh(rack);
        if (shelfNumber === 2) {
          shelfMesh.position.set(-24.2, 0, 32);
        } else {
          shelfMesh.position.set(-36, 0, 22.2);
        }
        this.rackGroup.add(shelfMesh);
        const width = shelfNumber === 2 ? 1.2 : 16;
        const depth = 1.2;
        this.registerRackCollisionBoundary(shelfMesh.position.x, shelfMesh.position.z, width, depth, 0);
        return;
      }

      const rackNumberPattern = rack.isCrossDocking
        ? /cross\s*dock(?:ing)?\s*(\d+)/
        : /pallet\s*rack(?:ing)?\s*(\d+)/;
      const rackNumber = Number(rackNameLower.match(rackNumberPattern)?.[1] ?? 0);
      const positionList = rack.isCrossDocking ? crossDockPositions : palletRackPositions;
      const position = rackNumber > 0 && rackNumber <= positionList.length
        ? positionList[rackNumber - 1]
        : positionList[rack.isCrossDocking ? 0 : fallbackPalletIndex++ % palletRackPositions.length];

      const rackMeshGroup = rack.isCrossDocking
        ? this.createCrossDockingMesh(rack)
        : this.createPalletRackMesh(rack);

      rackMeshGroup.position.set(position.x, 0, position.z);
      rackMeshGroup.rotation.y = position.rotateY;
      const bayWidth = rack.isCrossDocking
        ? Math.max(rack.bays.length, 2) * 3.8
        : Math.max(rack.bayCount, rack.bays.length, 1) * 4.5 - 0.3;
      const crossDockBinCount = Math.max(1, ...rack.bays.map((bay) => bay.levels[0]?.bins.length ?? 0));
      const bayDepth = rack.isCrossDocking
        ? crossDockBinCount * 2.2 + Math.max(0, crossDockBinCount - 1) * 0.2
        : 3.6;
      this.registerRackCollisionBoundary(position.x, position.z, bayWidth, bayDepth, position.rotateY);
      this.rackGroup.add(rackMeshGroup);
    });
  }

  private buildStandaloneBins(bins: Bin3D[]): void {
    for (const bin of bins) {
      const location = bin.location3D;
      if (!location) continue;

      const dimensions = this.getBinVisualDimensions(bin);
      const mesh = this.createBinMesh(bin, dimensions.width, dimensions.height, dimensions.depth);
      mesh.userData['standaloneBinDimensions'] = dimensions;
      mesh.position.set(
        location.positionX ?? 0,
        dimensions.height / 2,
        location.positionZ ?? 0
      );
      mesh.rotation.y = location.rotationY ?? 0;
      this.rackGroup.add(mesh);
      this.binMeshes.set(bin.id, mesh);
      this.attachCornerQrBadge(mesh, bin, dimensions.width, dimensions.height, dimensions.depth);
      this.setStandaloneBinCollision(bin, mesh);
    }
  }

  // Multi-Level Pallet Racks (Left, Back, Right)
  private createPalletRackMesh(rack: Rack3D): THREE.Group {
    const rackGroup = new THREE.Group();
    rackGroup.userData = { type: 'rack', rack };

    const bayCount = Math.max(rack.bayCount, rack.bays.length, 1);
    const levelCount = Math.max(rack.levelCount, 1);
    const bayWidth = 4.2;
    const bayGap = 0.3;
    const levelHeight = 2.8;
    const bayDepth = 3.6;
    const rackWidth = bayCount * (bayWidth + bayGap) - bayGap;
    const rackHeight = levelCount * levelHeight + 0.6;

    // Upright Steel Posts
    const postMat = new THREE.MeshStandardMaterial({ color: 0x334155, metalness: 0.6, roughness: 0.4 });
    const postGeo = new THREE.BoxGeometry(0.2, rackHeight, 0.2);

    for (let b = 0; b <= bayCount; b++) {
      const x = -rackWidth / 2 + b * (bayWidth + bayGap);
      const frontPost = new THREE.Mesh(postGeo, postMat);
      frontPost.position.set(x, rackHeight / 2, bayDepth / 2);
      rackGroup.add(frontPost);

      const backPost = new THREE.Mesh(postGeo, postMat);
      backPost.position.set(x, rackHeight / 2, -bayDepth / 2);
      rackGroup.add(backPost);
    }

    // Bays, Levels, and Bins
    rack.bays.forEach((bay, bayIndex) => {
      const bayX = -rackWidth / 2 + bayIndex * (bayWidth + bayGap) + bayWidth / 2;

      bay.levels.forEach((level, levelIndex) => {
        const levelY = 0.2 + levelIndex * levelHeight; // Level 1 starts at bottom

        // Shelf Beam
        const shelfMat = new THREE.MeshStandardMaterial({ color: 0x64748b, metalness: 0.5, roughness: 0.5 });
        const shelfMesh = new THREE.Mesh(new THREE.BoxGeometry(bayWidth, 0.12, bayDepth), shelfMat);
        shelfMesh.position.set(bayX, levelY, 0);
        rackGroup.add(shelfMesh);

        // Bins
        const binCount = level.bins.length;
        const binWidth = Math.min(1.5, bayWidth / Math.max(binCount, 1));
        const binGap = 0.12;
        const binDepth = 2.2;
        const binHeight = 1.2;
        const binTotalWidth = Math.min(bayWidth - 0.2, binCount * (binWidth + binGap) - binGap);
        const binStartX = bayX - binTotalWidth / 2;

        level.bins.forEach((bin, binIndex) => {
          const binX = binStartX + binIndex * (binWidth + binGap) + binWidth / 2;
          const binMesh = this.createBinMesh(bin, binWidth, binHeight, binDepth);
          binMesh.position.set(binX, levelY + binHeight / 2 + 0.06, 0);
          rackGroup.add(binMesh);

          if (bin.id) this.binMeshes.set(bin.id, binMesh);

          // Add floating QR badge to the TOP-RIGHT CORNER of the bin
          this.attachCornerQrBadge(binMesh, bin, binWidth, binHeight, binDepth);
        });
      });
    });

    const label = this.createTextSprite(rack.name ?? `Rack ${rack.id}`);
    label.position.set(0, rackHeight + 1.2, 0);
    rackGroup.add(label);

    return rackGroup;
  }

  private createMetalShelvingMesh(rack: Rack3D): THREE.Group {
    const group = new THREE.Group();
    group.userData = { type: 'metalShelving', rack };

    const shelfMat = new THREE.MeshStandardMaterial({ color: 0x94a3b8, metalness: 0.7, roughness: 0.35 });
    const frameMat = new THREE.MeshStandardMaterial({ color: 0x334155, metalness: 0.8, roughness: 0.35 });
    const horizontalShelving = rack.bays.length > 1;
    const shelfWidth = horizontalShelving ? 16 : 1.2;
    const shelfDepth = 1.2;
    const bayWidth = shelfWidth / Math.max(rack.bays.length, 1);
    const shelfHeight = 3.8;
    const shelfLevels = Math.max(rack.levelCount, 1);
    const levelSpacing = shelfHeight / shelfLevels;
    const framePositions = horizontalShelving
      ? Array.from({ length: rack.bays.length + 1 }, (_, index) => -shelfWidth / 2 + index * bayWidth)
      : [-shelfWidth / 2, shelfWidth / 2];

    framePositions.forEach((x) => {
      for (const z of [-shelfDepth / 2, shelfDepth / 2]) {
        const frame = new THREE.Mesh(new THREE.BoxGeometry(0.12, shelfHeight, 0.12), frameMat);
        frame.position.set(x, shelfHeight / 2, z);
        group.add(frame);
      }
    });

    rack.bays.forEach((bay, bayIndex) => {
      const bayX = horizontalShelving ? -shelfWidth / 2 + bayIndex * bayWidth + bayWidth / 2 : 0;
      bay.levels.forEach((level, levelIndex) => {
        const shelfY = 0.16 + levelIndex * levelSpacing;
        const shelf = new THREE.Mesh(new THREE.BoxGeometry(bayWidth, 0.12, shelfDepth), shelfMat);
        shelf.position.set(bayX, shelfY, 0);
        group.add(shelf);

        const binWidth = Math.max(0.45, Math.min(bayWidth - 0.2, 1.2));
        const binDepth = Math.max(0.6, Math.min(shelfDepth - 0.2, 0.9));
        const binHeight = Math.max(0.45, Math.min(0.6, levelSpacing - 0.18));
        const binCount = level.bins.length;
        const gap = 0.08;
        const totalBinWidth = Math.min(bayWidth - 0.2, binCount * binWidth + Math.max(0, binCount - 1) * gap);
        const firstBinX = bayX - totalBinWidth / 2 + binWidth / 2;

        level.bins.forEach((bin, binIndex) => {
          const binMesh = this.createBinMesh(bin, binWidth, binHeight, binDepth);
          binMesh.position.set(
            firstBinX + binIndex * (binWidth + gap),
            shelfY + binHeight / 2 + 0.06,
            0
          );
          group.add(binMesh);
          if (bin.id) this.binMeshes.set(bin.id, binMesh);
          this.attachCornerQrBadge(binMesh, bin, binWidth, binHeight, binDepth);
        });
      });
    });

    const label = this.createTextSprite(rack.name ?? 'Metal Shelving');
    label.position.set(0, shelfHeight + 1.0, 0);
    group.add(label);

    return group;
  }

  // Ground-Level Only Cross-Docking Staging Bays (Center Area)
  private createCrossDockingMesh(rack: Rack3D): THREE.Group {
    const group = new THREE.Group();
    group.userData = { type: 'crossDocking', rack };

    const bayCount = Math.max(rack.bays.length, 2);
    const bayWidth = 3.8;
    const binWidth = 2.2;
    const binDepth = 2.2;
    const binGap = 0.2;
    const bayDepth = Math.max(
      1,
      ...rack.bays.map((bay) => {
        const binCount = bay.levels[0]?.bins.length ?? 0;
        return binCount * binDepth + Math.max(0, binCount - 1) * binGap;
      })
    );
    const totalWidth = bayCount * bayWidth;

    // Ground Floor Pad Indicator
    const padMat = new THREE.MeshBasicMaterial({ color: 0xeab308, side: THREE.DoubleSide, transparent: true, opacity: 0.25 });
    const padMesh = new THREE.Mesh(new THREE.PlaneGeometry(totalWidth, bayDepth), padMat);
    padMesh.rotation.x = -Math.PI / 2;
    padMesh.position.y = 0.03;
    group.add(padMesh);

    rack.bays.forEach((bay, bayIndex) => {
      const bayX = -totalWidth / 2 + bayIndex * bayWidth + bayWidth / 2;
      const level = bay.levels[0];
      if (!level) return;

      const binHeight = 0.9;
      const rowCount = level.bins.length;
      const rowStride = binDepth + binGap;
      const firstBinZ = (rowCount * binDepth + Math.max(0, rowCount - 1) * binGap) / 2 - binDepth / 2;
      const binsFrontToBack = [...level.bins].sort((a, b) =>
        Number.parseInt(a.level ?? '', 10) - Number.parseInt(b.level ?? '', 10)
      );

      binsFrontToBack.forEach((bin, binIndex) => {
        const binMesh = this.createBinMesh(bin, binWidth, binHeight, binDepth);
        binMesh.position.set(bayX, binHeight / 2 + 0.04, firstBinZ - binIndex * rowStride);
        group.add(binMesh);

        if (bin.id) this.binMeshes.set(bin.id, binMesh);

        this.attachCornerQrBadge(binMesh, bin, binWidth, binHeight, binDepth);
      });
    });

    const label = this.createTextSprite(rack.name ?? 'Cross Docking', 'rgba(234, 179, 8, 0.9)', '#0f172a');
    label.position.set(0, 3.0, 0);
    group.add(label);

    return group;
  }

  private createBinMesh(bin: Bin3D, width: number, height: number, depth: number): THREE.Mesh {
    const geo = new THREE.BoxGeometry(width, height, depth);
    
    // Default neutral state before inventory lookup
    const mat = new THREE.MeshStandardMaterial({
      color: 0x3b82f6,
      transparent: true,
      opacity: 0.85,
      roughness: 0.4,
      emissive: 0x1e3a8a,
      emissiveIntensity: 0.1
    });

    const mesh = new THREE.Mesh(geo, mat);
    mesh.userData = {
      type: 'bin',
      binId: bin.id,
      binCode: bin.binName,
      bin
    };
    if (bin.isOccupied !== undefined) {
      this.updateBinVisualState(mesh, bin.isOccupied);
    }

    return mesh;
  }

  // Places floating QR badge precisely on top-right corner of bin mesh
  private attachCornerQrBadge(
    binMesh: THREE.Mesh,
    bin: Bin3D,
    binWidth: number,
    binHeight: number,
    binDepth: number
  ): void {
    if (!bin.binHashCode) return;

    void generateQrCodeDataUrl(bin.binHashCode, 128).then((url) => {
      if (!url) return;
      this.textureLoader.load(url, (texture) => {
        texture.colorSpace = THREE.SRGBColorSpace;
        const spriteMat = new THREE.SpriteMaterial({ map: texture, transparent: true, depthTest: true });
        const sprite = new THREE.Sprite(spriteMat);
        sprite.scale.set(0.4, 0.4, 1);

        // Position on top-right front corner of bin
        const dimensions = binMesh.userData['standaloneBinDimensions'] as BinVisualDimensions | undefined;
        const cornerX = (dimensions?.width ?? binWidth) / 2 - 0.1;
        const cornerY = (dimensions?.height ?? binHeight) / 2 + 0.2;
        const cornerZ = (dimensions?.depth ?? binDepth) / 2 + 0.05;
        sprite.position.set(cornerX, cornerY, cornerZ);

        binMesh.add(sprite);
        if (bin.id) this.qrSpriteMap.set(bin.id, sprite);
      });
    });
  }

  private addCollisionBox(minX: number, maxX: number, minZ: number, maxZ: number): void {
    this.collisionBoxes.push({ minX, maxX, minZ, maxZ });
  }

  private setStandaloneBinCollision(bin: Bin3D, mesh: THREE.Mesh): void {
    this.removeStandaloneBinCollision(bin.id);
    const dimensions = mesh.userData['standaloneBinDimensions'] as BinVisualDimensions | undefined;
    const width = dimensions?.width ?? bin.location3D?.width ?? 1.5;
    const depth = dimensions?.depth ?? bin.location3D?.depth ?? 1.2;
    const rotation = mesh.rotation.y;
    const axisAlignedWidth = Math.abs(Math.cos(rotation)) * width + Math.abs(Math.sin(rotation)) * depth;
    const axisAlignedDepth = Math.abs(Math.sin(rotation)) * width + Math.abs(Math.cos(rotation)) * depth;
    const box: CollisionBox = {
      minX: mesh.position.x - axisAlignedWidth / 2,
      maxX: mesh.position.x + axisAlignedWidth / 2,
      minZ: mesh.position.z - axisAlignedDepth / 2,
      maxZ: mesh.position.z + axisAlignedDepth / 2,
    };
    this.collisionBoxes.push(box);
    this.standaloneBinCollisionBoxes.set(bin.id, box);
  }

  private getBinVisualDimensions(bin: Bin3D): BinVisualDimensions {
    const width = bin.location3D?.width ?? 1.5;
    const height = bin.location3D?.height ?? 1.2;
    const depth = bin.location3D?.depth ?? 1.2;
    const baseVolume = width * height * depth;
    const scale = bin.totalStoredCbm && baseVolume > 0
      ? THREE.MathUtils.clamp(Math.cbrt(bin.totalStoredCbm / baseVolume), 0.65, 1.5)
      : 1;
    return { width: width * scale, height: height * scale, depth: depth * scale };
  }

  private updateStandaloneBinSize(bin: Bin3D, mesh: THREE.Mesh, totalCbm: number): void {
    bin.totalStoredCbm = totalCbm;
    const dimensions = this.getBinVisualDimensions(bin);
    mesh.geometry.dispose();
    mesh.geometry = new THREE.BoxGeometry(dimensions.width, dimensions.height, dimensions.depth);
    mesh.userData['standaloneBinDimensions'] = dimensions;
    mesh.position.y = dimensions.height / 2;
    const badge = this.qrSpriteMap.get(bin.id);
    if (badge) {
      badge.position.set(dimensions.width / 2 - 0.1, dimensions.height / 2 + 0.2, dimensions.depth / 2 + 0.05);
    }
    if (this.isMovingBin && this.selectedBin?.id === bin.id) {
      this.removeStandaloneBinCollision(bin.id);
    } else {
      this.setStandaloneBinCollision(bin, mesh);
    }
  }

  private removeStandaloneBinCollision(binId: number): void {
    const box = this.standaloneBinCollisionBoxes.get(binId);
    if (!box) return;
    this.collisionBoxes = this.collisionBoxes.filter((collisionBox) => collisionBox !== box);
    this.standaloneBinCollisionBoxes.delete(binId);
  }

  private registerRackCollisionBoundary(x: number, z: number, width: number, depth: number, rotationY: number): void {
    const halfWidth = width / 2;
    const halfDepth = depth / 2;
    const axisAlignedWidth = Math.abs(Math.cos(rotationY)) * width + Math.abs(Math.sin(rotationY)) * depth;
    const axisAlignedDepth = Math.abs(Math.sin(rotationY)) * width + Math.abs(Math.cos(rotationY)) * depth;

    this.addCollisionBox(
      x - axisAlignedWidth / 2,
      x + axisAlignedWidth / 2,
      z - axisAlignedDepth / 2,
      z + axisAlignedDepth / 2
    );
  }

  private addZoneLabel(text: string, x: number, y: number, z: number): void {
    const sprite = this.createTextSprite(text, 'rgba(30, 41, 59, 0.9)', '#94a3b8');
    sprite.position.set(x, y, z);
    sprite.scale.set(8, 2, 1);
    this.floorZonesGroup.add(sprite);
  }

  private createTextSprite(text: string, bgColor = 'rgba(15, 23, 42, 0.85)', textColor = '#f8fafc'): THREE.Sprite {
    const canvas = document.createElement('canvas');
    canvas.width = 512;
    canvas.height = 128;
    const ctx = canvas.getContext('2d');
    if (!ctx) return new THREE.Sprite();

    ctx.fillStyle = bgColor;
    ctx.fillRect(0, 0, canvas.width, canvas.height);
    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 4;
    ctx.strokeRect(6, 6, canvas.width - 12, canvas.height - 12);
    ctx.fillStyle = textColor;
    ctx.font = 'bold 34px Inter, sans-serif';
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillText(text, canvas.width / 2, canvas.height / 2);

    const texture = new THREE.CanvasTexture(canvas);
    texture.colorSpace = THREE.SRGBColorSpace;
    const material = new THREE.SpriteMaterial({ map: texture, transparent: true });
    const sprite = new THREE.Sprite(material);
    sprite.scale.set(7, 1.8, 1);
    return sprite;
  }

  // Pointer/Tap Raycasting for Bin Selection
  private onCanvasPointerDown(event: PointerEvent): void {
    if (event.button === 2) {
      event.preventDefault();
      this.setPointerFromEvent(event);
      this.raycaster.setFromCamera(this.pointer, this.camera);
      const hit = this.raycaster.intersectObjects(Array.from(this.binMeshes.values()), true)[0];
      const bin = this.getBinFromObject(hit?.object ?? null);
      if (this.shouldShowStandaloneBins && bin && (bin.rack ?? '').toLowerCase() === 'standalone') {
        this.selectedBin = bin;
        this.binSelected.emit(bin);
        const mesh = this.binMeshes.get(bin.id);
        if (mesh) void this.selectBin(bin, mesh);
        this.requestStandaloneBinMove(bin);
      } else if (!hit && this.shouldShowStandaloneBins) {
        const position = this.getGroundPosition();
        if (position) this.emptySpotClicked.emit(position);
      }
      return;
    }

    if (event.button !== 0) return;

    if (this.isMovingBin) {
      event.preventDefault();
      event.stopPropagation();
      this.dropMovingBin();
      return;
    }

    if (this.isPointerLocked) {
      // Direct center crosshair selection when pointer locked
      this.pointer.x = 0;
      this.pointer.y = 0;
    } else {
      const rect = this.renderer.domElement.getBoundingClientRect();
      this.pointer.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
      this.pointer.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;
    }

    this.raycaster.setFromCamera(this.pointer, this.camera);
    const interactiveObjects = Array.from(this.binMeshes.values());
    if (this.receivingActionMesh) {
      interactiveObjects.push(this.receivingActionMesh);
    }

    const intersects = this.raycaster.intersectObjects(interactiveObjects, true);

    if (intersects.length > 0) {
      if (intersects[0].object.userData['type'] === 'receiving-create') {
        this.preventPointerLockForNextClick = true;
        this.exitNavigation();
        if (!this.isWarehouse2Layout) {
          this.isReceivingCreateOpen = true;
          this.cd.markForCheck();
        }
        this.receivingCreateRequested.emit();
        return;
      }
      const targetObj = this.getBinFromObject(intersects[0].object);
      if (targetObj) {
        this.preventPointerLockForNextClick = true;
        this.exitNavigation();
        const bin = targetObj;
        this.binSelected.emit(bin);
        const mesh = this.binMeshes.get(bin.id);
        if (mesh) void this.selectBin(bin, mesh);
      }
    }
  }

  private onCanvasPointerMove(event: PointerEvent): void {
    if (!this.renderer || !this.camera) return;
    this.setPointerFromEvent(event);
    this.raycaster.setFromCamera(this.pointer, this.camera);

    if (this.isMovingBin) {
      this.emptySpotChanged.emit(null);
      return;
    }

    if (!this.shouldShowStandaloneBins) return;
    const binHit = this.raycaster.intersectObjects(Array.from(this.binMeshes.values()), true)[0];
    if (binHit) {
      this.emptySpotChanged.emit(null);
      return;
    }
    const position = this.getGroundPosition();
    if (position) {
      this.emptySpotChanged.emit({
        clientX: event.clientX,
        clientY: event.clientY,
        position,
      });
    } else {
      this.emptySpotChanged.emit(null);
    }
  }

  private onCanvasContextMenu(event: MouseEvent): void {
    if (this.shouldShowStandaloneBins) event.preventDefault();
  }

  private setPointerFromEvent(event: PointerEvent): void {
    if (this.isPointerLocked) {
      this.pointer.set(0, 0);
      return;
    }
    const rect = this.renderer.domElement.getBoundingClientRect();
    this.pointer.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
    this.pointer.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;
  }

  private getGroundPosition(): BinWorldPosition | null {
    const ground = new THREE.Plane(new THREE.Vector3(0, 1, 0), 0);
    const point = new THREE.Vector3();
    if (!this.raycaster.ray.intersectPlane(ground, point) ||
      Math.abs(point.x) > 50 || Math.abs(point.z) > 50) return null;
    return {
      positionX: point.x,
      positionY: 0.6,
      positionZ: point.z,
      rotationY: this.selectedBin?.location3D?.rotationY ?? 0,
    };
  }

  private getBinFromObject(object: THREE.Object3D | null): Bin3D | null {
    let current = object;
    while (current && current.userData?.['type'] !== 'bin') current = current.parent;
    return current?.userData?.['bin'] as Bin3D | undefined ?? null;
  }

  private captureMovingBinPosition(): void {
    const mesh = this.selectedBin ? this.binMeshes.get(this.selectedBin.id) : undefined;
    if (!mesh) return;
    this.movingBinOriginalPosition = mesh.position.clone();
    this.movingBinOriginalRotation = mesh.rotation.y;
    this.carriedBinForwardOffset = 2.5;
    this.carriedBinLateralOffset = 0;
  }

  private restoreMovingBinPosition(): void {
    const mesh = this.selectedBin ? this.binMeshes.get(this.selectedBin.id) : undefined;
    if (mesh && this.movingBinOriginalPosition) {
      mesh.position.copy(this.movingBinOriginalPosition);
      mesh.rotation.y = this.movingBinOriginalRotation;
    }
    if (mesh && this.selectedBin && (this.selectedBin.rack ?? '').toLowerCase() === 'standalone') {
      this.setStandaloneBinCollision(this.selectedBin, mesh);
    }
    this.movingBinOriginalPosition = null;
    this.emptySpotChanged.emit(null);
  }

  requestStandaloneBinMove(bin: Bin3D): void {
    if (this.binMoveMode || this.isLocalBinMoveActive) return;
    this.selectedBin = bin;
    this.binMoveError = '';
    if (this.isWarehouse2Layout) {
      this.binMoveRequested.emit(bin);
      return;
    }

    this.captureMovingBinPosition();
    this.removeStandaloneBinCollision(bin.id);
    this.isLocalBinMoveActive = true;
    if (!this.isMobileDevice && !this.isPointerLocked) {
      void this.renderer.domElement.requestPointerLock();
    }
    this.cd.markForCheck();
  }

  private cancelStandaloneBinMove(): void {
    if (this.binMoveMode) {
      this.binMoveCancelled.emit();
      return;
    }
    if (!this.isLocalBinMoveActive) return;
    this.restoreMovingBinPosition();
    this.isLocalBinMoveActive = false;
    this.cd.markForCheck();
  }

  private async saveLocalStandaloneBinMove(position: BinWorldPosition): Promise<void> {
    const bin = this.selectedBin;
    if (!bin || !this.isLocalBinMoveActive) return;
    try {
      await this.api.invoke(updateBin3DLocation, {
        id: bin.id,
        body: position,
      });
      this.completeBinMove(position);
      this.isLocalBinMoveActive = false;
    } catch (err) {
      console.error('Failed to move standalone bin:', err);
      this.binMoveError = 'Unable to save the bin location. The bin was returned to its previous position.';
      this.restoreMovingBinPosition();
      this.isLocalBinMoveActive = false;
    } finally {
      this.cd.markForCheck();
    }
  }

  private nudgeCarriedBin(forwardDelta: number, lateralDelta: number): void {
    this.carriedBinForwardOffset = THREE.MathUtils.clamp(
      this.carriedBinForwardOffset + forwardDelta,
      1.25,
      5
    );
    this.carriedBinLateralOffset = THREE.MathUtils.clamp(
      this.carriedBinLateralOffset + lateralDelta,
      -2,
      2
    );
  }

  private rotateMovingBin(): void {
    const mesh = this.selectedBin ? this.binMeshes.get(this.selectedBin.id) : undefined;
    if (mesh) mesh.rotation.y += Math.PI / 2;
  }

  private dropMovingBin(): void {
    const binId = this.selectedBin?.id;
    const mesh = binId ? this.binMeshes.get(binId) : undefined;
    if (!binId || !mesh || !this.isMovingBin) return;
    const dimensions = mesh.userData['standaloneBinDimensions'] as BinVisualDimensions | undefined;
    const position = {
      positionX: mesh.position.x,
      positionY: (dimensions?.height ?? this.selectedBin?.location3D?.height ?? 1.2) / 2,
      positionZ: mesh.position.z,
      rotationY: mesh.rotation.y,
    };
    if (this.binMoveMode) {
      this.binMoveDropped.emit({ binId, position });
    } else {
      void this.saveLocalStandaloneBinMove(position);
    }
  }

  get warehouseAddress(): string {
    const active = this.warehouseService.activeWarehouse();
    return active?.address && active.address !== 'All locations' ? active.address : '';
  }

  public getWarehouseNameLastIndex(name: string | null | undefined, type: 'text' | 'number' = 'number'): string {
    if (!name) return '';

    if (type === 'number') {
      const matches = name.match(/\d+/g);
      return matches ? matches[matches.length - 1] : '';
    }

    return name.replace(/\d+/g, '').trim();
  }

  public getInitials(name?: string | null): string {
    if (!name) return '';

    return name
      .trim()
      .split(/\s+/)
      .slice(0, 2)
      .map(word => word[0]?.toUpperCase() ?? '')
      .join('');
  }

  async refreshSelectedBinInventory(): Promise<void> {
    const bin = this.selectedBin;
    const mesh = bin ? this.binMeshes.get(bin.id) : undefined;
    if (bin && mesh) await this.selectBin(bin, mesh, true);
  }

  private async selectBin(bin: Bin3D, mesh: THREE.Mesh, forceRefresh = false): Promise<void> {
    this.selectedBin = bin;
    this.isLoadingInventory = true;
    this.selectedBinItems = [];
    this.cd.markForCheck();

    if (bin.binHashCode) {
      this.selectedBinQrUrl = await generateQrCodeDataUrl(bin.binHashCode, 180);
    } else {
      this.selectedBinQrUrl = '';
    }

    // Query checked-in stock in the bin using getBinStockById.
    this.warehouse3DService.fetchBinInventory(bin.id, forceRefresh).subscribe({
      next: (items) => {
        this.selectedBinItems = items;
        const isOccupied = items.length > 0;
        bin.isOccupied = isOccupied;
        if ((bin.rack ?? '').toLowerCase() === 'standalone') {
          this.updateStandaloneBinSize(bin, mesh, sumBinInventoryCbm(items));
        }

        // Dynamically update visual material based on actual inventory
        this.updateBinVisualState(mesh, isOccupied);
        this.isLoadingInventory = false;
        this.cd.markForCheck();
      },
      error: () => {
        this.isLoadingInventory = false;
        this.cd.markForCheck();
      }
    });
  }

  private updateBinVisualState(mesh: THREE.Mesh, isOccupied: boolean): void {
    const mat = mesh.material as THREE.MeshStandardMaterial;
    if (isOccupied) {
      mat.color.setHex(0x10b981); // Solid Green for Occupied
      mat.opacity = 0.95;
      mat.emissive.setHex(0x047857);
      mat.emissiveIntensity = 0.3;
    } else {
      mat.color.setHex(0x64748b); // Gray transparent for Empty
      mat.opacity = 0.35;
      mat.emissive.setHex(0x000000);
      mat.emissiveIntensity = 0;
    }
  }

  closeBinPanel(): void {
    this.selectedBin = null;
    this.selectedBinItems = [];
    this.cd.markForCheck();
  }

  get selectedBinDto(): BinSummaryDto | null {
    if (!this.selectedBin) return null;
    return {
      id: this.selectedBin.id,
      binName: this.selectedBin.binName,
      binHashCode: this.selectedBin.binHashCode,
      rack: this.selectedBin.rack,
      bay: this.selectedBin.bay,
      level: this.selectedBin.level,
      warehouse: this.selectedBin.warehouse,
      dateAdded: this.selectedBin.dateAdded ?? undefined,
      location3D: this.selectedBin.location3D,
    };
  }

  openCheckIn(): void {
    this.exitNavigation();
    this.isCheckInOpen = true;
  }

  openPickOrder(): void {
    this.exitNavigation();
    this.isPickOrderOpen = true;
  }

  closeCheckIn(): void {
    this.isCheckInOpen = false;
  }

  closePickOrder(): void {
    this.isPickOrderOpen = false;
  }

  closeReceivingCreate(): void {
    this.isReceivingCreateOpen = false;
  }

  onWorkflowCreated(): void {
    void this.loadWarehouseData();
  }

  onBinWorkflowCreated(): void {
    void this.refreshSelectedBinInventory();
  }

  // Animation Loop with Movement Physics & Collision Detection
  private animate(): void {
    this.animationFrameId = requestAnimationFrame(() => this.animate());

    const delta = 0.016; // ~60fps step
    const moveSpeed = 12.0 * delta;

    // Movement Vectors based on Yaw direction
    const forwardVec = new THREE.Vector3(-Math.sin(this.yaw), 0, -Math.cos(this.yaw)).normalize();
    const sideVec = new THREE.Vector3(-Math.cos(this.yaw), 0, Math.sin(this.yaw)).normalize();

    const targetVelocity = new THREE.Vector3();

    // Keyboard Input
    if (this.moveForward) targetVelocity.addScaledVector(forwardVec, moveSpeed);
    if (this.moveBackward) targetVelocity.addScaledVector(forwardVec, -moveSpeed);
    if (this.moveLeft) targetVelocity.addScaledVector(sideVec, moveSpeed);
    if (this.moveRight) targetVelocity.addScaledVector(sideVec, -moveSpeed);

    // Mobile Joystick Input
    if (this.touchJoystickActive) {
      targetVelocity.addScaledVector(forwardVec, -this.joystickVector.y * moveSpeed);
      targetVelocity.addScaledVector(sideVec, -this.joystickVector.x * moveSpeed);
    }

    // Proposed New Position
    const nextX = this.playerPos.x + targetVelocity.x;
    const nextZ = this.playerPos.z + targetVelocity.z;

    // Collision Check
    if (!this.checkCollision(nextX, this.playerPos.z)) {
      this.playerPos.x = nextX;
    }
    if (!this.checkCollision(this.playerPos.x, nextZ)) {
      this.playerPos.z = nextZ;
    }

    if (this.isFlying) {
      const verticalInput = Number(this.moveUp) - Number(this.moveDown);
      this.playerPos.y = THREE.MathUtils.clamp(this.playerPos.y + verticalInput * 12.0 * delta, 1.8, 24);
      this.playerVelocityY = 0;
      this.isGrounded = this.playerPos.y <= 1.8;
    } else {
      // Gravity & Jump Physics
      this.playerVelocityY -= 18.0 * delta; // Gravity force
      this.playerPos.y += this.playerVelocityY * delta;

      if (this.playerPos.y <= 1.8) { // Ground plane height = 1.8m
        this.playerPos.y = 1.8;
        this.playerVelocityY = 0;
        this.isGrounded = true;
      }
    }

    // Camera Direction Update
    this.camera.position.copy(this.playerPos);

    const dir = new THREE.Vector3(
      -Math.sin(this.yaw) * Math.cos(this.pitch),
      Math.sin(this.pitch),
      -Math.cos(this.yaw) * Math.cos(this.pitch)
    );
    this.camera.lookAt(this.playerPos.clone().add(dir));

    if (this.isMovingBin && this.selectedBin) {
      const carriedMesh = this.binMeshes.get(this.selectedBin.id);
      if (carriedMesh) {
        carriedMesh.position.set(
          this.playerPos.x + forwardVec.x * this.carriedBinForwardOffset +
            sideVec.x * this.carriedBinLateralOffset,
          1.15,
          this.playerPos.z + forwardVec.z * this.carriedBinForwardOffset +
            sideVec.z * this.carriedBinLateralOffset
        );
      }
    }

    if (this.renderer && this.scene) {
      this.renderer.render(this.scene, this.camera);
    }
  }

  private checkCollision(x: number, z: number): boolean {
    const radius = 0.8;
    for (const box of this.collisionBoxes) {
      const isPerimeter =
        box.minX <= -52 || box.maxX >= 52 || box.minZ <= -52 || box.maxZ >= 52;
      if (this.isFlying && this.playerPos.y > 3 && !isPerimeter) continue;

      if (
        x + radius > box.minX &&
        x - radius < box.maxX &&
        z + radius > box.minZ &&
        z - radius < box.maxZ
      ) {
        return true;
      }
    }
    return false;
  }

  resetPlayerPosition(): void {
    if (this.isWarehouse2Layout) {
      this.playerPos.set(0, 1.8, 29);
      this.yaw = 0;
      this.pitch = -0.25;
      return;
    }
    this.playerPos.set(0, 1.8, 45);
    this.yaw = -Math.PI / 2;
    this.pitch = 0;
  }

  private setupResizeObserver(): void {
    this.resizeObserver = new ResizeObserver(() => this.resize());
    this.resizeObserver.observe(this.viewerContainer.nativeElement);
  }

  private resize(): void {
    if (!this.renderer || !this.camera || !this.viewerContainer) return;
    const container = this.viewerContainer.nativeElement;
    const width = container.clientWidth || 1000;
    const height = container.clientHeight || 600;

    this.camera.aspect = width / height;
    this.camera.updateProjectionMatrix();
    this.renderer.setSize(width, height);
  }

  private clearScene(): void {
    if (this.rackGroup) this.rackGroup.clear();
    if (this.floorZonesGroup) this.floorZonesGroup.clear();
    this.binMeshes.clear();
    this.qrSpriteMap.clear();
    this.receivingActionMesh = null;
    this.closeBinPanel();
  }

  toggleFullscreen(): void {
    this.isFullscreen = !this.isFullscreen;
    document.body.classList.toggle('viewer-fullscreen', this.isFullscreen);
    setTimeout(() => this.resize(), 50);
  }

  get selectedWarehouseName(): string {
    const active = this.warehouseService.activeWarehouse();
    return active?.name && active.name !== 'All Warehouses' ? active.name : 'Warehouse Floor Plan';
  }
}