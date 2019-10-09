package com.todos.api.models;


import lombok.*;

@Getter
@Setter
@Builder
@AllArgsConstructor
public class Todo {
    private int Id;
    private String title;
    private boolean isCompleted;
}
