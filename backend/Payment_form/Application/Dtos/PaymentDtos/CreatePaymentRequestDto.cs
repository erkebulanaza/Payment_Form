using System.ComponentModel.DataAnnotations;
using Application.Enums.PaumentsEnum;

namespace Application.Dtos.PaymentDtos;

public class CreatePaymentRequestDto
{
    public string WalletNumber { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [RegularExpression(@"^\+?\d{10,15}$")]
    public string? Phone { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
    public PaymentStatus Status { get; set; } =  PaymentStatus.Created;
    public string? Comment { get; set; }
}