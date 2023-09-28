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

  categories$?: Observable<Category[]>;
  //categories?: Category[];

  constructor(private categoryService: CategoryService){

  }
  
  // ngOnInit(): void {
  //   this.categoryService.getAllCategories()
  //   .subscribe({
  //     next: (response)=>{
  //       this.categories = response;
  //     }
  //   });
  // }

  // Other way to import fetch data without using subscribe and unsubscribe model.
  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }

}
