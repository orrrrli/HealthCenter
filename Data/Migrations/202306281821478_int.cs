namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecordSheets", "medicalRecord_Id", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecordSheets", "sheet_Id", "dbo.Sheets");
            DropIndex("dbo.MedicalRecordSheets", new[] { "medicalRecord_Id" });
            DropIndex("dbo.MedicalRecordSheets", new[] { "sheet_Id" });
            CreateTable(
                "dbo.UserSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sheet_Id = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sheets", t => t.sheet_Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.sheet_Id)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.MedicalRecords", "Size", c => c.Double(nullable: false));
            AddColumn("dbo.MedicalRecords", "sBP", c => c.Double(nullable: false));
            AddColumn("dbo.MedicalRecords", "dBP", c => c.Double(nullable: false));
            AddColumn("dbo.Sheets", "mellitusDiabetes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "arterialHypertension", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "hypercholesterolemia", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "hypertriglyceridemia", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "chronicRenalFailure", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "heartDisease", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sheets", "liverDiseases", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sheets", "Nombre");
            DropColumn("dbo.Sheets", "Descripcion");
            DropColumn("dbo.Sheets", "Status");
            DropTable("dbo.MedicalRecordSheets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicalRecordSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        medicalRecord_Id = c.Int(),
                        sheet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sheets", "Status", c => c.String());
            AddColumn("dbo.Sheets", "Descripcion", c => c.String());
            AddColumn("dbo.Sheets", "Nombre", c => c.String());
            DropForeignKey("dbo.UserSheets", "user_Id", "dbo.Users");
            DropForeignKey("dbo.UserSheets", "sheet_Id", "dbo.Sheets");
            DropIndex("dbo.UserSheets", new[] { "user_Id" });
            DropIndex("dbo.UserSheets", new[] { "sheet_Id" });
            DropColumn("dbo.Sheets", "liverDiseases");
            DropColumn("dbo.Sheets", "heartDisease");
            DropColumn("dbo.Sheets", "chronicRenalFailure");
            DropColumn("dbo.Sheets", "hypertriglyceridemia");
            DropColumn("dbo.Sheets", "hypercholesterolemia");
            DropColumn("dbo.Sheets", "arterialHypertension");
            DropColumn("dbo.Sheets", "mellitusDiabetes");
            DropColumn("dbo.MedicalRecords", "dBP");
            DropColumn("dbo.MedicalRecords", "sBP");
            DropColumn("dbo.MedicalRecords", "Size");
            DropTable("dbo.UserSheets");
            CreateIndex("dbo.MedicalRecordSheets", "sheet_Id");
            CreateIndex("dbo.MedicalRecordSheets", "medicalRecord_Id");
            AddForeignKey("dbo.MedicalRecordSheets", "sheet_Id", "dbo.Sheets", "Id");
            AddForeignKey("dbo.MedicalRecordSheets", "medicalRecord_Id", "dbo.MedicalRecords", "Id");
        }
    }
}
