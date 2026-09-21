import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { RequestCacheService } from './request-cache.service';
import { environment } from '../config/app-env';
import { SignalREvent } from '../../api/signalr-events/signalr-events.enum';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection!: HubConnection;

  public receivingUpdated$ = new Subject<void>();
  public inventoryUpdated$ = new Subject<void>();
  public palletUpdated$ = new Subject<void>();

  constructor(private cacheService: RequestCacheService) {
    this.initConnection();
  }

  private initConnection(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.signalrHubUrl, {
        withCredentials: true
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connected.'))
      .catch(err => console.error('SignalR connection error:', err));

    this.hubConnection.on(SignalREvent.ReceivingCreated, () => this.handleEvent(this.receivingUpdated$));
    this.hubConnection.on(SignalREvent.ReceivingUpdated, () => this.handleEvent(this.receivingUpdated$));
    this.hubConnection.on(SignalREvent.ReceivingDeleted, () => this.handleEvent(this.receivingUpdated$));

    this.hubConnection.on(SignalREvent.InventoryUpdated, () => this.handleEvent(this.inventoryUpdated$));
    this.hubConnection.on(SignalREvent.PalletUpdated, () => this.handleEvent(this.palletUpdated$));
  }

  private handleEvent(subject$: Subject<void>): void {
    this.cacheService.clear();
    subject$.next();
  }
}