package com.todos.api.controllers;

import com.sun.jndi.toolkit.url.Uri;
import com.todos.api.models.Todo;
import com.todos.api.services.TodosService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import javax.xml.ws.Response;
import java.util.List;

@RestController
//@RequestMapping()
public class TodosController {

    @Autowired
    TodosService _service;

    @GetMapping(value = "/api/todos")
    public ResponseEntity< List<Todo>> get(){
        return  ResponseEntity.ok(  _service.GetAll());
    }
    @GetMapping(value = "/api/todos/{id}")
    public ResponseEntity<?> get(@PathVariable Integer id){
        return  ResponseEntity.ok(_service.Get(id));
    }

    @PostMapping(value = "/api/todos")
    public ResponseEntity<?> post(@RequestBody Todo todo){
        _service.create(todo);
        return  ResponseEntity.created(null).body(todo);
    }

    @PutMapping(value = "/api/todos/{id}")
    public ResponseEntity<Todo> put(@PathVariable Integer id, @RequestBody Todo todo){
        Todo td = _service.update(id,todo);
        return ResponseEntity.ok(td);
    }

    @DeleteMapping(value = "/api/todos/{id}")
    public ResponseEntity<?> delete(@PathVariable Integer id){
        _service.delete(id);
       return ResponseEntity.accepted().build();
    }
}
