import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CategoryComponent } from './category/category.component';
import { LoginComponent } from './login/login.component';
import { TaskComponent } from './task/task.component';
import { TasksCategoriesComponent } from './tasks-categories/tasks-categories.component';


const routes: Routes = [
  {path:'Tasks' ,component:TaskComponent,canActivate:[AuthGuard]},
  {path:'Categories' ,component:CategoryComponent,canActivate:[AuthGuard]},
  {path:'TasksCategories' ,component:TasksCategoriesComponent,canActivate:[AuthGuard]},
  {path:'login' ,component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
