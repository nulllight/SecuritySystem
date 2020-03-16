using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace SecureSystem.Models
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            if (user.NameOrg != null)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("NameOrg", user.NameOrg.ToString())
            });
            }
            if (user.Address != null)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Address", user.Address.ToString())
            });
            }
            if (user.FullName != null)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("FullName", user.FullName.ToString())
            });
            }
            if (user.Id != null)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Id", user.Id.ToString())
            });
            }
            if (user.Key != null)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Key", user.Key.ToString())
            });
            }

            if (user.Key != null)
            {
                RoleManager.Roles.Select(c => c.Name == "admin");
            }


            return principal;
        }

        

    }
}
