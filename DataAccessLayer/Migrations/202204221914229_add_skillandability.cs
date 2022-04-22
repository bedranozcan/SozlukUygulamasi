namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_skillandability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        AbilityID = c.Int(nullable: false, identity: true),
                        AbilityName = c.String(maxLength: 100),
                        AbilityCount = c.Int(nullable: false),
                        AbilityStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AbilityID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 150),
                        SkillImages = c.String(maxLength: 250),
                        Skills1 = c.String(maxLength: 50),
                        Skills2 = c.String(maxLength: 50),
                        Skills3 = c.String(maxLength: 50),
                        Skills4 = c.String(maxLength: 50),
                        Skills5 = c.String(maxLength: 50),
                        Skills6 = c.String(maxLength: 50),
                        Skills7 = c.String(maxLength: 50),
                        Skills8 = c.String(maxLength: 50),
                        Skills9 = c.String(maxLength: 50),
                        Skills10 = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.Abilities");
        }
    }
}
