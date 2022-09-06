using AppDemo.Domain;
using AutoMapper;

namespace AppDemo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.Phone, opt => opt.MapFrom(src => src.Phone.StartsWith("+966")? 
                src.Phone.Remove(0, 4) : src.Phone));

            CreateMap<CustomerDto, Customer> ()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Phone, opt => opt.MapFrom(src => $"+966{src.Phone}"));
        }
    }
}
