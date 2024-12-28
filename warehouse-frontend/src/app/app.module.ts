import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SidebarComponent } from './components/nav/sidebar/sidebar.component';
import { ProductComponent } from './components/page/product/product.component';
import { WareHouseComponent } from './components/page/ware-house/ware-house.component';
import { AddItemWarehouseComponent } from './components/page/ware-house/add-item-warehouse/add-item-warehouse.component';
import { DocumentComponent } from './components/page/document/document.component';
import { AddDocumentComponent } from './components/page/document/add-document/add-document.component';
import { CityComponent } from './components/page/city/city.component';
import { AddCityComponent } from './components/page/city/add-city/add-city.component';
import { ShelfComponent } from './components/page/shelf/shelf.component';
import { AddShelfComponent } from './components/page/shelf/add-shelf/add-shelf.component';
import { PurchaseComponent } from './components/page/purchase/purchase.component';
import { AddProductComponent } from './components/page/product/add-product/add-product.component'; 
@NgModule({
  declarations: [
    AddProductComponent,
    AppComponent,
    LoginComponent,
    SidebarComponent,
    ProductComponent,
    WareHouseComponent,
    AddItemWarehouseComponent,
    DocumentComponent,
    AddDocumentComponent,
    CityComponent,
    AddCityComponent,
    ShelfComponent,
    AddShelfComponent,
    PurchaseComponent,
    AddProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
