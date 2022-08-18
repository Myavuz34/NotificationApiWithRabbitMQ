using System.Text.Json.Serialization;

namespace Yvz.Notification.Models;

public class SumbitCustomer
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id : {Id} Name : {Name} CreatedDate : {CreatedDate}";
    }
}