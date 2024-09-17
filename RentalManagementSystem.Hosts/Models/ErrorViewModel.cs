namespace RentalManagementSystem.Host.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class CustomeErrorViewModel
    {
        public string? ErrorId { get; set; }
        public string? Message { get; set; }
    }
}
