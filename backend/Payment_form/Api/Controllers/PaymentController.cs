using Application.Contracts.PaymentContracts;
using Application.Dtos.PaymentDtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentServices _service;

    public PaymentController(IPaymentServices service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetPayments());
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentAsync([FromBody] CreatePaymentRequestDto dto)
    {
        return Ok(await _service.CreatePayment(dto));
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetPaymentsStats()
    {
        return Ok(await _service.GetPaymentsStats());
    }
}