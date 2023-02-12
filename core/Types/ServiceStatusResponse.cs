using System;
namespace core.Types
{
    public class ServiceStatusResponse
    {
        public string? Status { get; set; }
        public int? Progress { get; set; }

        public ServiceStatusResponse()
        {
        }
    }
}

