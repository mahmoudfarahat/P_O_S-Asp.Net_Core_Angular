import { CategoriesService } from './../../../../services/inventory/categories/categories.service';
import { CategoriesEditComponent } from './../categories-edit/categories-edit.component';


import { Component, OnInit , ViewChild  ,AfterViewInit, Inject} from '@angular/core';
import {MatTable} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';


export interface PeriodicElement {
  id:number
  name: string;
  isActive: number;
  note: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {id: 1, name: 'Hydrogen', isActive: 1.0079, note: 'H'},
  {id: 2, name: 'Helium', isActive: 4.0026, note: 'He'},
  {id: 3, name: 'Lithium', isActive: 6.941, note: 'Li'},
  {id: 4, name: 'Beryllium', isActive: 9.0122, note: 'Be'},
  {id: 5, name: 'Boron', isActive: 10.811, note: 'B'},
  {id: 6, name: 'Carbon', isActive: 12.0107, note: 'C'},
  {id: 7, name: 'Nitrogen', isActive: 14.0067, note: 'N'},
  {id: 8, name: 'Oxygen', isActive: 15.9994, note: 'O'},
  {id: 9, name: 'Fluorine', isActive: 18.9984, note: 'F'},
  {id: 10, name: 'Neon', isActive: 20.1797, note: 'Ne'},
];
@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit ,AfterViewInit{
  displayedColumns: string[] = ['id', 'categoryName',  'isActive','notes' , 'actions'];
  // dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  dataSource = []
  constructor(   public dialog: MatDialog,private CategoriesService:CategoriesService) { }

  ngOnInit(): void {
    this.getCategories()
  }

  // @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatPaginator) paginator: any;



  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
  }

  @ViewChild(MatTable) table: any ;

  openCategoryDialog(){
    const dialogRef = this.dialog.open(CategoriesEditComponent, {
      width: '500px',
      disableClose: true,
    });
  }

getCategories(){
 this.CategoriesService.getCategories().subscribe(a =>{
  this.dataSource = a
  console.log(a)
 })
}
}
