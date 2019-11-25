package com.todos.api.models;


import lombok.*;
import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Length;
import javax.validation.constraints.NotNull;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Builder
@Data
public class Todo {
    @Id @GeneratedValue
    private int Id;
    @NotNull
    @Length(min = 2,message = "Min length allowed is 2")
    private String title;
    private boolean isCompleted;
}
