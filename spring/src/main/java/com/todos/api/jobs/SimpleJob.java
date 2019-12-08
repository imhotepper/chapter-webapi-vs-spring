package com.todos.api.jobs;


import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import java.util.Date;

@Component
public class SimpleJob {
    //vod return type && no parameters
    //@Scheduled(cron = "0 15 10 15 * ?")
    @Scheduled( fixedRate = 5000, initialDelay = 100)
    public void Execute(){
        System.out.println("Job executed at: " + new Date());
    }
}
