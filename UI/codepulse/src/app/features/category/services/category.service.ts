// import { Injectable } from '@angular/core';
// import { AddCategoryRequest } from '../models/add-category-request.model';
// import { Observable } from 'rxjs';
// import { HttpClient } from '@angular/common/http';
// import { Category } from '../models/category.model';
// import { environment } from 'src/environments/environment.prod';


// @Injectable({
//   providedIn: 'root'
// })
// export class CategoryService {

//   constructor(private http:HttpClient) { }
//   // addCategory(){}

//   addCategory(model:AddCategoryRequest): Observable<void>{
//     return this.http.post<void>('https://localhost:44346/api/categories',model);
//   }
//   getAllCategories(): Observable<Category[]>{
//     return this.http.get<Category[]>('https://localhost:44346/api/categories');    // use environment here

//   }
//   getCategoryById(id:string):Observable<Category>{
//     return this.http.get<Category>('https://localhost:44346/api/categories/${id}');    // /api/Categories/{id}

//   }   
// }
// // https://localhost:44346/


// // getCategoryById(id: string): Observable<Category> {
// //   return this.http.get<Category>(`${environment.apiBaseUrl}/api/categories/${id}`);


import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model: AddCategoryRequest): Observable<void> {
    return this.http.post<void>('https://localhost:44346/api/categories', model);
  }

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('https://localhost:44346/api/categories'); // use environment here
  }

  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`https://localhost:44346/api/categories/${id}`); // use backticks for template string `````````Works now !!!!
  }
}
