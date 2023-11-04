using E_ticket.DLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.ConFigurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.Property(m => m.ImageURL).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Price).HasColumnType("decimal").IsRequired();
            builder.Property(m => m.StartDate).HasDefaultValue(DateTime.Now);
            builder.HasMany(m => m.Movie_Actor)
                .WithOne(a => a.Movies);
        }
    }
}
