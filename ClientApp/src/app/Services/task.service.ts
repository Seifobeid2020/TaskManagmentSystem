import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

import { Task } from '../Models/Task';


@Injectable({
  providedIn: 'root'
})



export class TaskService { 


  list : Task[];

  constructor(private http: HttpClient) { }
  readonly rootURL = 'https://localhost:44381/api';
  refreshList() {
    this.http.get(`${this.rootURL}/tasks`)
      .toPromise()
      .then(res => this.list = res as Task[]);
      console.log(this.list)

  }
  postTask(formData:Task) {
   
 
    return this.http.post(`${this.rootURL}/tasks`, formData);
  }
  putTask(formData) {
    return this.http.put(`${this.rootURL}/tasks`, formData);
  }
  deleteTask(id){
    
    return this.http.delete(`${this.rootURL}/tasks/${id}`)
      
    
  }
 
}
