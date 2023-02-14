namespace LabArquitetura.Infrastructure.DBContexts.Models
{

    public sealed class QueueDbModel
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Body { get; set; }
        public bool Read { get; set; }
        public string? Referrer { get; set; }
        public string? ActionType { get; set; }
    }
}