using AutoMapper;
using Backend.Application.AutoMapper.Profiles;

namespace Backend.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToDto());
            });
            return mapperConfiguration;
        }
    }
}
