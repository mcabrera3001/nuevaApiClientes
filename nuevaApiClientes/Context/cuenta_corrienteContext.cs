using Microsoft.EntityFrameworkCore;
using nuevaApiClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nuevaApiClientes.Context
{
    public class cuenta_corrienteContext : DbContext 
    {
        public cuenta_corrienteContext(DbContextOptions<cuenta_corrienteContext> options) : base(options)
        {

        }
        public DbSet<cuenta_corriente> cuenta_corriente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cuenta_corriente>().ToTable("cuenta_corriente");

        }
    }
}

