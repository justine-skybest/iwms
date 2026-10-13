import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BinSummaryDto, RackGroupDto } from '../../api/generated/models';
import { getBinsGroupedByRack } from '../../api/generated/functions';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';
import { CommonModule } from '@angular/common';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';

export interface UiBin extends BinSummaryDto {
  qrCodeUrl: string;
}

export interface UiLevelGroup {
  levelNumber: string;
  bins: UiBin[];
}

export interface UiRackGroup {
  rackId: number | null;
  rackName: string;
  warehouseName: string;
  isStandalone: boolean;
  levels: UiLevelGroup[];
}

@Component({
  selector: 'app-bins',
  standalone: true,
  imports: [CommonModule, PageHeaderComponent],
  templateUrl: './bins.component.html',
})
export class BinsComponent implements OnInit {
  rackGroups: UiRackGroup[] = [];
  isLoading = true;
  apiRootUrl = '';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadRackBins();
  }

  get totalBinsCount(): number {
    return this.rackGroups.reduce(
      (total, rack) => total + rack.levels.reduce((sub, lvl) => sub + lvl.bins.length, 0),
      0
    );
  }

  loadRackBins(): void {
    this.isLoading = true;
    getBinsGroupedByRack(this.http, this.apiRootUrl).subscribe({
      next: async (response) => {
        const data = response.body ?? [];
        this.rackGroups = await this.transformRackGroups(data);
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to load bins for directory booklet:', err);
        this.isLoading = false;
      },
    });
  }

  private async transformRackGroups(groups: RackGroupDto[]): Promise<UiRackGroup[]> {
    const formattedGroups: UiRackGroup[] = [];

    for (const group of groups) {
      const rawBins = group.bins ?? [];

      const enrichedBins: UiBin[] = await Promise.all(
        rawBins.map(async (bin) => ({
          ...bin,
          qrCodeUrl: await generateQrCodeDataUrl(bin.binHashCode ?? bin.binName, 140),
        }))
      );

      const levelMap = new Map<string, UiBin[]>();
      for (const bin of enrichedBins) {
        const levelKey = bin.level?.trim() ? bin.level : 'Unassigned';
        if (!levelMap.has(levelKey)) {
          levelMap.set(levelKey, []);
        }
        levelMap.get(levelKey)!.push(bin);
      }

      const levels: UiLevelGroup[] = Array.from(levelMap.entries())
        .map(([levelNumber, bins]) => ({
          levelNumber,
          bins,
        }))
        .sort((a, b) => a.levelNumber.localeCompare(b.levelNumber, undefined, { numeric: true }));

      const isStandalone = !group.rackId || group.rackName === 'Standalone';

      formattedGroups.push({
        rackId: group.rackId ?? null,
        rackName: group.rackName ?? (isStandalone ? 'Standalone Bins' : 'Unknown Rack'),
        warehouseName: group.warehouseName ?? 'Main Warehouse',
        isStandalone,
        levels,
      });
    }

    return formattedGroups;
  }

  printBooklet(): void {
    window.print();
  }
}