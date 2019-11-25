package com.todos.api.models;


import lombok.*;
import javax.persistence.*;
import javax.validation.constraints.Max;
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
    @Max(value = 250,message = "Max length allowed is 250")
    private String title;
    private boolean isCompleted;
}
