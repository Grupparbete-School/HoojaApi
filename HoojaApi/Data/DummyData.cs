using HoojaApi.Models;
using HoojaApi.Models.RelationTables;

namespace HoojaApi.Data
{
    public static class DummyData
    {
        public static void DummyInsert(HoojaApiDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Customers.Any())
            {
                var customers = new Customer[]
                {
                    new Customer {FirstName = "Aldor", LastName ="Bescher", PhoneNumber ="0704445648",SecurityNumber = "920616", Email = "aldor@gmail.com"},
                    new Customer {FirstName = "Emma",  LastName = "Hjalmarsson Wahlström", PhoneNumber ="0704568915",SecurityNumber = "900328", Email = "emma@gmail.com"},
                    new Customer {FirstName = "Madde", LastName ="Lundström", PhoneNumber ="0704445648",SecurityNumber = "890417", Email = "madde@gmail.com"},
                    new Customer {FirstName = "Malin", LastName ="Eriksson", PhoneNumber ="0704445648",SecurityNumber = "910729", Email = "emma@gmail.com"},
                    new Customer {FirstName = "Ellinor", LastName ="Vonck", PhoneNumber ="0704445648",SecurityNumber = "000101", Email = "ellinor@gmail.com"},
                    new Customer {FirstName = "Oskar", LastName ="Ullsten", PhoneNumber ="0704445648",SecurityNumber = "820304", Email = "oskar@gmail.com"},
                };

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employees = new Employee[]
                {
                    new Employee {FirstName = "Kalle", LastName ="Andersson", PhoneNumber ="0704445648",SecurityNumber = "920616", Email = "kalle@gmail.com"},
                    new Employee {FirstName = "Lisa",  LastName = "Larson", PhoneNumber ="0704568915",SecurityNumber = "900328", Email = "lisa@gmail.com"},
                    new Employee {FirstName = "Mårdhund", LastName ="Lundström", PhoneNumber ="0704445648",SecurityNumber = "890417", Email = "mårdhund@gmail.com"},
                    new Employee {FirstName = "Knasen", LastName ="Eriksson", PhoneNumber ="0704445648",SecurityNumber = "910729", Email = "knasen@gmail.com"},
                    new Employee {FirstName = "Li", LastName ="Vonck", PhoneNumber ="0704445648",SecurityNumber = "000101", Email = "li@gmail.com"},
                    new Employee {FirstName = "Valle", LastName ="Ullsten", PhoneNumber ="0704445648",SecurityNumber = "820304", Email = "valle@gmail.com"},
                };

                context.Employees.AddRange(employees);
                context.SaveChanges();
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
                    new Product { ProductName = "iPhone 12 Pro", ProductDescription = "The latest flagship smartphone from Apple.", Price = 9999, Quantity = 10, FK_ProductTypeId = 1, FK_CampaignCodeId = null },
                    new Product { ProductName = "Stylish T-Shirt", ProductDescription = "Comfortable and fashionable clothing item.", Price = 299, Quantity = 20, FK_ProductTypeId = 2, FK_CampaignCodeId = null },
                    new Product { ProductName = "Kitchen Mixer", ProductDescription = "Powerful appliance for mixing ingredients in the kitchen.", Price = 599, Quantity = 5, FK_ProductTypeId = 3, FK_CampaignCodeId = null },
                    new Product { ProductName = "The Great Gatsby", ProductDescription = "Classic novel by F. Scott Fitzgerald.", Price = 99, Quantity = 15, FK_ProductTypeId = 4, FK_CampaignCodeId = null },
                    new Product { ProductName = "Organic Face Cream", ProductDescription = "Natural beauty product for nourishing the skin.", Price = 199, Quantity = 12, FK_ProductTypeId = 5, FK_CampaignCodeId = null }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var orders = new Order[]
                {
                    new Order { OrderName = "Order 1", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(7), FK_CustomerId = 1 },
                    new Order { OrderName = "Order 2", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(5), FK_CustomerId = 2 },
                    new Order { OrderName = "Order 3", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(3), FK_CustomerId = 3 },
                    new Order { OrderName = "Order 4", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(4), FK_CustomerId = 4 },
                    new Order { OrderName = "Order 5", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 5 },
                    new Order { OrderName = "Order 6", OrderDate = DateTime.Now, DeliveryDate = DateTime.Now.AddDays(6), FK_CustomerId = 6 }
                };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }

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


            if (!context.Addresses.Any())
            {
                var customerAddresses = new Address[]
                {
                    new Address { Street = "Storgatan 1", PostalCode = "111 11", City = "Stockholm", FK_CustomerId = 1 },
                    new Address { Street = "Lilla Vägen 2", PostalCode = "222 22", City = "Göteborg", FK_CustomerId = 2 },
                    new Address { Street = "Kungsgatan 3", PostalCode = "333 33", City = "Malmö", FK_CustomerId = 3 },
                    new Address { Street = "Södra Gränd 4", PostalCode = "444 44", City = "Uppsala", FK_CustomerId = 4 },
                    new Address { Street = "Norra Vägen 5", PostalCode = "555 55", City = "Örebro", FK_CustomerId = 5 },
                    new Address { Street = "Gustavsgatan 6", PostalCode = "666 66", City = "Helsingborg", FK_CustomerId = 6 }
                };

                var employeeAddresses = new Address[]
                {
                    new Address { Street = "Drottninggatan 7", PostalCode = "777 77", City = "Stockholm", FK_EmployeeId = 1 },
                    new Address { Street = "Långgatan 8", PostalCode = "888 88", City = "Göteborg", FK_EmployeeId = 2 },
                    new Address { Street = "Storgatan 9", PostalCode = "999 99", City = "Malmö", FK_EmployeeId = 3 },
                    new Address { Street = "Gärdet 10", PostalCode = "101 01", City = "Uppsala", FK_EmployeeId = 4 },
                    new Address { Street = "Karlsgatan 11", PostalCode = "111 11", City = "Örebro", FK_EmployeeId = 5 },
                    new Address { Street = "Ängelholmsgatan 12", PostalCode = "121 21", City = "Helsingborg", FK_EmployeeId = 6 }
                };

                context.Addresses.AddRange(customerAddresses);
                context.Addresses.AddRange(employeeAddresses);
                context.SaveChanges();
            }

            if (!context.OrderHistorys.Any())
            {
                var orderHistorys = new OrderHistory[]
                {
                    new OrderHistory { FK_OrderId = 1, FK_ProductId = 1 },
                    new OrderHistory { FK_OrderId = 2, FK_ProductId = 2 },
                    new OrderHistory { FK_OrderId = 3, FK_ProductId = 3 },
                    new OrderHistory { FK_OrderId = 4, FK_ProductId = 4 },
                    new OrderHistory { FK_OrderId = 5, FK_ProductId = 5 }
                };

                context.OrderHistorys.AddRange(orderHistorys);
                context.SaveChanges();
            }

        }
    }
}
