import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse } from "@angular/common/http";

import { Category } from '../Models/Category';
import { TasksCategories } from '../Models/TasksCategories';


@Injectable({
  providedIn: 'root'
})



export class TasksCategoriesService { 


  list : TasksCategories[];

  constructor(private http: HttpClient) { }
  readonly rootURL = 'https://localhost:44381/api/TasksCategories';
  refreshList() {
    this.http.get(`${this.rootURL}`)
      .toPromise()
      .then(res => this.list = res as TasksCategories[]);
    console.log(this.list)
  }
  postTasksCategories(formData:TasksCategories) {
   
 
    return this.http.post(`${this.rootURL}`, formData);
  }
  putTasksCategories(formData) {
    return this.http.put(`${this.rootURL}/${formData.categoryId}/${formData.taskId}`,formData)
  }
  deleteTasksCategories(formData){
    
    return this.http.delete(`${this.rootURL}/${formData.categoryId}/${formData.taskId}`)
  
    
  }
 
}
