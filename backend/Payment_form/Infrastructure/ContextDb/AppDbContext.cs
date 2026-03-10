using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContextDb;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Payment> Payments { get; set; } = null;
}