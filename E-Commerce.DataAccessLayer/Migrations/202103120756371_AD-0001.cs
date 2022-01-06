namespace E_Commerce.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AD0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Description = c.String(),
                        StockCode = c.String(),
                        Piece = c.Int(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.DeliveryInformations", t => t.DeliveryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.DeliveryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        UpperCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.UpperCategoryId)
                .Index(t => t.UpperCategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Pass = c.String(),
                        LoginId = c.Int(nullable: false),
                        OrderHistoryId = c.Int(nullable: false),
                        DeliveryAddress = c.String(),
                        BillingAddress = c.String(),
                        Baskets_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Baskets_Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .ForeignKey("dbo.OrderHistories", t => t.OrderHistoryId, cascadeDelete: true)
                .Index(t => t.LoginId)
                .Index(t => t.OrderHistoryId)
                .Index(t => t.Baskets_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Pass = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellBy = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        CargoFollow = c.String(),
                        BasketId = c.Int(nullable: false),
                        OrderDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_Id)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.BasketId)
                .Index(t => t.OrderDetail_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CargoCompanies", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.VariantId)
                .Index(t => t.CargoId)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.CargoCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Adress = c.String(),
                        Telefon = c.String(),
                        WebSite = c.String(),
                        EMail = c.String(),
                        TaxNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.VariantId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Definition = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderInformation = c.String(),
                        SmtpServer = c.String(),
                        SmtpPort = c.String(),
                        MailSender = c.String(),
                        Email = c.String(),
                        EmailPass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailSubscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MailAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipAgreements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrivacyPolicies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RefundConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Keyword = c.String(),
                        Content = c.String(),
                        Map = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telefon = c.String(),
                        WhatsApp = c.String(),
                        Adres = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Instagram = c.String(),
                        YouTube = c.String(),
                        Twitter = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Baskets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "DeliveryId", "dbo.DeliveryInformations");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderDetails", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.OrderDetails", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.ProductVariants", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Variants", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductVariants", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.ProductVariants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Properties", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "OrderDetail_Id", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "CargoId", "dbo.CargoCompanies");
            DropForeignKey("dbo.Orders", "BasketId", "dbo.Baskets");
            DropForeignKey("dbo.Users", "OrderHistoryId", "dbo.OrderHistories");
            DropForeignKey("dbo.Users", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Users", "Baskets_Id", "dbo.Baskets");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "UpperCategoryId", "dbo.Categories");
            DropIndex("dbo.Variants", new[] { "Category_Id" });
            DropIndex("dbo.ProductVariants", new[] { "PropertyId" });
            DropIndex("dbo.ProductVariants", new[] { "VariantId" });
            DropIndex("dbo.ProductVariants", new[] { "ProductId" });
            DropIndex("dbo.Properties", new[] { "Category_Id" });
            DropIndex("dbo.OrderDetails", new[] { "PropertyId" });
            DropIndex("dbo.OrderDetails", new[] { "PaymentMethodId" });
            DropIndex("dbo.OrderDetails", new[] { "CargoId" });
            DropIndex("dbo.OrderDetails", new[] { "VariantId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "OrderDetail_Id" });
            DropIndex("dbo.Orders", new[] { "BasketId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Baskets_Id" });
            DropIndex("dbo.Users", new[] { "OrderHistoryId" });
            DropIndex("dbo.Users", new[] { "LoginId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Categories", new[] { "UpperCategoryId" });
            DropIndex("dbo.Products", new[] { "DeliveryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Baskets", new[] { "VariantId" });
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            DropTable("dbo.SocialMedias");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.Seos");
            DropTable("dbo.RefundConditions");
            DropTable("dbo.PrivacyPolicies");
            DropTable("dbo.MembershipAgreements");
            DropTable("dbo.MailSubscribers");
            DropTable("dbo.MailSettings");
            DropTable("dbo.DeliveryInformations");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Variants");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Properties");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.CargoCompanies");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderHistories");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Baskets");
            DropTable("dbo.Abouts");
        }
    }
}
