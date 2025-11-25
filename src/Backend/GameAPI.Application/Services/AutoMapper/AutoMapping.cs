using AutoMapper;
using GameAPI.Communication.Requests;
using GameAPI.Domain.Entities;

namespace GameAPI.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }
        private void RequestToDomain()
        {
            CreateMap<RequestRegisterPlayerJson, Player>();
        }
    }
}
