using System;
using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length allowed is 2")]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
