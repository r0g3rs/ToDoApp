import { Injectable } from '@angular/core';
import { Http, Response, Headers } from "@angular/http";

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class AppService {

  public toDoList: Observable<ToDoItem[]>;
  private _toDoList: BehaviorSubject<ToDoItem[]>;
  private baseUrl: string;
  private dataStore: {
    toDoList: ToDoItem[];
  };

  constructor(private _http: Http) {
    this.baseUrl = '/api/todolist/';
    this.dataStore = { toDoList: [] };
    this._toDoList = <BehaviorSubject<ToDoItem[]>>new BehaviorSubject([]);
    this.toDoList = this._toDoList.asObservable();

  }

  GetAllToDo() {
    this._http.get(this.baseUrl)
      .map(response => response.json())
      .subscribe(data => {
        this.dataStore.toDoList = data;
        this._toDoList.next(Object.assign({}, this.dataStore).toDoList);
      }, error => console.log('Não foi possivel carregar a lista de ToDo.'));
  };

  CreateToDo(newTodo: ToDoItem) {
    debugger;
    var headers = new Headers();
    headers.append('Content-Type', 'application/json; charset=utf-8');

    this._http.post(`${this.baseUrl}Create/`, JSON.stringify(newTodo), { headers: headers })
      .map(response => response.json()).subscribe(data => {
        this.dataStore.toDoList.push(data);
        this._toDoList.next(Object.assign({}, this.dataStore).toDoList);
      }, error => console.log('Nao foi possivel criar ToDo.'));
  };

  UpdateToDo(newTodo: ToDoItem) {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json; charset=utf-8');

    this._http.put(`${this.baseUrl}Update/`, newTodo, { headers: headers })
      .map(response => response.json()).subscribe(data => {
        this.dataStore.toDoList.forEach((t, i) => {
          if (t.id === data.id) { this.dataStore.toDoList[i] = data; }
        });
      }, error => console.log('Nao foi possivel alterar ToDo.'));
  };

  DeleteToDo(todoId: number) {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json; charset=utf-8');

    this._http.delete(`${this.baseUrl}${todoId}`, { headers: headers }).subscribe(response => {
      this.dataStore.toDoList.forEach((t, i) => {
        if (t.id === todoId) { this.dataStore.toDoList.splice(i, 1); }
      });

      this._toDoList.next(Object.assign({}, this.dataStore).toDoList);
    }, error => console.log('Nao foi possivel excluir ToDo.'));
  }
}

export class ToDoItem {
  public id: number;
  public task: string;
  public done: boolean;
}  
