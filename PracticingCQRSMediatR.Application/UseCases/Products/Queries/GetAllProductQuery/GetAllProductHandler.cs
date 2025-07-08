using MediatR;
using AutoMapper;
using PracticingCQRSMediatR.Application.Interfaces;

namespace PracticingCQRSMediatR.Application.UseCases.Products.Queries.GetAllProductQuery;

public class GetAllProductHandler: IRequestHandler<GetAllProductQuery, List<ProductVM>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ProductVM>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _unitOfWork.ProductRepository.GetAllAsync();
        return _mapper.Map<List<ProductVM>>(allProducts);
    }
}
