import { Component, ElementRef,  EventEmitter,  Output,  ViewChild, OnInit } from '@angular/core';



@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent {
  @ViewChild('Input')
  input: ElementRef<HTMLInputElement> | undefined;
 
constructor(){

}
@Output() output = new EventEmitter<HTMLElement>()
ngOnInit(){
  this.output.emit(this.input?.nativeElement)
}

}

