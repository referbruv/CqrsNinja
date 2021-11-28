using AutoMapper;
using CqrsNinja.Contracts.Data.Entities;
using CqrsNinja.Contracts.DTO;

namespace CqrsNinja.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ninja, NinjaDTO>();
        }
    }
}
