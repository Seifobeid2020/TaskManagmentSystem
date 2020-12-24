import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

import { Category } from '../Models/Category';


@Injectable({
  providedIn: 'root'
})



export class CategoryService { 


  list : Category[];

  constructor(private http: HttpClient) { }
  readonly rootURL = 'https://localhost:44381/api/Categories';
  refreshList() {
    this.http.get(`${this.rootURL}`)
      .toPromise()
      .then(res => this.list = res as Category[]);
    console.log(this.list)
  }
  postCategory(formData:Category) {
   
 
    return this.http.post(`${this.rootURL}`, formData);
  }
  putCategory(formData) {
    return this.http.put(`${this.rootURL}`, formData);
  }
  deleteCategory(id){
    
    return this.http.delete(`${this.rootURL}/${id}`)
      
    
  }
 
}
