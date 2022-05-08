using BTE3PV_HFT_2021221.Data;
using BTE3PV_HFT_2021221.Endpoint.Services;
using BTE3PV_HFT_2021221.Logic;
using BTE3PV_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BTE3PV_HFT_2021221.Endpoint
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IBookLogic, BookLogic>();
            services.AddTransient<IAuthorLogic, AuthorLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<LibraryDbContext, LibraryDbContext>();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BTE3PV_HFT_2021221.Endpoint", Version = "v1" });
                
            });
        }

        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BTE3PV_HFT_2021221.Endpoint v1"));
            }
            


            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:22573"));


            app.UseRouting();

            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
          
        }
    }
}
