using Microsoft.VisualBasic;

namespace CCD_SHARE2TEACH.Models
{
    public class USERS
    {
        public int Id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public int roleID { get; set; }
        public DateTimeOffset? createddate { get; set; }
        public DateTimeOffset? lastlogin { get; set; }
    }
}
