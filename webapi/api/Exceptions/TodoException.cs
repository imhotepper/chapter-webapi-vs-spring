

using System;

public class TodoException: ApplicationException{
    public TodoException(){}

    public TodoException(string message): base(message){}
}