using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using LibraryMananementDemo.Entities;
using LibraryMananementDemo.GraphQLServices;
using LibraryMananementDemo.GraphQLTypes;
using LibraryMananementDemo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryMananementDemo
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
            services.AddDbContext<LibraryGraphQLDemoContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                           .WithMethods("GET", "POST")
                           .WithOrigins("http://localhost:3000");
                });
            });
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services
                    .AddDataLoaderRegistry()
                    .AddGraphQL(sp => SchemaBuilder.New()
                    .AddServices(sp)
                    .AddObjectType<AuthorInputType>()
                    .AddObjectType<BookInputType>()
                    .AddType<BookType>()
                    .AddType<AuthorType>()
                    .AddQueryType<LibraryQuery>()    
                    .AddMutationType<LibraryMutation>()
                    .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseCors("DefaultPolicy");
            app.UseHttpsRedirection();
            app.UsePlayground();
            app.UseGraphQL();
        }
    }
}
