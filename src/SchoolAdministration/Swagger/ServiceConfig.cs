using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SchoolAdministration.Helper;

namespace SchoolAdministration.Swagger
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            return services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = GlobalResource.APINAME,
                    Version = "v1"
                });
                o.DocumentFilter<HideDocsFilter>();
            });
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            return
                 app.UseSwagger()
                 .UseSwaggerUI(o =>
                 {
                     o.SwaggerEndpoint("/swagger/v1/swagger.json", $"{GlobalResource.APINAME} v1");
                 });
        }
    }
}
