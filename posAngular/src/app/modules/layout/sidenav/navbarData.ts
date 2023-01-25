import { INavbarData } from './helper';

export const navbarData : INavbarData[] =[
  {
    routerLink:'dashboard',
    icon:'fa fa-home',
    label :'Dashboard'
  },

  {
    routerLink:'inventory',
    icon:'fa fa-list',
    label :'Inventory',
    items : [
      {
        routerLink:'inventory/products',
        label:'Products'
      },
      {
        routerLink:'inventory/units',
        label:'Units'
      },
      {
        routerLink:'inventory/categories',
        label:'Categories'
      }


    ]
  } ,{
    routerLink:'sales',
    icon:'fa fa-tags',
    label :'Sales'
  },


]
