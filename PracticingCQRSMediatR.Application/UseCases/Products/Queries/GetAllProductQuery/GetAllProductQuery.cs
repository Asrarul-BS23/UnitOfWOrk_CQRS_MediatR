using MediatR;

namespace PracticingCQRSMediatR.Application.UseCases.Products.Queries.GetAllProductQuery;

public class GetAllProductQuery: IRequest<List<ProductVM>>
{
}
