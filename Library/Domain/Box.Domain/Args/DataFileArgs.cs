using System;
namespace Box.Domain.Args
{
    public class DataFileArgs
    {
        public DataFileArgs(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

