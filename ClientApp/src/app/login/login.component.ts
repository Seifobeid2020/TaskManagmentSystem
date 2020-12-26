import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean;
  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }
  login(form: NgForm) {
    const credentials = JSON.stringify(form.value);
    console.log(JSON.stringify(form.value));
    this.http.post("https://localhost:44381/api/Authenticate/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      console.log("this is toto",token);
      this.invalidLogin = false;
      this.router.navigate(["/Tasks"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

}
