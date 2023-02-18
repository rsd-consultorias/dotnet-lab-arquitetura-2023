using System;
namespace LabArquitetura.Core.Types
{
    public class CommandResponse
    {
        public IEnumerable<string>? Messages { get; set; }
        public bool Success { get; set; }

        public CommandResponse()
        {
        }
    }

    public class CommandResponse<TModel> : CommandResponse
    {
        public TModel? Data { get; set; }
    }
}

