import { Component, Input } from '@angular/core';
import { TodoService } from './todo-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
constructor(public TodoService: TodoService){

}

input : HTMLElement = new HTMLElement;
Acceptor(field: HTMLElement)
{
this.input = field
}


}
