using Microsoft.EntityFrameworkCore;
using Todos;

namespace ApiTodo
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Todos");
        }
    }
}
