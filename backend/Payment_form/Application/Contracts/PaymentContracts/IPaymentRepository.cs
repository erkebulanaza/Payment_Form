using Domain.Entities;

namespace Application.Contracts.PaymentContracts;

public interface IPaymentRepository
{
    Task<Payment> CreatePayment(Payment payment);
    Task<List<Payment>> GetPayments();
}