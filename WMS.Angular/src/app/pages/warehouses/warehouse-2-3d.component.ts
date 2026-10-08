import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit, ViewChild, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Api } from '../../api/generated/api';
import { BinSummaryDto } from '../../api/generated/models';
import { updateBin3DLocation } from '../../api/generated/fn/wms-api/update-bin-3-d-location';
import { WarehouseService } from '../../lib/services/warehouse.service';
import { CreateCheckInModalComponent } from '../check-in/components/create/create-check-in-modal.component';
import { CreatePickOrderModalComponent } from '../pick-order/create-pick-order-modal.component';
import { ReceivingCreateComponent } from '../receiving/create/receiving-create.component';
import { CreateBinDialogComponent } from '../../shared/components/dialog/create-bin-dialog.component';
import { Bin3D } from './warehouse-3d-viewer.service';
import {
  BinWorldPosition,
  EmptySpotPointer,
  Warehouse3DViewerComponent,
} from './warehouse-3d-viewer.component';
import { CreateBinPosition } from '../../shared/components/dialog/create-bin-dialog.component';

@Component({
  selector: 'app-warehouse-2-3d',
  standalone: true,
  imports: [
    CommonModule,
    Warehouse3DViewerComponent,
    CreateBinDialogComponent,
    CreateCheckInModalComponent,
    CreatePickOrderModalComponent,
    ReceivingCreateComponent,
  ],
  templateUrl: './warehouse-2-3d.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Warehouse2ThreeDComponent implements OnInit {
  readonly warehouseId = 2;

  @ViewChild(Warehouse3DViewerComponent) viewer?: Warehouse3DViewerComponent;

  selectedBin: Bin3D | null = null;
  isCreateBinOpen = false;
  isCheckInOpen = false;
  isPickOrderOpen = false;
  isReceivingCreateOpen = false;
  binMoveMode = false;
  isSavingLocation = false;
  actionError = '';
  emptySpot: EmptySpotPointer | null = null;
  createBinPosition: CreateBinPosition | null = null;

  private readonly api = inject(Api);
  private readonly warehouseService = inject(WarehouseService);
  private readonly cd = inject(ChangeDetectorRef);

  ngOnInit(): void {
    this.warehouseService.setWarehouse(this.warehouseId);
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

  onBinSelected(bin: Bin3D): void {
    this.selectedBin = bin;
    this.actionError = '';
    this.cd.markForCheck();
  }

  openMoveForm(): void {
    this.actionError = '';
    this.binMoveMode = true;
    this.emptySpot = null;
    this.cd.markForCheck();
  }

  async saveDroppedLocation(drop: { binId: number; position: BinWorldPosition }): Promise<void> {
    if (this.isSavingLocation) return;
    this.isSavingLocation = true;
    this.actionError = '';
    this.cd.markForCheck();
    try {
      await this.api.invoke(updateBin3DLocation, {
        id: drop.binId,
        body: {
          positionX: drop.position.positionX,
          positionY: drop.position.positionY,
          positionZ: drop.position.positionZ,
          rotationY: drop.position.rotationY,
        },
      });
      this.viewer?.completeBinMove(drop.position);
      this.binMoveMode = false;
    } catch (err) {
      console.error('Failed to move standalone bin:', err);
      this.actionError = 'Unable to save the bin location. Please try again.';
      this.binMoveMode = false;
    } finally {
      this.isSavingLocation = false;
      this.cd.markForCheck();
    }
  }

  onEmptySpotChanged(spot: EmptySpotPointer | null): void {
    this.emptySpot = this.binMoveMode ? null : spot;
    this.cd.markForCheck();
  }

  onEmptySpotClicked(position: BinWorldPosition): void {
    this.viewer?.exitNavigation();
    this.createBinPosition = position;
    this.isCreateBinOpen = true;
    this.emptySpot = null;
    this.cd.markForCheck();
  }

  openCreateBinDialog(): void {
    this.viewer?.exitNavigation();
    this.createBinPosition = null;
    this.isCreateBinOpen = true;
  }

  openCheckIn(): void {
    this.viewer?.exitNavigation();
    this.isCheckInOpen = true;
  }

  openPickOrder(): void {
    this.viewer?.exitNavigation();
    this.isPickOrderOpen = true;
  }

  closeCreateBinDialog(): void {
    this.isCreateBinOpen = false;
    this.createBinPosition = null;
  }

  onMoveRequested(bin: Bin3D): void {
    this.onBinSelected(bin);
    this.openMoveForm();
  }

  cancelBinMove(): void {
    this.binMoveMode = false;
    this.cd.markForCheck();
  }

  async onBinCreated(bin: BinSummaryDto): Promise<void> {
    this.isCreateBinOpen = false;
    this.createBinPosition = null;
    if (bin.id) {
      this.selectedBin = {
        id: bin.id,
        binName: bin.binName ?? null,
        binHashCode: bin.binHashCode ?? null,
        rack: bin.rack ?? 'Standalone',
        bay: bin.bay ?? null,
        level: bin.level ?? null,
        warehouse: bin.warehouse ?? null,
        dateAdded: bin.dateAdded ?? null,
        location3D: bin.location3D,
      };
      this.viewer?.addCreatedStandaloneBin(this.selectedBin);
    }
    this.cd.markForCheck();
  }

  onWorkflowCreated(): void {
    void this.viewer?.loadWarehouseData();
  }

  onBinWorkflowCreated(): void {
    void this.viewer?.refreshSelectedBinInventory();
  }

  openReceivingCreate(): void {
    this.viewer?.exitNavigation();
    this.isReceivingCreateOpen = true;
    this.cd.markForCheck();
  }

  closeReceivingCreate(): void {
    this.isReceivingCreateOpen = false;
    this.cd.markForCheck();
  }
}
