using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using rawdata_pp_2.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace rawdata_pp_2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //string _key = "AasdasdaASFF78SDsdasDSADAF";
            
            services.AddMvc();
            // this is the actual injection of the dataservice obeying the IDataService interface
            services.AddSingleton<IDataService, DataService>();
            var key = Encoding.UTF8.GetBytes(Configuration["security:key"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(option =>
               {
                   option.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false,
                       ValidateIssuer = false,
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ClockSkew = TimeSpan.Zero
                   };
               });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            MapperConfig();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseFileServer();
            app.UseMvc();

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
        private void MapperConfig()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostModel>();
                cfg.CreateMap<Post, PostListModel>()
                    .ForMember(x => x.Comment, opt => opt.MapFrom(src => src.Comment.Id));

                cfg.CreateMap<SearchResult, SearchResultListModel>();

                cfg.CreateMap<ExactMatchResult, ExactSearchResultListModel>();
                cfg.CreateMap<Bookmark, BookmarkListModel>();
            });
        }
    }
}
