 import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '' , redirectTo : '/dashboard' ,pathMatch:"full"},

  {path:'dashboard' ,
  loadChildren: () => import('./modules/dashboard/dashboard.module')
  .then(mod => mod.DashboardModule)},


   {path:'inventory',
   loadChildren: () => import('./modules/inventory/inventory.module')
   .then(mod => mod.InventoryModule)},

 


];

@NgModule({
  imports: [RouterModule.forRoot(routes , {preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
