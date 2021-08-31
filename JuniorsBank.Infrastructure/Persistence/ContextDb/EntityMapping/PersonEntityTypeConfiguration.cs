using JuniorsBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorsBank.Infrastructure.Persistence.ContextDb.EntityMapping
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder
            //    .ToTable(typeof(Person).Name);

            builder
                .HasKey(x => x.Id);
            // Para configurar o nome da chave se necessário...
            //.HasName("")

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("FirstName");

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName");

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password");

            builder
                .HasOne(x => x.CheckingAccount)
                .WithOne(x => x.Person)
                .HasForeignKey<CheckingAccount>(x => x.PersonId);
        }
    }
}
