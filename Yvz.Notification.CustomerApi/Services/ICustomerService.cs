using Yvz.Notification.Models;

namespace Yvz.Notification.CustomerApi.Services;

public interface ICustomerService
{
    public Task<int> AddCustomer(SubmitCustomer submitCustomer);
}