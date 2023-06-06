using System;
namespace Box.Contract.DTOs
{
	public class DataFileDTO
	{
		public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Extention { get; set; }
        public bool IsDeleted { get;  set; }
        public int Size { get; set; }
        public string Name { get;  set; }
        public string SystemName { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDateTime { get;  set; }
    }
}

