import { Component, EventEmitter, Input, Output, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Html5Qrcode } from 'html5-qrcode';
import { LucideAngularModule, Camera } from 'lucide-angular';

@Component({
  selector: 'app-qr-scanner',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  template: `
    <!-- Trigger Button -->
    <button 
      (click)="openScannerDialog()" 
      type="button" 
      class="flex items-center gap-1.5 px-3 py-1.5 bg-blue-600 text-white text-xs font-semibold rounded-lg hover:bg-blue-700 transition-colors"
    >
      <lucide-icon [img]="CameraIcon" [size]="14"></lucide-icon>
      {{ buttonText }}
    </button>

    <!-- SCANNER MODAL DIALOG OVERLAY -->
    <div *ngIf="isCameraActive" class="fixed inset-0 z-50 flex items-center justify-center bg-slate-900/70 backdrop-blur-sm p-4">
      <div class="w-full max-w-md bg-slate-900 rounded-2xl shadow-2xl border border-slate-800 overflow-hidden flex flex-col">
        <!-- Dialog Header -->
        <div class="p-4 border-b border-slate-800 flex items-center justify-between text-white">
          <div class="flex items-center gap-2">
            <lucide-icon [img]="CameraIcon" [size]="16" class="text-blue-400"></lucide-icon>
            <h3 class="text-sm font-bold m-0">{{ modalTitle }}</h3>
          </div>
          <button (click)="closeScannerDialog()" type="button" class="p-1 rounded-lg text-slate-400 hover:text-white hover:bg-slate-800">
            ✕
          </button>
        </div>

        <!-- Dialog Body / Camera Viewfinder -->
        <div class="p-4 flex flex-col items-center justify-center space-y-3">
          <p class="text-xs text-slate-400 text-center">Center the QR code inside the viewfinder</p>
          
          <div class="w-full rounded-xl overflow-hidden bg-black border border-slate-800 relative min-h-[260px]">
            <div [id]="scannerContainerId" class="w-full"></div>
          </div>

          <!-- Error Alert -->
          <div *ngIf="errorMessage" class="text-xs text-red-400 font-medium text-center bg-red-950/50 p-2.5 rounded-lg border border-red-800/50 w-full">
            {{ errorMessage }}
          </div>
        </div>

        <!-- Dialog Footer -->
        <div class="p-3 bg-slate-950/50 border-t border-slate-800 flex justify-end">
          <button 
            (click)="closeScannerDialog()" 
            type="button" 
            class="px-4 py-2 bg-slate-800 text-slate-300 hover:text-white text-xs font-semibold rounded-lg transition-colors"
          >
            Cancel
          </button>
        </div>
      </div>
    </div>
  `
})
export class QrScannerComponent implements OnDestroy {
  readonly CameraIcon = Camera;

  @Input() buttonText = 'Scan with Camera';
  @Input() modalTitle = 'Scan QR Code';
  @Input() qrboxSize = 230;
  @Input() fps = 10;

  @Output() scanSuccess = new EventEmitter<string>();
  @Output() scanError = new EventEmitter<string>();

  public scannerContainerId = `qr-reader-${Math.random().toString(36).substring(2, 9)}`;
  private scannerInstance: Html5Qrcode | null = null;
  public isCameraActive = false;
  public errorMessage = '';

  ngOnDestroy(): void {
    void this.stopScan();
  }

  async openScannerDialog(): Promise<void> {
    this.errorMessage = '';
    this.isCameraActive = true;

    setTimeout(async () => {
      try {
        this.scannerInstance = new Html5Qrcode(this.scannerContainerId);
        await this.scannerInstance.start(
          { facingMode: 'environment' },
          { fps: this.fps, qrbox: { width: this.qrboxSize, height: this.qrboxSize } },
          (decodedText: string) => {
            this.scanSuccess.emit(decodedText);
            void this.closeScannerDialog();
          },
          (error: string) => {
            this.scanError.emit(error);
          }
        );
      } catch (err) {
        console.error('Camera initialization error:', err);
        this.errorMessage = 'Camera access denied or secure connection (HTTPS) required.';
      }
    }, 150);
  }

  async closeScannerDialog(): Promise<void> {
    await this.stopScan();
  }

  private async stopScan(): Promise<void> {
    if (this.scannerInstance && this.isCameraActive) {
      try {
        await this.scannerInstance.stop();
        this.scannerInstance.clear();
      } catch (err) {
        console.warn('Scanner cleanup warning:', err);
      } finally {
        this.scannerInstance = null;
        this.isCameraActive = false;
      }
    } else {
      this.isCameraActive = false;
    }
  }
}