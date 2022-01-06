using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<DeliveryInformation> DeliveryInformations { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<MailSetting> MailSettings { get; set; }
        public DbSet<MailSubscriber> MailSubscribers { get; set; }
        public DbSet<MembershipAgreement> MembershipAgreements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RefundConditions> RefundConditions { get; set; }
        public DbSet<Seo> Seos { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Variant> Variants { get; set; }

        public DatabaseContext() : base("DatabaseContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, DataAccessLayer.Migrations.Configuration>());
        }
        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
