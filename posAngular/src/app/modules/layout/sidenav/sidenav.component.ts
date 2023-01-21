import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { navbarData } from './navbarData';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {

  @Output() onToggleSideNav : EventEmitter<SideNavToggle> = new EventEmitter()
  constructor() { }
  screenWidth = 0

  ngOnInit(): void {
    this.screenWidth= window.innerWidth
  }

  collapsed =false;

  navData =  navbarData

  toggleCollapse():void{
    console.log(window.innerWidth)
this.collapsed =!this.collapsed
this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth: this.screenWidth})
  }

  closeSidenav():void {
this.collapsed = false
this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth: this.screenWidth})

  }}



  interface SideNavToggle{
    screenWidth: number;
    collapsed : boolean
  }
