using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            if (webHost != null)
            {
                //Migration  DB Schema
                using (var scope = webHost.Services.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<SchoolDBContext>())
                    {
                        try
                        {
                            appContext.Database.Migrate();
                        }
                        catch (Exception ex)
                        {
                            //Log errors or do anything you think it's needed
                            throw;
                        }
                    }
                }
            }
            return webHost;
        }
    }
}
