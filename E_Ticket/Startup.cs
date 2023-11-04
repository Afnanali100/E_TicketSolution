using E_ticket.BLL.Data;
using E_ticket.BLL.Interfaces;
using E_ticket.BLL.Repositries;
using E_ticket.DLL.Contexts;
using E_ticket.DLL.Models;
using E_Ticket.BLL.Interfaces;
using E_Ticket.BLL.Repositries;
using E_Ticket.Profiles;
using E_Ticket.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace E_Ticket
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<E_TicketDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddAutoMapper(m => m.AddProfile(new GenericMapper<Movie,MovieViewModel>()));
            services.AddAutoMapper(m => m.AddProfile(new GenericMapper<Actor, ActorViewModel>()));
            services.AddAutoMapper(m => m.AddProfile(new GenericMapper<Producer, ProducerViewModel>()));
            services.AddAutoMapper(m => m.AddProfile(new GenericMapper<Cinema, CinemaViewModel>()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            await StoreContextSeed.Seed(app);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
