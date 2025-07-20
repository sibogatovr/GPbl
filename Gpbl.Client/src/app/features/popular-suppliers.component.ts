import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { HttpClient } from '@angular/common/http';

interface PopularSupplier {
  id: number;
  name: string;
  offersCount: number;
}

@Component({
  selector: 'app-popular-suppliers',
  standalone: true,
  imports: [CommonModule, NzListModule, NzSpinModule],
  template: `
    <nz-spin [nzSpinning]="loading">
      <nz-list
        nzHeader="Популярные поставщики"
        [nzDataSource]="suppliers"
        [nzRenderItem]="item"
        [nzBordered]="true"
      >
        <ng-template #item let-supplier>
          <nz-list-item>
            <span>{{ supplier.name }}</span>
            <span style="float:right;">Офферов: {{ supplier.offersCount }}</span>
          </nz-list-item>
        </ng-template>
      </nz-list>
    </nz-spin>
  `
})
export class PopularSuppliersComponent implements OnInit {
  suppliers: PopularSupplier[] = [];
  loading = true;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<PopularSupplier[]>('/api/supplier/popular')
      .subscribe({
        next: data => {
          this.suppliers = data;
          this.loading = false;
        },
        error: () => this.loading = false
      });
  }
}
