namespace CCD_SHARE2TEACH.Models
{
    public class MODERATIONS
    {
        public int Id { get; set; }
        public int documentid { get; set; }
        public int moderatorid { get; set; }
        public enum status
        {
            PENDING,APPROVED,DENIED
        }
        public string? comment { get; set; }
        public DateTimeOffset? createdat { get; set; }
        public DateTimeOffset? updatedat { get; set; }
    }
}
