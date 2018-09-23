using Microsoft.EntityFrameworkCore;

namespace TodoList.Web.Models
{
    public class TodoItemsDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoItemsDbContext(DbContextOptions<TodoItemsDbContext> options)
            : base(options)
        {

        }
    }
}
