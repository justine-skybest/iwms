import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Api } from '../../api/generated/api';
import { ApiConfiguration } from '../../api/generated/api-configuration';
import {
  ManualPickingSummaryDtoPaginatedResponse,
} from '../../api/generated/models';
import {
  dispatchLoadingPlan,
  createLoadingPlanException,
  createOutboundLoadingPlan,
  outboundLoadingPlansGet,
  outboundLoadingPlansIdGet,
  outboundStagesGet,
  outboundStagesIdGet,
  outboundStagesPost,
  startLoadingPlan,
  updateLoadingPlanLineQuantities,
  updateOutboundStageLineQuantities,
  uploadLoadingPlanPhoto,
  uploadLoadingPlanEvidence,
} from '../../api/generated/functions';
import {
  CreateLoadingPlan,
  CreateLoadingException,
  CreateOutboundStage,
  LoadingEvidence,
  LoadingEvidenceType,
  LoadingException,
  LoadingPlan,
  ManualPickingDetails,
  OutboundStage,
  UpdateOutboundStageQuantities,
} from './outbound-workflow.models';
import { WarehouseService } from '../../lib/services/warehouse.service';

@Injectable({ providedIn: 'root' })
export class OutboundWorkflowService {
  private readonly http = inject(HttpClient);
  private readonly api = inject(Api);
  private readonly apiConfiguration = inject(ApiConfiguration);
  private readonly apiUrl = this.apiConfiguration.rootUrl.replace(/\/+$/, '');
  private readonly warehouseService = inject(WarehouseService);

  async getPickOrders(): Promise<ManualPickingSummaryDtoPaginatedResponse> {
    return firstValueFrom(
      this.http.get<ManualPickingSummaryDtoPaginatedResponse>(
        `${this.apiUrl}/manualpicking/v2`,
        { params: { page: 1, pageSize: 100, WarehouseId: Number(this.warehouseService.selectedWarehouseId)! } },
      ),
    );
  }

  async getPickOrderDetails(id: number): Promise<ManualPickingDetails> {
    return firstValueFrom(
      this.http.get<ManualPickingDetails>(`${this.apiUrl}/manualpicking/${id}`),
    );
  }

  async getStages(): Promise<OutboundStage[]> {
    return await this.api.invoke(outboundStagesGet, {}) as OutboundStage[];
  }

  async getStage(id: number): Promise<OutboundStage> {
    return await this.api.invoke(outboundStagesIdGet, { id }) as OutboundStage;
  }

  async createStage(stage: CreateOutboundStage): Promise<OutboundStage> {
    return await this.api.invoke(outboundStagesPost, { body: stage }) as OutboundStage;
  }

  async updateStagedQuantities(
    id: number,
    lines: UpdateOutboundStageQuantities['lines'],
  ): Promise<OutboundStage> {
    return await this.api.invoke(updateOutboundStageLineQuantities, { id, body: { lines } }) as OutboundStage;
  }

  async getLoadingPlans(): Promise<LoadingPlan[]> {
    return await this.api.invoke(outboundLoadingPlansGet, {}) as LoadingPlan[];
  }

  async getLoadingPlan(id: number): Promise<LoadingPlan> {
    return await this.api.invoke(outboundLoadingPlansIdGet, { id }) as LoadingPlan;
  }

  async createLoadingPlan(plan: CreateLoadingPlan): Promise<LoadingPlan> {
    return await this.api.invoke(createOutboundLoadingPlan, { body: plan }) as LoadingPlan;
  }

  async uploadLoadingPlanPhoto(id: number, file: File): Promise<string> {
    return await this.api.invoke(uploadLoadingPlanPhoto, { id, body: { file } });
  }

  async uploadLoadingPlanEvidence(
    id: number,
    file: File,
    evidenceType: LoadingEvidenceType,
  ): Promise<LoadingEvidence> {
    return await this.api.invoke(uploadLoadingPlanEvidence, {
      id,
      body: { file, evidenceType },
    }) as LoadingEvidence;
  }

  async createLoadingException(
    id: number,
    exception: CreateLoadingException,
  ): Promise<LoadingException> {
    return await this.api.invoke(createLoadingPlanException, {
      id,
      body: exception,
    }) as LoadingException;
  }

  async startLoadingPlan(id: number): Promise<LoadingPlan> {
    return await this.api.invoke(startLoadingPlan, { id }) as LoadingPlan;
  }

  async updateLoadedQuantities(
    id: number,
    lines: { loadingPlanLineId: number; quantityLoaded: number }[],
  ): Promise<LoadingPlan> {
    return await this.api.invoke(updateLoadingPlanLineQuantities, { id, body: { lines } }) as LoadingPlan;
  }

  async dispatchLoadingPlan(id: number): Promise<LoadingPlan> {
    return await this.api.invoke(dispatchLoadingPlan, { id }) as LoadingPlan;
  }

  static errorMessage(error: unknown): string {
    if (error instanceof HttpErrorResponse) {
      const body = error.error;
      if (typeof body === 'string' && body.trim()) {
        try {
          const parsed = JSON.parse(body) as { message?: string; title?: string };
          return parsed.message ?? parsed.title ?? body;
        } catch {
          return body;
        }
      }
      if (body && typeof body === 'object') {
        const message = (body as { message?: string; title?: string }).message
          ?? (body as { title?: string }).title;
        if (message) return message;
      }
      return error.message || 'The request failed. Please try again.';
    }

    return error instanceof Error
      ? error.message
      : 'An unexpected error occurred. Please try again.';
  }
}
