namespace firstMvcProjectAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
