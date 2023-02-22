using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Section1Group6.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            //Leave blank for now
        }
        //Create Tables
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryType = "Home" },
                new Category { CategoryID = 2, CategoryType = "School" },
                new Category { CategoryID = 3, CategoryType = "Work" },
                new Category { CategoryID = 4, CategoryType = "Church" }
            );

            mb.Entity<Task>().HasData(

                new Task
                {
                    TaskID = 1,
                    CategoryID = 1,
                    QuadrantNumber = 1,
                    TaskTitle = "Do your chores",
                    Completed = false,
                    DueDate = "2023/08/06",
                    TaskNotes = ""
                }
            );
        }
    }
}