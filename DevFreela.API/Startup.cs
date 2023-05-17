using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DevFreela.API
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
            //EXCLUIR PARA USAR O MEDIATR
            //services.Configure<OpeningTimeOption>(Configuration.GetSection("OpeningTime"));
            //services.AddScoped<ExampleClass>(e => new ExampleClass { Name = "Initial Stage" });


            //services.AddScoped<IProjectService, ProjectService>();
            //services.AddScoped<IUsersService, UsersService>();
            //services.AddScoped<ISkillService, SkillService>();

            //USAR SQL - VER AULAS DE MIGRATIONS
            //var connectionString = Configuration.GetConnectionString("DevFreelaCs");
            //services.AddDbContext<DevFreelaDbContext>(
            //    options => options.UseSqlServer(connectionString));

            //USAR EFCORE INMEMORY
            services.AddDbContext<DevFreelaDbContext>(
                options => options.UseInMemoryDatabase("DevFreela"));


            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });

            services.AddMediatR(typeof(CreateProjectCommand));
            services.AddMediatR(typeof(CreateUserCommand));

            //REGISTRAR INJEÇÃO DE DEPENDENCIA DOS REPOSITORIOS (Refatorando as Queries - Parte 1, ver comentários)
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IUserRepository, UserRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
