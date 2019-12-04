package com.todos.api.models;


import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.NotNull;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Data
//@Builder
public class Todo {
    @Id @GeneratedValue
    private int Id;
    @NotNull
    //@Length(min = 2,message = "Min length allowed is 2")
    private String title;
    private boolean isCompleted;
}
