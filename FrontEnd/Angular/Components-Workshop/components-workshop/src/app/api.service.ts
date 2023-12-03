import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Post } from './types/post';
import { Theme } from './types/theme';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }


  GetThemes(){
    const{appUrl} = environment
return this.http.get<Theme[]>(`${appUrl}/themes`)
  }
  GetPosts(limit?: number){
    const{appUrl} = environment
    const limitFilter = limit ? `?limit=${limit}` : ''
    return this.http.get<Post[]>(`${appUrl}/posts${limitFilter}`)
  }
}
