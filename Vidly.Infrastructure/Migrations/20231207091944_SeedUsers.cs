using Microsoft.EntityFrameworkCore.Migrations;
using Vidly.Shared;

#nullable disable

namespace Vidly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8cef07b6-1ed0-47f0-bbf2-ec2d4f1e2104', N'{IdentityRoles.CanManageMovies}', N'{IdentityRoles.CanManageMovies.ToUpper()}', NULL)

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c5c775dd-2c88-476c-ba9f-c87e2357ad27', N'admin@vidly.com', N'ADMIN@VIDLY.COM', N'admin@vidly.com', N'ADMIN@VIDLY.COM', 0, N'AQAAAAIAAYagAAAAECwJD04i5COZS8Ch/1mXkKMt8+9Uy5cZL8BGrAx0bsqC1J5RqpZk7q05/2kZZ3dtCg==', N'CKKFWWX6DVHVD2AXWBOFMI2ZIBIM6MGZ', N'9d59b88a-b422-46af-94f0-15ed4a506c96', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fc38ca7d-446a-4fac-b8aa-8a9debeb35e4', N'guest@vidly.com', N'GUEST@VIDLY.COM', N'guest@vidly.com', N'GUEST@VIDLY.COM', 0, N'AQAAAAIAAYagAAAAEHiV2FoxUlYheYxWJLJMAZ0d9HiT8iEcrspbxYoYpboFDkT2vVwKGlsgBQA+pD8R5g==', N'4JQUMAPPD3VRRZHBGLIPLEVE2ZSGJLJN', N'74c4aaeb-c51d-4fc6-80a2-1e4a1808aad2', NULL, 0, 0, NULL, 1, 0)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c5c775dd-2c88-476c-ba9f-c87e2357ad27', N'8cef07b6-1ed0-47f0-bbf2-ec2d4f1e2104')
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
