package com.todos.api.models;


import lombok.*;
import javax.persistence.*;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
public class Todo {
    @Id @GeneratedValue
    private int Id;
    private String title;
    private boolean isCompleted;
}
