import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { 
  LucideAngularModule, 
  Sparkles, 
  Search, 
  Calendar, 
  Tag, 
  Layers, 
  GitCommit, 
  CheckCircle2, 
  Wrench, 
  ArrowLeft,
  Filter
} from 'lucide-angular';
import { ReleaseNoteDto, SystemVersionResponseDto } from '../../api/generated/models';
import { PageHeaderComponent } from '../../shared/layout/page-header/page-header.component';
import { Api } from '../../api/generated/api';
import { getSystemVersion } from '../../api/generated/functions';

export interface ChangeItem {
  type: 'FEATURE' | 'IMPROVEMENT' | 'FIX' | string;
  description: string;
}

export interface ReleaseNote {
  version: string;
  releaseDate: string;
  title: string;
  changes: ChangeItem[];
}

@Component({
  selector: 'app-changelog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    LucideAngularModule,
    PageHeaderComponent
  ],
  templateUrl: './changelog.component.html'
})
export class ChangelogComponent implements OnInit {
  private http = inject(HttpClient);
  private api = inject(Api);
  private cd = inject(ChangeDetectorRef);

  readonly sparklesIcon = Sparkles;
  readonly searchIcon = Search;
  readonly calendarIcon = Calendar;
  readonly tagIcon = Tag;
  readonly layersIcon = Layers;
  readonly commitIcon = GitCommit;
  readonly checkIcon = CheckCircle2;
  readonly wrenchIcon = Wrench;
  readonly backIcon = ArrowLeft;
  readonly filterIcon = Filter;

  isLoading = true;
  error = '';
  search = '';
  selectedType = 'ALL';

  currentVersion = '1.7.0';
  releaseNotes: ReleaseNoteDto[] = [];

  // Summary Metrics
  totalReleases = 0;
  totalFeatures = 0;
  totalImprovements = 0;
  totalFixes = 0;

  ngOnInit(): void {
    this.fetchVersionAndChangelog();
  }

async fetchVersionAndChangelog(): Promise<void> {
    this.isLoading = true;
    this.error = '';
    this.cd.markForCheck();

    try {
      const response = await this.api.invoke(getSystemVersion) as SystemVersionResponseDto;
      this.currentVersion = response.currentVersion ?? 'Unknown';
      this.releaseNotes = response.releaseNotes ?? [];
      this.calculateMetrics();
    } catch (err) {
      this.error = 'Unable to load system changelog history.';
      console.error('Failed to load changelog data:', err);
    } finally {
      this.isLoading = false;
      this.cd.markForCheck();
    }
  }

  private calculateMetrics(): void {
    this.totalReleases = this.releaseNotes.length;
    this.totalFeatures = 0;
    this.totalImprovements = 0;
    this.totalFixes = 0;

    for (const note of this.releaseNotes) {
      for (const change of note.changes ?? []) {
        const type = change.type?.toUpperCase();
        if (type === 'FEATURE') this.totalFeatures++;
        else if (type === 'IMPROVEMENT') this.totalImprovements++;
        else if (type === 'FIX') this.totalFixes++;
      }
    }
  }

  get filteredReleaseNotes(): ReleaseNoteDto[] {
    const query = this.search.trim().toLowerCase();

    return this.releaseNotes
      .map(note => {
        const matchingChanges = note.changes?.filter(change => {
          const matchesType = this.selectedType === 'ALL' || change.type?.toUpperCase() === this.selectedType;
          const matchesSearch = !query || 
            change.description?.toLowerCase().includes(query) ||
            note.version?.toLowerCase().includes(query) ||
            note.title?.toLowerCase().includes(query);

          return matchesType && matchesSearch;
        });

        return { ...note, changes: matchingChanges };
      })
      .filter(note => note.changes?.length! > 0 || (!query && this.selectedType === 'ALL'));
  }

  getBadgeClass(type: string): string {
    switch (type?.toUpperCase()) {
      case 'FEATURE':
        return 'bg-blue-50 text-blue-700 border-blue-200';
      case 'IMPROVEMENT':
        return 'bg-purple-50 text-purple-700 border-purple-200';
      case 'FIX':
        return 'bg-amber-50 text-amber-700 border-amber-200';
      default:
        return 'bg-slate-100 text-slate-700 border-slate-200';
    }
  }
}