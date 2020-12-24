import { Component, OnInit ,ViewChild} from '@angular/core';

import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component'
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {
  displayedColumns: string[] = ['categoryId', 'categoryName', 'action'];
 
  constructor(public categoryService:CategoryService,public dialog: MatDialog) { }
 
  ngOnInit(): void {
    this.categoryService.refreshList();
    
   
    
  }




  @ViewChild(MatTable) table: MatTable<any>;



  openDialog(action,obj) {
    obj.action = action;
    obj.component="Category";
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '300px',
      data:obj,
     
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);



      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
     
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data.categoryId);
      }
    });
  }

  addRowData(row_obj){
   
    this.categoryService.postCategory({
      
      categoryId : parseInt(row_obj.categoryId),
      categoryName: row_obj.categoryName,
     


    }).subscribe(
      data => {
        // Processing for successfull response
        this.categoryService.refreshList();
        this.table.renderRows();
      },
      error => {
        // Processing for failures
      }
    );;
   
    
  }
   updateRowData(row_obj){
 
   this.categoryService.putCategory(row_obj).subscribe( data => {
    // Processing for successfull response
    this.categoryService.refreshList();
      this.table.renderRows();

  },
  error => {
    // Processing for failures
  })  ;

    
  }
  deleteRowData(row_obj){
  
this.categoryService.deleteCategory(row_obj).subscribe(
  data => {
    // Processing for successfull response
    this.categoryService.refreshList();
    this.table.renderRows();
  },
  error => {
    // Processing for failures
  }
);

  }


}
