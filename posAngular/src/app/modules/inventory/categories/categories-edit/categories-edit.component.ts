import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-categories-edit',
  templateUrl: './categories-edit.component.html',
  styleUrls: ['./categories-edit.component.css']
})
export class CategoriesEditComponent implements OnInit {
  cateogryForm!:FormGroup
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,public dialog: MatDialogRef<CategoriesEditComponent>,  public matDialog: MatDialog) { }

  ngOnInit(): void {
    this.cateogryForm = new FormGroup({
      CategoryName:new FormControl('',[Validators.required]),
      Notes:new FormControl(''),
      IsActive:new FormControl(true),
    })
  }


addCategory(){
  console.log(this.cateogryForm.value)
}

Close(){
  
}

}
