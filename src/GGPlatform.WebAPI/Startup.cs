using AutoMapper;
using GGPlatform.Application.IService;
using GGPlatform.Application.Service;
using GGPlatform.Infrastructure;
using GGPlatform.Infrastructure.Data;
using GGPlatform.Infrastructure.Repository;
using GGPlatform.WebAPI.AutoMapper;
using GGPlatform.WebAPI.Filter;
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
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Text;

namespace GGPlatform.WebAPI
{
    public class Startup
    {
        public static ILoggerRepository _repository
        {
            get; set;
        }
        public Startup(IConfiguration configuration)
        {
            _repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(_repository, new FileInfo("log4net.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private MapperConfiguration _mapperConfiguration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            switch (Configuration["ConnectionStrings:Type"])
            {
                case "SqlServer":
                    services.AddDbContext<GGPatlformContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Dbconnection"]));
                    break;
                case "MySql":
                    services.AddDbContext<GGPatlformContext>(options =>
                        options.UseMySql(Configuration["ConnectionStrings:Dbconnection"]));
                    break;
            }
            #region IOC
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorityManagementRepository, AuthorityManagementRepository>();
            services.AddScoped<IAuthorityManagementService, AuthorityManagementService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            #region Json 
            services.AddMvc().AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            #endregion

            #region JWT           
            var tokenValidationParameters = new TokenValidationParameters
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

            #region AutoMapper
            //install-package   AutoMapper
            //install - package   AutoMapper.Extensions.Microsoft.DependencyInjection
            //_mapperConfiguration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutomapperProfile());
            //});
            //services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

            //var config = new MapperConfiguration(cfg =>
            // {
            //     cfg.AddProfile<AutomapperProfile>();
            // });
            //services.AddTransient(config);
            //services.AddSingleton(config);
            //services.AddScoped<IMapper, Mapper>();
            services.AddAutoMapper();
            #endregion

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<ValidateModelAttribute>();
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            //AutoMapper 自己定义注册
            Mappings.RegisterMappings();
            //用户授权
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
