namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalRecordSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        medicalRecord_Id = c.Int(),
                        sheet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.medicalRecord_Id)
                .ForeignKey("dbo.Sheets", t => t.sheet_Id)
                .Index(t => t.medicalRecord_Id)
                .Index(t => t.sheet_Id);
            
            CreateTable(
                "dbo.Sheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        medicalRecord_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.medicalRecord_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.medicalRecord_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        Phone = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        theRole_Id = c.Int(),
                        theUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.theRole_Id)
                .ForeignKey("dbo.Users", t => t.theUser_Id)
                .Index(t => t.theRole_Id)
                .Index(t => t.theUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "theUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "theRole_Id", "dbo.Roles");
            DropForeignKey("dbo.UserRecords", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRecords", "medicalRecord_Id", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecordSheets", "sheet_Id", "dbo.Sheets");
            DropForeignKey("dbo.MedicalRecordSheets", "medicalRecord_Id", "dbo.MedicalRecords");
            DropIndex("dbo.UserRoles", new[] { "theUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "theRole_Id" });
            DropIndex("dbo.UserRecords", new[] { "User_Id" });
            DropIndex("dbo.UserRecords", new[] { "medicalRecord_Id" });
            DropIndex("dbo.MedicalRecordSheets", new[] { "sheet_Id" });
            DropIndex("dbo.MedicalRecordSheets", new[] { "medicalRecord_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.UserRecords");
            DropTable("dbo.Sheets");
            DropTable("dbo.MedicalRecordSheets");
            DropTable("dbo.MedicalRecords");
        }
    }
}
