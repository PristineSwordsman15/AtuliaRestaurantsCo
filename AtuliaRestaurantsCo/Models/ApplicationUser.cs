using Microsoft.AspNetCore.Identity;

namespace AtuliaRestaurantsCo.Models

   
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}
