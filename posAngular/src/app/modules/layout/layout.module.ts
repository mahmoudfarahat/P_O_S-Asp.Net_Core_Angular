import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';
import { RouterModule } from '@angular/router';
import { BodyComponent } from './body/body.component';







@NgModule({
  declarations: [
    SidenavComponent,
    BodyComponent,

  ],
  imports: [
    CommonModule,
    RouterModule
  ],
exports:[

  SidenavComponent,
  BodyComponent
]

})
export class LayoutModule { }
