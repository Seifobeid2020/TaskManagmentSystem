


import { Component, OnInit ,ViewChild} from '@angular/core';

import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component'
import { TasksCategoriesService } from '../Services/tasks-categories.service';

@Component({
  selector: 'app-tasks-categories',
  templateUrl: './tasks-categories.component.html',
  styleUrls: ['./tasks-categories.component.css']
})

export class TasksCategoriesComponent implements OnInit {
  displayedColumns: string[] = ['categoryId', 'taskId', 'action'];
 
  constructor(public tasksCategoriesService:TasksCategoriesService,public dialog: MatDialog) { }
 
  ngOnInit(): void {
    this.tasksCategoriesService.refreshList();
    
   
    
  }




  @ViewChild(MatTable) table: MatTable<any>;



  openDialog(action,obj) {
    obj.action = action;
    obj.component="TasksCategories";
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '500px',
      data:obj,
     
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);



      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
     
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj){
   
    this.tasksCategoriesService.postTasksCategories({
      
      categoryId : parseInt(row_obj.categoryId),
      taskId: row_obj.taskId,
     


    }).subscribe(
      data => {
        // Processing for successfull response
        this.tasksCategoriesService.refreshList();
        this.table.renderRows();
      },
      error => {
        // Processing for failures
      }
    );;
   
    
  }
   updateRowData(row_obj){
 
   this.tasksCategoriesService.putTasksCategories(row_obj).subscribe( data => {
    // Processing for successfull response
    this.tasksCategoriesService.refreshList();
      this.table.renderRows();

  },
  error => {
    // Processing for failures
  })  ;

    
  }
  deleteRowData(data){
  
this.tasksCategoriesService.deleteTasksCategories(data).subscribe(
  data => {
    // Processing for successfull response
    this.tasksCategoriesService.refreshList();
    this.table.renderRows();
  },
  error => {
    // Processing for failures
  }
);

  }


}
