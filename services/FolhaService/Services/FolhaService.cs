using System;
using FolhaServiceGRPC;
using FolhaWorker;
using Grpc.Core;
using static FolhaServiceGRPC.FolhaServiceStatus;

namespace FolhaService.Services
{
	public class FolhaService : FolhaServiceStatusBase
    {
        private readonly Worker _worker;

        public FolhaService(Worker worker)
        {
            _worker = worker;
        }

        public override Task<FolhaServiceStatusResponse> GetStatus(FolhaServiceStatusRequest request, ServerCallContext context)
        {
            var response = new FolhaServiceStatusResponse {
                Status = "Teste OK! ====>" + _worker.Status
            };

            return Task.FromResult(response);
        }
    }
}

