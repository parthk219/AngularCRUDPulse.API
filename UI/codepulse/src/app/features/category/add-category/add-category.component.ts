import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest;
  private addCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService,private router:Router) {
    this.model = {
      name: 'Initial Name',
      urlHandle: 'Initial Url Handle'
    };
  }

  onFormSubmit() {
    // console.log(this.model)
    this.addCategorySubscription = this.categoryService.addCategory(this.model)
      .subscribe({
        next: (response) => {
          // console.log('This was successful');
          this.router.navigateByUrl('/admin/categories');
        }
      });
  }

  ngOnDestroy(): void {
    // Don't throw an error here, implement any cleanup logic if needed
    if (this.addCategorySubscription) {
      this.addCategorySubscription.unsubscribe();
    }
  }
}
