import { ProductsModule } from './modules/products/products.module';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { CategoriesModule } from './modules/categories/categories.module';
import { CatergoriesRoutingModule } from './modules/categories/categories-routing.module';
import { SidenavComponent } from './modules/layout/sidenav/sidenav.component';
import { LayoutModule } from './modules/layout/layout.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    CategoriesModule,
    DashboardModule,
    BrowserAnimationsModule,
    ProductsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
