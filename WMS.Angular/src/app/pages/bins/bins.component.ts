import { Component, OnInit, ChangeDetectorRef, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { BinSummaryDto, RackGroupDto } from '../../api/generated/models';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { Api } from '../../api/generated/api';
import { getBinsGroupedByRack, GetBinsGroupedByRack$Params } from '../../api/generated/functions';
import { generateQrCodeDataUrl } from '../../lib/utils/qr-code.util';

export interface LevelColorTheme {
  bg: string;
  border: string;
  qrBorder: string;
  hashText: string;
  binHighlight: string;
}

export interface UiBin extends BinSummaryDto {
  qrCodeUrl: string;
}

export interface UiLevelGroup {
  levelNumber: string;
  theme: LevelColorTheme;
  bins: UiBin[];
}

export interface UiRackGroup {
  rackId: number | null;
  rackName: string;
  warehouseName: string;
  isStandalone: boolean;
  levels: UiLevelGroup[];
}

// Dedicated theme for Standalone / Unassigned / N/A levels
const NA_LEVEL_THEME: LevelColorTheme = {
  bg: 'bg-slate-300',
  border: 'border-slate-400',
  qrBorder: 'border-slate-400/40',
  hashText: 'text-slate-900',
  binHighlight: 'bg-slate-300',
};

// Global level-to-color mapping: Level 1 = Index 0, Level 2 = Index 1, etc.
const GLOBAL_LEVEL_THEMES: LevelColorTheme[] = [
  { // Level 1 -> Classic Yellow
    bg: 'bg-yellow-400',
    border: 'border-yellow-500',
    qrBorder: 'border-yellow-500/30',
    hashText: 'text-yellow-950',
    binHighlight: 'bg-yellow-400',
  },
  { // Level 2 -> Emerald Green
    bg: 'bg-emerald-400',
    border: 'border-emerald-500',
    qrBorder: 'border-emerald-500/30',
    hashText: 'text-emerald-950',
    binHighlight: 'bg-emerald-400',
  },
  { // Level 3 -> Sky Blue
    bg: 'bg-sky-400',
    border: 'border-sky-500',
    qrBorder: 'border-sky-500/30',
    hashText: 'text-sky-950',
    binHighlight: 'bg-sky-400',
  },
  { // Level 4 -> Vivid Orange
    bg: 'bg-orange-400',
    border: 'border-orange-500',
    qrBorder: 'border-orange-500/30',
    hashText: 'text-orange-950',
    binHighlight: 'bg-orange-400',
  },
  { // Level 5 -> Purple
    bg: 'bg-purple-400',
    border: 'border-purple-500',
    qrBorder: 'border-purple-500/30',
    hashText: 'text-purple-950',
    binHighlight: 'bg-purple-400',
  },
  { // Level 6 -> Rose Pink
    bg: 'bg-rose-400',
    border: 'border-rose-500',
    qrBorder: 'border-rose-500/30',
    hashText: 'text-rose-950',
    binHighlight: 'bg-rose-400',
  },
  { // Level 7 -> Teal
    bg: 'bg-teal-400',
    border: 'border-teal-500',
    qrBorder: 'border-teal-500/30',
    hashText: 'text-teal-950',
    binHighlight: 'bg-teal-400',
  },
];

@Component({
  selector: 'app-bins',
  standalone: true,
  imports: [CommonModule, PageHeaderComponent],
  templateUrl: './bins.component.html',
  styleUrls: ['./bins.component.scss'],
})
export class BinsComponent implements OnInit {
  rackGroups: UiRackGroup[] = [];
  isLoading = true;
  isGeneratingQrs = false;
  qrProgress = { completed: 0, total: 0 };
  errorMessage: string | null = null;

  constructor(
    private api: Api,
    private cdr: ChangeDetectorRef,
    @Inject(PLATFORM_ID) private platformId: object
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      this.loadRackBins();
    }
  }

  get totalBinsCount(): number {
    return this.rackGroups.reduce(
      (total, rack) => total + rack.levels.reduce((sub, lvl) => sub + lvl.bins.length, 0),
      0
    );
  }

  async loadRackBins(): Promise<void> {
    this.isLoading = true;
    this.errorMessage = null;
    this.cdr.markForCheck();

    try {
      const params: GetBinsGroupedByRack$Params = {};
      const fetchPromise = this.api.invoke(getBinsGroupedByRack, params);
      const timeoutPromise = new Promise((_, reject) =>
        setTimeout(() => reject(new Error('Network request timed out. Please check your connection or session.')), 15000)
      );

      const response: any = await Promise.race([fetchPromise, timeoutPromise]);

      const data: RackGroupDto[] = Array.isArray(response)
        ? response
        : Array.isArray(response?.body)
          ? response.body
          : [];

      const allBins: UiBin[] = [];
      this.rackGroups = this.buildRackGroups(data, allBins);
      this.isLoading = false;
      this.cdr.detectChanges();

      await this.generateQrsInBatches(allBins);
    } catch (err: any) {
      console.error('Failed to load bins for directory booklet:', err);
      this.errorMessage = err?.message || 'Failed to load warehouse directory.';
      this.isLoading = false;
      this.cdr.detectChanges();
    }
  }

  private buildRackGroups(groups: RackGroupDto[], collector: UiBin[]): UiRackGroup[] {
    const formattedGroups: UiRackGroup[] = [];

    for (const group of groups) {
      const rawBins = group.bins ?? [];
      const uiBins: UiBin[] = rawBins.map((bin) => ({
        ...bin,
        qrCodeUrl: '',
      }));

      collector.push(...uiBins);

      const levelMap = new Map<string, UiBin[]>();
      for (const bin of uiBins) {
        const levelKey = bin.level?.trim() ? bin.level : '1';
        if (!levelMap.has(levelKey)) {
          levelMap.set(levelKey, []);
        }
        levelMap.get(levelKey)!.push(bin);
      }

      const levels: UiLevelGroup[] = Array.from(levelMap.entries())
        .map(([levelNumber, bins]) => ({
          levelNumber,
          theme: this.resolveLevelTheme(levelNumber),
          bins,
        }))
        .sort((a, b) => a.levelNumber.localeCompare(b.levelNumber, undefined, { numeric: true }));

      const isStandalone = !group.rackId || group.rackName === 'Standalone';

      formattedGroups.push({
        rackId: group.rackId ?? null,
        rackName: group.rackName ?? (isStandalone ? 'Standalone Bins' : 'Unknown Rack'),
        warehouseName: group.warehouseName ?? 'Warehouse',
        isStandalone,
        levels,
      });
    }

    return formattedGroups;
  }
/**
   * Deterministically maps level values across all racks:
   * - "Level 1", "1", "Lvl 1" -> Yellow across ALL racks
   * - "Level 2", "2", "Lvl 2" -> Emerald Green across ALL racks
   * - "Level 3", "3", "Lvl 3" -> Sky Blue across ALL racks
   * - "Level 4", "4", "Lvl 4" -> Orange across ALL racks
   * - "N/A", "Unassigned", or empty -> Slate Gray across ALL racks
   */
  private resolveLevelTheme(levelStr: string): LevelColorTheme {
    const normalized = (levelStr || '').trim().toUpperCase();

    if (!normalized || normalized === 'N/A' || normalized === 'UNASSIGNED') {
      return NA_LEVEL_THEME;
    }

    const numericMatch = normalized.match(/\d+/);
    if (numericMatch) {
      const levelNum = parseInt(numericMatch[0], 10);
      const index = (levelNum - 1) % GLOBAL_LEVEL_THEMES.length;
      return GLOBAL_LEVEL_THEMES[index >= 0 ? index : 0];
    }

    // Stable hash fallback for named non-numeric levels (e.g., "MEZZANINE", "GROUND")
    let hash = 0;
    for (let i = 0; i < normalized.length; i++) {
      hash = normalized.charCodeAt(i) + ((hash << 5) - hash);
    }
    const index = Math.abs(hash) % GLOBAL_LEVEL_THEMES.length;
    return GLOBAL_LEVEL_THEMES[index];
  }

  private async generateQrsInBatches(bins: UiBin[], batchSize = 12): Promise<void> {
    if (bins.length === 0) return;

    this.isGeneratingQrs = true;
    this.qrProgress = { completed: 0, total: bins.length };

    for (let i = 0; i < bins.length; i += batchSize) {
      const batch = bins.slice(i, i + batchSize);

      await Promise.all(
        batch.map(async (bin) => {
          const qrTarget = bin.binHashCode || bin.binName || String(bin.id ?? '');
          bin.qrCodeUrl = await generateQrCodeDataUrl(qrTarget, 100);
        })
      );

      this.qrProgress.completed = Math.min(i + batchSize, bins.length);
      this.cdr.detectChanges();
      await new Promise((resolve) => setTimeout(resolve, 10));
    }

    this.isGeneratingQrs = false;
    this.cdr.detectChanges();
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
      .map((word) => word[0]?.toUpperCase() ?? '')
      .join('');
  }

  printBooklet(): void {
    window.print();
  }
}