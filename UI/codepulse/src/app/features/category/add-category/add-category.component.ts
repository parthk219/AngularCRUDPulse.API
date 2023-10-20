import { Component, OnInit } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CategoryService } from '../services/category.service';


@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent  {

  model: AddCategoryRequest;

  constructor(private categoryService: CategoryService ) {
    this.model = {
      name: 'Initial Name',
      urlHandle: 'Initial Url Handle'
    };
  }
  onFormSubmit() { 
      // console.log(this.model)
      this.categoryService.addCategory(this.model)
      .subscribe({
        next:(response)=> {
          console.log('this was successful');
        }
      })
    }}