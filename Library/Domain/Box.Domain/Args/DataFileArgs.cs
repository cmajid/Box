using System;
namespace Box.Domain.Args
{
    public class DataFileArgs
    {
        public DataFileArgs() { }
        public DataFileArgs(string name, int userId, string username)
        {
            Name = name;
            UserId = userId;
            Username = username;
        }

        public string Name { get; set; }
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string Size { get; set; }
        public string PhysicalPath { get; set; }
    }
}

