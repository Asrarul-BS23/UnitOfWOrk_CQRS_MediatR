using Microsoft.EntityFrameworkCore.Storage;
using PracticingCQRSMediatR.Infrastructure.Data;
using PracticingCQRSMediatR.Application.Interfaces;

namespace PracticingCQRSMediatR.Infrastructure.Repository;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private IDbContextTransaction? _transaction;
    private bool _disposed = false;

    public IProductRepository ProductRepository {get;}

    public UnitOfWork(AppDbContext dbContext, 
        IProductRepository productRepository)
    {
        _dbContext = dbContext;
        ProductRepository = productRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            if(_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        finally
        {
            if(_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }
        finally
        {
            if(_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(_disposed) 
            return;

        if(disposing) { 
            _transaction?.Dispose();
            _dbContext?.Dispose();
        }

        _disposed = true;
    }
}
