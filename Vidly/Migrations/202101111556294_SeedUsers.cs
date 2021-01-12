namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'573ac20a-79d5-4888-9b86-3e2d210c50d6', N'guest@gmail.com', 0, N'AP9fGIbf00zb9j/y4BLM6qFLCu4A0R4UyVK/2l5UnMfBn/ehrzws+G6+ZcntsEBGhw==', N'a006f7cd-1c1c-4ecb-b7b0-a751a775c438', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'696b1be6-4f67-4e9c-8f84-fc69e0b5836f', N'admin@vidly.com', 0, N'AMs+/LN3Bg0CrKnILAy0r41Rqmzut4ksN7aCdTt1mVPREE2gWmVqOYSbC5CuktE3xA==', N'bc7abc62-efde-4b19-a281-781516ad25e8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be541eb3-4130-4f8d-b4c9-1e355caf108f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'696b1be6-4f67-4e9c-8f84-fc69e0b5836f', N'be541eb3-4130-4f8d-b4c9-1e355caf108f')

");
        }
        
        public override void Down()
        {

        }
    }
}
