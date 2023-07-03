import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Post } from '../types/post';
import { Theme } from '../types/theme';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.scss']
})
export class PostsListComponent implements OnInit {
constructor(private api: ApiService){

}
posts: Post[] = []

ngOnInit(): void{
  this.api.GetPosts(5).subscribe((posts)=> {
    console.log(posts)
this.posts = posts;
  })
}
}
