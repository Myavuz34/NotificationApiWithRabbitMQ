using Yvz.Notification.Models;

namespace Yvz.Notifcation.Api.Services;

public interface IMailService
{
    public void SendMail(SubmitCustomer submitCustomer);
}