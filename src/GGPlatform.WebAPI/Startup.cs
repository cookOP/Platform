using GGPlatform.Application.IService;
using GGPlatform.Application.Service;
using GGPlatform.Infrastructure.Data;
using GGPlatform.Infrastructure.Repository;
using GGPlatoform.Domain.Entity.User;
using GGPlatoform.Domain.Interface;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Text;

namespace GGPlatform.WebAPI
{
    public class Startup
    {
        public static ILoggerRepository repository
        {
            get; set;
        }
        public Startup(IConfiguration configuration)
        {
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));          

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //SqlServer 
            //services.AddDbContext<GGPatlformContext>(options => options.UseSqlServer(connection));
            //MySql
            services.AddDbContext<GGPatlformContext>(options =>
                options.UseMySql(Configuration["ConnectionStrings:Dbconnection"]));
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IUserService, UserService>();          
            services.AddMvc().AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            # region 注入JWT
            //注入JWT
            var tokenValidationParameters =  new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
            #endregion

            #region Swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GGPlatform", Version = "v1" });
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TwBusManagement API V1");               
            });
            //用户授权
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
