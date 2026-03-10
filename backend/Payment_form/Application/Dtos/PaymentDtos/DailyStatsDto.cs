namespace Application.Dtos.PaymentDtos;

public class DailyStatsDto
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public decimal Amount { get; set; }
}