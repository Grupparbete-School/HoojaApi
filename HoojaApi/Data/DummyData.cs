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
                    
                    var newCustomer2 = new User()
                    {
                        FirstName = "Mårdhund",
                        LastName = "Hooja",
                        FK_AddressId = 2,
                        UserName = "Mårdhund",
                        Email = "mårdhund@gmail.com",
                        SecurityNumber = "940414",
                        EmailConfirmed = true
                    };

                    check = await userManager.CreateAsync(newCustomer2, "customerMaX33!");
                    
                    var newCustomer3 = new User()
                    {
                        FirstName = "Hooja",
                        LastName = "Mårdhund",
                        FK_AddressId = 2,
                        UserName = "hooja",
                        Email = "hooja@gmail.com",
                        SecurityNumber = "940414",
                        EmailConfirmed = true
                    };

                    check = await userManager.CreateAsync(newCustomer3, "customerMaX33!");

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
                    new ProductType { ProductTypeName = "Hair Care" },
                    new ProductType { ProductTypeName = "Beauty Products" },
                    new ProductType { ProductTypeName = "Perfume" },
                    new ProductType { ProductTypeName = "Makeup" },
                    new ProductType { ProductTypeName = "Skin Care" },
                };

                    context.ProductTypes.AddRange(productTypes);
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    var products = new Product[]
                    {
                    new Product { ProductName = "Shampoo", ProductDescription = "Cleanses and nourishes hair.", Price = 49, QuantityStock = 20, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Conditioner", ProductDescription = "Detangles and softens hair.", Price = 39, QuantityStock = 15, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Hair Serum", ProductDescription = "Adds shine and controls frizz.", Price = 29, QuantityStock = 30, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Hair Mask", ProductDescription = "Deeply conditions and repairs hair.", Price = 59, QuantityStock = 10, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Hair Oil", ProductDescription = "Nourishes and strengthens hair.", Price = 34, QuantityStock = 25, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Perfume", ProductDescription = "Elegant fragrance for men and women.", Price = 79, QuantityStock = 8, FK_ProductTypeId = 3, FK_CampaignCodeId = null },
                    new Product { ProductName = "Makeup Set", ProductDescription = "Complete makeup kit for a flawless look.", Price = 149, QuantityStock = 5, FK_ProductTypeId = 4, FK_CampaignCodeId = null },
                    new Product { ProductName = "Moisturizer", ProductDescription = "Hydrates and nourishes the skin.", Price = 39, QuantityStock = 12, FK_ProductTypeId = 5, FK_CampaignCodeId = null },
                    new Product { ProductName = "Facial Cleanser", ProductDescription = "Gently removes impurities from the skin.", Price = 29, QuantityStock = 18, FK_ProductTypeId = 5, FK_CampaignCodeId = null }
                    };

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }



                if (!context.Orders.Any())
                {
                    var orders = new Order[]
                    {
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(7), FK_CustomerId = 3 },
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(5), FK_CustomerId = 2 },
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(3), FK_CustomerId = 3 },
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(4), FK_CustomerId = 4 },
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 4 },
                        new Order { OrderComment = "Order comment", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 2 }
                    };

                    context.Orders.AddRange(orders);
                    context.SaveChanges();
                }

                if (!context.ProductReviews.Any())
                {
                    var reviews = new ProductReview[]
                    {
                        new ProductReview { Review = "Cleanses hair thoroughly. Highly recommended!", FK_ProductId = 1 },
                        new ProductReview { Review = "Leaves hair soft and manageable. Love it!", FK_ProductId = 1 },
                        new ProductReview { Review = "Provides excellent shine and controls frizz.", FK_ProductId = 3 },
                        new ProductReview { Review = "Deeply conditions and repairs damaged hair.", FK_ProductId = 4 },
                        new ProductReview { Review = "Nourishes and strengthens hair. Works wonders!", FK_ProductId = 5 },
                        new ProductReview { Review = "Delivers a captivating fragrance. Absolutely love it!", FK_ProductId = 6 },
                        new ProductReview { Review = "Great variety of makeup products in the set. Highly recommend.", FK_ProductId = 7 },
                        new ProductReview { Review = "Keeps skin moisturized and hydrated. Perfect for daily use.", FK_ProductId = 9 },
                        new ProductReview { Review = "Gently cleanses the skin without drying it out.", FK_ProductId = 9 }
                    };

                    context.ProductReviews.AddRange(reviews);
                    context.SaveChanges();
                }


                if (!context.OrderHistorys.Any())
                {
                    var orderHistorys = new OrderHistory[]
                    {
                        new OrderHistory { FK_OrderId = 1, FK_ProductId = 1 , Amount = 5},
                        new OrderHistory { FK_OrderId = 1, FK_ProductId = 3 , Amount = 3},
                        new OrderHistory { FK_OrderId = 1, FK_ProductId = 4 , Amount = 1},
                        new OrderHistory { FK_OrderId = 2, FK_ProductId = 4 , Amount = 19},
                        new OrderHistory { FK_OrderId = 2, FK_ProductId = 5 , Amount = 6},
                        new OrderHistory { FK_OrderId = 2, FK_ProductId = 6 , Amount = 8},
                        new OrderHistory { FK_OrderId = 3, FK_ProductId = 3 , Amount = 45},
                        new OrderHistory { FK_OrderId = 4, FK_ProductId = 9 , Amount = 900},
                        new OrderHistory { FK_OrderId = 4, FK_ProductId = 8 , Amount = 55},
                        new OrderHistory { FK_OrderId = 4, FK_ProductId = 7 , Amount = 3},
                        new OrderHistory { FK_OrderId = 5, FK_ProductId = 2 , Amount = 5},
                        new OrderHistory { FK_OrderId = 5, FK_ProductId = 9 , Amount = 5},
                        new OrderHistory { FK_OrderId = 5, FK_ProductId = 1 , Amount = 5},
                    };

                    context.OrderHistorys.AddRange(orderHistorys);
                    context.SaveChanges();
                }
            }


        }
    }
}
