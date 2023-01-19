
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StaticsComponent } from './statics/statics.component';
import { DashboardRoutingModule } from './Dashboard-routing.module';



@NgModule({
  declarations: [
    StaticsComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
