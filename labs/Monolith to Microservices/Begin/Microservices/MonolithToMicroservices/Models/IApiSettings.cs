namespace MonolithToMicroservices.Models
{
    public interface IApiSettings
    {
        string CustomersUri { get; set; }
        string LookupUri { get; set; }
        string CustomerOrdersUri { get; set; }
    }
}