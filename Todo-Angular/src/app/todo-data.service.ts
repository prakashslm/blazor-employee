import { Injectable } from '@angular/core';
import {Todo} from './todo';

@Injectable({ 
  providedIn: 'root'
})
export class TodoDataService {
  lastId : number = 0;
  todo : Todo[] = [];
  constructor() { }


  addTodo(todo : Todo) : TodoDataService{
    if(!todo.id){
      todo.id = ++this.lastId;
    }
    this.todo.push(todo);
    return this;
  }
  deleteTodo(id : number) : TodoDataService{
    this.todo = this.todo.filter(todo => todo.id !== id);
    return this;
  }
  updateTodoById(id : number, values : Object = {}) : Todo{
    let todo = this.getTodoById(id);
    if(!todo){
      return null;
    }
    Object.assign(todo,values);
    return todo;
  }
  getAllTodos(): Todo[]{
    return this.todo;
  }
  getTodoById(id : number) : Todo{
    return this.todo.filter(todo => todo.id == id).pop();
  }
  toggleTodoComplete(todo : Todo){
    let updateTodo = this.updateTodoById(todo.id, {
      complete : !todo.complete
    });
    return updateTodo;
  }
}
