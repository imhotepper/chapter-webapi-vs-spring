package com.todos.api.services;

import java.util.*;
import com.todos.api.models.Todo;
import com.todos.api.repositories.TodosRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TodosService {

    private final TodosRepository _db;

    public TodosService(TodosRepository repository){
        _db = repository;
    }

    public List<Todo> getAll(){ return _db.findAll();}
    public Optional<Todo> get(int id){
        return _db.findById(id);}

    public Todo create(Todo todo) {
        todo = _db.saveAndFlush(todo);
        return todo;
    }

    public Todo update(int id, Todo todo) {

        Optional<Todo> td =  _db.findById(id);
        if (td.isPresent()){
            td.get().setCompleted(todo.isCompleted());
            td.get().setTitle(todo.getTitle());
            _db.saveAndFlush(td.get());
        }
        return td.get();
    }

    public void delete(int id){
        _db.deleteById(id);
    }
}

