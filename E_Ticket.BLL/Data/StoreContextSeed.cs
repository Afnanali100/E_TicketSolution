using E_ticket.DLL.Contexts;
using E_ticket.DLL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_ticket.BLL.Data
{
    public static class StoreContextSeed
    {
       
        public static async  Task Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<E_TicketDbContext>();
                context.Database.EnsureCreated();
                
                if (!context.Actors.Any())
                {
                    var Actors = File.ReadAllText("../E_Ticket.BLL/Data/DataSeed/actors.json");
                    var data = JsonSerializer.Deserialize<List<Actor>>(Actors);

                    if (data?.Count() > 0)
                    {
                        foreach (var actor in data)
                        {
                            await context.Actors.AddAsync(actor);

                            await context.SaveChangesAsync();

                        }
                    }

                }


                if (!context.Producers.Any())
                {
                    var producers = File.ReadAllText("../E_Ticket.BLL/Data/DataSeed/producers.json");
                    var data = JsonSerializer.Deserialize<List<Producer>>(producers);

                    if (data?.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            await context.Producers.AddAsync(item);

                            await context.SaveChangesAsync();

                        }
                    }

                }


                if (!context.Cinemas.Any())
                {
                    var cinemas = File.ReadAllText("../E_Ticket.BLL/Data/DataSeed/cinemas.json");
                    var data = JsonSerializer.Deserialize<List<Cinema>>(cinemas);

                    if (data?.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            await context.Cinemas.AddAsync(item);

                            await context.SaveChangesAsync();

                        }
                    }


                }







                if (!context.Movies.Any())
                {
                    var movies = File.ReadAllText("../E_Ticket.BLL/Data/DataSeed/movies.json");
                    var data = JsonSerializer.Deserialize<List<Movie>>(movies);

                    if (data?.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            await context.Movies.AddAsync(item);

                            await context.SaveChangesAsync();

                        }
                    }

                }


                if (!context.ActorsMovies.Any())
                {
                    var MoviesActor = File.ReadAllText("../E_Ticket.BLL/Data/DataSeed/Actors_Movies.json");
                    var data = JsonSerializer.Deserialize<List<Movies_Actors>>(MoviesActor);

                    if (data?.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            await context.ActorsMovies.AddAsync(item);

                            await context.SaveChangesAsync();

                        }
                    }

                }






         
            }

        } 

    }
}
