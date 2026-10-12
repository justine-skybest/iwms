import {
  ManualPickingSummaryDto,
  PickedProductSummaryDto,
} from '../../api/generated/models';

export interface ManualPickingDetails {
  id: number;
  warehouseId: number;
  binId: number;
  pickedProductIds: number[] | null;
  pickProducts: PickedProductSummaryDto[];
  pickingDate: string;
  notes: string | null;
}

export interface CreateOutboundStageLine {
  pickedProductId: number;
  receivedProductId: number;
  originalBinId: number | null;
  originalPalletId: number | null;
  quantityToStage: number;
  stagingBinId: number | null;
  remarks: string | null;
}

export interface CreateOutboundStage {
  manualPickingId: number;
  warehouseId: number;
  stagingBinId: number | null;
  lines: CreateOutboundStageLine[];
  notes: string | null;
}

export interface OutboundStageLine {
  id: number;
  pickedProductId: number;
  receivedProductId: number;
  originalBinId: number | null;
  originalPalletId: number | null;
  stagingBinId: number | null;
  quantityToStage: number;
  quantityStaged: number;
  status: string;
  remarks: string | null;
  productName: string | null;
  createdAt: string;
  updatedAt: string;
}

export interface OutboundStage {
  id: number;
  manualPickingId: number;
  warehouseId: number;
  stagingBinId: number | null;
  stageReference: string;
  status: string;
  notes: string | null;
  lines: OutboundStageLine[];
  requestedAt: string;
  startedAt: string | null;
  completedAt: string | null;
  createdAt: string;
  updatedAt: string;
}

export interface UpdateOutboundStageQuantities {
  lines: { outboundStageLineId: number; quantityStaged: number }[];
}

export interface CreateLoadingPlan {
  warehouseId: number;
  loadingReference: string;
  vehiclePlateNumber: string | null;
  trailerPlateNumber: string | null;
  containerNumber: string | null;
  containerType: string | null;
  sealNumber: string | null;
  customerName: string | null;
  shipperName: string | null;
  consigneeName: string | null;
  destination: string | null;
  scheduledDate: string | null;
  supervisorUserId: string | null;
  loaderUserId: string | null;
  stageIds: number[];
  remarks: string | null;
}

export interface LoadingPlanLine {
  id: number;
  loadingPlanId: number;
  outboundStageId: number | null;
  outboundStageLineId: number | null;
  pickedProductId: number | null;
  originalPalletId: number | null;
  palletNumber: number | null;
  palletHashCode: number | null;
  palletQrCodeUrl?: string;
  quantityPlanned: number;
  quantityLoaded: number;
  remainingQuantity: number;
  status: string;
  productName: string | null;
  createdAt: string;
  updatedAt: string;
}

export interface LoadingPlan {
  id: number;
  warehouseId: number;
  loadingReference: string;
  status: string;
  vehiclePlateNumber: string | null;
  containerNumber: string | null;
  sealNumber: string | null;
  customerName: string | null;
  shipperName: string | null;
  destination: string | null;
  lines: LoadingPlanLine[];
  photoUrls: string[];
  evidence: LoadingEvidence[];
  exceptions: LoadingException[];
  createdAt: string;
  updatedAt: string;
  actualStartAt: string | null;
  completedAt: string | null;
}

export type LoadingEvidenceType =
  | 'LoadingStart'
  | 'SealCheck'
  | 'VehicleInspection'
  | 'Damage'
  | 'FinalDispatch';

export interface LoadingEvidence {
  id: number;
  evidenceType: LoadingEvidenceType;
  fileName: string;
  storedPath: string;
  mimeType: string | null;
  uploadedAt: string;
}

export type LoadingExceptionType =
  | 'MissingPallet'
  | 'DamagedItem'
  | 'UnauthorizedPallet'
  | 'WrongVehicle'
  | 'SealMismatch'
  | 'QuantityOverflow';

export type LoadingExceptionSeverity = 'Low' | 'Medium' | 'High' | 'Critical';

export interface LoadingException {
  id: number;
  loadingPlanId: number;
  exceptionType: LoadingExceptionType;
  description: string | null;
  severity: LoadingExceptionSeverity;
  palletId: number | null;
  loadingPlanLineId: number | null;
  createdAt: string;
}

export interface CreateLoadingException {
  exceptionType: LoadingExceptionType;
  description: string;
  severity: LoadingExceptionSeverity;
  palletId: number | null;
  loadingPlanLineId: number | null;
}

export interface StageProductSelection {
  product: PickedProductSummaryDto;
  selected: boolean;
  quantity: number;
}

export type PickOrderOption = ManualPickingSummaryDto;
