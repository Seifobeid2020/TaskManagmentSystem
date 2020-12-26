import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { AuthGuard } from './guards/auth-guard.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskComponent } from './task/task.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from "@auth0/angular-jwt";

import { FormsModule } from '@angular/forms';

import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';
import {MatDatepickerModule} from '@angular/material/datepicker';



import {ReactiveFormsModule} from '@angular/forms';
import {MatNativeDateModule} from '@angular/material/core';

import {MAT_FORM_FIELD_DEFAULT_OPTIONS} from '@angular/material/form-field';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { CategoryComponent } from './category/category.component';
import { TasksCategoriesComponent } from './tasks-categories/tasks-categories.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';
import {
  MatCardModule

} from '@angular/material/card';



export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    DialogBoxComponent,
    MainNavComponent,
    CategoryComponent,
    TasksCategoriesComponent,
    LoginComponent,
  
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, FormsModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,ReactiveFormsModule, LayoutModule, MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule,MatCardModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44381"],
        blacklistedRoutes: []
      }
    })
  
  ],
  providers: [   { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } },[AuthGuard]],
  bootstrap: [AppComponent]
})
export class AppModule { }
