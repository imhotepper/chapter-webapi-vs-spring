package com.todos.api.services;

import com.todos.api.models.Todo;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class TodosServiceFake {
    private List<Todo> _todos = new ArrayList<>();

    {
        _todos. add(new Todo(1,"First todo", false));;
    };

    public List<Todo> GetAll(){ return _todos;}
    public Todo Get(int id){
        return _todos.stream().filter(x->x.getId() == id).findFirst().get();}

    public Todo create(Todo todo) {
        todo.setId(_todos.size() + 1);
        _todos.add(todo);
        return todo;
    }

    public Todo update(int id, Todo todo) {

        Todo td = _todos.stream().filter(x-> x.getId() == id)
                .findFirst().get();
        if (td != null){
            td.setCompleted(todo.isCompleted());
            td.setTitle(todo.getTitle());
        }
        return td;
    }

    public void delete(int id){
        _todos.remove(
                _todos.stream().filter(x-> x.getId() == id)
                .findFirst().get());
    }
}
