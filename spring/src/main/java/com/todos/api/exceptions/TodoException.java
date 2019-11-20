package com.todos.api.exceptions;

import com.todos.api.services.TodosService;

public class TodoException extends RuntimeException {
    public TodoException(){super();}
    public TodoException(final String message){super(message);}
}
