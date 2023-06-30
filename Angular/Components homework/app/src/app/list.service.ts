import { Injectable } from '@angular/core';
import { TodoService } from './todo-service.service';
import { AppComponent } from './app.component';


@Injectable({
  providedIn: 'root'
})
export class ListService {

  constructor(public TodoService: TodoService) { }

  arr =  this.TodoService.Todos
  Delete(CurrentItem: HTMLElement){

  for (let index = 0; index < this.arr.length; index++) {
    
  
      if(this.arr[index].task === CurrentItem.textContent){
     this.arr.splice(index, 1 )
     }
   }
 }
editdata:string = ""
Edit(CurrentItem: HTMLElement, box: HTMLElement){

this.editdata= String(CurrentItem.textContent)
box.textContent = this.editdata;

this.Delete(CurrentItem);


}
}
