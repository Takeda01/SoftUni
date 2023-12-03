import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  constructor(private api: ApiService){

  }
  ngOnInit(): void{
    this.api.GetThemes().subscribe((themes) => {
  console.log(themes)
    })
  }
}
