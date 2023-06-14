using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalRPaygateService.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPaygateService
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
           services.AddSignalR().AddAzureSignalR("Endpoint=https://signalrpaygate.service.signalr.net;AccessKey=Lve+NdAyy/pCumuQ07TIKouni2Z33Ruit4izSFIswQM=;Version=1.0;");
           services.AddCors(options => {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
            });
            services.AddControllers().AddXmlSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CORSPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseWebSockets();


            app.UseAzureSignalR(builder =>
            {
                builder.MapHub<PaygateHub>("/paygate");
            });

            //app.UseEndpoints(endpoints => {
            //    endpoints.MapHub<PaygateHub>("/paygate");
            //});


            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
                
            });
        }
    }
}
