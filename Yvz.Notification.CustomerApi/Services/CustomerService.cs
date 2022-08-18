using Yvz.Notification.CustomerApi.Context;
using Yvz.Notification.Models;

namespace Yvz.Notification.CustomerApi.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _dbContext;

    public CustomerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddCustomer(SubmitCustomer submitCustomer)
    {
        await _dbContext.AddAsync(submitCustomer);
        var response = await _dbContext.SaveChangesAsync();
        return response > 0 ? 1 : 0;
    }
}