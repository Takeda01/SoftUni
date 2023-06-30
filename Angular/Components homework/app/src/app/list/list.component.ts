import { Component } from '@angular/core';
import {Input} from '@angular/core'
import { Todo } from '../types/Todo';
import { ListService } from '../list.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent {
  @Input() Todos : Todo[]  = []
  @Input() input : HTMLElement = new HTMLElement
  constructor(public ListService: ListService){

  }

  Edit(CurrentItem: HTMLElement){
    
    this.ListService.Edit(CurrentItem, this.input)
  }
  Delete(CurrentItem: HTMLElement){
    this.ListService.Delete(CurrentItem)
  }
}
