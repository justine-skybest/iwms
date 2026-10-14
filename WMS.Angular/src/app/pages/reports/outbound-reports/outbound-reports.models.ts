// export type OutboundReportType =
//   | 'manifest'
//   | 'turnaround'
//   | 'staging'
//   | 'verifications'
//   | 'exceptions'
//   | 'compliance'
//   | 'cancellations'
//   | 'workforce';

// export interface DispatchManifestItem {
//   loadingPlanId: number;
//   loadingReference: string;
//   warehouseName: string;
//   status: string;
//   customerName?: string;
//   destination?: string;
//   transport: {
//     vehiclePlateNumber?: string;
//     containerNumber?: string;
//     sealNumber?: string;
//   };
//   timestamps: {
//     actualStartAt?: string;
//     completedAt?: string;
//     durationMinutes?: number;
//   };
//   totalQuantityPlanned: number;
//   totalQuantityLoaded: number;
//   fulfillmentRatePercentage: number;
//   lines: Array<{
//     lineId: number;
//     productName: string;
//     productSku: string;
//     quantityPlanned: number;
//     quantityLoaded: number;
//     status: string;
//   }>;
// }

// export interface DockTurnaroundItem {
//   id: number;
//   loadingReference: string;
//   vehiclePlateNumber?: string;
//   containerNumber?: string;
//   scheduledDate?: string;
//   plannedStartAt?: string;
//   actualStartAt?: string;
//   completedAt?: string;
//   startDelayMinutes?: number;
//   netTurnaroundMinutes: number;
//   totalUnitsLoaded: number;
//   totalPalletsCount: number;
//   unitsPerHour: number;
// }

// export interface StagingVelocityItem {
//   stageId: number;
//   stageReference: string;
//   manualPickingId: number;
//   status: string;
//   stagingDurationMinutes?: number;
//   totalRequested: number;
//   totalStaged: number;
//   stagingAccuracyRate: number;
//   lineCount: number;
// }

// export interface LoadingExceptionItem {
//   exceptionId: number;
//   loadingPlanId: number;
//   loadingReference: string;
//   exceptionType: string;
//   severity: 'Low' | 'Medium' | 'High' | 'Critical';
//   description: string;
//   palletId?: number;
//   affectedProduct: string;
//   createdAt: string;
// }

// export interface PalletVerificationReport {
//   totalScans: number;
//   authorizedCount: number;
//   discrepancyCount: number;
//   errorRatePercentage: number;
//   verifications: Array<{
//     id: number;
//     loadingPlanId: number;
//     loadingReference: string;
//     palletId: number;
//     scanResult: string;
//     scanTime: string;
//     isDiscrepancy: boolean;
//     remarks?: string;
//   }>;
// }

// export interface EvidenceComplianceReport {
//   totalCompletedPlans: number;
//   compliantCount: number;
//   nonCompliantCount: number;
//   complianceRate: number;
//   plans: Array<{
//     id: number;
//     loadingReference: string;
//     vehiclePlateNumber?: string;
//     sealNumber?: string;
//     completedAt?: string;
//     hasVehicleInspection: boolean;
//     hasLoadingStart: boolean;
//     hasSealCheck: boolean;
//     hasFinalDispatch: boolean;
//     isAuditCompliant: boolean;
//   }>;
// }