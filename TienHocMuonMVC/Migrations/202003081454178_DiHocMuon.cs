namespace TienHocMuonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiHocMuon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiHocMuons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(),
                        HinhThucNopPhat = c.String(),
                        SoLuong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NgayNopPhat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiHocMuons");
        }
    }
}
