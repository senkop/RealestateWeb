using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Try.Configuration;
using Try.DAL.Database;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authorization;
using Try.BL.Mapper;
using Try.DAL.Entity;
using Try.Services;
using Try.Api.Services;
//using Try.Services;

namespace Try
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //        public IConfiguration Configuration { get; }

        //        // This method gets called by the runtime. Use this method to add services to the container.
        //        public void ConfigureServices(IServiceCollection services)
        //        {
        //            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
        //          //  services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        //            services.AddDbContextPool<DbContainer>(opts =>
        //          opts.UseSqlServer(Configuration.GetConnectionString("SharpDbConnection")));


        //           // services.AddAutoMapper(x => x.AddProfile(new DomainProfile())); 

        //           //x// services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbContainer>(); 


        //                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

        //            var tokenValidationParams = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = false,
        //                ValidateAudience = false,
        //                ValidateLifetime = true,
        //                RequireExpirationTime = false,
        //                ClockSkew = TimeSpan.Zero
        //            };
        //            //x  //services.AddMvc(options =>
        //            //{
        //            //    options.SuppressAsyncSuffixInActionNames = false;
        //            //});
        //            services.AddSingleton(tokenValidationParams);

        //            services.AddAuthentication(options => {
        //                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //            })
        //            .AddJwtBearer(jwt => {
        //                jwt.SaveToken = true;
        //                jwt.TokenValidationParameters = tokenValidationParams;
        //            });

        //            services.AddIdentity<Users, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
        //                        .AddEntityFrameworkStores<DbContainer>();
        //            services.AddCors(); 
        //            services.AddControllers();
        //            services.AddControllers().AddNewtonsoftJson();
        //            services.AddSwaggerGen(c =>
        //            {
        //                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstate", Version = "v1" });
        //                c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
        //                {
        //                    Type = SecuritySchemeType.Http,
        //                    Scheme = JwtBearerDefaults.AuthenticationScheme.ToLowerInvariant(),
        //                    In = ParameterLocation.Header,
        //                    Name = "Authorization",
        //                    BearerFormat = "JWT",
        //                    Description = "JWT Authorization header using the Bearer scheme."
        //                });

        //                c.OperationFilter<AuthResponsesOperationFilter>();
        //            });

        //            //services.AddCors(options =>
        //            //{
        //            //    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        //            //});
        //            services.AddCors(options =>
        //            {
        //                options.AddDefaultPolicy( builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        //            });

        //            services.AddAuthorization(options =>
        //            {
        //                options.AddPolicy("DepartmentPolicy",
        //                    policy => policy.RequireClaim("department"));
        //            });
        //        }

        //        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //        {
        //            app.UseCors(Options => Options.WithOrigins("http://localhost:11447")
        //            .AllowAnyMethod()
        //            .AllowAnyHeader());
        //            app.UseCors();
        //            if (env.IsDevelopment())
        //            {
        //                app.UseDeveloperExceptionPage();
        //                app.UseSwagger();
        //                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp v1"));
        //            }

        //            app.UseStaticFiles();
        //            app.UseHttpsRedirection();

        //            app.UseRouting();
        //            app.UseAuthentication();
        //            app.UseAuthorization();
        //            app.UseCors();
        //            //app.UseCors("Open");

        //            app.UseEndpoints(endpoints =>
        //            {
        //                endpoints.MapControllers();
        //            });
        //        }
        //    }

        //    internal class AuthResponsesOperationFilter : IOperationFilter
        //    {
        //        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        //        {
        //            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
        //                                .Union(context.MethodInfo.GetCustomAttributes(true));

        //            if (attributes.OfType<IAllowAnonymous>().Any())
        //            {
        //                return;
        //            }


        //        }
        //    }
        //}
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddMvc();


            //services.AddTransient<IEmailServices, EmailServices>();

            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IMailService, SendGridMailService>();


            services.AddDbContextPool<DbContainer>(opts =>
          opts.UseSqlServer(Configuration.GetConnectionString("SharpDbConnection")));

            var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParams);

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParams;
            });

            services.AddIdentity<Users, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultTokenProviders()
                        .AddEntityFrameworkStores<DbContainer>();


            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbContainer>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstate", Version = "v1" });
                c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme.ToLowerInvariant(),
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.OperationFilter<AuthResponsesOperationFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DepartmentPolicy",
                    policy => policy.RequireClaim("department"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
              //c  app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("Open");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                .Union(context.MethodInfo.GetCustomAttributes(true));

            if (attributes.OfType<IAllowAnonymous>().Any())
            {
                return;
            }

            var authAttributes = attributes.OfType<IAuthorizeData>();

            if (authAttributes.Any())
            {
                operation.Responses["401"] = new OpenApiResponse { Description = "Unauthorized" };

                if (authAttributes.Any(att => !String.IsNullOrWhiteSpace(att.Roles) || !String.IsNullOrWhiteSpace(att.Policy)))
                {
                    operation.Responses["403"] = new OpenApiResponse { Description = "Forbidden" };
                }

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "BearerAuth",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                };
            }
        }
    }
}