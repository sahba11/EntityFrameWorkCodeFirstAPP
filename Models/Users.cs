using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCodeFirstAPP.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set;}
        public string Name { get; set;}
        public string ContactNumber { get; set;}

    }
}
