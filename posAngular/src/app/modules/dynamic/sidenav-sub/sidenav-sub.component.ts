import { trigger, style, state, transition, animate } from '@angular/animations';
import { INavbarData } from '../../layout/sidenav/helper';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav-sub',
  templateUrl: './sidenav-sub.component.html',
  styleUrls: ['./sidenav-sub.component.css'],
  animations:[
    trigger('submenu' , [
        state('hidden', style ({
          height:'0',
          overflow: 'hidden'
        })),
        state('visible' ,style({
          height:'*'
        })),
        transition('visible <=> hidden', [style({overflow:'hidden'}),
          animate('{{transitionParams}}'),
          transition('void =>*', animate(0))
      ])

    ])
  ]
})
export class SidenavSubComponent implements OnInit {
@Input() data: INavbarData ={
  routerLink: '',
  icon:'',
  label:'',
  items:[]
}
@Input() collapsed = false;
@Input() animating : boolean | undefined;
@Input() expanded : boolean | undefined;
@Input() multiple : boolean = false;



  constructor() { }

  ngOnInit(): void {
  }


  handleClick(item: any):void {
    if(!this.multiple){
      if(this.data.items && this.data.items.length > 0){
        for(let modelItem of this.data.items){
          if(item !== modelItem && modelItem.expanded)
          {
            modelItem.expanded =false
          }
        }
      }
    }
    item.expanded = !item.expanded;
  }
}
