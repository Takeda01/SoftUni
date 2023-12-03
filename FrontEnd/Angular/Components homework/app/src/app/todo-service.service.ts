import { Injectable } from '@angular/core';
import { Todo } from './types/Todo';
import { ListService } from './list.service';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
Todos: Todo[] =
 [
  {task: "Shopping"},
  {task: "Rent Pay"},
  {task: "Cleaning"}
 ]
  constructor() { }

    AddTask(t:string){
      this.Todos.push(new Todo(t))
    }
}
