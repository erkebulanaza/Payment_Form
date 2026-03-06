using System.IO.Pipes;
using Application.Contracts.PaymentContracts;
using Application.Dtos.PaymentDtos;
using Application.Enums.PaumentsEnum;
using Domain.Entities;

namespace Application.Services;

public class PaymentServices : IPaymentServices
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentServices(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentResponseDto> CreatePayment(CreatePaymentRequestDto dto)
    {
        
        if (string.IsNullOrEmpty(dto.WalletNumber) || dto.Amount <= 0 || string.IsNullOrEmpty(dto.Email))
        {
            var invalidPayment = new Payment(dto.WalletNumber, dto.Amount, dto.AccountId, dto.Email, dto.Phone, dto.Currency , DateTime.UtcNow,nameof(PaymentStatus.Rejected) ,dto.Comment);
            await _paymentRepository.CreatePayment(invalidPayment);
            return new PaymentResponseDto
            {
                Id = invalidPayment.Id,
                WalletNumber = invalidPayment.WalletNumber,
                Amount = invalidPayment.Amount,
                CreatedAt = invalidPayment.CreatedAt,
                Email = invalidPayment.Email,
                Phone = invalidPayment.Phone,
                Status = invalidPayment.Status,
                AccountId = invalidPayment.AccountId,
                Comment = invalidPayment.Comment,
                Currency = invalidPayment.Currency,
            };
        }
        var payment = new Payment(dto.WalletNumber, dto.Amount, dto.AccountId, dto.Email, dto.Phone, dto.Currency , DateTime.UtcNow,nameof(PaymentStatus.Created) ,dto.Comment);

        if (payment == null)
        {
            throw new Exception("Payment Creation Failed");
        }
        await _paymentRepository.CreatePayment(payment);

        return new PaymentResponseDto
        {
            Id = payment.Id,
            WalletNumber = payment.WalletNumber,
            Amount = payment.Amount,
            CreatedAt = payment.CreatedAt,
            Email = payment.Email,
            Phone = payment.Phone,
            Status = payment.Status,
            AccountId = payment.AccountId,
            Comment = payment.Comment,
            Currency = payment.Currency,
        };
    }

    public async Task<List<PaymentResponseDto>> GetPayments()
    {
        var payments = await _paymentRepository.GetPayments();
        if (payments == null)
        {
            throw new Exception("Payments not found");
        }
        return payments.Select(payment => new PaymentResponseDto
        {
            Id = payment.Id,
            WalletNumber = payment.WalletNumber,
            Amount = payment.Amount,
            CreatedAt = payment.CreatedAt,
            Email = payment.Email,
            Phone = payment.Phone,
            Status = payment.Status,
            AccountId = payment.AccountId,
            Comment = payment.Comment,
            Currency = payment.Currency,
        }).ToList();
    }
    
    public async Task<PaymentStatsResponseDto> GetPaymentsStats()
    {
        var payments = await _paymentRepository.GetPayments();
        if (payments == null)
        {
            throw new Exception("Payments not found");
        }

        return new PaymentStatsResponseDto
        {
            TotalCount = payments.Count,
            TotalAmount = payments.Sum(payment => payment.Amount),
            Daily = payments.GroupBy(p => p.CreatedAt.Date).Select(payment => new DailyStatsDto
            {
                Count = payment.Count(),
                Amount = payment.Sum(p => p.Amount),
                Date = payment.Key
            }).ToList()
        };
    }
    
    
}