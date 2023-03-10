import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { UnitsComponent } from './units/units.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoriesListComponent } from './categories/categories-list/categories-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { InventoryRoutingModule } from './inventory-routing.module';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { MatInputModule } from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { UnitsListComponent } from './units/units-list/units-list.component';
import {MatSortModule} from '@angular/material/sort';
import { CategoriesEditComponent } from './categories/categories-edit/categories-edit.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    ProductsComponent,
    UnitsComponent,
    CategoriesComponent,
    CategoriesListComponent,
    ProductsListComponent,
    UnitsListComponent,
    CategoriesEditComponent,

  ],
  imports: [
    CommonModule,
    MatTableModule,
    InventoryRoutingModule,
    MatButtonModule,
    MatPaginatorModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSortModule,
    MatDialogModule,
    MatCheckboxModule,
    ReactiveFormsModule

  ]
})
export class InventoryModule { }
