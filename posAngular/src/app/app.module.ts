import { DynamicModule } from './modules/dynamic/dynamic.module';
import { InventoryModule } from './modules/inventory/inventory.module';

import { DashboardModule } from './modules/dashboard/dashboard.module';

import { LayoutModule } from './modules/layout/layout.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';




@NgModule({
  declarations: [
    AppComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    InventoryModule,
    DashboardModule,
    DynamicModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
