// import { Component, OnInit } from '@angular/core';
// import { CategoryService } from '../services/category.service'; // Corrected the import statement
// import { Category } from '../models/category.model';
// import { Observable } from 'rxjs';


// @Component({
//   selector: 'app-category-list',
//   templateUrl: './category-list.component.html',
//   styleUrls: ['./category-list.component.css']
// })
// export class CategoryListComponent implements OnInit {
//   //categories?: Category[]; // Assuming Category is a defined type
// categories$?: Observable<Category>[]>;
//   constructor(private categoryService: CategoryService) { }

//   ngOnInit(): void { // Note the correct spelling of ngOnInit
//   // this.categoryService.getAllCategories()
//   this.categories$=this.categoryService.getAllCategories();
//   //     .subscribe({
//   //       next: (response) => {
//   //         this.categories = response; // Assuming response is an array of categories
//   //       },
//   //       error: (error) => {
//   //         console.error('Error fetching categories:', error);
//   //       }
//   //     });
//   }
// }


////////////////////////////////

import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories$?: Observable<Category[]>; // Changed to an array of Observable Categories

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }
}
