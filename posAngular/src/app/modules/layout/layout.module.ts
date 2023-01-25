import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';
import { RouterModule } from '@angular/router';
import { BodyComponent } from './body/body.component';
import { SidenavSubComponent } from './sidenav-sub/sidenav-sub.component';







@NgModule({
  declarations: [
    SidenavComponent,
    BodyComponent,
    SidenavSubComponent,

  ],
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule
  ],
exports:[

  SidenavComponent,
  BodyComponent
]

})
export class LayoutModule { }
