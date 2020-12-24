import { Component, OnInit,ViewChild } from '@angular/core';

import { TaskService } from '../Services/task.service';

import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component'

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  displayedColumns: string[] = ['taskId', 'subject', 'createTime','startDate','dueDate', 'completedDate','complete', 'importance','action'];
  //displayedColumns: string[] = ['TaskId', 'Subject', 'CreateTime','StartDate','DueDate', 'CompletedDate','Complete', 'Importance','action'];

  constructor(public taskService:TaskService,public dialog: MatDialog) { }
 
  ngOnInit(): void {
    this.taskService.refreshList();
   
  }




  @ViewChild(MatTable) table: MatTable<any>;



  openDialog(action,obj) {
    obj.action = action;
    obj.component = "Task";
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
        this.deleteRowData(result.data.taskId);
      }
    });
  }

  addRowData(row_obj){
   
    this.taskService.postTask({
      
      taskId : parseInt(row_obj.taskId),
      subject: row_obj.subject,
      createTime: row_obj.createTime ,
      startDate: row_obj.startDate ,
      dueDate: row_obj.dueDate ,
      completedDate: row_obj.completedDate ,
      complete: Boolean(JSON.parse(row_obj.complete)),
      importance: row_obj.importance,



    }).subscribe(
      data => {
        // Processing for successfull response
        this.taskService.refreshList();
        this.table.renderRows();
      },
      error => {
        // Processing for failures
      }
    );;
   
    
  }
   updateRowData(row_obj){
 
   this.taskService.putTask(row_obj).subscribe( data => {
    // Processing for successfull response
    this.taskService.refreshList();
      this.table.renderRows();

  },
  error => {
    // Processing for failures
  })  ;

    
  }
  deleteRowData(row_obj){
  
this.taskService.deleteTask(row_obj).subscribe(
  data => {
    // Processing for successfull response
    this.taskService.refreshList();
    this.table.renderRows();
  },
  error => {
    // Processing for failures
  }
);

  }


}
