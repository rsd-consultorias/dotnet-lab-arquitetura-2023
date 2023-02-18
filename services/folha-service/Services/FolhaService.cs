using System;
using FolhaServiceGRPC;
using FolhaWorker;
using Grpc.Core;
using static FolhaServiceGRPC.FolhaServiceStatus;

namespace FolhaService.Services
{
    public class FolhaService : FolhaServiceStatusBase
    {
        private readonly ServiceStatus _serviceStatus;

        public FolhaService(ServiceStatus serviceStatus)
        {
            _serviceStatus = serviceStatus;
        }

        public override Task<FolhaServiceStatusResponse> GetStatus(FolhaServiceStatusRequest request, ServerCallContext context)
        {
            var response = new FolhaServiceStatusResponse
            {
                Status = _serviceStatus.Status,
                Progress = _serviceStatus.Progress
            };

            return Task.FromResult(response);
        }
    }

    public class ServiceStatus
    {
        public string? Status { get; set; }
        public int Progress { get; set; }
    }
}

