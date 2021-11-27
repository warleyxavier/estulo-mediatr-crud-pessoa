using estulo_mediatr_crud_pessoa.CommandHandlers;
using estulo_mediatr_crud_pessoa.Commands;
using estulo_mediatr_crud_pessoa.Models;
using estulo_mediatr_crud_pessoa.NotificationHandlers;
using estulo_mediatr_crud_pessoa.Notifications;
using estulo_mediatr_crud_pessoa.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            services.AddSingleton<IRepository<Person>, PersonRepository>();

            services.AddScoped<PersonCommandHandler>();
            services.AddScoped<IRequestHandler<CreatePersonCommand, Unit>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand, Unit>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<DeletePersonCommand, Unit>, PersonCommandHandler>();

            services.AddScoped<PersonNotificationHandler>();
            services.AddScoped<INotificationHandler<PersonCreatedNotification>, PersonNotificationHandler>();
            services.AddScoped<INotificationHandler<PersonUpdatedNotification>, PersonNotificationHandler>();
            services.AddScoped<INotificationHandler<PersonDeletedNotification>, PersonNotificationHandler>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
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
