import {
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  Input,
  Output,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subject, from } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { IconComponent } from '../icon/icon.component';

export interface SelectOption<T = unknown> {
  id: number;
  label: string;
  sublabel?: string | null;
  raw: T;
}

@Component({
  selector: 'app-searchable-select',
  standalone: true,
  imports: [CommonModule, FormsModule, IconComponent],
  templateUrl: './searchable-select.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchableSelectComponent<T = unknown> {
  @Input() label = '';
  @Input() placeholder = 'Search...';
  @Input() multiple = false;
  @Input() disabled = false;
  /** Minimum characters before triggering a search. 0 = search on focus too. */
  @Input() minChars = 0;

  @Input()
  set selected(value: SelectOption<T>[] | null | undefined) {
    this._selected = value ?? [];
  }
  get selected(): SelectOption<T>[] {
    return this._selected;
  }

  @Input() searchFn!: (term: string) => Promise<SelectOption<T>[]>;

  @Output() selectedChange = new EventEmitter<SelectOption<T>[]>();

  @ViewChild('searchInput') searchInput?: ElementRef<HTMLInputElement>;

  private _selected: SelectOption<T>[] = [];

  query = '';
  isOpen = false;
  isLoading = false;
  options: SelectOption<T>[] = [];

  private query$ = new Subject<string>();
  private searchToken = 0;

  constructor(private elementRef: ElementRef<HTMLElement>, private cd: ChangeDetectorRef) {
    this.query$
      .pipe(
        debounceTime(250),
        distinctUntilChanged(),
        switchMap((term) => {
          this.isLoading = true;
          this.cd.markForCheck();
          const token = ++this.searchToken;
          return from(this.runSearch(term, token));
        })
      )
      .subscribe((result) => {
        if (result.token !== this.searchToken) {
          return;
        }
        this.options = result.options;
        this.isLoading = false;
        this.cd.markForCheck();
      });
  }

  private async runSearch(term: string, token: number): Promise<{ options: SelectOption<T>[]; token: number }> {
    try {
      const options = await this.searchFn(term);
      return { options, token };
    } catch (err) {
      console.error('Searchable select: search failed', err);
      return { options: [], token };
    }
  }

  openDropdown(event?: Event): void {
    if (this.disabled) {
      return;
    }

    // Ignore container clicks if clicking actionable inner buttons (like 'x' clear)
    if (event) {
      const target = event.target as HTMLElement;
      if (target.closest('button')) {
        return;
      }
    }

    this.isOpen = true;
    this.cd.markForCheck();

    // Focus input on next tick once *ngIf renders it
    setTimeout(() => {
      this.searchInput?.nativeElement.focus();
    });

    if (this.query.length >= this.minChars) {
      this.query$.next(this.query);
    }
  }

  onFocus(): void {
    if (this.disabled) {
      return;
    }
    this.isOpen = true;
    if (this.query.length >= this.minChars) {
      this.query$.next(this.query);
    }
  }

  onQueryChange(value: string): void {
    this.query = value;
    if (value.length >= this.minChars) {
      this.query$.next(value);
    } else {
      this.options = [];
    }
  }

  isSelected(option: SelectOption<T>): boolean {
    return this._selected.some((s) => s.id === option.id);
  }

  toggleOption(option: SelectOption<T>): void {
    if (this.multiple) {
      const next = this.isSelected(option)
        ? this._selected.filter((s) => s.id !== option.id)
        : [...this._selected, option];
      this._selected = next;
      this.selectedChange.emit(next);
    } else {
      this._selected = [option];
      this.selectedChange.emit(this._selected);
      this.query = '';
      this.isOpen = false;
    }
  }

  removeSelected(option: SelectOption<T>, event: Event): void {
    event.stopPropagation();
    const next = this._selected.filter((s) => s.id !== option.id);
    this._selected = next;
    this.selectedChange.emit(next);
  }

  clearSingle(event: Event): void {
    event.stopPropagation();
    this._selected = [];
    this.query = '';
    this.selectedChange.emit([]);
    this.openDropdown();
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent): void {
    if (!this.elementRef.nativeElement.contains(event.target as Node)) {
      this.isOpen = false;
      this.cd.markForCheck();
    }
  }
}