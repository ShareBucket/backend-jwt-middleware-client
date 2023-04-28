using AutoMapper;
using ShareBucket.DataAccessLayer.Models.Entities;
using ShareBucket.JwtMiddlewareClient.Dto.Responses;

namespace ShareBucket.JwtMiddlewareClient.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<User, AuthenticateResponse>());

            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();
        }
    }
}