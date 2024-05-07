
using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class ExamenContext:DbContext
    {

        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Banque> Banques { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionRetraite> TransactionRetraites { get; set; }
        public DbSet<TransactionTransfert> transactionTransferts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Initial Catalog=AirportManagementDB1;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;");




        }
        //appel des classe de config FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
           
        }
    }
}
