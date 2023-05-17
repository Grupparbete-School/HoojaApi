using HoojaApi.Models;
using HoojaApi.Models.RelationTables;
using Microsoft.EntityFrameworkCore;

namespace HoojaApi.Data
{
    public class HoojaApiDbContext : DbContext
    {
        public HoojaApiDbContext(DbContextOptions<HoojaApiDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
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
