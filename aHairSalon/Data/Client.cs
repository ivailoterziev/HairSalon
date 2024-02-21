using Microsoft.AspNetCore.Identity;

namespace HairSalon.Data
{
    public class Client : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime RegisterOn { get; set; }

    }
}
