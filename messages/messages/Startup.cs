using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using messages.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace messages
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddTransient<IMessageSender>(provider =>
            {
                if (DateTime.Now.Hour >= 12) return new EmailMessageSender();
                else return new SmsMessageSender();
            });
            services.AddTransient<MessageService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MessageService messageService)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageService.Send(context));
                
            });
        }
    }
}