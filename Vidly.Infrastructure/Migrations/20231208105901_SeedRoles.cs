using Microsoft.EntityFrameworkCore.Migrations;
using Vidly.Shared;

#nullable disable

namespace Vidly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8cef07b6-1ed0-48f0-bbf2-ec2d4f1e2104', N'{IdentityRoles.CanManageGenres}', N'{IdentityRoles.CanManageGenres.ToUpper()}', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8cef07b6-1ed0-49f0-bbf2-ec2d4f1e2104', N'{IdentityRoles.CanManageCustomers}', N'{IdentityRoles.CanManageCustomers.ToUpper()}', NULL)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c5c775dd-2c88-476c-ba9f-c87e2357ad27', N'8cef07b6-1ed0-48f0-bbf2-ec2d4f1e2104')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c5c775dd-2c88-476c-ba9f-c87e2357ad27', N'8cef07b6-1ed0-49f0-bbf2-ec2d4f1e2104')
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
