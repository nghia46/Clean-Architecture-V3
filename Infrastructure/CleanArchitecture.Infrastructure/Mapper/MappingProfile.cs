using AutoMapper;
using CleanArchitecture.Application.Commons.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}