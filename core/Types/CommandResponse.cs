using System;
namespace core.Types
{
	public class CommandResponse<TModel>
	{
		public TModel? Data { get; set; }
		public IEnumerable<string>? Errors { get; set; }
		public bool Success { get; set; }

		public CommandResponse()
		{
		}
	}
}

