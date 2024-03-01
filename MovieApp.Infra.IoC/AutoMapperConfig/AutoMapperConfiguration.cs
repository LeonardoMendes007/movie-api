using AutoMapper;
using MovieApp.Application.AutoMapper;

namespace MovieApp.Infra.IoC.AutoMapperConfig;
public class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMappings()
        => new(mc =>
        {
            mc.AddProfiles(new List<Profile>() { new RequestToDomain(), new DomainToResponse() });
        });
}
