using Application.Dtos.PaymentDtos;

namespace Application.Contracts.PaymentContracts;

public interface IPaymentServices
{
    Task<PaymentResponseDto> CreatePayment(CreatePaymentRequestDto dto);
    Task<List<PaymentResponseDto>> GetPayments();
    Task<PaymentStatsResponseDto> GetPaymentsStats();
}