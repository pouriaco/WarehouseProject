import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { SidebarComponent } from './components/nav/sidebar/sidebar.component';
import { ProductComponent } from './components/page/product/product.component';
import { AddProductComponent } from './components/page/add-item/add-product/add-product.component';

const routes: Routes = [
  // {path:'' , component:AppComponent},
  {path:'login' , component:LoginComponent},
  {path:'sidebar' , component:SidebarComponent},
  {path:'products' , component:ProductComponent},
  {path:'addProducts' , component:AddProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
