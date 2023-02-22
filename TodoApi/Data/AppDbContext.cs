using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoModel>().HasData(new TodoModel()
            {
                Id = 1,
                Description = "Take out trash",
                Completed = true,
            });

            modelBuilder.Entity<TodoModel>().HasData(new TodoModel()
            {
                Id = 2,
                Description = "Mow lawn",
                Completed = false,
            });

            modelBuilder.Entity<TodoModel>().HasData(new TodoModel()
            {
                Id = 3,
                Description = "Pay bills",
                Completed = false,
            });
        }
    }
}
