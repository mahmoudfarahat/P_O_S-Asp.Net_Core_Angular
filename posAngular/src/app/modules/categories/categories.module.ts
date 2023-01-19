import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatergoriesListComponent } from './catergories-list/catergories-list.component';
import { CatergoriesRoutingModule } from './categories-routing.module';




@NgModule({
  declarations: [
    CatergoriesListComponent,

  ],
  imports: [
    CommonModule,
    CatergoriesRoutingModule
  ]

})
export class CategoriesModule { }
