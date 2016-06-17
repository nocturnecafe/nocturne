﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Nocturne.BL.Helpers;
using Nocturne.Common.Models;

namespace Nocturne.BL
{
    public class NocturneInitializer : /*DropCreateDatabaseAlways*/DropCreateDatabaseIfModelChanges<NocturneContext>
    {
        protected override void Seed(NocturneContext context)
        {
            var autoDetectChangesEnabled = context.Configuration.AutoDetectChangesEnabled;
            context.Configuration.AutoDetectChangesEnabled = false;

            InitializeRoles(context);
            InitializeUsers(context);
            InitializeUserRoles(context);
            InitializeClients(context);
            InitializeCards(context);
            InitializeProducts(context);
            InitializeDiscountTypes(context);
            InitializeDiscounts(context);
            InitializeSessions(context);
            InitializeUsedProducts(context);

            context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;

            base.Seed(context);
        }

        private void InitializeUsedProducts(NocturneContext dc)
        {
            if (!dc.UsedProducts.Any())
            {
                var now = DateTime.Now;
                dc.UsedProducts.Add(new UsedProduct
                {
                    Amount = 2,
                    Date = new DateTime(2015, 1, 1, 14, 0, 0),
                    ProductId = 1,
                    SessionId = 1,
                    RegisteredById = 1
                });
                dc.UsedProducts.Add(new UsedProduct
                {
                    Amount = 3,
                    Date = new DateTime(2015, 1, 1, 14, 5, 0),
                    ProductId = 2,
                    SessionId = 1,
                    RegisteredById = 1
                });

                dc.UsedProducts.Add(new UsedProduct
                {
                    Amount = 1,
                    Date = new DateTime(2015, 1, 2, 16, 5, 0),
                    ProductId = 2,
                    SessionId = 2,
                    RegisteredById = 1
                });

                dc.UsedProducts.Add(new UsedProduct
                {
                    Amount = 1,
                    Date = now.AddMinutes(-130),
                    ProductId = 2,
                    SessionId = 3,
                    RegisteredById = 1
                });

                dc.UsedProducts.Add(new UsedProduct
                {
                    Amount = 5,
                    Date = now.AddMinutes(-17),
                    ProductId = 4,
                    SessionId = 3,
                    RegisteredById = 1
                });

                dc.SaveChanges();
            }
        }
        private void InitializeSessions(NocturneContext dc)
        {
            if (!dc.Sessions.Any())
            {
                var now = DateTime.Now;
                dc.Sessions.Add(new Session
                {
                    CardId = 2,
                    ClientId = 1,
                    From = new DateTime(2015, 1, 1, 13, 0, 0),
                    RegisteredById = 1,
                    To = new DateTime(2015, 1, 1, 15, 0, 0)
                });
                dc.Sessions.Add(new Session
                {
                    CardId = 3,
                    ClientId = 1,
                    From = new DateTime(2015, 1, 2, 15, 0, 0),
                    RegisteredById = 1
                });
                dc.Sessions.Add(new Session
                {
                    CardId = 4,
                    ClientId = 3,
                    From = now.AddMinutes(-147),
                    RegisteredById = 1
                });
                dc.Sessions.Add(new Session
                {
                    CardId = 5,
                    ClientId = 4,
                    From = now.AddMinutes(-37),
                    RegisteredById = 1
                });
                dc.Sessions.Add(new Session
                {
                    CardId = 6,
                    ClientId = 2,
                    From = now.AddMinutes(-62),
                    RegisteredById = 1
                });

                dc.SaveChanges();
            }
        }

        private void InitializeDiscounts(NocturneContext dc)
        {
            if (!dc.Discounts.Any())
            {
                dc.Discounts.Add(new Discount
                {
                    AmountPercent = 10,
                    DiscountTypeId = 1,
                    ProductId = 1,
                    IsActive = true
                });
                dc.Discounts.Add(new Discount
                {
                    AmountPercent = 5,
                    DiscountTypeId = 2,
                    ProductId = 1,
                    IsActive = true
                });
                dc.Discounts.Add(new Discount
                {
                    AmountPercent = 50,
                    DiscountTypeId = 3,
                    ProductId = 2,
                    IsActive = true
                });
                dc.SaveChanges();
            }
        }

        private void InitializeDiscountTypes(NocturneContext dc)
        {
            if (!dc.DiscountTypes.Any())
            {
                var dt = new DiscountType
                {
                    Name = new MultiLangString("A modest discount", "en", "A modest discount", "DiscountType"),
                    IsActive = true,
                };
                dc.DiscountTypes.Add(dt);
                dc.Translations.Add(new Translation()
                {
                    Value = "Tagasihoidlik allahindlus",
                    Culture = "et",
                    MultiLangString = dt.Name
                });

                dt = new DiscountType
                {
                    Name = new MultiLangString("Today's special!", "en", "Today's special!", "DiscountType"),
                    IsActive = true,
                };
                dc.DiscountTypes.Add(dt);
                dc.Translations.Add(new Translation()
                {
                    Value = "Päeva eri!",
                    Culture = "et",
                    MultiLangString = dt.Name
                });

                dt = new DiscountType
                {
                    Name = new MultiLangString("-50%! Everything goes!", "en", "-50%! Everything goes!", "DiscountType"),
                    IsActive = true,
                };
                dc.DiscountTypes.Add(dt);
                dc.Translations.Add(new Translation()
                {
                    Value = "-50%! Kõik müügiks!",
                    Culture = "et",
                    MultiLangString = dt.Name
                });

                dc.SaveChanges();
            }
        }

        private void InitializeProducts(NocturneContext dc)
        {
            if (!dc.Products.Any())
            {
                var product = new Product
                {
                    Name = new MultiLangString("Caesar Salad", "en", "Caesar Salad", "Product"),
                    Description = new MultiLangString(
                        "Romaine with freshly made croutons, parmesan cheese, and our great caesar dressing", "en",
                        "Romaine with freshly made croutons, parmesan cheese, and our great caesar dressing", "Product"),
                    IsActive = true,
                    Price = 8
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation() { Value = "Salat", Culture = "et", MultiLangString = product.Name });
                dc.Translations.Add(new Translation()
                {
                    Value = "Värske salat",
                    Culture = "et",
                    MultiLangString = product.Description
                });


                product = new Product
                {
                    Name = new MultiLangString("Whole Chicken", "en", "Whole Chicken", "Product"),
                    Description = new MultiLangString("Total dinner with 3 sides", "en", "Total dinner with 3 sides", "Product"),
                    IsActive = true,
                    Price = 27.5m
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation()
                {
                    Value = "Kana",
                    Culture = "et",
                    MultiLangString = product.Name
                });
                dc.Translations.Add(new Translation()
                {
                    Value = "Täitsa suur praad",
                    Culture = "et",
                    MultiLangString = product.Description
                });

                product = new Product
                {
                    Name = new MultiLangString("Chicken Ceasar Salad Wrap", "en", "Chicken Ceasar Salad Wrap", "Product"),
                    Description = new MultiLangString("In whole wheat tortilla", "en", "In whole wheat tortilla", "Product"),
                    Price = 12
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation()
                {
                    Value = "Kana salat",
                    Culture = "et",
                    MultiLangString = product.Name
                });
                dc.Translations.Add(new Translation()
                {
                    Value = "Koos jalgadega",
                    Culture = "et",
                    MultiLangString = product.Description
                });

                product = new Product
                {
                    Name = new MultiLangString("Beef Chili", "en", "Beef Chili", "Product"),
                    Description = new MultiLangString(
                        "Chili con carne topped with cheese, served with rice and our fresh chips", "en",
                        "Chili con carne topped with cheese, served with rice and our fresh chips", "Product"),
                    IsActive = true,
                    Price = 14.5m
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation()
                {
                    Value = "Liha",
                    Culture = "et",
                    MultiLangString = product.Name
                });
                dc.Translations.Add(new Translation()
                {
                    Value = "Kergelt vürtsine",
                    Culture = "et",
                    MultiLangString = product.Description
                });

                product = new Product
                {
                    Name = new MultiLangString("Tossed Salad", "en", "Tossed Salad", "Product"),
                    Description = new MultiLangString(
                        "Tossed salad with chips and taco vinaigrette", "en",
                        "Tossed salad with chips and taco vinaigrette", "Product"),
                    IsActive = true,
                    Price = 9
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation()
                {
                    Value = "Veel üks salat",
                    Culture = "et",
                    MultiLangString = product.Name
                });
                dc.Translations.Add(new Translation()
                {
                    Value = "Täitsa söödav",
                    Culture = "et",
                    MultiLangString = product.Description
                });

                product = new Product
                {
                    Name = new MultiLangString("Mineral water", "en", "Mineral water", "Product"),
                    Description = new MultiLangString("Exceptionally good carbonized water", "en", "Exceptionally good carbonized water", "Product"),
                    IsActive = true,
                    Price = 2
                };
                dc.Products.Add(product);
                dc.Translations.Add(new Translation()
                {
                    Value = "Mineraalvesi",
                    Culture = "et",
                    MultiLangString = product.Name
                });
                dc.Translations.Add(new Translation()
                {
                    Value = "Kergelt soolane",
                    Culture = "et",
                    MultiLangString = product.Description
                });

                dc.SaveChanges();
            }
        }

        private void InitializeCards(NocturneContext dc)
        {
            if (!dc.Cards.Any())
            {
                dc.Cards.Add(new Card
                {
                    ClientId = 5,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = 4,
                    Uid = 1894916139,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = null,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = 1,
                    Uid = 10000000000001,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = null,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = 2,
                    Uid = 10000000000002,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = null,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = 3,
                    Uid = 10000000000003,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = null,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = 4,
                    Uid = 10000000000004,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = 2,
                    CardType = (int)CardTypeEnum.RfidCard,
                    Firstname = null,
                    Lastname = null,
                    UserId = null,
                    Uid = 1020304050607,
                    RegCard = null
                });

                dc.Cards.Add(new Card
                {
                    ClientId = null,
                    CardType = (int)CardTypeEnum.IdCard,
                    Firstname = "Jenna",
                    Lastname = "Jameson",
                    UserId = null,
                    Uid = 0,
                    RegCard = "49010124259"
                });

                dc.SaveChanges();
            }
        }

        private void InitializeClients(NocturneContext dc)
        {
            if (!dc.Clients.Any())
            {
                dc.Clients.Add(new Client { Name = "Nikki", Surname = "Benz", IdCode = "49010124250" });
                dc.Clients.Add(new Client { Name = "Asa", Surname = "Akira", IdCode = "49010124251" });
                dc.Clients.Add(new Client { Name = "Lisa", Surname = "Ann", IdCode = "49010124252" });
                dc.Clients.Add(new Client { Name = "Sunny", Surname = "Leone", IdCode = "49010124253" });
                dc.Clients.Add(new Client { Name = "Sasha", Surname = "Grey", IdCode = "49010124254" });
                dc.Clients.Add(new Client { Name = "Jenna", Surname = "Haze", IdCode = "49010124255" });
                dc.Clients.Add(new Client { Name = "Bree", Surname = "Olson", IdCode = "49010124256" });
                dc.Clients.Add(new Client { Name = "Jesse", Surname = "Jane", IdCode = "49010124257" });
                dc.Clients.Add(new Client { Name = "Tera", Surname = "Patrick", IdCode = "49010124258" });
                dc.Clients.Add(new Client { Name = "Jenna", Surname = "Jameson", IdCode = "49010124259" });

                dc.SaveChanges();
            }
        }

        private static void InitializeUserRoles(NocturneContext dc)
        {
            if (!dc.Roles.Any())
            {
                dc.Roles.Add(new Role { Name = User.Administrator });
                dc.Roles.Add(new Role { Name = User.Worker });
                dc.SaveChanges();
            }
        }

        private static void InitializeRoles(NocturneContext dc)
        {
            if (!dc.Roles.Any())
            {
                dc.Roles.Add(new Role { Name = User.Administrator });
                dc.Roles.Add(new Role { Name = User.Worker });
                dc.SaveChanges();
            }
        }

        private static void InitializeUsers(NocturneContext dc)
        {
            if (!dc.Users.Any())
            {
                dc.Users.Add(new User
                {
                    Name = User.Administrator,
                    DisplayName = "Admin kasutaja",
                    IsActive = true,
                    RegCode = "37529732200",
                    UserRoles = new List<UserRole> { new UserRole { RoleId = 1 } }
                });
                dc.Users.Add(new User
                {
                    Name = User.Worker,
                    DisplayName = "Töötaja kasutaja",
                    IsActive = true,
                    RegCode = "37529732201",
                    UserRoles = new List<UserRole> { new UserRole { RoleId = 2 } }
                });
                dc.Users.Add(new User
                {
                    Name = "Empty",
                    DisplayName = "Kasutaja X",
                    IsActive = true,
                    RegCode = "37529732202"
                });
                dc.Users.Add(new User
                {
                    Name = "SysAdmin",
                    DisplayName = "Test kasutaja",
                    IsActive = true,
                    RegCode = "37529732203",
                    UserRoles = new List<UserRole> { new UserRole { RoleId = 1 }, new UserRole { RoleId = 2 } }
                });
                dc.SaveChanges();
            }
        }
    }
}
