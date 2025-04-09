using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trizen.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Categories", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "DestinationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_DestinationTypes", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Personalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Personalities", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "TourTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_TourTypes", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GeographicalLocation = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DestinationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Destinations", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Destinations_DestinationTypes_DestinationTypeId",
                        column: x => x.DestinationTypeId,
                        principalTable: "DestinationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PersonalityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PersonalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PersonalityCategories", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityCategories_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PersonalityDestinationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PersonalityDestinationTypes", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityDestinationTypes_DestinationTypes_DestinationTypeId",
                        column: x => x.DestinationTypeId,
                        principalTable: "DestinationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityDestinationTypes_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PersonalityId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WalletAmount = table.Column<double>(type: "float", nullable: false),
                    ImageProfile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Users", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Users_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "PersonalityTourTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PersonalityTourTypes", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityTourTypes_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PersonalityTourTypes_TourTypes_TourTypeId",
                        column: x => x.TourTypeId,
                        principalTable: "TourTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    MinimumAge = table.Column<int>(type: "int", nullable: false),
                    MaximumAge = table.Column<int>(type: "int", nullable: false),
                    MaximumPassenger = table.Column<int>(type: "int", nullable: false),
                    DaysCount = table.Column<int>(type: "int", nullable: false),
                    SleepNightsCount = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    TourTypeId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Tours", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Tours_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_Tours_TourTypes_TourTypeId",
                        column: x => x.TourTypeId,
                        principalTable: "TourTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "TourCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_TourCategories", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_TourCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_TourCategories_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "TourObserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservedTourId = table.Column<int>(type: "int", nullable: false),
                    ObserverUserId = table.Column<int>(type: "int", nullable: false),
                    ObserveType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_TourObserves", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_TourObserves_Tours_ObservedTourId",
                        column: x => x.ObservedTourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_TourObserves_Users_ObserverUserId",
                        column: x => x.ObserverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraveledTourId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Travels", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Travels_Tours_TraveledTourId",
                        column: x => x.TraveledTourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_Travels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    PassengerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Passengers", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Passengers_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    _ = table.ForeignKey(
                        name: "FK_Passengers_Users_PassengerUserId",
                        column: x => x.PassengerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Destinations_DestinationTypeId",
                table: "Destinations",
                column: "DestinationTypeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Passengers_PassengerUserId",
                table: "Passengers",
                column: "PassengerUserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Passengers_TravelId",
                table: "Passengers",
                column: "TravelId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityCategories_CategoryId",
                table: "PersonalityCategories",
                column: "CategoryId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityCategories_PersonalityId",
                table: "PersonalityCategories",
                column: "PersonalityId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityDestinationTypes_DestinationTypeId",
                table: "PersonalityDestinationTypes",
                column: "DestinationTypeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityDestinationTypes_PersonalityId",
                table: "PersonalityDestinationTypes",
                column: "PersonalityId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityTourTypes_PersonalityId",
                table: "PersonalityTourTypes",
                column: "PersonalityId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PersonalityTourTypes_TourTypeId",
                table: "PersonalityTourTypes",
                column: "TourTypeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_TourCategories_CategoryId",
                table: "TourCategories",
                column: "CategoryId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_TourCategories_TourId",
                table: "TourCategories",
                column: "TourId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_TourObserves_ObservedTourId",
                table: "TourObserves",
                column: "ObservedTourId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_TourObserves_ObserverUserId",
                table: "TourObserves",
                column: "ObserverUserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tours_DestinationId",
                table: "Tours",
                column: "DestinationId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tours_TourTypeId",
                table: "Tours",
                column: "TourTypeId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Travels_TraveledTourId",
                table: "Travels",
                column: "TraveledTourId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId",
                table: "Travels",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalityId",
                table: "Users",
                column: "PersonalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "Passengers");

            _ = migrationBuilder.DropTable(
                name: "PersonalityCategories");

            _ = migrationBuilder.DropTable(
                name: "PersonalityDestinationTypes");

            _ = migrationBuilder.DropTable(
                name: "PersonalityTourTypes");

            _ = migrationBuilder.DropTable(
                name: "TourCategories");

            _ = migrationBuilder.DropTable(
                name: "TourObserves");

            _ = migrationBuilder.DropTable(
                name: "Travels");

            _ = migrationBuilder.DropTable(
                name: "Categories");

            _ = migrationBuilder.DropTable(
                name: "Tours");

            _ = migrationBuilder.DropTable(
                name: "Users");

            _ = migrationBuilder.DropTable(
                name: "Destinations");

            _ = migrationBuilder.DropTable(
                name: "TourTypes");

            _ = migrationBuilder.DropTable(
                name: "Personalities");

            _ = migrationBuilder.DropTable(
                name: "DestinationTypes");
        }
    }
}
