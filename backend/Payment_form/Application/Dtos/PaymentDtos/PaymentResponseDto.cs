namespace Application.Dtos.PaymentDtos;

public class PaymentResponseDto
{
    public Guid Id { get; set; }
    public string WalletNumber { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
}