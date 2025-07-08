using Microsoft.EntityFrameworkCore;
using PracticingCQRSMediatR.Domain.Models;

namespace PracticingCQRSMediatR.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

}
