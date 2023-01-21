import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'posAngular';


  isSideNavCollapsed = false;
  screenWidth =0
  
  onToggleSideNav(data: SideNavToggle):void{

  this.screenWidth = data.screenWidth;
  this.isSideNavCollapsed = data.collapsed


  }


}

  interface SideNavToggle{
    screenWidth: number;
    collapsed : boolean
  }
