using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            //Retrieve all classes which inherit IMapFrom interface
            var mapFromTypes = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            //Create instance of each type and execute 'Mapping' method
            foreach (var type in mapFromTypes)
            {
                var instance = Activator.CreateInstance(type); //Creates the instance
                var methodInfo = type.GetMethod("Mapping"); //Attempts to retrieve the Mapping method
                methodInfo?.Invoke(instance, new object[] { this }); //Executes the method and passes this profile as it's argument
            }
        }
    }
}
