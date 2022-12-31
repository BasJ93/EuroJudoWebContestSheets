namespace EJUPublisher.Configuration;

public sealed class WebConfiguration : IWebConfiguration
{
    public string WebServer { get; set; }
    public string ApiKey { get; set; }
}