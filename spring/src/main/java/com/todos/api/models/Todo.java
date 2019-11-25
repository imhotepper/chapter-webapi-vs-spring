package com.todos.api.models;


import lombok.*;
import javax.persistence.*;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotNull;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Builder
public class Todo {
    @Id @GeneratedValue
    private int Id;
    @NotNull
    @Min(value = 2,message = "Minimum length allowed is 2")
    private String title;
    private boolean isCompleted;
}
