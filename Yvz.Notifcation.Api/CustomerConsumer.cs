using MassTransit;
using Yvz.Notifcation.Api.Services;
using Yvz.Notification.Models;

namespace Yvz.Notifcation.Api;

public class CustomerConsumer : IConsumer<SubmitCustomer>
{
    private readonly IMailService _mailService;

    public CustomerConsumer(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task Consume(ConsumeContext<SubmitCustomer> context)
    {
        Console.WriteLine($"Value: {context.Message}");
        if (context.Message.Id > 0)
        {
            await context.RespondAsync(
                new CustomerResult
                {
                    CustomerId = context.Message.Id,
                    Message = "Customer added Sending email.",
                    StatusCode = 200,
                    CreatedDate = DateTime.Now
                });
            _mailService.SendMail(context.Message);
        }
        else
        {
            await context.RespondAsync(
                new CustomerResult
                {
                    CustomerId = context.Message.Id,
                    Message = "Failed to add Customer",
                    StatusCode = 500,
                    CreatedDate = DateTime.Now
                });
        }
    }
}