using System;
namespace core.Models
{
	public abstract class BaseModel
    {
        // 
        public Guid Id { get; set; } = Guid.NewGuid();

        // Auditoria 
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAlteracao { get; set; }

        public BaseModel()
		{
		}
	}
}

