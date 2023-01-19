import { CatergoriesListComponent } from './catergories-list/catergories-list.component';
 import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
{path:'', component:CatergoriesListComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatergoriesRoutingModule { }
