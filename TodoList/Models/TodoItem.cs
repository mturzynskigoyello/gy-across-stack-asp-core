using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Web.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
