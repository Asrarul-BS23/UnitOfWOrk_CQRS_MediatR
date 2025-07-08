
using AutoMapper;
using PracticingCQRSMediatR.Application.UseCases.Products.Commands.CreateProductCommand;
using PracticingCQRSMediatR.Application.UseCases.Products.Queries.GetAllProductQuery;
using PracticingCQRSMediatR.Domain.Models;

namespace PracticingCQRSMediatR.Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ProductVM, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>().ReverseMap();
    }
}
