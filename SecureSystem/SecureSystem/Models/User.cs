using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SecureSystem.Models
{
    public class User :IdentityUser
    {
        public string FullName { get; set; }
        public string NameOrg { get; set; }
        public string Address { get; set; }
        public string Key { get; set; }
    }
   
}
