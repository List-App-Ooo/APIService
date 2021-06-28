using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIService.Models;
using APIService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace APIService
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

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddScoped<IListUIService, ListUIService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IHttpClient, TypedHttpClient>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddHttpClient("List", client => {
                client.BaseAddress = new Uri("https://localhost:5001");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });

            services.AddHttpClient("Note", client => {
                client.BaseAddress = new Uri("https://localhost:5002");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });

            services.AddHttpClient("Todo", client => {
                client.BaseAddress = new Uri("https://localhost:5003");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");
            });
            services.AddScoped<ServiceConfig>(m => {
                return new ServiceConfig
                {
                    ListUrl = "api/list",
                    NoteUrl = "api/note",
                    TodoUrl = "api/todo",
                    ListClient = "List",
                    NoteClient = "Note",
                    TodoClient = "Todo"    
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
