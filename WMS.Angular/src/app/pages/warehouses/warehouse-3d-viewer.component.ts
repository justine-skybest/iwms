import { AfterViewInit, Component, ElementRef, OnDestroy, ViewChild, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Warehouse3DViewerService, Rack3D, Bin3D } from './warehouse-3d-viewer.service';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { WarehouseDetailsDto } from '../../api/generated/models';
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
  LogOut
} from 'lucide-angular';
import * as THREE from 'three';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';

@Component({
  selector: 'app-warehouse-3d-viewer',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './warehouse-3d-viewer.component.html',
  styles: [`
    .viewer-canvas {
      width: 100% !important;
      height: 100% !important;
      display: block;
      outline: none;
    }
  `]
})
export class Warehouse3DViewerComponent implements AfterViewInit, OnDestroy {
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

  @ViewChild('viewerContainer', { static: true }) viewerContainer!: ElementRef<HTMLDivElement>;

  racks: Rack3D[] = [];
  selectedWarehouse: WarehouseDetailsDto | null = null;
  isLoading = true;
  error = '';
  showInfo = true;
  hoveredBin: Bin3D | null = null;
  selectedBin: Bin3D | null = null;
  selectedBinQrUrl = '';
  selectedRack: Rack3D | null = null;
  totalBins = 0;
  totalRacks = 0;
  totalBays = 0;
  totalLevels = 0;
  isFullscreen = false;

  private scene!: THREE.Scene;
  private camera!: THREE.PerspectiveCamera;
  private renderer!: THREE.WebGLRenderer;
  private controls!: OrbitControls;
  private rackGroup!: THREE.Group;
  private floorZonesGroup!: THREE.Group;
  private raycaster = new THREE.Raycaster();
  private pointer = new THREE.Vector2();
  private animationFrameId = 0;
  private resizeObserver: ResizeObserver | null = null;
  private binMeshes = new Map<number, THREE.Mesh>();
  private textureLoader = new THREE.TextureLoader();

  constructor(
    private warehouse3DService: Warehouse3DViewerService,
    private warehouseService: WarehouseService,
    private cd: ChangeDetectorRef
  ) {}

  ngAfterViewInit(): void {
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
  }

  async loadWarehouseData(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.clearScene();

    try {
      await this.warehouseService.ensureInitialized();
      this.selectedWarehouse = this.warehouseService.activeWarehouse();

      const data = await this.warehouse3DService.fetchWarehouse3DData();
      this.racks = data.racks;
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
      );
      
      this.buildFloorPlanZones();
      this.buildFloorPlanRacks(data.racks);

      // Force canvas size recalculation after Angular removes loading overlay
      setTimeout(() => {
        this.resize();
        this.focusScene();
      }, 0);
    } catch (err: any) {
      console.error('Failed to load warehouse 3D data:', err);
      this.error = err?.message || 'Unable to load warehouse structure. Please try again.';
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  private initScene(): void {
    const container = this.viewerContainer.nativeElement;
    const width = container.clientWidth || 1000;
    const height = container.clientHeight || 600;

    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0x0f172a);
    this.scene.fog = new THREE.Fog(0x0f172a, 80, 200);

    this.camera = new THREE.PerspectiveCamera(50, width / height, 0.1, 1000);
    this.camera.position.set(0, 70, 75);

    this.renderer = new THREE.WebGLRenderer({ antialias: true });
    this.renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));
    this.renderer.setSize(width, height);
    this.renderer.shadowMap.enabled = true;
    this.renderer.shadowMap.type = THREE.PCFSoftShadowMap;
    this.renderer.domElement.classList.add('viewer-canvas');
    container.appendChild(this.renderer.domElement);

    const ambientLight = new THREE.AmbientLight(0xffffff, 0.45);
    this.scene.add(ambientLight);

    const directionalLight = new THREE.DirectionalLight(0xffffff, 1.2);
    directionalLight.position.set(30, 60, 40);
    directionalLight.castShadow = true;
    directionalLight.shadow.mapSize.set(2048, 2048);
    this.scene.add(directionalLight);

    const fillLight = new THREE.DirectionalLight(0x93c5fd, 0.4);
    fillLight.position.set(-30, 40, -30);
    this.scene.add(fillLight);

    // Concrete Ground
    const groundGeometry = new THREE.PlaneGeometry(120, 120);
    const groundMaterial = new THREE.MeshStandardMaterial({ color: 0x1e293b, roughness: 0.9 });
    const ground = new THREE.Mesh(groundGeometry, groundMaterial);
    ground.rotation.x = -Math.PI / 2;
    ground.receiveShadow = true;
    this.scene.add(ground);

    const grid = new THREE.GridHelper(120, 60, 0x334155, 0x1e293b);
    grid.position.y = 0.02;
    this.scene.add(grid);

    this.floorZonesGroup = new THREE.Group();
    this.scene.add(this.floorZonesGroup);

    this.rackGroup = new THREE.Group();
    this.scene.add(this.rackGroup);

    this.controls = new OrbitControls(this.camera, this.renderer.domElement);
    this.controls.enableDamping = true;
    this.controls.dampingFactor = 0.05;
    this.controls.maxPolarAngle = Math.PI / 2.05;
    this.controls.minDistance = 10;
    this.controls.maxDistance = 160;
    this.controls.target.set(0, 0, 0);

    this.renderer.domElement.addEventListener('pointermove', this.onPointerMove.bind(this));
    this.renderer.domElement.addEventListener('click', this.onCanvasClick.bind(this));

    this.animate();
  }

public getWareHouseNameLastIndex(name: string, type: 'text' | 'number' = 'number'): string {
  if (!name) return '';

  if (type === 'number') {
    // Extracts the last numeric portion (e.g., "S.Warehouse 6" -> "6")
    const matches = name.match(/\d+/g);
    return matches ? matches[matches.length - 1] : '';
  }

  // Extracts the text/alphabetic portion (e.g., "S.Warehouse 6" -> "S.Warehouse")
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

  private buildFloorPlanZones(): void {
    // 1. Office / Comfort Room Zone
    const officeGeo = new THREE.BoxGeometry(22, 4, 18);
    const officeMat = new THREE.MeshStandardMaterial({ color: 0x334155, roughness: 0.7, transparent: true, opacity: 0.85 });
    const officeMesh = new THREE.Mesh(officeGeo, officeMat);
    officeMesh.position.set(-36, 2, 32);
    this.floorZonesGroup.add(officeMesh);
    this.addZoneLabel('OFFICE / COMFORT ROOM', -36, 4.5, 32);

    // 2. Receiving Area
    const receivingGeo = new THREE.PlaneGeometry(16, 12);
    const receivingMat = new THREE.MeshBasicMaterial({ color: 0x3b82f6, side: THREE.DoubleSide, transparent: true, opacity: 0.25 });
    const receivingMesh = new THREE.Mesh(receivingGeo, receivingMat);
    receivingMesh.rotation.x = -Math.PI / 2;
    receivingMesh.position.set(-10, 0.05, 30);
    this.floorZonesGroup.add(receivingMesh);
    this.addZoneLabel('RECEIVING AREA', -10, 0.2, 30);

    // 3. Outgoing Area
    const outgoingGeo = new THREE.PlaneGeometry(16, 12);
    const outgoingMat = new THREE.MeshBasicMaterial({ color: 0x10b981, side: THREE.DoubleSide, transparent: true, opacity: 0.25 });
    const outgoingMesh = new THREE.Mesh(outgoingGeo, outgoingMat);
    outgoingMesh.rotation.x = -Math.PI / 2;
    outgoingMesh.position.set(14, 0.05, 30);
    this.floorZonesGroup.add(outgoingMesh);
    this.addZoneLabel('OUTGOING AREA', 14, 0.2, 30);

    // 4. Weighing Scale
    const scaleGeo = new THREE.BoxGeometry(6, 0.3, 5);
    const scaleMat = new THREE.MeshStandardMaterial({ color: 0xf59e0b, metalness: 0.5 });
    const scaleMesh = new THREE.Mesh(scaleGeo, scaleMat);
    scaleMesh.position.set(-10, 0.15, 42);
    this.floorZonesGroup.add(scaleMesh);

    // 5. Loading and Unloading Bay
    const bayGeo = new THREE.PlaneGeometry(45, 4);
    const bayMat = new THREE.MeshBasicMaterial({ color: 0xeab308, side: THREE.DoubleSide, transparent: true, opacity: 0.35 });
    const bayMesh = new THREE.Mesh(bayGeo, bayMat);
    bayMesh.rotation.x = -Math.PI / 2;
    bayMesh.position.set(2, 0.06, 46);
    this.floorZonesGroup.add(bayMesh);
    this.addZoneLabel('LOADING & UNLOADING BAY', 2, 0.2, 46);

    // 6. Empty Pallet Area
    const palletZoneGeo = new THREE.PlaneGeometry(14, 10);
    const palletZoneMat = new THREE.MeshBasicMaterial({ color: 0x64748b, side: THREE.DoubleSide, transparent: true, opacity: 0.2 });
    const palletZoneMesh = new THREE.Mesh(palletZoneGeo, palletZoneMat);
    palletZoneMesh.rotation.x = -Math.PI / 2;
    palletZoneMesh.position.set(38, 0.05, 36);
    this.floorZonesGroup.add(palletZoneMesh);
    this.addZoneLabel('EMPTY PALLET AREA', 38, 0.2, 36);

    // 7. Fire Exit
    const exitGeo = new THREE.BoxGeometry(4, 5, 0.4);
    const exitMat = new THREE.MeshStandardMaterial({ color: 0xef4444 });
    const exitMesh = new THREE.Mesh(exitGeo, exitMat);
    exitMesh.position.set(-44, 2.5, -44);
    this.floorZonesGroup.add(exitMesh);
    this.addZoneLabel('FIRE EXIT', -44, 5.5, -44);
  }

  private buildFloorPlanRacks(racks: Rack3D[]): void {
    const positions = [
      { nameMatch: 'racking area #1', x: -42, z: -10, rotateY: Math.PI / 2 },
      { nameMatch: 'racking area #2', x: 0, z: -40, rotateY: 0 },
      { nameMatch: 'racking area #3', x: 42, z: -5, rotateY: Math.PI / 2 },
      { nameMatch: 'cross docking area #1', x: -22, z: -5, rotateY: 0 },
      { nameMatch: 'cross docking area #2', x: 0, z: -5, rotateY: 0 },
      { nameMatch: 'cross docking area #3', x: 22, z: -5, rotateY: 0 }
    ];

    racks.forEach((rack, idx) => {
      const rackNameLower = (rack.name ?? '').toLowerCase();
      let targetPos = positions.find(p => rackNameLower.includes(p.nameMatch));

      if (!targetPos) {
        const fallbackIndex = idx % positions.length;
        targetPos = positions[fallbackIndex];
      }

      const rackMeshGroup = this.createSingleRackMesh(rack);
      rackMeshGroup.position.set(targetPos.x, 0, targetPos.z);
      rackMeshGroup.rotation.y = targetPos.rotateY;
      this.rackGroup.add(rackMeshGroup);
    });
  }

  private createSingleRackMesh(rack: Rack3D): THREE.Group {
    const rackGroup = new THREE.Group();
    rackGroup.userData['rack'] = rack;

    const bayCount = Math.max(rack.bayCount, rack.bays.length, 1);
    const levelCount = Math.max(rack.levelCount, 1);
    const bayWidth = 4.2;
    const bayGap = 0.3;
    const levelHeight = 3.0;
    const bayDepth = 3.8;
    const rackWidth = bayCount * (bayWidth + bayGap) - bayGap;
    const rackHeight = levelCount * levelHeight + 1;

    // Upright Posts
    const postMaterial = new THREE.MeshStandardMaterial({ color: 0x475569, metalness: 0.6, roughness: 0.4 });
    const postGeometry = new THREE.BoxGeometry(0.25, rackHeight, 0.25);
    const postPositions = [
      [-rackWidth / 2, -bayDepth / 2],
      [rackWidth / 2, -bayDepth / 2],
      [-rackWidth / 2, bayDepth / 2],
      [rackWidth / 2, bayDepth / 2]
    ];

    postPositions.forEach(([x, z]) => {
      const post = new THREE.Mesh(postGeometry, postMaterial);
      post.position.set(x, rackHeight / 2, z);
      post.castShadow = true;
      post.receiveShadow = true;
      rackGroup.add(post);
    });

    // Bays & Levels
    rack.bays.forEach((bay, bayIndex) => {
      const bayX = -rackWidth / 2 + bayIndex * (bayWidth + bayGap) + bayWidth / 2;
      const bayGroup = new THREE.Group();
      bayGroup.position.x = bayX;

      bay.levels.forEach((level, levelIndex) => {
        const levelY = 0.5 + levelIndex * levelHeight;
        const levelGroup = new THREE.Group();
        levelGroup.position.y = levelY;

        // Shelf Beam
        const shelfMaterial = new THREE.MeshStandardMaterial({ color: 0x94a3b8, metalness: 0.4, roughness: 0.5 });
        const shelf = new THREE.Mesh(new THREE.BoxGeometry(bayWidth, 0.15, bayDepth), shelfMaterial);
        shelf.castShadow = true;
        shelf.receiveShadow = true;
        levelGroup.add(shelf);

        // Bins
        const binCount = level.bins.length;
        const binWidth = Math.min(1.5, bayWidth / Math.max(binCount, 1));
        const binGap = 0.1;
        const binDepth = 2.0;
        const binHeight = 1.3;
        const binTotalWidth = Math.min(bayWidth - 0.2, binCount * (binWidth + binGap) - binGap);
        const binStartX = -binTotalWidth / 2;

        level.bins.forEach((bin, binIndex) => {
          const binX = binStartX + binIndex * (binWidth + binGap) + binWidth / 2;
          const binMaterial = new THREE.MeshStandardMaterial({
            color: 0x3b82f6,
            metalness: 0.2,
            roughness: 0.5,
            emissive: 0x1d4ed8,
            emissiveIntensity: 0.15,
            transparent: true,
            opacity: 0.95
          });

          const binMesh = new THREE.Mesh(new THREE.BoxGeometry(binWidth, binHeight, binDepth), binMaterial);
          binMesh.position.set(binX, binHeight / 2 + 0.15, 0);
          binMesh.castShadow = true;
          binMesh.receiveShadow = true;
          binMesh.userData['bin'] = bin;
          levelGroup.add(binMesh);

          if (bin.id) this.binMeshes.set(bin.id, binMesh);

          // Map QR Code image to front face (+Z) asynchronously
          void this.applyQrTextureToBinMesh(binMesh, bin.binHashCode, binMaterial);
        });

        bayGroup.add(levelGroup);
      });

      rackGroup.add(bayGroup);
    });

    const label = this.createTextSprite(rack.name ?? `Rack ${rack.id}`);
    label.position.set(0, rackHeight + 1.2, 0);
    rackGroup.add(label);

    return rackGroup;
  }

  private async applyQrTextureToBinMesh(
    mesh: THREE.Mesh,
    binHashCode: string | null | undefined,
    baseMaterial: THREE.MeshStandardMaterial
  ): Promise<void> {
    if (!binHashCode) return;

    const dataUrl = await generateQrCodeDataUrl(binHashCode, 128);
    if (!dataUrl) return;

    this.textureLoader.load(dataUrl, (texture) => {
      texture.colorSpace = THREE.SRGBColorSpace;
      const qrMaterial = new THREE.MeshStandardMaterial({
        map: texture,
        roughness: 0.2,
        metalness: 0.1
      });

      // Material order: [+X, -X, +Y, -Y, +Z (Front), -Z]
      mesh.material = [
        baseMaterial,
        baseMaterial,
        baseMaterial,
        baseMaterial,
        qrMaterial,
        baseMaterial
      ];
    });
  }

  private addZoneLabel(text: string, x: number, y: number, z: number): void {
    const sprite = this.createTextSprite(text, 'rgba(30, 41, 59, 0.9)', '#94a3b8');
    sprite.position.set(x, y, z);
    sprite.scale.set(10, 2.5, 1);
    this.floorZonesGroup.add(sprite);
  }

  private createTextSprite(text: string, bgColor = 'rgba(15, 23, 42, 0.85)', textColor = '#f8fafc'): THREE.Sprite {
    const canvas = document.createElement('canvas');
    canvas.width = 512;
    canvas.height = 128;
    const context = canvas.getContext('2d');
    if (!context) return new THREE.Sprite();

    context.fillStyle = bgColor;
    context.fillRect(0, 0, canvas.width, canvas.height);
    context.strokeStyle = '#38bdf8';
    context.lineWidth = 4;
    context.strokeRect(6, 6, canvas.width - 12, canvas.height - 12);
    context.fillStyle = textColor;
    context.font = 'bold 36px Inter, sans-serif';
    context.textAlign = 'center';
    context.textBaseline = 'middle';
    context.fillText(text, canvas.width / 2, canvas.height / 2);

    const texture = new THREE.CanvasTexture(canvas);
    texture.colorSpace = THREE.SRGBColorSpace;
    const material = new THREE.SpriteMaterial({ map: texture, transparent: true, depthTest: false });
    const sprite = new THREE.Sprite(material);
    sprite.scale.set(8, 2, 1);
    return sprite;
  }

  private clearScene(): void {
    if (this.rackGroup) this.rackGroup.clear();
    if (this.floorZonesGroup) this.floorZonesGroup.clear();
    this.binMeshes.clear();
    this.selectedBin = null;
    this.selectedBinQrUrl = '';
    this.hoveredBin = null;
    this.selectedRack = null;
  }

  private onPointerMove(event: PointerEvent): void {
    if (!this.renderer) return;

    const rect = this.renderer.domElement.getBoundingClientRect();
    this.pointer.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
    this.pointer.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;

    this.raycaster.setFromCamera(this.pointer, this.camera);
    const intersects = this.raycaster.intersectObjects(Array.from(this.binMeshes.values()), false);

    if (intersects.length > 0) {
      const mesh = intersects[0].object as THREE.Mesh;
      const bin = mesh.userData['bin'] as Bin3D;
      if (this.hoveredBin?.id !== bin.id) {
        this.hoveredBin = bin;
        this.resetBinMaterials();
        this.highlightMesh(mesh, 0xfacc15, 0.6);
        this.viewerContainer.nativeElement.style.cursor = 'pointer';
      }
    } else {
      this.hoveredBin = null;
      this.resetBinMaterials();
      this.viewerContainer.nativeElement.style.cursor = 'default';
    }
  }

  private onCanvasClick(event: PointerEvent): void {
    if (!this.renderer) return;

    const rect = this.renderer.domElement.getBoundingClientRect();
    this.pointer.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
    this.pointer.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;

    this.raycaster.setFromCamera(this.pointer, this.camera);
    const intersects = this.raycaster.intersectObjects(Array.from(this.binMeshes.values()), false);

    if (intersects.length > 0) {
      const mesh = intersects[0].object as THREE.Mesh;
      const bin = mesh.userData['bin'] as Bin3D;
      this.selectedBin = bin;
      this.resetBinMaterials();
      this.highlightMesh(mesh, 0x22c55e, 0.7);

      if (bin.binHashCode) {
        generateQrCodeDataUrl(bin.binHashCode, 180).then((url: any) => {
          this.selectedBinQrUrl = url;
          this.cd.markForCheck();
        });
      } else {
        this.selectedBinQrUrl = '';
      }
    } else {
      this.selectedBin = null;
      this.selectedBinQrUrl = '';
      this.resetBinMaterials();
    }
  }

  private resetBinMaterials(): void {
    this.binMeshes.forEach(mesh => {
      this.highlightMesh(mesh, 0x1d4ed8, 0.15);
    });
  }

  private highlightMesh(mesh: THREE.Mesh, colorHex: number, intensity: number): void {
    if (Array.isArray(mesh.material)) {
      mesh.material.forEach(mat => {
        const standardMat = mat as THREE.MeshStandardMaterial;
        standardMat.emissive = new THREE.Color(colorHex);
        standardMat.emissiveIntensity = intensity;
      });
    } else {
      const standardMat = mesh.material as THREE.MeshStandardMaterial;
      standardMat.emissive = new THREE.Color(colorHex);
      standardMat.emissiveIntensity = intensity;
    }
  }

  private focusScene(): void {
    if (!this.controls) return;
    this.camera.position.set(0, 75, 75);
    this.controls.target.set(0, 0, 0);
    this.controls.update();
  }

  resetView(): void {
    this.focusScene();
  }

  toggleFullscreen(): void {
    this.isFullscreen = !this.isFullscreen;
    document.body.classList.toggle('viewer-fullscreen', this.isFullscreen);
    setTimeout(() => {
      this.resize();
      this.focusScene();
    }, 50);
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

  private animate(): void {
    this.animationFrameId = requestAnimationFrame(() => this.animate());
    if (this.controls) this.controls.update();
    if (this.renderer && this.scene && this.camera) {
      this.renderer.render(this.scene, this.camera);
    }
  }

  get selectedWarehouseName(): string {
    const active = this.warehouseService.activeWarehouse();
    return active?.name && active.name !== 'All Warehouses' ? active.name : 'Warehouse Floor Plan';
  }

  get warehouseAddress(): string {
    const active = this.warehouseService.activeWarehouse();
    return active?.address && active.address !== 'All locations' ? active.address : '';
  }
}