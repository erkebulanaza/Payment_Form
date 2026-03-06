using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Payment
{
    public Guid Id { get; private set; }
    public string WalletNumber { get; private set; }
    public decimal Amount { get; private set; }
    public int AccountId { get;private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public string Currency { get; private set; }
    public DateTime CreatedAt { get;private set; }
    public string Status { get; private set; }
    public string? Comment { get;private set; }

    public Payment(string walletNumber, decimal amount, int accountId, string email, string? phone, string currency, DateTime createdAt, string status, string? comment)
    {
        Id = Guid.NewGuid();
        WalletNumber = walletNumber;
        Amount = amount;
        AccountId = accountId;
        Email = email;
        Phone = phone;
        Currency = currency;
        CreatedAt = createdAt;
        Status = status;
        Comment = comment;
    }
    
    public Payment(string status)
    {
        Status = status;
    }
}