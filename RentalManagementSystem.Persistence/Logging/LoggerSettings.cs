public class LoggerSettings
{
    public string AppName { get; set; } = "RentalManagementSystem";
    public string ElasticSearchUrl { get; set; } = string.Empty;
    public bool WriteToFile { get; set; } = true;
    public bool StructuredConsoleLogging { get; set; } = true;
    public string MinimumLogLevel { get; set; } = "Information";
}
