using AutoMapper;
using Customer.Application.Dtos;
using Customer.Domain.Entities;

namespace Customer.Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, CustomerEntity>().ReverseMap();
        }
    }
}
