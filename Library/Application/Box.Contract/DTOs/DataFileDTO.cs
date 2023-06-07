using System;
namespace Box.Contract.DTOs
{
	public class DataFileDTO
	{
        public int Id { get; set; }
        public string Extention { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public DateTime PublicDownloadDateTime { get; set; }
        public string Username { get; set; }
    }
}

