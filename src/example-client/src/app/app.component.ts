import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Table, TableModule } from 'primeng/table';
import {
  GetListRequestConfigListItemDto,
  GetListRequestConfigListItemDtoGetListResponse,
  OperationClaim,
  OperationClaimsService,
  RequestConfigsService,
} from './shared/services/api';
import { DropdownModule } from 'primeng/dropdown';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { MultiSelectModule } from 'primeng/multiselect';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { BadgeModule } from 'primeng/badge';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ButtonModule,
    TableModule,
    InputTextModule,
    FormsModule,
    DropdownModule,
    CurrencyPipe,
    MultiSelectModule,
    OverlayPanelModule,
    BadgeModule,
    CommonModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'example-client';
  configs!: GetListRequestConfigListItemDtoGetListResponse;
  jwt: string = '';
  clonedConfigs: { [s: string]: GetListRequestConfigListItemDto } = {};
  @ViewChild('dt2') dt2!: Table;

  operationClaims: OperationClaim[] = [];
  constructor(
    private requestConfigService: RequestConfigsService,
    private operationClaimsService: OperationClaimsService
  ) {}

  ngOnInit() {
    this.fetchConfigs();
    this.fetchOperationClaims();
  }

  filterGlobal(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    this.dt2.filterGlobal(inputElement.value, 'contains');
  }

  fetchOperationClaims() {
    this.operationClaimsService.apiOperationClaimsGet().subscribe({
      next: (value) => {
        this.operationClaims = value;
      },
      error: (err) => console.log(err),
    });
  }
  fetchConfigs() {
    this.requestConfigService
      .apiRequestConfigsGet({
        pageIndex: 0,
        pageSize: 500,
      })
      .subscribe({
        next: (value) => {
          this.configs = value;
        },
        error: (err) => console.log(err),
      });
  }

  getClaimTexts(claims: OperationClaim[]) {
    return claims.map((i) => i.name).join(',');
  }

  onRowEditInit(product: GetListRequestConfigListItemDto) {
    this.clonedConfigs[product.id as string] = { ...product };
  }

  onRowEditSave(product: GetListRequestConfigListItemDto) {
    console.log(product);
    product.claims = this.operationClaims.filter((i) =>
      product.claimIds?.includes(i.id!)
    );
  }

  onRowEditCancel(product: GetListRequestConfigListItemDto, index: number) {
    this.configs.items![index] = this.clonedConfigs[product.id as string];
    delete this.clonedConfigs[product.id as string];
  }
}
