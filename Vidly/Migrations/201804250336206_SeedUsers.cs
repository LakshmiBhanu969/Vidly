namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eef2fa11-535f-47b5-a8e3-1f6c5a357462', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'867bbf87-22c2-492c-b691-8b9d6a3157e1', N'bhanu@vidly.com', 0, N'AJGLzt3xB3BuNTu5gqcBs7/5yEx8K9JgdYiTslOxPA0c53YuJ6zqAW5j8d+ZmT+j7g==', N'9fe17a94-a02b-4d73-a4dc-caad941b39e4', NULL, 0, 0, NULL, 1, 0, N'bhanu@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8b8f6c5e-e04f-48ab-a385-357a4b6fc757', N'admin@vidly.com', 0, N'ANLm2rDX3I0r0kfgvrXKMF7hPYj0q2TdlLH3usUx8+xWkURwzEBFxccEY1X2y6L+nA==', N'167d20f6-b483-473e-a691-6cea01ec266b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b8f6c5e-e04f-48ab-a385-357a4b6fc757', N'eef2fa11-535f-47b5-a8e3-1f6c5a357462')



            ");
        }
        
        public override void Down()
        {
        }
    }
}
