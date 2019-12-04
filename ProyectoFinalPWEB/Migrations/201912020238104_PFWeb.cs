namespace ProyectoFinalPWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PFWeb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliados",
                c => new
                    {
                        AfiliadosID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Parentesco = c.String(),
                    })
                .PrimaryKey(t => t.AfiliadosID);
            
            CreateTable(
                "dbo.Socios",
                c => new
                    {
                        SocioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cedula = c.Int(nullable: false),
                        Foto = c.Binary(),
                        Direccion = c.String(),
                        Telefonos = c.String(),
                        Sexo = c.String(),
                        Edad = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        AfiliadosID = c.Int(nullable: false),
                        MembresiaID = c.Int(nullable: false),
                        LugarDeTrabajo = c.DateTime(nullable: false),
                        DireccionOficina = c.String(),
                        TelefonoOficina = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SocioId)
                .ForeignKey("dbo.Afiliados", t => t.AfiliadosID, cascadeDelete: true)
                .ForeignKey("dbo.TiposMembresias", t => t.MembresiaID, cascadeDelete: true)
                .Index(t => t.AfiliadosID)
                .Index(t => t.MembresiaID);
            
            CreateTable(
                "dbo.TiposMembresias",
                c => new
                    {
                        MembresiaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Costo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MembresiaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Socios", "MembresiaID", "dbo.TiposMembresias");
            DropForeignKey("dbo.Socios", "AfiliadosID", "dbo.Afiliados");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Socios", new[] { "MembresiaID" });
            DropIndex("dbo.Socios", new[] { "AfiliadosID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TiposMembresias");
            DropTable("dbo.Socios");
            DropTable("dbo.Afiliados");
        }
    }
}
