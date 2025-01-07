using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Database.Configuration;
using APIDemo.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Database
{
    public class APIDemoContext(DbContextOptions<APIDemoContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .HasDefaultSchema("APIDemo")
                .ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}