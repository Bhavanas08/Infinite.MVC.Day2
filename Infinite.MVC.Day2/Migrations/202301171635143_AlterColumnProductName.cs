﻿namespace Infinite.MVC.Day2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnProductName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
