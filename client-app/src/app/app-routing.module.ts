import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { DxChartModule, DxDataGridModule, DxFormModule, DxPieChartModule, DxRangeSelectorModule, DxSelectBoxModule, DxToastModule } from 'devextreme-angular';
import { ProductComponent } from './pages/product/product.component';
import { DxiSeriesModule } from 'devextreme-angular/ui/nested';

const routes: Routes = [
  {
    path: 'product',
    component: ProductComponent,
  },
  {
    path: 'profile',
    component: ProfileComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
 
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), DxDataGridModule, DxFormModule, DxToastModule, DxChartModule,
    DxSelectBoxModule, DxiSeriesModule, DxPieChartModule, DxRangeSelectorModule],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
    ProfileComponent,
    ProductComponent
  ]
})
export class AppRoutingModule { }
