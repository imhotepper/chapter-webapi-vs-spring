package com.todos.api.repositories;

import com.todos.api.models.Todo;
import org.springframework.data.jpa.repository.JpaRepository;

public interface TodosRepository extends JpaRepository<Todo,Integer> {
}

