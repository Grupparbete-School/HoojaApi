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
                        SecurityNumber = "740414",
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
                    new Product {
                        Brand = "Head & Shoulders",
                        ProductName = "Shampoo",
                        ProductDescription = "Cleanses and nourishes hair.",
                        Price = 49, QuantityStock = 20,
                        FK_ProductTypeId = 1,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1543363363-6dbd3125fb6d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=764&q=80"
                    },
                    new Product {
                        Brand = "Tresemmé",
                        ProductName = "Conditioner",
                        ProductDescription = "Detangles and softens hair.",
                        Price = 39, QuantityStock = 15,
                        FK_ProductTypeId = 1,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1526947425960-945c6e72858f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80"
                    },
                    new Product {
                        Brand = "Björk Tämja",
                        ProductName = "Hair Serum",
                        ProductDescription = "Adds shine and controls frizz.",
                        Price = 29, QuantityStock = 30,
                        FK_ProductTypeId = 1,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1608571424266-edeb9bbefdec?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                    },
                    new Product {
                        Brand = "Verb",
                        ProductName = "Hair Mask",
                        ProductDescription = "Deeply conditions and repairs hair.",
                        Price = 59, QuantityStock = 10,
                        FK_ProductTypeId = 1,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1588514899099-e2df6951dde6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1169&q=80"
                    },
                    new Product {Brand = "Mielle Rosemary",
                        ProductName = "Hair Oil",
                        ProductDescription = "Nourishes and strengthens hair.",
                        Price = 34, QuantityStock = 25,
                        FK_ProductTypeId = 1,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1611224596242-2326c5484b57?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                    },
                    new Product {
                        Brand ="Carolina Herrera",
                        ProductName = "Perfume",
                        ProductDescription = "Elegant fragrance for men and women.",
                        Price = 79, QuantityStock = 8,
                        FK_ProductTypeId = 3,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1588405748880-12d1d2a59f75?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                    },
                    new Product {
                        Brand ="Grande Csometics",
                        ProductName = "Makeup Set",
                        ProductDescription = "Complete makeup kit for a flawless look.",
                        Price = 149, QuantityStock = 5,
                        FK_ProductTypeId = 4,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1526045405698-cf8b8acc4aaf?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1171&q=80"
                    },
                    new Product {
                        Brand = "Olay",
                        ProductName = "Moisturizer",
                        ProductDescription = "Hydrates and nourishes the skin.",
                        Price = 39, QuantityStock = 12,
                        FK_ProductTypeId = 5,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1584949514490-73fc1a2faa97?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                    },
                    new Product {
                        Brand = "Kale",
                        ProductName = "Facial Cleanser",
                        ProductDescription = "Gently removes impurities from the skin.",
                        Price = 29, QuantityStock = 18,
                        FK_ProductTypeId = 5,
                        FK_CampaignCodeId = null,
                        ProductPicture = "https://images.unsplash.com/photo-1629196869698-2ce173dacc24?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                    }
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
                       new ProductReview { Review = "Cleanses hair thoroughly. Highly recommended!", FK_ProductId = 1, Rating = 3, CustomerName = "Emma", ReviewOfDate = new DateTime(2023, 1, 1) },
                       new ProductReview { Review = "Leaves hair soft and manageable. Love it!", FK_ProductId = 1, Rating = 1, CustomerName = "Oskar", ReviewOfDate = new DateTime(2023, 2, 15) },
                       new ProductReview { Review = "Provides excellent shine and controls frizz.", FK_ProductId = 3, Rating = 2, CustomerName = "Malin", ReviewOfDate = new DateTime(2023, 3, 10) },
                       new ProductReview { Review = "Deeply conditions and repairs damaged hair.", FK_ProductId = 4, Rating = 2, CustomerName = "Madde", ReviewOfDate = new DateTime(2023, 4, 5) },
                       new ProductReview { Review = "Nourishes and strengthens hair. Works wonders!", FK_ProductId = 5, Rating = 5, CustomerName = "Aldor", ReviewOfDate = new DateTime(2023, 5, 20) },
                       new ProductReview { Review = "Delivers a captivating fragrance. Absolutely love it!", FK_ProductId = 6, Rating = 5, CustomerName = "Mårdhund", ReviewOfDate = new DateTime(2023, 6, 30) },
                       new ProductReview { Review = "Great variety of makeup products in the set. Highly recommend.", FK_ProductId = 7, Rating = 3, CustomerName = "Hooja", ReviewOfDate = new DateTime(2023, 7, 12) },
                       new ProductReview { Review = "Keeps skin moisturized and hydrated. Perfect for daily use.", FK_ProductId = 9, Rating = 4, CustomerName = "Sven", ReviewOfDate = new DateTime(2023, 8, 25) },
                       new ProductReview { Review = "Gently cleanses the skin without drying it out.", FK_ProductId = 9, Rating = 4, CustomerName = "Lisa", ReviewOfDate = new DateTime(2023, 9, 8) }

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
