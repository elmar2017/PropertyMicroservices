using Microsoft.OpenApi.Models;
using Property.API.Dtos.Home;
using Property.API.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Property.API.Swagger
{
    public class CustomDocumentFilter : IDocumentFilter
    {

        private readonly List<Type> types;

        public CustomDocumentFilter()
        {
            types = ClassTypeReader.GetDtoTypes();
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var type in types)
            {
                context.SchemaGenerator.GenerateSchema(type, context.SchemaRepository);
            }

        }
    }
}
