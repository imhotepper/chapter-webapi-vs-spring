package com.todos.api.controllers;

import com.todos.api.exceptions.TodoException;
import lombok.Builder;
import lombok.Data;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@Data
@Builder
class JSONException{
    private String message;
    private int statusCode;
}

@RestControllerAdvice
public class TodosControllerAdvice {

    @ExceptionHandler(TodoException.class)
    @ResponseStatus(HttpStatus.INTERNAL_SERVER_ERROR)
    public ResponseEntity<?> handleNonExistingHero(TodoException exp) {
        return new ResponseEntity<>( new JSONException( exp.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR.value()), HttpStatus.INTERNAL_SERVER_ERROR);
    }

    @ExceptionHandler(RuntimeException.class)
    @ResponseStatus(HttpStatus.INTERNAL_SERVER_ERROR)
    public ResponseEntity<?> handleNonExistingHero(RuntimeException exp) {
        return new ResponseEntity<>( new JSONException( exp.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR.value()), HttpStatus.INTERNAL_SERVER_ERROR);
    }

}
