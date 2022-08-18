using Microsoft.EntityFrameworkCore;
using Yvz.Notification.Models;

namespace Yvz.Notification.CustomerApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<SubmitCustomer> Customers { get; set; }
}