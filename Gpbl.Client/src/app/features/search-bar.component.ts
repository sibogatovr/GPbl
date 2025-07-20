import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface SupplierOption {
  id: number;
  name: string;
}

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [
    CommonModule,
    NzInputModule,
    NzButtonModule,
    NzIconModule,
    NzSelectModule,
    FormsModule
  ],
  template: `
    <form (ngSubmit)="onSearch()" style="display: flex; gap: 12px; flex-wrap: wrap; align-items: center;">
      <input
        nz-input
        placeholder="Марка"
        [(ngModel)]="brand"
        name="brand"
        style="width: 160px;"
      />
      <input
        nz-input
        placeholder="Модель"
        [(ngModel)]="model"
        name="model"
        style="width: 160px;"
      />
      <nz-select
        style="width: 180px;"
        placeholder="Поставщик"
        [(ngModel)]="supplierId"
        name="supplierId"
        nzAllowClear
      >
        <nz-option *ngFor="let s of suppliers" [nzValue]="s.id" [nzLabel]="s.name"></nz-option>
      </nz-select>
      <button nz-button nzType="primary" type="submit" style="min-width: 100px; display: flex; align-items: center; gap: 4px;">
        <span nz-icon nzType="search"></span>
        Поиск
      </button>
    </form>
  `
})
export class SearchBarComponent implements OnInit {
  brand: string = '';
  model: string = '';
  supplierId: number | null = null;
  suppliers: SupplierOption[] = [];

  @Output() search = new EventEmitter<{ brand: string; model: string; supplierId: number | null }>();

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any[]>('/api/supplier').subscribe({
      next: data => {
        this.suppliers = data.map(x => ({ id: x.id, name: x.name }));
      }
    });
  }

  onSearch() {
    this.search.emit({
      brand: this.brand,
      model: this.model,
      supplierId: this.supplierId
    });
  }
}
