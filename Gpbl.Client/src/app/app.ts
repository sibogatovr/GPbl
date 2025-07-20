import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PopularSuppliersComponent } from './features/popular-suppliers.component';
import { SearchBarComponent } from './features/search-bar.component';
import { OfferListComponent } from './features/offer-list.component';
import { HttpClient } from '@angular/common/http';
import { AllOffersComponent } from './features/all-offers.component';
import { NzTabsModule } from 'ng-zorro-antd/tabs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, PopularSuppliersComponent, SearchBarComponent, OfferListComponent, AllOffersComponent, NzTabsModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Gpbl.Client');
  offers: any[] = [];
  totalCount: number = 0;
  loading = false;
  selectedTabIndex = 0;

  constructor(private http: HttpClient) {}

  onSearch({ brand, model, supplierId }: { brand: string; model: string; supplierId: number | null }) {
    this.loading = true;
    this.selectedTabIndex = 0;
    const params: any = {};
    if (brand) params.brand = brand;
    if (model) params.model = model;
    if (supplierId) params.supplierId = supplierId;

    this.http.get<any>('/api/offer', { params }).subscribe({
      next: (data) => {
        this.offers = data.offers;
        this.totalCount = data.totalCount;
        this.loading = false;
      },
      error: () => {
        this.offers = [];
        this.totalCount = 0;
        this.loading = false;
      }
    });
  }
}
