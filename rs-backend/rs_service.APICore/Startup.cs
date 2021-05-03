using rs_service.Application.Interfaces;
using rs_service.Application.Infrastructure.AutoMapper;
using rs_service.APICore.Filters;
using rs_service.Application.Infrastructure;
using rs_service.Persistence;
using rs_service.Domain.Entities;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using rs_service.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;
using System.Linq;
using rs_service.Application.Property.Queries.GetById;

namespace rs_service.APICore
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add MediatR
            // It's used only one class to access the assembly where MediatR is needed
            services.AddMediatR(typeof(GetByIdQueryHandler).GetTypeInfo().Assembly);

            // Add MediatR Application's Interceptors
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(RequestLogger<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(RequestExceptionCustomHandler<,,>));

            // Inject DbContext using SQL Server Provider
            services.AddDbContext<IDatabaseContext, TheDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TheDatabase"));
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Add cross-layer concerns services
            services.AddSingleton(typeof(IEmailService), typeof(EmailService));

            var validOriginDomains = Configuration.GetSection("ValidOriginDomains").GetChildren().ToArray().Select(x=>x.Value).ToArray();
            
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(validOriginDomains)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });


            // Add filters
            // Add JSON Configuration
            // Add compatibility version
            // Inject Validator classes using FluentValidation
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)

                // The RegisterValidatorsFromAssemblyContaining method registers all validators derived from AbstractValidator 
                // within the assembly that contains the specified type/class. So by providing only one Validator class, the rest will be
                // registered as well
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetByIdQueryValidator>())
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Configure the Memory Cache
            services.AddMemoryCache();


            //// add identity
            //var builder = services.AddIdentityCore<User>(o =>
            //{
            //    // configure identity options
            //    o.Password.RequireDigit = false;
            //    o.Password.RequireLowercase = false;
            //    o.Password.RequireUppercase = false;
            //    o.Password.RequireNonAlphanumeric = false;
            //    o.Password.RequiredLength = 6;
            //});

            //builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            //app.UseAuthentication();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });

            app.UseMvc();
        }
    }
}
