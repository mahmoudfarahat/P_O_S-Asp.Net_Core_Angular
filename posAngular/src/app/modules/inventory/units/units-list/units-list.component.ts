import { UnitsService } from './../../../../services/inventory/units/units.service';
import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-units-list',
  templateUrl: './units-list.component.html',
  styleUrls: ['./units-list.component.css']
})
export class UnitsListComponent implements OnInit ,AfterViewInit {

  // page:any = 1
  filteration: any = {
    // page:this.page,
    // limit:10
  }
  total:any =50;
  constructor( private unitsService: UnitsService) {
    // Create 100 users


    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit(): void {
this.getUnits()
  }

  GetData(data:any){
    console.log(data);
    this.unitsService.getUnits(this.filteration,(data.pageIndex *data.pageSize)
      ,data.pageSize).subscribe(units => {
    console.log(units)
    this.dataSource =   units.data;
    this.total = units.totalCount
  })
  }


  displayedColumns: string[] = ['id', 'unitName', 'notes', 'isActive' ,'actions'];
  // dataSource: MatTableDataSource<UserData>;
   dataSource: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

getUnits(){
  this.unitsService.getUnits(this.filteration,0,10).subscribe(units => {
    console.log(units)
    this.dataSource =   units.data;
    this.total = units.totalCount
  })
}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {

  this.filteration['search'] = (event.target as HTMLInputElement).value;
  this.getUnits();
  // this.page =1
  // this.filteration['page']=1



    // this.dataSource.filter = filterValue.trim().toLowerCase();

    // if (this.dataSource.paginator) {
    //   this.dataSource.paginator.firstPage();
    // }
  }
}
