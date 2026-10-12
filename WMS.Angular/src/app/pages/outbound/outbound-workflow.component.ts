import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { ToastService } from '../../lib/services/toast.service';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';
import {
  CreateLoadingPlan,
  CreateLoadingException,
  CreateOutboundStage,
  LoadingEvidenceType,
  LoadingExceptionSeverity,
  LoadingExceptionType,
  LoadingPlan,
  ManualPickingDetails,
  OutboundStage,
  PickOrderOption,
  StageProductSelection,
} from './outbound-workflow.models';
import { OutboundWorkflowService } from './outbound-workflow.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-outbound-workflow',
  standalone: true,
  imports: [CommonModule, FormsModule, PageHeaderComponent, RouterLink],
  templateUrl: './outbound-workflow.component.html',
})
export class OutboundWorkflowComponent implements OnInit {
  private readonly outboundService = inject(OutboundWorkflowService);
  private readonly toastService = inject(ToastService);
  private readonly cd = inject(ChangeDetectorRef);
  private hasLoadedData = false;

  // Workspace Navigation & Drawer States
  activeTab: 'stages' | 'loadingPlans' = 'stages';
  drawerTab: 'manifest' | 'evidence' | 'exceptions' = 'manifest';

  isLoading = true;
  isLoadingDetails = false;
  isLoadingPickDetails = false;
  isCreatingStage = false;
  isCreatingPlan = false;
  isSavingStageQuantities = false;
  isSavingLoadQuantities = false;
  isUploadingEvidence = false;
  isCreatingException = false;

  evidenceType: LoadingEvidenceType = 'SealCheck';
  exceptionType: LoadingExceptionType = 'MissingPallet';
  exceptionSeverity: LoadingExceptionSeverity = 'Medium';
  exceptionDescription = '';
  exceptionPalletId: number | null = null;
  exceptionLoadingPlanLineId: number | null = null;

  createForm: 'stage' | 'loadingPlan' | null = null;
  activeStageId: number | null = null;
  activeLoadingPlanId: number | null = null;
  actionLoadingPlanId: number | null = null;

  // Search & Filter States
  stageStatusFilter = 'All';
  stageSearchQuery = '';
  loadingPlanStatusFilter = 'All';
  loadingPlanSearchQuery = '';
  error = '';

  pickOrders: PickOrderOption[] = [];
  stages: OutboundStage[] = [];
  loadingPlans: LoadingPlan[] = [];
  selectedPickOrderId: number | null = null;
  selectedPickDetails: ManualPickingDetails | null = null;
  productSelections: StageProductSelection[] = [];
  stageBinId: number | null = null;
  stageNotes = '';

  loadingReference = '';
  vehiclePlateNumber = '';
  containerNumber = '';
  sealNumber = '';
  customerName = '';
  shipperName = '';
  destination = '';
  scheduledDate = '';
  planRemarks = '';
  selectedStageIds = new Set<number>();
  private savedLineQuantities = new Map<number, number>();

  ngOnInit(): void {
    void this.loadData();
  }

  // --- KPI Computed Metrics ---
  get readyToStageCount(): number {
    return this.pickOrders.length;
  }

  get availableStagesCount(): number {
    return this.availableStages.length;
  }

  get activeLoadingPlansCount(): number {
    return this.loadingPlans.filter(
      (plan) => plan.status === 'InProgress' || plan.status === 'Partial' || plan.status === 'Assigned',
    ).length;
  }

  get openExceptionsCount(): number {
    return this.loadingPlans.reduce(
      (total, plan) => total + (plan.exceptions?.length ?? 0),
      0,
    );
  }

  get hasUnsavedLoadQuantities(): boolean {
    const plan = this.activeLoadingPlan;
    if (!plan) return false;
    return plan.lines.some(
      (line) => this.savedLineQuantities.get(line.id) !== line.quantityLoaded,
    );
  }

  // --- Filtered Data Getters ---
  get filteredStages(): OutboundStage[] {
    return this.stages.filter((stage) => {
      const matchesStatus =
        this.stageStatusFilter === 'All' ||
        stage.status?.toLowerCase() === this.stageStatusFilter.toLowerCase();

      const query = this.stageSearchQuery.trim().toLowerCase();
      const matchesSearch =
        !query ||
        stage.stageReference?.toLowerCase().includes(query) ||
        stage.manualPickingId?.toString().includes(query) ||
        stage.warehouseId?.toString().includes(query);

      return matchesStatus && matchesSearch;
    });
  }

  get filteredLoadingPlans(): LoadingPlan[] {
    return this.loadingPlans.filter((plan) => {
      const matchesStatus =
        this.loadingPlanStatusFilter === 'All' ||
        plan.status?.toLowerCase() === this.loadingPlanStatusFilter.toLowerCase();

      const query = this.loadingPlanSearchQuery.trim().toLowerCase();
      const matchesSearch =
        !query ||
        plan.loadingReference?.toLowerCase().includes(query) ||
        plan.customerName?.toLowerCase().includes(query) ||
        plan.vehiclePlateNumber?.toLowerCase().includes(query) ||
        plan.containerNumber?.toLowerCase().includes(query);

      return matchesStatus && matchesSearch;
    });
  }

  getStatusBadgeClass(status?: string | null): string {
    switch (status) {
      case 'Completed':
        return 'bg-emerald-50 text-emerald-700 border border-emerald-200';
      case 'InProgress':
      case 'Partial':
      case 'Assigned':
        return 'bg-amber-50 text-amber-800 border border-amber-200';
      case 'Cancelled':
      case 'CancellationRequested':
      case 'Rejected':
        return 'bg-rose-50 text-rose-700 border border-rose-200';
      default:
        return 'bg-slate-100 text-slate-700 border border-slate-200';
    }
  }

  // --- Drawer Controls ---
  openCreateForm(form: 'stage' | 'loadingPlan'): void {
    this.closeDetails();
    this.createForm = form;
  }

closeCreateForm(): void {
  this.createForm = null;
  this.resetStageForm();
  this.resetLoadingPlanForm();
}

private resetStageForm(): void {
  this.selectedPickOrderId = null;
  this.selectedPickDetails = null;
  this.productSelections = [];
  this.stageBinId = null;
  this.stageNotes = '';
  this.isLoadingPickDetails = false;
}

closeDetails(): void {
    this.activeStageId = null;
    this.activeLoadingPlanId = null;
    this.createForm = null;
    this.savedLineQuantities.clear();
  }

  async openStage(stage: OutboundStage): Promise<void> {
    if (this.activeStageId === stage.id) {
      this.closeDetails();
      return;
    }

    this.activeStageId = stage.id;
    this.activeLoadingPlanId = null;
    this.createForm = null;
    this.isLoadingDetails = true;
    this.cd.markForCheck();
    try {
      const details = await this.outboundService.getStage(stage.id);
      if (this.activeStageId === stage.id) {
        this.stages = this.stages.map((item) => (item.id === stage.id ? details : item));
      }
    } catch (err) {
      this.error = `Unable to load stage details. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to load outbound stage details:', err);
    } finally {
      this.isLoadingDetails = false;
      this.cd.markForCheck();
    }
  }

async openLoadingPlan(plan: LoadingPlan): Promise<void> {
    if (this.activeLoadingPlanId === plan.id) {
      this.closeDetails();
      return;
    }

    this.activeLoadingPlanId = plan.id;
    this.activeStageId = null;
    this.createForm = null;
    this.drawerTab = 'manifest';
    this.isLoadingDetails = true;
    this.cd.markForCheck();
    try {
      const details = await this.outboundService.getLoadingPlan(plan.id);
      const updatedPlan = await this.withPalletQrCodes(details);
      if (this.activeLoadingPlanId === plan.id) {
        this.loadingPlans = this.loadingPlans.map((item) =>
          item.id === plan.id ? updatedPlan : item,
        );
        // Sync saved snapshot when opening the drawer
        this.syncSavedLineQuantities(updatedPlan);
      }
    } catch (err) {
      this.error = `Unable to load loading-plan details. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to load loading plan details:', err);
    } finally {
      this.isLoadingDetails = false;
      this.cd.markForCheck();
    }
  }

  // --- Printing ---
  printLoadingPlanReceipt(plan: LoadingPlan): void {
    const printWindow = window.open('', '_blank', 'width=900,height=700');
    if (!printWindow) {
      this.error = 'Your browser blocked the receipt window. Allow pop-ups and try again.';
      this.toastService.error(this.error);
      return;
    }

    const escapeHtml = (value: string | number | null | undefined): string =>
      String(value ?? '—').replace(/[&<>"']/g, (character) => ({
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#39;',
      })[character]!);

    const lineRows = plan.lines.map((line) => `
      <article class="pallet">
        <div>
          <strong>${escapeHtml(line.productName || `Picked product #${line.pickedProductId ?? '—'}`)}</strong>
          <p>Planned: ${escapeHtml(line.quantityPlanned)} &nbsp; Loaded: ${escapeHtml(line.quantityLoaded)}</p>
          <p>Pallet: ${escapeHtml(line.palletNumber ?? line.originalPalletId)}</p>
        </div>
        ${line.palletQrCodeUrl
          ? `<img src="${escapeHtml(line.palletQrCodeUrl)}" alt="Pallet QR code">`
          : '<p class="no-qr">No pallet QR code available</p>'}
      </article>
    `).join('');

    printWindow.document.write(`<!doctype html>
      <html lang="en">
      <head>
        <meta charset="utf-8">
        <title>Loading receipt ${escapeHtml(plan.loadingReference)}</title>
        <style>
          @page { size: A4; margin: 14mm; }
          * { box-sizing: border-box; }
          body { color: #0f172a; font: 12px Arial, sans-serif; margin: 0; }
          h1 { font-size: 21px; margin: 0 0 6px; }
          h2 { font-size: 14px; margin: 20px 0 8px; }
          p { margin: 4px 0; }
          .meta { border-bottom: 1px solid #cbd5e1; display: grid; gap: 7px 20px; grid-template-columns: 1fr 1fr; padding: 12px 0 16px; }
          .pallet { align-items: center; border-bottom: 1px solid #cbd5e1; display: flex; justify-content: space-between; min-height: 112px; padding: 12px 0; page-break-inside: avoid; }
          .pallet img { height: 96px; object-fit: contain; width: 96px; }
          .no-qr { color: #64748b; }
          .muted { color: #475569; }
          @media print { .pallet:last-child { border-bottom: 0; } }
        </style>
      </head>
      <body>
        <h1>Loading plan receipt</h1>
        <p class="muted">${escapeHtml(plan.loadingReference)} · ${escapeHtml(plan.status)}</p>
        <section class="meta">
          <p><strong>Customer:</strong> ${escapeHtml(plan.customerName)}</p>
          <p><strong>Shipping line:</strong> ${escapeHtml(plan.shipperName)}</p>
          <p><strong>Vehicle:</strong> ${escapeHtml(plan.vehiclePlateNumber)}</p>
          <p><strong>Container:</strong> ${escapeHtml(plan.containerNumber)}</p>
          <p><strong>Seal:</strong> ${escapeHtml(plan.sealNumber)}</p>
          <p><strong>Destination:</strong> ${escapeHtml(plan.destination)}</p>
          <p><strong>Started:</strong> ${escapeHtml(this.formatDate(plan.actualStartAt))}</p>
          <p><strong>Finished:</strong> ${escapeHtml(this.formatDate(plan.completedAt))}</p>
        </section>
        <h2>Pallets and quantities</h2>
        ${lineRows || '<p>No loading lines are recorded.</p>'}
      </body>
      </html>`);
    printWindow.document.close();
    printWindow.focus();
    window.setTimeout(() => printWindow.print(), 400);
  }

  // --- Data Loading & Operations ---
async loadData(): Promise<void> {
    this.isLoading = !this.hasLoadedData;
    this.error = '';
    this.cd.markForCheck();

    try {
      const [pickOrders, stages, loadingPlans] = await Promise.all([
        this.outboundService.getPickOrders(),
        this.outboundService.getStages(),
        this.outboundService.getLoadingPlans(),
      ]);
      this.pickOrders = pickOrders.items ?? [];
      this.stages = stages;
      const activePlan =
        this.activeLoadingPlanId === null
          ? null
          : loadingPlans.find((plan) => plan.id === this.activeLoadingPlanId) ?? null;
      const activePlanWithQr = activePlan ? await this.withPalletQrCodes(activePlan) : null;
      
      this.loadingPlans = activePlanWithQr
        ? loadingPlans.map((plan) => (plan.id === activePlanWithQr.id ? activePlanWithQr : plan))
        : loadingPlans;

      // Sync saved state snapshot if active plan exists
      if (activePlanWithQr) {
        this.syncSavedLineQuantities(activePlanWithQr);
      }
    } catch (err) {
      this.error = `Unable to load outbound data. ${OutboundWorkflowService.errorMessage(err)}`;
      console.error('Failed to load outbound workflow data:', err);
    } finally {
      this.isLoading = false;
      this.hasLoadedData = true;
      this.cd.markForCheck();
    }
  }

  async onPickOrderChange(): Promise<void> {
    this.selectedPickDetails = null;
    this.productSelections = [];
    this.error = '';

    if (!this.selectedPickOrderId) {
      this.cd.markForCheck();
      return;
    }

    this.isLoadingPickDetails = true;
    this.cd.markForCheck();
    try {
      const details = await this.outboundService.getPickOrderDetails(this.selectedPickOrderId);
      this.selectedPickDetails = details;
      this.productSelections = (details.pickProducts ?? [])
        .filter((product) => product.id !== undefined)
        .map((product) => ({
          product,
          selected: false,
          quantity: this.getRemainingStageQuantity(product.id!, product.quantityPicked ?? 0),
        }))
        .filter((selection) => selection.quantity > 0);
    } catch (err) {
      this.error = `Unable to load the selected pick order. ${OutboundWorkflowService.errorMessage(err)}`;
      console.error('Failed to load pick order details:', err);
    } finally {
      this.isLoadingPickDetails = false;
      this.cd.markForCheck();
    }
  }

  updateProductSelection(selection: StageProductSelection, checked: boolean): void {
    selection.selected = checked;
    if (checked && selection.quantity <= 0) {
      selection.quantity = this.getRemainingStageQuantity(
        selection.product.id!,
        selection.product.quantityPicked ?? 0,
      );
    }
  }

  getRemainingStageQuantity(pickedProductId: number, quantityPicked: number): number {
    const reservedQuantity = this.stages
      .filter((stage) => stage.status !== 'Cancelled' && stage.status !== 'CancellationRequested')
      .flatMap((stage) => stage.lines)
      .filter((line) => line.pickedProductId === pickedProductId && line.status !== 'Cancelled')
      .reduce((total, line) => total + line.quantityToStage, 0);
    const dispatchedWithoutStageLines = this.loadingPlans
      .filter((plan) => plan.status === 'Completed')
      .flatMap((plan) => plan.lines)
      .filter((line) => line.pickedProductId === pickedProductId && line.outboundStageLineId === null)
      .reduce((total, line) => total + line.quantityLoaded, 0);
    return Math.max(quantityPicked - reservedQuantity - dispatchedWithoutStageLines, 0);
  }

  getRemainingLoadQuantity(stageLineId: number, quantityStaged: number): number {
    const plannedQuantity = this.loadingPlans
      .filter((plan) => plan.status !== 'Cancelled')
      .flatMap((plan) => plan.lines)
      .filter((line) => line.outboundStageLineId === stageLineId)
      .reduce((total, line) => total + line.quantityPlanned, 0);
    return Math.max(quantityStaged - plannedQuantity, 0);
  }

  get availableStages(): OutboundStage[] {
    return this.stages.filter(
      (stage) =>
        stage.status !== 'Cancelled' &&
        stage.status !== 'CancellationRequested' &&
        stage.lines.some((line) => this.getRemainingLoadQuantity(line.id, line.quantityStaged) > 0),
    );
  }

  get activeStage(): OutboundStage | null {
    return this.stages.find((stage) => stage.id === this.activeStageId) ?? null;
  }

  toggleStageSelection(stage: OutboundStage, checked: boolean): void {
    if (checked) {
      const currentWarehouseId = this.selectedStageWarehouseId;
      if (currentWarehouseId !== null && currentWarehouseId !== stage.warehouseId) {
        this.error = 'A loading plan can only include stages from the same warehouse.';
        this.cd.markForCheck();
        return;
      }
      this.selectedStageIds.add(stage.id);
      this.error = '';
    } else {
      this.selectedStageIds.delete(stage.id);
      this.error = '';
    }
  }

  get selectedStageWarehouseId(): number | null {
    const selected = this.stages.find((stage) => this.selectedStageIds.has(stage.id));
    return selected?.warehouseId ?? null;
  }

  get selectedProductCount(): number {
    return this.productSelections.filter((selection) => selection.selected).length;
  }

  get selectedStageCount(): number {
    return this.selectedStageIds.size;
  }

  get activeLoadingPlan(): LoadingPlan | null {
    return this.loadingPlans.find((plan) => plan.id === this.activeLoadingPlanId) ?? null;
  }

get canDispatchActivePlan(): boolean {
    const plan = this.activeLoadingPlan;
    if (!plan || plan.lines.length === 0) return false;

    return (
      !this.hasUnsavedLoadQuantities &&
      plan.lines.every(
        (line) =>
          line.quantityLoaded === line.quantityPlanned &&
          this.savedLineQuantities.get(line.id) === line.quantityPlanned,
      )
    );
  }

private syncSavedLineQuantities(plan: LoadingPlan): void {
    this.savedLineQuantities.clear();
    (plan.lines ?? []).forEach((line) => {
      this.savedLineQuantities.set(line.id, line.quantityLoaded);
    });
  }

async createStage(): Promise<void> {
  const selected = this.productSelections.filter((selection) => selection.selected);
  if (!this.selectedPickDetails || selected.length === 0) {
    this.error = 'Choose a pick order and at least one picked product to stage.';
    return;
  }
  if (
    selected.some(
      (selection) =>
        !Number.isInteger(selection.quantity) ||
        selection.quantity < 1 ||
        selection.quantity >
          this.getRemainingStageQuantity(
            selection.product.id!,
            selection.product.quantityPicked ?? 0,
          ),
    )
  ) {
    this.error =
      'Each staged quantity must be a whole number within the remaining quantity available to stage.';
    return;
  }

  this.isCreatingStage = true;
  this.error = '';
  this.cd.markForCheck();

  const request: CreateOutboundStage = {
    manualPickingId: this.selectedPickDetails.id,
    warehouseId: this.selectedPickDetails.warehouseId,
    stagingBinId: this.stageBinId || null,
    notes: this.stageNotes.trim() || null,
    lines: selected.map(({ product, quantity }) => ({
      pickedProductId: product.id!,
      receivedProductId: 0,
      originalBinId: this.selectedPickDetails!.binId,
      originalPalletId: null,
      quantityToStage: quantity,
      stagingBinId: this.stageBinId || null,
      remarks: null,
    })),
  };

  try {
    const created = await this.outboundService.createStage(request);
    this.toastService.success(`Outbound stage ${created.stageReference} created.`);
    this.closeCreateForm(); // Automatically calls resetStageForm() and resetLoadingPlanForm()
    await this.loadData();
  } catch (err) {
    this.error = `Unable to create the outbound stage. ${OutboundWorkflowService.errorMessage(err)}`;
    this.toastService.error(this.error);
    console.error('Failed to create outbound stage:', err);
  } finally {
    this.isCreatingStage = false;
    this.cd.markForCheck();
  }
}

  async createLoadingPlan(): Promise<void> {
    if (this.selectedStageIds.size === 0) {
      this.error = 'Select at least one outbound stage for the loading plan.';
      return;
    }
    if (!this.loadingReference.trim()) {
      this.error = 'Enter a loading reference.';
      return;
    }

    const warehouseId = this.selectedStageWarehouseId;
    if (warehouseId === null) {
      this.error = 'The selected stages do not have a warehouse.';
      return;
    }

    this.isCreatingPlan = true;
    this.error = '';
    this.cd.markForCheck();

    const request: CreateLoadingPlan = {
      warehouseId,
      loadingReference: this.loadingReference.trim(),
      vehiclePlateNumber: this.vehiclePlateNumber.trim() || null,
      trailerPlateNumber: null,
      containerNumber: this.containerNumber.trim() || null,
      containerType: null,
      sealNumber: this.sealNumber.trim() || null,
      customerName: this.customerName.trim() || null,
      shipperName: this.shipperName.trim() || null,
      consigneeName: null,
      destination: this.destination.trim() || null,
      scheduledDate: this.scheduledDate || null,
      supervisorUserId: null,
      loaderUserId: null,
      stageIds: [...this.selectedStageIds],
      remarks: this.planRemarks.trim() || null,
    };

    try {
      const plan = await this.outboundService.createLoadingPlan(request);
      this.toastService.success(`Loading plan ${plan.loadingReference} created.`);
      this.closeCreateForm();
      this.resetLoadingPlanForm();
      await this.loadData();
    } catch (err) {
      this.error = `Unable to create the loading plan. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to create loading plan:', err);
    } finally {
      this.isCreatingPlan = false;
      this.cd.markForCheck();
    }
  }

  async startLoading(plan: LoadingPlan): Promise<void> {
    this.actionLoadingPlanId = plan.id;
    this.error = '';
    this.cd.markForCheck();
    try {
      await this.outboundService.startLoadingPlan(plan.id);
      this.toastService.success(`Loading started for ${plan.loadingReference}.`);
      await this.loadData();
      this.activeLoadingPlanId = plan.id;
    } catch (err) {
      this.error = `Unable to start loading. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to start loading plan:', err);
    } finally {
      this.actionLoadingPlanId = null;
      this.cd.markForCheck();
    }
  }

  async uploadLoadingEvidence(plan: LoadingPlan, input: HTMLInputElement): Promise<void> {
    const file = input.files?.[0];
    if (!file) return;

    if (!file.type.startsWith('image/')) {
      this.error = 'Choose an image file to upload.';
      input.value = '';
      return;
    }

    this.isUploadingEvidence = true;
    this.error = '';
    this.cd.markForCheck();
    try {
      const evidence = await this.outboundService.uploadLoadingPlanEvidence(
        plan.id,
        file,
        this.evidenceType,
      );
      plan.evidence = [...(plan.evidence ?? []), evidence];
      plan.photoUrls = [...(plan.photoUrls ?? []), evidence.storedPath];
      this.toastService.success(`${this.formatEvidenceType(evidence.evidenceType)} evidence uploaded.`);
      input.value = '';
    } catch (err) {
      this.error = `Unable to upload loading evidence. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to upload loading evidence:', err);
    } finally {
      this.isUploadingEvidence = false;
      this.cd.markForCheck();
    }
  }

  async createLoadingException(plan: LoadingPlan): Promise<void> {
    const description = this.exceptionDescription.trim();
    if (!description) {
      this.error = 'Enter a description for the loading exception.';
      return;
    }

    this.isCreatingException = true;
    this.error = '';
    this.cd.markForCheck();
    const request: CreateLoadingException = {
      exceptionType: this.exceptionType,
      description,
      severity: this.exceptionSeverity,
      palletId: this.exceptionPalletId,
      loadingPlanLineId: this.exceptionLoadingPlanLineId,
    };

    try {
      const exception = await this.outboundService.createLoadingException(plan.id, request);
      plan.exceptions = [exception, ...(plan.exceptions ?? [])];
      this.exceptionDescription = '';
      this.exceptionPalletId = null;
      this.exceptionLoadingPlanLineId = null;
      this.toastService.success('Loading exception recorded.');
    } catch (err) {
      this.error = `Unable to record the loading exception. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to record loading exception:', err);
    } finally {
      this.isCreatingException = false;
      this.cd.markForCheck();
    }
  }

  formatEvidenceType(type: LoadingEvidenceType): string {
    const labels: Record<LoadingEvidenceType, string> = {
      LoadingStart: 'Loading start',
      SealCheck: 'Seal check',
      VehicleInspection: 'Vehicle inspection',
      Damage: 'Damaged items',
      FinalDispatch: 'Final dispatch',
    };
    return labels[type];
  }

  formatExceptionType(type: LoadingExceptionType): string {
    return type.replace(/([a-z])([A-Z])/g, '$1 $2');
  }

  async saveStagedQuantities(stage: OutboundStage): Promise<void> {
    if (
      stage.lines.some(
        (line) =>
          !Number.isInteger(line.quantityStaged) ||
          line.quantityStaged < 0 ||
          line.quantityStaged > line.quantityToStage,
      )
    ) {
      this.error =
        'Staged quantities must be whole numbers between zero and each line’s requested quantity.';
      return;
    }

    this.isSavingStageQuantities = true;
    this.error = '';
    this.cd.markForCheck();
    try {
      await this.outboundService.updateStagedQuantities(
        stage.id,
        stage.lines.map((line) => ({
          outboundStageLineId: line.id,
          quantityStaged: line.quantityStaged,
        })),
      );
      this.toastService.success(`Staged quantities saved for ${stage.stageReference}.`);
      await this.loadData();
    } catch (err) {
      this.error = `Unable to save staged quantities. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to save staged quantities:', err);
    } finally {
      this.isSavingStageQuantities = false;
      this.cd.markForCheck();
    }
  }

async saveLoadedQuantities(plan: LoadingPlan): Promise<void> {
  const invalidLine = plan.lines.find(
    (line) =>
      !Number.isInteger(line.quantityLoaded) ||
      line.quantityLoaded < 0 ||
      line.quantityLoaded > line.quantityPlanned,
  );

  if (invalidLine) {
    this.error = `Loaded quantity for line #${invalidLine.id} cannot exceed planned quantity (${invalidLine.quantityPlanned}).`;
    this.toastService.error(this.error);
    return;
  }

  this.isSavingLoadQuantities = true;
  this.actionLoadingPlanId = plan.id;
  this.error = '';
  this.cd.markForCheck();
  try {
    await this.outboundService.updateLoadedQuantities(
      plan.id,
      plan.lines.map((line) => ({
        loadingPlanLineId: line.id,
        quantityLoaded: line.quantityLoaded,
      })),
    );

    this.syncSavedLineQuantities(plan);
    this.toastService.success(`Loaded quantities saved for ${plan.loadingReference}.`);
    await this.loadData();
  } catch (err) {
    this.error = `Unable to save loaded quantities. ${OutboundWorkflowService.errorMessage(err)}`;
    this.toastService.error(this.error);
    console.error('Failed to save loaded quantities:', err);
  } finally {
    this.isSavingLoadQuantities = false;
    this.actionLoadingPlanId = null;
    this.cd.markForCheck();
  }
}

  async confirmFinalDispatch(plan: LoadingPlan): Promise<void> {
    if (!this.canDispatchActivePlan || this.activeLoadingPlanId !== plan.id) {
      this.error = 'Save all planned quantities as loaded before final dispatch.';
      return;
    }
    if (
      !window.confirm(
        `Confirm final dispatch for ${plan.loadingReference}? This will complete the loading plan.`,
      )
    ) {
      return;
    }

    this.actionLoadingPlanId = plan.id;
    this.error = '';
    this.cd.markForCheck();
    try {
      await this.outboundService.dispatchLoadingPlan(plan.id);
      this.toastService.success(`Final dispatch confirmed for ${plan.loadingReference}.`);
      this.closeDetails();
      await this.loadData();
    } catch (err) {
      this.error = `Unable to confirm final dispatch. ${OutboundWorkflowService.errorMessage(err)}`;
      this.toastService.error(this.error);
      console.error('Failed to confirm final dispatch:', err);
    } finally {
      this.actionLoadingPlanId = null;
      this.cd.markForCheck();
    }
  }

  formatDate(value?: string | null): string {
    if (!value) return '—';
    const date = new Date(value);
    return Number.isNaN(date.getTime())
      ? '—'
      : date.toLocaleString(undefined, { dateStyle: 'medium', timeStyle: 'short' });
  }

  private resetLoadingPlanForm(): void {
    this.loadingReference = '';
    this.vehiclePlateNumber = '';
    this.containerNumber = '';
    this.sealNumber = '';
    this.customerName = '';
    this.shipperName = '';
    this.destination = '';
    this.scheduledDate = '';
    this.planRemarks = '';
    this.selectedStageIds.clear();
  }

  private async withPalletQrCodes(plan: LoadingPlan): Promise<LoadingPlan> {
    const lines = await Promise.all(
      (plan.lines ?? []).map(async (line) => ({
        ...line,
        palletQrCodeUrl:
          line.palletHashCode == null
            ? ''
            : await generateQrCodeDataUrl(line.palletHashCode, 160),
      })),
    );
    return { ...plan, lines };
  }

  onLoadedQuantityChange(line: any): void {
    if (line.quantityLoaded == null) return;

    if (line.quantityLoaded > line.quantityPlanned) {
      line.quantityLoaded = line.quantityPlanned;
      this.error = `Loaded quantity cannot exceed planned quantity (${line.quantityPlanned}).`;
      this.toastService.error(this.error);
    } else if (line.quantityLoaded < 0) {
      line.quantityLoaded = 0;
    } else {
      this.error = '';
    }
  }
}