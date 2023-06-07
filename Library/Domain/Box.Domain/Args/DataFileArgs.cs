using System;
namespace Box.Domain.Args
{
    public class DataFileArgs
    {
        public DataFileArgs() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Size { get; set; }
        public string PhysicalPath { get; set; }
        public int DownloadCount { get; set; }
    }
}

