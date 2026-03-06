using Application.Contracts.PaymentContracts;
using Domain.Entities;
using Infrastructure.ContextDb;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _dbContext;

    public PaymentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Payment> CreatePayment(Payment payment)
    {
        await _dbContext.Payments.AddAsync(payment);
        await _dbContext.SaveChangesAsync();
        return payment;
    }

    public async Task<List<Payment>> GetPayments()
    {
        return await _dbContext.Payments.ToListAsync();
    }
}