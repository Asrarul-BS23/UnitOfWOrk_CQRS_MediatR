using Microsoft.EntityFrameworkCore;
using PracticingCQRSMediatR.Infrastructure.Data;
using PracticingCQRSMediatR.Application.Interfaces;

namespace PracticingCQRSMediatR.Infrastructure.Repository;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();  
    }
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        TEntity? entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        IEnumerable<TEntity> entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

}
