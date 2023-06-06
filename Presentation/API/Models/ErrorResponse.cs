using System;
namespace Box.API.Models
{
	public class ErrorResponse
	{
		public ErrorResponse()
		{
			Messages = new();
        }

        public bool IsSucceed { get; set; }
		public List<string> Messages { get; set; }
    }
}

