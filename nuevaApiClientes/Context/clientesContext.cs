using nuevaApiClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace nuevaApiClientes.Context
{
        public class clientesContext : DbContext
        {
        public clientesContext(DbContextOptions<clientesContext> options) : base(options)
            {

            }
            public DbSet<clientes> clientes { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<clientes>().ToTable("clientes");
                    //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
                    //modelBuilder.Entity<Student>().ToTable("Student");
                }
        }
}
