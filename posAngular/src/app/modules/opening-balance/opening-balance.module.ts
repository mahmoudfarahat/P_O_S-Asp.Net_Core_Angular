import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OpeningBalanceEditComponent } from './opening-balance-edit/opening-balance-edit.component';
import { OpeningBalanceListComponent } from './opening-balance-list/opening-balance-list.component';



@NgModule({
  declarations: [
    OpeningBalanceEditComponent,
    OpeningBalanceListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OpeningBalanceModule { }
