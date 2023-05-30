using HoojaApi.Models;
using HoojaApi.Models.RelationTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Data
{
    public class HoojaApiDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public HoojaApiDbContext(DbContextOptions<HoojaApiDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CampaignCode> CampaignCodes { get; set; }

        //Relations tabeller
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderHistory> OrderHistorys { get; set; }
        public DbSet<OrderHistory> OrderProducts { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
