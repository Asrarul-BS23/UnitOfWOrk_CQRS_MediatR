using PracticingCQRSMediatR.Domain.Models;
using PracticingCQRSMediatR.Infrastructure.Data;
using PracticingCQRSMediatR.Application.Interfaces;

namespace PracticingCQRSMediatR.Infrastructure.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext): base(dbContext)
    {

    }
}
