 import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '' , redirectTo : '/dashboard' ,pathMatch:"full"},

  {path:'dashboard' ,
  loadChildren: () => import('./modules/dashboard/dashboard.module')
  .then(mod => mod.DashboardModule)},


   {path:'categories',
   loadChildren: () => import('./modules/categories/categories.module')
   .then(mod => mod.CategoriesModule)},


   {path:'products',
   loadChildren: () => import('./modules/products/products.module')
   .then(mod => mod.ProductsModule)},


];

@NgModule({
  imports: [RouterModule.forRoot(routes , {preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
