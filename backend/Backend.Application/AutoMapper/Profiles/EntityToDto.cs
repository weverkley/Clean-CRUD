using AutoMapper;
using Backend.Application.DTO;
using Backend.Domain.Entities;

namespace Backend.Application.AutoMapper.Profiles
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap();

            CreateMap<Address, AddressDTO>()
               .ReverseMap();
        }
    }
}
