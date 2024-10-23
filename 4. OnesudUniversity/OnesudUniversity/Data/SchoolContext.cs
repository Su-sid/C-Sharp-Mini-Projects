using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnesudUniversity.Models;
//using System.Data.Entity.ModelC;


namespace OnesudUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<OnesudUniversity.Models.Student> Student { get; set; } = default!;
  
        public DbSet<OnesudUniversity.Models.Enrollment> Enrollment { get; set; }
        public DbSet<OnesudUniversity.Models.Course> Course { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
