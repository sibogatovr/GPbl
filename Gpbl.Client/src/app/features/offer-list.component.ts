import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';

interface Offer {
  id: number;
  brand: string;
  model: string;
  registrationDate: string;
  supplier: { id: number; name: string };
}

@Component({
  selector: 'app-offer-list',
  standalone: true,
  imports: [CommonModule, NzTableModule],
  template: `
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
  `
})
export class OfferListComponent {
  @Input() offers: Offer[] = [];
} 