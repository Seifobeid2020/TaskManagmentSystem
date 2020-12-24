import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryComponent } from './category/category.component';
import { TaskComponent } from './task/task.component';
import { TasksCategoriesComponent } from './tasks-categories/tasks-categories.component';


const routes: Routes = [
  {path:'Tasks' ,component:TaskComponent},
  {path:'Categories' ,component:CategoryComponent},
  {path:'TasksCategories' ,component:TasksCategoriesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
