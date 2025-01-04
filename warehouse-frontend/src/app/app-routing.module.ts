import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SidebarComponent } from './components/nav/sidebar/sidebar.component';
import { ProductComponent } from './components/page/product/product.component';
import { WareHouseComponent } from './components/page/ware-house/ware-house.component';
import { DocumentComponent } from './components/page/document/document.component';
import { CityComponent } from './components/page/city/city.component';
import { ShelfComponent } from './components/page/shelf/shelf.component';
import { PurchaseComponent } from './components/page/purchase/purchase.component';
import { DashboardComponent } from './components/page/dashboard/dashboard.component';

const routes: Routes = [
  {path:'' , component:SidebarComponent},
  {path:'login' , component:LoginComponent},
  {path:'warehouse' , component:WareHouseComponent},
  {path:'document' , component:DocumentComponent},
  {path:'products' , component:ProductComponent},
  {path:'city' , component:CityComponent},
  {path:'shelf' , component:ShelfComponent},
  {path:'dashboard' , component:DashboardComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
