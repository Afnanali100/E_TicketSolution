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
    public class Movies_ActorsConfigurations : IEntityTypeConfiguration<Movies_Actors>
    {
        public void Configure(EntityTypeBuilder<Movies_Actors> builder)
        {
            builder.HasKey(xm => new
            {
                xm.MovieId,
                xm.ActorId
            });

            builder.HasOne(ma => ma.Movies).WithMany(m => m.Movie_Actor);

            builder.HasOne(ma => ma.Actors).WithMany(m => m.Movie_Actor);

        }
    }
}
