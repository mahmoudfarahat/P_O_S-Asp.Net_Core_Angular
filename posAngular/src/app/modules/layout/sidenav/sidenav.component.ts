import { INavbarData } from './helper';
import { animate, keyframes, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, HostListener, OnInit, Output } from '@angular/core';
import { navbarData } from './navbarData';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css'],
  animations:[
    trigger('fadeInOut',[
      transition(':enter', [
        style({opacity: 0}),
        animate('350ms',
        style({opactiy:1}))
      ]),
      transition(':leave',[
        style({opacity:1}),
        animate('100ms',
        style({opacity:0})
        )
      ])
    ]),
    trigger('rotate',[
      transition(':enter',[
        animate('1000ms',
        keyframes([
          style({transform:'rotate(0deg)', offset:'0'}),
          style({transform:'rotate(2turn)', offset:'1'}),

        ]))
      ])
    ])
  ]
})
export class SidenavComponent implements OnInit {

  @Output() onToggleSideNav : EventEmitter<SideNavToggle> = new EventEmitter()
  constructor() { }
  screenWidth = 0

@HostListener('window:resize' , ['$event'])

onResize(event :any){
  this.screenWidth =window.innerWidth
  if(this.screenWidth <= 768){
    this.collapsed = false
    this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth: this.screenWidth})
  }
}

  ngOnInit(): void {
    this.screenWidth= window.innerWidth
  }

  collapsed =false;

  navData =  navbarData
multiple: boolean =false;
  toggleCollapse():void{
    console.log(window.innerWidth)
this.collapsed =!this.collapsed
this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth: this.screenWidth})
  }

  closeSidenav():void {
this.collapsed = false
this.onToggleSideNav.emit({collapsed:this.collapsed, screenWidth: this.screenWidth})

  }

handleClick(item : INavbarData):void{
if(!this.multiple){
  for(let modelItem of this.navData){
    if(item !== modelItem && modelItem.expanded){
      modelItem.expanded =false;
    }
  }
}
item.expanded =!item.expanded
}
}



  interface SideNavToggle{
    screenWidth: number;
    collapsed : boolean
  }
