using AutoMapper;
using Automation.Core.Models.Request;
using Automation.Core.Models.Response;

namespace Automation.Core.Extensions
{
    public static class Mapper
    {
        public static UserRequestDto CreateUserRequestDtoBasedOnResponse(this UserResponseDto source)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserResponseDto, UserRequestDto>()
                    .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                    .ForMember(d => d.Email, d => d.MapFrom(s => s.Email))
                    .ForMember(d => d.Gender, d => d.MapFrom(s => s.Gender))
                    .ForMember(d => d.Status, d => d.MapFrom(s => s.Status))
                );

            return config.CreateMapper().Map(source, new UserRequestDto());
        }
    }
}
