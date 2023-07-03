import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Theme } from '../types/theme';

@Component({
  selector: 'app-themes-list',
  templateUrl: './themes-list.component.html',
  styleUrls: ['./themes-list.component.scss']
})
export class ThemesListComponent implements OnInit {
  ThemesList: Theme[] = []
constructor(private api: ApiService){}

ngOnInit(): void {
 this.api.GetThemes().subscribe((themes)=>{
this.ThemesList = themes;
 })
}

}
