using HoojaApi.Models;
using HoojaApi.Models.RelationTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HoojaApi.Data
{
    public static class DummyData
    {
        public static async void DummyInsert(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HoojaApiDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                context.Database.EnsureCreated();

                if (!context.Addresses.Any())
                {
                    var AddAddresses = new Address[]
                    {
                    new Address { Street = "Storgatan 1", PostalCode = "111 11", City = "Stockholm"},
                    new Address { Street = "Lilla Vägen 2", PostalCode = "222 22", City = "Göteborg" },
                    new Address { Street = "Kungsgatan 3", PostalCode = "333 33", City = "Malmö" },
                    new Address { Street = "Södra Gränd 4", PostalCode = "444 44", City = "Uppsala" },
                    new Address { Street = "Norra Vägen 5", PostalCode = "555 55", City = "Örebro" },
                    new Address { Street = "Gustavsgatan 6", PostalCode = "666 66", City = "Helsingborg" },

                    new Address { Street = "Drottninggatan 7", PostalCode = "777 77", City = "Stockholm" },
                    new Address { Street = "Långgatan 8", PostalCode = "888 88", City = "Göteborg" },
                    new Address { Street = "Storgatan 9", PostalCode = "999 99", City = "Malmö" },
                    new Address { Street = "Gärdet 10", PostalCode = "101 01", City = "Uppsala" },
                    new Address { Street = "Karlsgatan 11", PostalCode = "111 11", City = "Örebro" },
                    new Address { Street = "Ängelholmsgatan 12", PostalCode = "121 21", City = "Helsingborg" }
                    };

                    context.Addresses.AddRange(AddAddresses);
                    context.SaveChanges();
                }

                if (!context.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                    await roleManager.CreateAsync(new IdentityRole<int>("Employee"));
                    await roleManager.CreateAsync(new IdentityRole<int>("Customer"));
                }

                if (!context.Users.Any())
                {
                    var newAdmin = new User()
                    {
                        FirstName = "Admin",
                        LastName = "Aldor",
                        FK_AddressId = 1,
                        UserName = "admin",
                        Email = "admin@Hooja.se",
                        SecurityNumber = "920616",
                        EmailConfirmed = true
                    };

                    var check = await userManager.CreateAsync(newAdmin, "adminMaX33!");

                    var newEmployee = new User()
                    {
                        FirstName = "Employee",
                        LastName = "Aldor",
                        FK_AddressId = 3,
                        UserName = "Employee",
                        Email = "Employee@Hooja.se",
                        SecurityNumber = "930515",
                        EmailConfirmed = true
                    };

                    check = await userManager.CreateAsync(newEmployee, "employeeMaX33!");

                    var newCustomer = new User()
                    {
                        FirstName = "Customer",
                        LastName = "Aldor",
                        FK_AddressId = 2,
                        UserName = "Customer",
                        Email = "customer@gmail.com",
                        SecurityNumber = "940414",
                        EmailConfirmed = true
                    };

                    check = await userManager.CreateAsync(newCustomer, "customerMaX33!");

                    await userManager.UpdateSecurityStampAsync(newAdmin);
                    await userManager.AddToRoleAsync(newAdmin, "Admin");

                    await userManager.UpdateSecurityStampAsync(newEmployee);
                    await userManager.AddToRoleAsync(newEmployee, "Employee");

                    await userManager.UpdateSecurityStampAsync(newCustomer);
                    await userManager.AddToRoleAsync(newCustomer, "Customer");
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypes = new ProductType[]
                    {
                    new ProductType { ProductTypeName = "Electronics" },
                    new ProductType { ProductTypeName = "Clothing" },
                    new ProductType { ProductTypeName = "Home Appliances" },
                    new ProductType { ProductTypeName = "Books" },
                    new ProductType { ProductTypeName = "Beauty Products" }
                    };

                    context.ProductTypes.AddRange(productTypes);
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var products = new Product[]
                    {
                    new Product { ProductName = "iPhone 12 Pro", ProductDescription = "The latest flagship smartphone from Apple.", Price = 9999, QuantityStock = 10, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Stylish T-Shirt", ProductDescription = "Comfortable and fashionable clothing item.", Price = 299, QuantityStock = 20, FK_ProductTypeId = 2, FK_CampaignCodeId = null },
                    new Product { ProductName = "Kitchen Mixer", ProductDescription = "Powerful appliance for mixing ingredients in the kitchen.", Price = 599, QuantityStock = 5, FK_ProductTypeId = 3, FK_CampaignCodeId = null },
                    new Product { ProductName = "The Great Gatsby", ProductDescription = "Classic novel by F. Scott Fitzgerald.", Price = 99, QuantityStock = 15, FK_ProductTypeId = 4, FK_CampaignCodeId = null },
                    new Product { ProductName = "Organic Face Cream", ProductDescription = "Natural beauty product for nourishing the skin.", Price = 199, QuantityStock = 12, FK_ProductTypeId = 5, FK_CampaignCodeId = null }
                    };

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                //if (!context.Orders.Any())
                //{
                //    var orders = new Order[]
                //    {
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(7), FK_CustomerId = 1 },
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(5), FK_CustomerId = 2 },
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(3), FK_CustomerId = 3 },
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(4), FK_CustomerId = 4 },
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 5 },
                //        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 6 }
                //    };

                //    context.Orders.AddRange(orders);
                //    context.SaveChanges();
                //}

                if (!context.ProductReviews.Any())
                {
                    var reviews = new ProductReview[]
                    {
                    new ProductReview { Review = "Amazing phone!", FK_ProductId = 1 },
                    new ProductReview { Review = "Excellent camera quality.", FK_ProductId = 1 },
                    new ProductReview { Review = "Great value for the price.", FK_ProductId = 2 },
                    new ProductReview { Review = "Impressive gaming performance.", FK_ProductId = 3 },
                    new ProductReview { Review = "Sleek design and powerful performance.", FK_ProductId = 4 },
                    new ProductReview { Review = "Outstanding image quality.", FK_ProductId = 5 }
                    };

                    context.ProductReviews.AddRange(reviews);
                    context.SaveChanges();
                }

                //if (!context.OrderHistorys.Any())
                //{
                //    var orderHistorys = new OrderHistory[]
                //    {
                //        new OrderHistory { FK_OrderId = 1, FK_ProductId = 1 },
                //        new OrderHistory { FK_OrderId = 2, FK_ProductId = 2 },
                //        new OrderHistory { FK_OrderId = 3, FK_ProductId = 3 },
                //        new OrderHistory { FK_OrderId = 4, FK_ProductId = 4 },
                //        new OrderHistory { FK_OrderId = 5, FK_ProductId = 5 }
                //    };

                //    context.OrderHistorys.AddRange(orderHistorys);
                //    context.SaveChanges();
                //}
            }


        }
    }
}
