package com.todos.api;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableScheduling;

@SpringBootApplication
@EnableScheduling
public class ApiApplication {

	public static void main(final String[] args) {

		SpringApplication.run(ApiApplication.class, args);
	}

}
