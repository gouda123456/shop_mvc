using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop_mvc.Models;
using System.ComponentModel.DataAnnotations;

namespace shop_mvc.Models
{
    public class context:IdentityDbContext<iuser>
    {
        public context(DbContextOptions<context> op):base(op)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<item> Items { get; set; }
        public DbSet<catagory> Catagories { get; set; }
        public DbSet<admin_manage> admin_manage { get; set; }
        public DbSet<shop_mvc.Models.clsLayout> clsLayout { get; set; } = default!;

    }
    public class iuser : IdentityUser
    {
        
    }
}
