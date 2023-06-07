using System;
namespace Box.API.Models
{
	public class FileRequest
	{
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}

