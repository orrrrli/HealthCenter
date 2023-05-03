namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sheets", "MedicalRecord_Id", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "User_Id", "dbo.Users");
            DropIndex("dbo.MedicalRecords", new[] { "User_Id" });
            DropIndex("dbo.Sheets", new[] { "MedicalRecord_Id" });
            DropColumn("dbo.MedicalRecords", "User_Id");
            DropColumn("dbo.Sheets", "MedicalRecord_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sheets", "MedicalRecord_Id", c => c.Int());
            AddColumn("dbo.MedicalRecords", "User_Id", c => c.Int());
            CreateIndex("dbo.Sheets", "MedicalRecord_Id");
            CreateIndex("dbo.MedicalRecords", "User_Id");
            AddForeignKey("dbo.MedicalRecords", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Sheets", "MedicalRecord_Id", "dbo.MedicalRecords", "Id");
        }
    }
}
