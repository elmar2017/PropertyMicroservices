using System.Reflection;

namespace Property.API.Swagger
{
    public class ClassTypeReader
    {
        public static List<Type> GetDtoTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var dtoTypes = assembly.GetTypes()
                .Where(type => type.Name.EndsWith("Dto", StringComparison.OrdinalIgnoreCase))
                .ToList();

            return dtoTypes;
        }
    }
}
