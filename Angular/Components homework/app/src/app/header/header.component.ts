import { Component } from '@angular/core';
import {  TodoService } from '../todo-service.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  
  constructor(public TodoService : TodoService){

  }

  AddTask(input: HTMLInputElement){
    this.TodoService.AddTask(String(input.value))
    input.value = ""
  }
}