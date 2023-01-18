﻿namespace Infinite.MVC.Day2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProductName_Varchar50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
