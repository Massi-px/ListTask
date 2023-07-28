using ListTask.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorAppDbContext.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        //Gestion de la table Task
        public DbSet<TaskItem> Task { get; set; }
    }
};