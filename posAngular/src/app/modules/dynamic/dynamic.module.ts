

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavSubComponent } from './sidenav-sub/sidenav-sub.component';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    SidenavSubComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule
  ],
  exports:[
    SidenavSubComponent
  ]
})
export class DynamicModule { }
