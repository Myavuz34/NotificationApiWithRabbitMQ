using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Yvz.Notification.CustomerApi.Services;
using Yvz.Notification.Models;

namespace Yvz.Notification.CustomerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IRequestClient<SubmitCustomer> _requestClient;

    public CustomerController(IRequestClient<SubmitCustomer> requestClient, ICustomerService customerService)
    {
        _requestClient = requestClient;
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SubmitCustomer submitCustomer)
    {
        await _customerService.AddCustomer(submitCustomer);
        var response = await _requestClient.GetResponse<CustomerResult>(submitCustomer);
        return Ok(response.Message);
    }
}