import { 
  Component, 
  OnInit, 
  OnDestroy, 
  ElementRef, 
  ViewChild, 
  inject, 
  ChangeDetectorRef, 
  HostListener 
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import * as THREE from 'three';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';

import { Api } from '../../../api/generated/api';
import { getRacks, getWarehouseOccupancyReport } from '../../../api/generated/functions';
import { RackSummaryDto, OccupancyReportResponse, BinOccupancyDto } from '../../../api/generated/models';
import { WarehouseService } from '../../../lib/services/warehouse.service';
import { PageHeaderComponent } from '../../../shared/layout/page-header/page-header.component';
import { SearchableSelectComponent, SelectOption } from '../../../shared/components/select/select.component';
import { formatDate } from '../../../lib/utils/format-date';
import { 
  LucideAngularModule, 
  Boxes, 
  Grid, 
  Table, 
  CheckCircle2, 
  AlertCircle, 
  Loader2, 
  Search, 
  RefreshCw,
  X,
  Package,
  Calendar,
  Hash,
  FileText,
  MousePointerClick,
  Building2
} from 'lucide-angular';

@Component({
  selector: 'app-warehouse-occupancy',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    LucideAngularModule, 
    PageHeaderComponent, 
    SearchableSelectComponent
  ],
  templateUrl: './warehouse-occupancy.component.html',
})
export class WarehouseOccupancyComponent implements OnInit, OnDestroy {
  readonly BoxesIcon = Boxes;
  readonly GridIcon = Grid;
  readonly TableIcon = Table;
  readonly CheckIcon = CheckCircle2;
  readonly AlertIcon = AlertCircle;
  readonly LoaderIcon = Loader2;
  readonly SearchIcon = Search;
  readonly RefreshIcon = RefreshCw;
  readonly CloseIcon = X;
  readonly PackageIcon = Package;
  readonly CalendarIcon = Calendar;
  readonly HashIcon = Hash;
  readonly NotesIcon = FileText;
  readonly PointerIcon = MousePointerClick;
  readonly WarehouseIcon = Building2;

  public formatDate = formatDate;

  @ViewChild('canvasContainer', { static: false }) canvasContainer!: ElementRef<HTMLDivElement>;

  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);
  public warehouseService = inject(WarehouseService);

  selectedRackOptions: SelectOption<RackSummaryDto>[] = [];
  searchQuery = '';
  viewMode: '3d' | 'table' = '3d';

  report: OccupancyReportResponse | null = null;
  selectedBin: BinOccupancyDto | null = null;
  isDrawerOpen = false;
  isLoading = false;
  error = '';

  // Three.js Core
  private scene!: THREE.Scene;
  private camera!: THREE.PerspectiveCamera;
  private renderer!: THREE.WebGLRenderer;
  private controls!: OrbitControls;
  private raycaster = new THREE.Raycaster();
  private mouse = new THREE.Vector2();
  private animationFrameId: number | null = null;
  
  // Master rack structure container
  private rackGroup: THREE.Group | null = null;
  private selectedBinGroup: THREE.Group | null = null;
  private binGroups: THREE.Group[] = [];
  private qrTexture: THREE.CanvasTexture | null = null;

  private pointerDownPos = new THREE.Vector2();
  private pointerDownListener?: (e: PointerEvent) => void;
  private pointerUpListener?: (e: PointerEvent) => void;

  ngOnInit(): void {
    void this.loadOccupancyReport();
  }

  ngOnDestroy(): void {
    this.disposeThreeScene();
  }

  searchRacks = async (term: string): Promise<SelectOption<RackSummaryDto>[]> => {
    try {
      const warehouseId = this.warehouseService.selectedWarehouseId();
      const params = warehouseId ? { warehouseId } : {};
      const racks = (await this.api.invoke(getRacks, params)) as RackSummaryDto[];
      
      const filtered = term 
        ? racks.filter(r => r.name?.toLowerCase().includes(term.toLowerCase()))
        : racks;

      return filtered.map(r => ({
        id: r.id!,
        label: r.name || `Rack #${r.id}`,
        sublabel: `Warehouse: ${r.warehouse}`,
        raw: r
      }));
    } catch (err) {
      console.error('Failed to search racks:', err);
      return [];
    }
  };

  onRackSelectionChange(selected: SelectOption<RackSummaryDto>[]): void {
    this.selectedRackOptions = selected;
    this.selectedBin = null;
    this.isDrawerOpen = false;
    void this.loadOccupancyReport();
  }

  async loadOccupancyReport(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.selectedBin = null;
    this.isDrawerOpen = false;
    this.cd.markForCheck();

    const selectedRack = this.selectedRackOptions[0]?.raw;
    const warehouseId = this.warehouseService.selectedWarehouseId();

    const params = {
      warehouseId: warehouseId || undefined,
      rackId: selectedRack ? selectedRack.id : undefined
    };

    try {
      this.report = (await this.api.invoke(getWarehouseOccupancyReport, params)) as OccupancyReportResponse;
      
      if (this.viewMode === '3d' && this.selectedRackOptions.length > 0) {
        setTimeout(() => this.initOrUpdate3DScene(), 0);
      }
    } catch (err) {
      console.error('Failed to load warehouse occupancy report:', err);
      this.error = 'Failed to load occupancy data.';
      this.report = null;
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  setViewMode(mode: '3d' | 'table'): void {
    this.viewMode = mode;
    this.cd.markForCheck();
    if (mode === '3d' && this.selectedRackOptions.length > 0) {
      setTimeout(() => this.initOrUpdate3DScene(), 0);
    }
  }

  openBinDrawer(bin: BinOccupancyDto): void {
    this.selectedBin = bin;
    this.isDrawerOpen = true;
    this.cd.markForCheck();
  }

  closeBinDrawer(): void {
    this.isDrawerOpen = false;
    this.cd.markForCheck();
  }

  get filteredBins(): BinOccupancyDto[] {
    if (!this.report?.bins) return [];
    if (!this.searchQuery.trim()) return Array.from(this.report.bins);

    const q = this.searchQuery.toLowerCase().trim();
    return Array.from(this.report.bins).filter(b => 
      b.binName?.toLowerCase().includes(q) ||
      b.rackName?.toLowerCase().includes(q) ||
      b.bayNumber?.toString().includes(q) ||
      b.levelNumber?.toString().includes(q)
    );
  }

  // ==========================================
  // LOW-CONTRAST QR CODE CANVAS TEXTURE GENERATOR
  // ==========================================
  private getOrCreateQrTexture(): THREE.CanvasTexture {
    if (this.qrTexture) return this.qrTexture;

    const canvas = document.createElement('canvas');
    canvas.width = 256;
    canvas.height = 256;
    const ctx = canvas.getContext('2d')!;

    ctx.fillStyle = '#2563eb';
    ctx.fillRect(0, 0, 256, 256);

    ctx.fillStyle = '#3b82f6';
    ctx.fillRect(20, 20, 216, 216);

    ctx.fillStyle = '#1e40af';
    const margin = 30;
    const tileSize = 13;

    for (let r = 0; r < 15; r++) {
      for (let c = 0; c < 15; c++) {
        const isCorner = 
          (r < 4 && c < 4) || 
          (r < 4 && c > 10) || 
          (r > 10 && c < 4);

        if (isCorner) {
          ctx.fillRect(margin + c * tileSize, margin + r * tileSize, tileSize, tileSize);
        } else if ((r * 7 + c * 13) % 3 === 0 || (r + c) % 5 === 0) {
          ctx.fillRect(margin + c * tileSize, margin + r * tileSize, tileSize, tileSize);
        }
      }
    }

    this.qrTexture = new THREE.CanvasTexture(canvas);
    return this.qrTexture;
  }

  // ==========================================
  // FLOATING RACK HEADER LABEL (CYAN OUTLINE)
  // ==========================================
  private createRackHeaderLabel(title: string): THREE.Mesh {
    const canvas = document.createElement('canvas');
    canvas.width = 512;
    canvas.height = 128;
    const ctx = canvas.getContext('2d')!;

    ctx.fillStyle = '#0a0f1d';
    ctx.fillRect(0, 0, 512, 128);

    ctx.strokeStyle = '#00aaff';
    ctx.lineWidth = 10;
    ctx.strokeRect(8, 8, 496, 112);

    ctx.fillStyle = '#ffffff';
    ctx.font = 'bold 36px sans-serif';
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillText(title, 256, 64);

    const texture = new THREE.CanvasTexture(canvas);
    const mat = new THREE.MeshBasicMaterial({ map: texture, transparent: true, side: THREE.DoubleSide });
    const geo = new THREE.PlaneGeometry(5, 1.25);
    return new THREE.Mesh(geo, mat);
  }

  // ==========================================
  // THREE.JS CANVAS & RACK RENDERER
  // ==========================================
  private initOrUpdate3DScene(): void {
    if (!this.canvasContainer || this.selectedRackOptions.length === 0) return;

    const container = this.canvasContainer.nativeElement;
    const width = container.clientWidth;
    const height = container.clientHeight || 580;

    if (!this.scene) {
      this.scene = new THREE.Scene();
      this.scene.background = new THREE.Color(0x060913);

      this.camera = new THREE.PerspectiveCamera(45, width / height, 0.1, 1000);
      
      this.renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
      this.renderer.setSize(width, height);
      this.renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));

      container.innerHTML = '';
      container.appendChild(this.renderer.domElement);

      this.controls = new OrbitControls(this.camera, this.renderer.domElement);
      this.controls.enableDamping = true;
      this.controls.dampingFactor = 0.05;

      const ambientLight = new THREE.AmbientLight(0xffffff, 0.85);
      this.scene.add(ambientLight);

      const overheadLight = new THREE.DirectionalLight(0xffffff, 1.0);
      overheadLight.position.set(15, 30, 20);
      this.scene.add(overheadLight);

      const floorGrid = new THREE.GridHelper(80, 40, 0x1e293b, 0x0f172a);
      floorGrid.position.y = 0;
      this.scene.add(floorGrid);

      this.pointerDownListener = (e: PointerEvent) => {
        this.pointerDownPos.set(e.clientX, e.clientY);
      };

      this.pointerUpListener = (e: PointerEvent) => {
        const dist = Math.hypot(e.clientX - this.pointerDownPos.x, e.clientY - this.pointerDownPos.y);
        if (dist < 5) {
          this.handleCanvasClick(e);
        }
      };

      this.renderer.domElement.addEventListener('pointerdown', this.pointerDownListener);
      this.renderer.domElement.addEventListener('pointerup', this.pointerUpListener);

      const animate = () => {
        this.animationFrameId = requestAnimationFrame(animate);
        this.controls.update();
        this.renderer.render(this.scene, this.camera);
      };
      animate();
    } else {
      this.renderer.setSize(width, height);
      this.camera.aspect = width / height;
      this.camera.updateProjectionMatrix();
    }

    this.renderRackFromImageStyle();
  }

  private renderRackFromImageStyle(): void {
    // 1. Completely dispose and remove the previous master rack structure from scene
    if (this.rackGroup) {
      this.scene.remove(this.rackGroup);
      this.rackGroup.traverse((child) => {
        if (child instanceof THREE.Mesh) {
          child.geometry.dispose();
          if (Array.isArray(child.material)) {
            child.material.forEach((m) => m.dispose());
          } else {
            child.material.dispose();
          }
        }
      });
      this.rackGroup = null;
    }
    this.binGroups = [];
    this.selectedBinGroup = null;

    if (!this.report?.bins || this.report.bins.length === 0 || this.selectedRackOptions.length === 0) return;

    // 2. Create new master rack group
    this.rackGroup = new THREE.Group();

    const bins = Array.from(this.report.bins);
    const selectedRack = this.selectedRackOptions[0]?.raw;
    const rackTitle = selectedRack?.name || 'Metal Shelving 1';

    const bayWidth = 2.4;
    const levelHeight = 1.8;
    const depth = 1.4;
    const postThickness = 0.1;

    let maxBay = 1;
    let maxLevel = 1;

    bins.forEach(b => {
      if ((b.bayNumber || 1) > maxBay) maxBay = b.bayNumber || 1;
      if ((b.levelNumber || 1) > maxLevel) maxLevel = b.levelNumber || 1;
    });

    const postMat = new THREE.MeshStandardMaterial({ color: 0x111827, roughness: 0.5 });
    const shelfPlateMat = new THREE.MeshStandardMaterial({ color: 0x475569, roughness: 0.4 });

    // Build Vertical Steel Posts (Added to rackGroup)
    for (let bay = 0; bay <= maxBay; bay++) {
      const posX = bay * bayWidth;
      const postGeo = new THREE.BoxGeometry(postThickness, maxLevel * levelHeight + 0.4, postThickness);

      const frontPost = new THREE.Mesh(postGeo, postMat);
      frontPost.position.set(posX, (maxLevel * levelHeight) / 2, depth / 2);
      this.rackGroup.add(frontPost);

      const backPost = new THREE.Mesh(postGeo, postMat);
      backPost.position.set(posX, (maxLevel * levelHeight) / 2, -depth / 2);
      this.rackGroup.add(backPost);
    }

    // Build Shelves (Added to rackGroup)
    for (let level = 1; level <= maxLevel; level++) {
      const posY = (level - 1) * levelHeight + 0.05;
      const shelfGeo = new THREE.BoxGeometry(maxBay * bayWidth, 0.08, depth);
      const shelfMesh = new THREE.Mesh(shelfGeo, shelfPlateMat);
      shelfMesh.position.set((maxBay * bayWidth) / 2, posY, 0);
      this.rackGroup.add(shelfMesh);
    }

    // Build Floating Title Header (Added to rackGroup)
    const headerLabel = this.createRackHeaderLabel(rackTitle);
    headerLabel.position.set((maxBay * bayWidth) / 2, maxLevel * levelHeight + 1.2, 0);
    this.rackGroup.add(headerLabel);

    const qrTex = this.getOrCreateQrTexture();
    const qrBoxMat = new THREE.MeshStandardMaterial({ map: qrTex, roughness: 0.3 });

    // Build Bins & Cargo Boxes (Added to rackGroup)
    bins.forEach(bin => {
      const bay = bin.bayNumber || 1;
      const level = bin.levelNumber || 1;

      const posX = (bay - 0.5) * bayWidth;
      const posY = (level - 1) * levelHeight + 0.08;
      const posZ = 0;

      const binGroup = new THREE.Group();
      binGroup.position.set(posX, posY, posZ);
      binGroup.userData = { bin, isBinGroup: true };

      if (bin.isOccupied) {
        const boxGeo = new THREE.BoxGeometry(1.2, 0.9, 1.0);
        const cargoMesh = new THREE.Mesh(boxGeo, qrBoxMat);
        cargoMesh.name = 'cargoMesh';
        cargoMesh.position.set(0, 0.45, 0);
        binGroup.add(cargoMesh);
      } else {
        const emptyGeo = new THREE.BoxGeometry(1.4, 0.9, 1.0);
        const emptyMat = new THREE.MeshStandardMaterial({
          color: 0x059669,
          transparent: true,
          opacity: 0.15,
          wireframe: true
        });
        const emptyMesh = new THREE.Mesh(emptyGeo, emptyMat);
        emptyMesh.name = 'cargoMesh';
        emptyMesh.position.set(0, 0.45, 0);
        binGroup.add(emptyMesh);
      }

      this.rackGroup!.add(binGroup);
      this.binGroups.push(binGroup);
    });

    this.scene.add(this.rackGroup);

    const centerX = (maxBay * bayWidth) / 2;
    const centerY = (maxLevel * levelHeight) / 2;

    this.controls.target.set(centerX, centerY, 0);
    this.camera.position.set(centerX, centerY + 1, maxBay * 2.2 + 6);
    this.controls.update();
  }

  private handleCanvasClick(event: PointerEvent): void {
    if (!this.canvasContainer || !this.renderer) return;

    const rect = this.renderer.domElement.getBoundingClientRect();
    this.mouse.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
    this.mouse.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;

    this.raycaster.setFromCamera(this.mouse, this.camera);
    const intersects = this.raycaster.intersectObjects(this.scene.children, true);

    for (const intersect of intersects) {
      let obj: THREE.Object3D | null = intersect.object;
      
      while (obj && !obj.userData?.['isBinGroup']) {
        obj = obj.parent;
      }

      if (obj && obj.userData?.['bin']) {
        const bin = obj.userData['bin'] as BinOccupancyDto;
        this.highlightBinGroup(obj as THREE.Group);
        this.openBinDrawer(bin);
        break;
      }
    }
  }

  private highlightBinGroup(group: THREE.Group): void {
    if (this.selectedBinGroup) {
      const prevCargo = this.selectedBinGroup.getObjectByName('cargoMesh') as THREE.Mesh;
      if (prevCargo) {
        prevCargo.scale.set(1, 1, 1);
      }
    }

    this.selectedBinGroup = group;
    const cargo = group.getObjectByName('cargoMesh') as THREE.Mesh;
    if (cargo) {
      cargo.scale.set(1.1, 1.1, 1.1);
    }
  }

  @HostListener('window:resize')
  onWindowResize(): void {
    if (this.viewMode === '3d' && this.canvasContainer && this.renderer && this.camera) {
      const width = this.canvasContainer.nativeElement.clientWidth;
      const height = this.canvasContainer.nativeElement.clientHeight || 580;
      this.camera.aspect = width / height;
      this.camera.updateProjectionMatrix();
      this.renderer.setSize(width, height);
    }
  }

  private disposeThreeScene(): void {
    if (this.renderer?.domElement) {
      if (this.pointerDownListener) this.renderer.domElement.removeEventListener('pointerdown', this.pointerDownListener);
      if (this.pointerUpListener) this.renderer.domElement.removeEventListener('pointerup', this.pointerUpListener);
    }
    if (this.animationFrameId) {
      cancelAnimationFrame(this.animationFrameId);
    }
    if (this.rackGroup) {
      this.scene?.remove(this.rackGroup);
    }
    if (this.renderer) {
      this.renderer.dispose();
    }
  }
}