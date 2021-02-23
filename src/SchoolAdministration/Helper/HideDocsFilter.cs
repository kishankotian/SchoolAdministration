using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SchoolAdministration.Helper
{
    public class HideDocsFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var path in swaggerDoc.Paths)
            {
                if (path.Key.Contains("dotnetify"))
                    swaggerDoc.Paths.Remove(path.Key);
            }
        }
    }
}
