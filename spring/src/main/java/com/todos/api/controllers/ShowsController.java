package com.todos.api.controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

@RestController
public class ShowsController {

    @GetMapping(value = "api/shows")
    public ResponseEntity<?> get(){
        RestTemplate restTemplate = new RestTemplate();
        return ResponseEntity.ok(
                restTemplate
                .getForEntity("http://jsnoise.herokuapp.com/api/showslist", String.class)
                .getBody());
    }
}
