using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskVueJsASPNET5.EntityDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User[]
        //        {
        //        new User { Id=1, Name="Tom", Surname="Marly"},
        //        new User { Id=2, Name="Alice", Surname="Vine"},
        //        new User { Id=3, Name="Sam", Surname="Smitt"}
        //        });
        //}
    }
}

