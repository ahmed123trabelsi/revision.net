using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;


namespace Examen.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(rt => new { rt.Date, rt.CompteFk, rt.DABFk });
            builder.HasDiscriminator<int>("TransactionType")
               .HasValue<Transaction>(0)
               .HasValue<TransactionRetraite>(1)
               .HasValue<TransactionTransfert>(2);

        }


    }
}
