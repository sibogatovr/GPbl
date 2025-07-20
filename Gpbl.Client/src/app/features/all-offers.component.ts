import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';
import { HttpClient } from '@angular/common/http';

interface Offer {
  id: number;
  brand: string;
  model: string;
  registrationDate: string;
  supplier: { id: number; name: string };
}

@Component({
  selector: 'app-all-offers',
  standalone: true,
  imports: [CommonModule, NzTableModule],
  template: `
    <h3 style="margin-bottom: 16px;">Все офферы</h3>
    <nz-table
      [nzData]="offers"
      [nzFrontPagination]="false"
      *ngIf="offers.length > 0"
      nzBordered
    >
      <thead>
        <tr>
          <th>Марка</th>
          <th>Модель</th>
          <th>Поставщик</th>
          <th>Дата регистрации</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let offer of offers">
          <td>{{ offer.brand }}</td>
          <td>{{ offer.model }}</td>
          <td>{{ offer.supplier.name }}</td>
          <td>{{ offer.registrationDate | date: 'shortDate' }}</td>
        </tr>
      </tbody>
    </nz-table>
    <div *ngIf="offers.length === 0" style="margin-top: 16px;">Нет данных</div>
    <div *ngIf="offers.length > 0" style="margin-top: 8px;">Всего записей: {{ offers.length }}</div>
  `
})
export class AllOffersComponent implements OnInit {
  offers: Offer[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any>('/api/offer').subscribe({
      next: (data) => {
        this.offers = data.offers || [];
      },
      error: () => {
        this.offers = [];
      }
    });
  }
} 