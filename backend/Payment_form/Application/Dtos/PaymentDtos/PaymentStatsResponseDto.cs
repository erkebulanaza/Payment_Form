namespace Application.Dtos.PaymentDtos;

public class PaymentStatsResponseDto
{
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
    public List<DailyStatsDto> Daily { get; set; } = new List<DailyStatsDto>();
}