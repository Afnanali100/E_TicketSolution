using E_ticket.DLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.ConFigurations
{
    internal class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Logo).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(100);
        }
    }
}
