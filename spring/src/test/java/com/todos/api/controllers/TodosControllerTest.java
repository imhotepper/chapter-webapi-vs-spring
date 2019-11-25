package com.todos.api.controllers;

import com.todos.api.models.Todo;
import com.todos.api.services.TodosService;
import org.hamcrest.core.Is;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import java.util.Arrays;
import java.util.List;

import static org.hamcrest.collection.IsCollectionWithSize.hasSize;
import static org.mockito.BDDMockito.given;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@WebMvcTest(TodosController.class)
//@TestPropertySource(
//        locations = "classpath:application-integrationtest.properties")
public class TodosControllerTest {
    @Autowired private MockMvc mvc;
    @MockBean private TodosService service;

    @Test
   public void ca_call_get() throws Exception {
        Todo todo =  Todo.builder() .Id(1).title("first todo").build();
        List<Todo> todos = Arrays.asList(todo);
        given(service.getAll()).willReturn(todos);
        mvc.perform(get("/api/todos")
                .contentType(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(1)))
                .andExpect(MockMvcResultMatchers.jsonPath("$[0].title", Is.is(todo.getTitle())));;
    }
}

