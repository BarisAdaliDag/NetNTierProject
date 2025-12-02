using Microsoft.Extensions.DependencyInjection;
using Project.Bll.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    public static class DtoMapperResolver
    {
        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));

        }
    }
}
