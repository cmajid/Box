using System.Linq;
using System.Xml.Linq;
using Box.Domain.Args;

namespace Box.Domain.Entities
{
    public class DataFile : BaseEntity
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }

        public string Extention { get; private set; }
        public bool IsDeleted { get;  set; }
        public string Size { get; private set; }
        public string Name { get; private set; }
        public string SystemName { get; private set; }
        public DateTime CreatedDatetime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public string Provider { get; private set; }
        public string PhysicalPath { get; private set; }
        public string Url { get; private set; }
        public DateTime PublicDownloadDateTime { get; private set; }

        private int DownloadCount { get; set; }

        protected DataFile() {
            
        }

        private DataFile(DataFileArgs args)
        {
            Id = args.Id;
            Name = args.Name;
            UserId = args.UserId;
            Extention = Path.GetExtension(args.Name);
            CreatedDatetime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
            SystemName = GetSystemName();
            Size = args.Size;
            UserName = args.Username;
            Provider = "FILE_SYSTEM";
            PhysicalPath = args.PhysicalPath;
            Url = GetFileUrl();
            DownloadCount = args.DownloadCount;

            CheckNameIsFilled(Name);
            ValidateFileName(Name);
            CheckFileExtentionIsSupported(Extention);
        }

        private static void ValidateFileName(string name)
        {
            if (name.Any(f => Path.GetInvalidFileNameChars().Contains(f)))
                throw new InvalidFileNameException(name);
        }

        private static void CheckNameIsFilled(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidFileNameException(name);
        }

        private void CheckFileExtentionIsSupported(string extention)
        {
            var SupportedExtention = new string[]
            {
                ".pdf",
                ".jpg", ".png", ".jpeg",
                ".xlsx", ".xls", ".xlsm",
                ".doc", ".docs",
                ".txt"
            };
            if (!SupportedExtention.Contains(Extention))
                throw new InvalidFileExtentionException(extention);
        }

       

        public static DataFile Create(DataFileArgs args)
        {
            return new DataFile(args);
        }

        public int GetDownloadCount()
        {
            return DownloadCount;
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
            return $"storage/{UserName}/{SystemName}";
        }

        public void Share(DateTime dateTime)
        {
            PublicDownloadDateTime = dateTime;
        }

        public string DownloadFile()
        {
            if (IsNotPublicDownloadable())
                throw new NotPublicDownloadableException();

            return $"{PhysicalPath}{SystemName}";
        }

        public string DownloadByOwner()
        {
            return $"{PhysicalPath}{SystemName}";
        }

        private bool IsNotPublicDownloadable()
        {
            return PublicDownloadDateTime < DateTime.Now;
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

        [Serializable]
        public class FileNotFoundExtentionException : ApplicationException
        {
            public FileNotFoundExtentionException() { }

            public FileNotFoundExtentionException(string name)
                : base(String.Format("File not found: {0}", name)) { }
        }
    }
}

