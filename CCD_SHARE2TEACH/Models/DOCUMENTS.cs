namespace CCD_SHARE2TEACH.Models
{
    public class DOCUMENTS
    {
        public int Id { get; set; }
        public string? title { get; set; }
        public int tags { get; set; }
        public int grade { get; set; }
        public int rating { get; set; }
        public string? description { get; set; }
        public string? filepath { get; set; }
        public string? filetype { get; set; }
        public DateTimeOffset? createddate { get; set; }
        public int createdby { get; set; }
        public DateTimeOffset? updateddate { get; set; }
        public int updatedby { get; set; }
        public DateTimeOffset? accessdate { get; set; }
        public int accessby { get; set; }
    }
}
