import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatergoriesListComponent } from './catergories-list/catergories-list.component';
import { CatergoriesRoutingModule } from './categories-routing.module';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';



@NgModule({
  declarations: [
    CatergoriesListComponent,

  ],
  imports: [
    CommonModule,
    CatergoriesRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule

  ]

})
export class CategoriesModule { }
