using System.Linq;
using System.Xml.Linq;
using Box.Domain.Args;

namespace Box.Domain.Entities
{
    public class DataFile : BaseEntity
    {
        private readonly string[] SupportedExtention;

        public int UserId { get; private set; }
        public string UserName { get; private set; }

        public string Extention { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Size { get; private set; }
        public string Name { get; private set; }
        public string SystemName { get; private set; }
        public DateTime CreatedDatetime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public string Provider { get; private set; }
        public string PhysicalPath { get; private set; }
        public string Url { get; private set; }
        public DateTime PublicDownloadDateTime { get; private set; }

        protected DataFile() {
            
        }

        private DataFile(DataFileArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Name))
                throw new InvalidFileNameException(args.Name);

            if (args.Name.Any(f => Path.GetInvalidFileNameChars().Contains(f)))
                throw new InvalidFileNameException(args.Name);

            Name = args.Name;
            Extention = Path.GetExtension(args.Name);
            CreatedDatetime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            SystemName = GetSystemName();
            PhysicalPath = args.PhysicalPath;
            Size = args.Size;
            UserId = args.UserId;
            UserName = args.Username;
            Provider = "FILE_SYSTEM";
            string workingDirectory = Environment.CurrentDirectory;
            PhysicalPath = Directory.GetParent(workingDirectory)
                ?.Parent?.Parent?.FullName ?? string.Empty;
            Url = GetFileUrl();

            CheckFileExtentionIsSupported(SupportedExtention);
        }

        private void CheckFileExtentionIsSupported(string[]? SupportedExtention)
        {
            SupportedExtention = new string[]
            {
                ".pdf",
                ".jpg", ".png", ".jpeg",
                ".xlsx", ".xls", ".xlsm",
                ".doc", ".docs",
                ".txt"
            };
            if (!SupportedExtention.Contains(Extention))
                throw new InvalidFileExtentionException(Name);
        }

        public static DataFile Create(DataFileArgs args)
        {
            return new DataFile(args);
        }

        public void Rename(string name)
        {
            var extention = Path.GetExtension(name);
            if(extention != Extention)
                throw new InvalidFileNameException(name);

            UpdatedDateTime = DateTime.Now;
            Name = name;
        }

        public void Delete()
        {
            IsDeleted = true;
            UpdatedDateTime = DateTime.Now;
        }

        private string GetSystemName()
        {
            return $"{UserId}-{CreatedDatetime.ToString("yyMMddHHmmssff")}";
        }

        private string GetFileUrl()
        {
            return $"storage/{UserName}/{Provider}/{GetSystemName()}";
        }

        public void Share(DateTime dateTime)
        {
            PublicDownloadDateTime = dateTime;
        }

        public string Download()
        {
            if (PublicDownloadDateTime < DateTime.Now)
                throw new NotPublicDownloadableException();

            return GetFileUrl();
        }

        public void StopShare()
        {
            PublicDownloadDateTime = DateTime.MinValue;
        }

        [Serializable]
        public class InvalidFileNameException : ApplicationException
        {
            public InvalidFileNameException() { }

            public InvalidFileNameException(string name)
                : base(String.Format("Invalid file name: {0}", name)) {}
        }

        [Serializable]
        public class NotPublicDownloadableException : ApplicationException
        {
            public NotPublicDownloadableException()
                : base(String.Format("File is not public")) {}
        }

        [Serializable]
        public class InvalidFileExtentionException : ApplicationException
        {
            public InvalidFileExtentionException() { }

            public InvalidFileExtentionException(string name)
                : base(String.Format("File type is not supported: {0}", name)) { }
        }
    }
}

