import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse ,HttpHeaders } from "@angular/common/http";

import { Task } from '../Models/Task';


@Injectable({
  providedIn: 'root'
})



export class TaskService { 

  //  t:string ="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MDg5Njg0OTcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMCJ9.L2b9qemAL5n2OMl0bOipGHomlDHkTlf5H8GM7mbfoqc"
  // list : Task[];
  //  headers_object:HttpHeaders = new HttpHeaders({
  //   'Content-Type': 'application/json',
  //    'Authorization': "Bearer "+this.t});
  //     httpOptions = {
  //     headers: this.headers_object
  //   };
  list : Task[];

  constructor(private http: HttpClient) { }
  readonly rootURL = 'https://localhost:44381/api';
  refreshList() {
    this.http.get(`${this.rootURL}/tasks`,{
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      this.list = response as Task[]
    }, err => {
      console.log(err)
    });
      // .toPromise()
      // .then(res => this.list = res as Task[]);
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
