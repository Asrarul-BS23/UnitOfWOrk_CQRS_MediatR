

namespace PracticingCQRSMediatR.Application.Interfaces;

public interface IUnitOfWork: IDisposable
{
    public IProductRepository ProductRepository { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveChangesAsync();
}
