namespace Box.Domain.Entities
{
    public class Download : BaseEntity
    {
        public int FileId { get; private set; }
        public DateTime CreateDateTime { get; private set; }

        protected Download() { }
        private Download(int fileId)
        {
            FileId = fileId;
            CreateDateTime = DateTime.Now;
        }

        public static Download Create(int fileId)
        {
            return new Download(fileId);
        }
    }

}