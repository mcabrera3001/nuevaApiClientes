using nuevaApiClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace nuevaApiClientes.Context
{
        public class ClientesContext : DbContext
        {
        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
            {

            }
            public DbSet<Clientes> Clientes { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Clientes>().ToTable("clientes");
                    //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
                    //modelBuilder.Entity<Student>().ToTable("Student");
                }
        }
}
