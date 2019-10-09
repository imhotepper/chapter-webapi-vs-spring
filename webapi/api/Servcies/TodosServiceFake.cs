using System;
using System.Collections.Generic;
using api.Model;
using System.Linq;

namespace api.Servcies
{
    public class TodosServiceFake
    {
        List<Todo> _todos = new List<Todo> {
        new Todo{Id=1, Title="First todo!", IsCompleted = false} };

        public List<Todo> GetAll() => _todos;
        public Todo Get(int id) =>
            _todos.Single(x => x.Id == id);
        public void Create(Todo todo) {
            todo.Id = _todos.Count + 1;
            _todos.Add(todo);
        }
        
        public Todo Update(int id,Todo todo)
        {
            var td = _todos.FirstOrDefault(x => x.Id == id);
            if (td != null)
            {
                td.Title = todo.Title;
                td.IsCompleted = todo.IsCompleted;
            }
            return td;
        }
        public void Delete(int id) =>
            _todos.Remove(_todos.Single(x => x.Id == id));
    }
}
