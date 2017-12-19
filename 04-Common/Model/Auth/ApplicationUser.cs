using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Common;
using Newtonsoft.Json;

namespace Model.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity = await CreateUserClaims(userIdentity, manager, userIdentity.GetUserId());
            return userIdentity;
        }

        // Create additional parameters to persist on the cookie
        public async static Task<ClaimsIdentity> CreateUserClaims(
            ClaimsIdentity identity,
            UserManager<ApplicationUser> manager,
            string userId
        )
        {
            // Current User
            var currentUser = await manager.FindByIdAsync(userId);
            
            // Your User Data
            var jUser = JsonConvert.SerializeObject(new CurrentUser
            {
                UserId = currentUser.Id,
            Name = currentUser.Email,
            UserName = currentUser.Email,
            });
            
            identity.AddClaim(new Claim(ClaimTypes.UserData, jUser));
            
              return await Task.FromResult(identity);
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Credit { get; set; }

        /*public static implicit operator ApplicationUser(ApplicationUser v)
        {
            throw new NotImplementedException();
        }*/
    }
}
