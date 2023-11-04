using E_ticket.DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ticket.DLL.ConFigurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a=>a.FullName).IsRequired().HasMaxLength(100);
            builder.Property(a=>a.ProfilePictureURL).IsRequired();
            builder.Property(a => a.Bio).HasMaxLength(200);
        }
    }
}
