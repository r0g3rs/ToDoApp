import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { AppService } from './app.service';
import { ToDoItem } from "./app.service";
import { Observable } from "rxjs/Observable";

@Component({
  selector: 'app-root',
  providers: [AppService],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  pageTitle: string = '';
  errorMessage: string = '';
  toDoList: Observable<ToDoItem[]>;

  hideOnBlur = true;
  inputShow = true;
  item = {};
  index = Number;

  showEditor = true;
  myName: string;
  newTodo: ToDoItem;

  constructor(private _appService: AppService) {
    this.newTodo = new ToDoItem();
  }

  ngOnInit(): void {
    this._appService.GetAllToDo();
    this.toDoList = this._appService.toDoList;    
    this.hideOnBlur = true;
  }

  public editRecord(item: ToDoItem, indx) {
    this.hideOnBlur = true;
    this.inputShow = true;
    this.item = item;
    this.index = indx;
  };

  public createToDo(item: ToDoItem) {
    this._appService.CreateToDo(item);
  }

  public updateToDo(item: ToDoItem) {
    this._appService.UpdateToDo(item);
  }

  public deleteToDo(todoId: number) {
    this._appService.DeleteToDo(todoId);
  }
}
