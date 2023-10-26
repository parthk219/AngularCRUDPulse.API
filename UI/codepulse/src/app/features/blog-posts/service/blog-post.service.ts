import { Injectable } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  constructor(private http:HttpClient) { }

  createBlogPost(data:AddBlogPost):Observable<BlogPost>
  {
    return this.http.post<BlogPost>(`https://localhost:44346/api/blogposts`,data); 
  }
}

// (`https://localhost:44346/api/categories/${id}`);