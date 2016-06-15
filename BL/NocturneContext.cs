using Nocturne.Common.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static System.Data.Entity.Database;

namespace Nocturne.BL
{
    public class NocturneContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UsedProduct> UsedProducts { get; set; }
        public DbSet<MultiLangString> MultiLangStrings { get; set; }
        public DbSet<Translation> Translations { get; set; }


        public NocturneContext() : base("name=NocturneContext")
        {
            Database.SetInitializer(new NocturneInitializer());
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}