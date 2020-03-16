using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SecureSystem.Models
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Servies> Servies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
          Database.EnsureCreated();
        }
       
    }
   
}
