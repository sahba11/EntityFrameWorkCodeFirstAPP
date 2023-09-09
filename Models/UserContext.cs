using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCodeFirstAPP.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)

        {
            
                
        }
        public DbSet<Users> Users { get; set; }
    }
}
