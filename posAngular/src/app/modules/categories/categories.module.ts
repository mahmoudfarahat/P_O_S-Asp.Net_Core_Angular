import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatergoriesListComponent } from './catergories-list/catergories-list.component';
import { CatergoriesRoutingModule } from './categories-routing.module';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import { CatergoriesEditComponent } from './catergories-edit/catergories-edit.component';
import {MatIconModule} from '@angular/material/icon';



@NgModule({
  declarations: [
    CatergoriesListComponent,
    CatergoriesEditComponent,

  ],
  imports: [
    CommonModule,
    CatergoriesRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatIconModule

  ]

})
export class CategoriesModule { }
