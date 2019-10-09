using System;
using System.Collections.Generic;
using api.Model;
using System.Linq;

namespace api.Servcies
{
    public class TodosService
    {
        private readonly AppDb _db;

        public TodosService(){}
        public TodosService(AppDb db) => _db = db;
        
        public virtual List<Todo> GetAll() =>
            _db.Todos.OrderByDescending(x=>x.Id).ToList();
        public Todo Get(int id) =>
            _db.Todos.Single(x => x.Id == id);
      
        public void Create(Todo todo) {
            _db.Todos.Add(todo);
            _db.SaveChanges();
        }
        
        public Todo Update(int id,Todo todo)
        {
            var td = _db.Todos.FirstOrDefault(x => x.Id == id);
            if (td != null)
            {
                td.Title = todo.Title;
                td.IsCompleted = todo.IsCompleted;
                _db.SaveChanges();
            }
            return td;
        }

        public void Delete(int id)
        {
            _db.Todos.Remove(new Todo {Id = id});
            _db.SaveChanges();
        }
    }
}
