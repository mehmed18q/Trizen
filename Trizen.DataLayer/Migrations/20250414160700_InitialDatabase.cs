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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    PersonalityId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                    PersonalityId = table.Column<int>(type: "int", nullable: false),
                    DestinationTypeId = table.Column<int>(type: "int", nullable: false)
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
                    Gender = table.Column<int>(type: "int", nullable: false),
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
                    PersonalityId = table.Column<int>(type: "int", nullable: false),
                    TourTypeId = table.Column<int>(type: "int", nullable: false)
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
                name: "DestinationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_DestinationCategories", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_DestinationCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_DestinationCategories_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
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
                name: "DestinationObserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservedDestinationId = table.Column<int>(type: "int", nullable: false),
                    ObserverUserId = table.Column<int>(type: "int", nullable: false),
                    ObserveType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_DestinationObserves", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_DestinationObserves_Destinations_ObservedDestinationId",
                        column: x => x.ObservedDestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_DestinationObserves_Users_ObserverUserId",
                        column: x => x.ObserverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "SuggestedTours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PersonalityId = table.Column<int>(type: "int", nullable: false),
                    UserAge = table.Column<int>(type: "int", nullable: false),
                    SuggestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_SuggestedTours", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_SuggestedTours_Personalities_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SuggestedTours_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SuggestedTours_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            _ = migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "طبیعت‌گردی" },
                    { 2, "ماجراجویی و هیجان" },
                    { 3, "تفریحی و استراحتی" },
                    { 4, "فرهنگی و هنری" },
                    { 5, "تاریخی" },
                    { 6, "زیارتی" },
                    { 7, "ورزشی" },
                    { 8, "کمپینگ و بقا در طبیعت" },
                    { 9, "تورهای غذایی و آشپزی" },
                    { 10, "تورهای عکاسی" },
                    { 11, "تورهای کشتی و کروز" },
                    { 12, "تورهای خاص و لاکچری" },
                    { 13, "سفرهای علمی و آموزشی" },
                    { 14, "سفر های کاری" },
                    { 15, "خانوادگی" },
                    { 16, "بوم گردی" },
                    { 17, "یوگا" },
                    { 18, "سلامت" },
                    { 19, "صنایع دستی و کارگاه‌های محلی" },
                    { 20, "موسیقی و رقص‌های فولکلور" },
                    { 21, "مشارکتی با جوامع محلی" },
                    { 22, "گل‌دهی و طبیعت بهاری" },
                    { 23, "فستیوال‌ها و کارناوال‌ها" },
                    { 24, "زمستانی و برفی " },
                    { 25, "نوجوانان و جوانان" },
                    { 26, "سالمندان" },
                    { 27, "حیوانات خانگی" },
                    { 28, "مدیتیشن و ریلکسیشن" },
                    { 29, "ارواح و مکان‌های اسرارآمیز" },
                    { 30, "نجومی و تماشای ستارگان" },
                    { 31, "هلیکوپتری " },
                    { 32, "اقامت در هتل‌های بی‌نظیر" },
                    { 33, "زبان‌آموزی" },
                    { 34, "کسب‌وکار و استارتاپی" },
                    { 35, "زیست‌شناس" },
                    { 36, "تورهای اکوولنتیرینگ" },
                    { 37, "انسان‌دوستانه" },
                    { 38, "صنایع دستی و کارگاه‌های محلی" }
                });

            _ = migrationBuilder.InsertData(
                table: "DestinationTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "دریا" },
                    { 2, "جنگل" },
                    { 3, "کویر" },
                    { 4, "جزایر" },
                    { 5, "کوهستان" },
                    { 6, "غارها" },
                    { 7, "روستاهای بوم‌گردی" },
                    { 8, "مناطق قطبی" },
                    { 9, "چشمه‌های آبگرم" },
                    { 10, "موزه" },
                    { 11, "مقاصد مذهبی و زیارتی" },
                    { 12, "رودخانه و دریاچه" },
                    { 13, "شهرهای مدرن" },
                    { 14, "شهرهای تاریخی" },
                    { 15, "سایر" },
                    { 16, "طبیعت" },
                    { 17, "معابد" },
                    { 18, "مناطق خاص" },
                    { 19, "تالاب‌ و مرداب" },
                    { 20, "دشت‌های نمکی و آیینه‌ای" },
                    { 21, "دره‌های رنگارنگ" },
                    { 22, "پارک‌های ملی حیات وحش" },
                    { 23, "آتشفشان‌های نیمه‌فعال" },
                    { 24, "چشمه‌های آب معدنی و گِلی" },
                    { 25, "صخره‌های مرجانی و دنیای زیر آب" },
                    { 26, "بیابان‌های یخی و یخچال‌های طبیعی" },
                    { 27, "شهرهای زیرزمینی" },
                    { 28, "قلعه‌های مخروبه و افسانه‌ای" },
                    { 29, "مسیرهای باستانی و جاده‌های تاریخی" },
                    { 30, "سایت‌های باستان‌شناسی مرموز" },
                    { 31, "شهرهای شناور و آبی" },
                    { 32, "شهرهای آینده‌نگر و تکنولوژیک" },
                    { 33, "شهرهای ارواح و متروکه" },
                    { 34, "پارک‌های ملی با مسیرهای تراولینگ و سنگ‌نوردی" },
                    { 35, "تونل‌های درختی و جنگل‌های بارانی" },
                    { 36, "مناطق بیابانی با تپه‌های شنی بلند" },
                    { 37, "مکان‌های انرژی‌های ماورایی " },
                    { 38, "مناطق با پدیده‌های نوری" },
                    { 39, "روستاهای رنگارنگ" },
                    { 40, "مزارع چای و قهوه" }
                });

            _ = migrationBuilder.InsertData(
                table: "Personalities",
                columns: new[] { "Id", "Code", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "ENFJ", "برون گرا, شهودی, احساسی, قضاوتی, کاریزماتیک, اجتماعی, دلسوز", "رهبر الهام بخش" },
                    { 2, "ENFP", "برون گرا, شهودی, احساسی, ادراکی, خلاق, پر انرژی, اجتماعی", "مبارز" },
                    { 3, "ESFJ", "برون گرا, حسی, احساسی, قضاوتی, وفادار, مردم دار, سازمان ده", "مشاور اجتماعی" },
                    { 4, "ESFP", "برون گرا, حسی, احساسی, ادراکی, اجتماعی, هیجان دوست, سرزنده", "مجری" },
                    { 5, "INFJ", "درون گرا, حسی, احسایسی, ادراکی, آرامان گرا, الهام بخش", "مشاور" },
                    { 6, "INFP", "درون گرا, شهودی, احساسی, قضاوتی, خلاق, الهام بخش", "ایده آل گرا" },
                    { 7, "INTJ", "درون گرا, شهودی, منطقی, قضاوتی, استراتژیک, مستقل, تحلیلگر", "معمار" },
                    { 8, "INTP", "درون گرا, شهودی, منطقی, ادراکی, تحلیلی, کنجکاو", "متفکر" },
                    { 9, "ISFJ", "درون گرا, حسی, احساسی, قضاوتی, وفادار, مهربان, دقیق", "مدافع" },
                    { 10, "ISFP", "درون گرا, حسی, احساسی,  قضاوتی, هنرمند, انعطاف پذیر", "هنرمند" },
                    { 11, "ISTJ", "درون گرا, حسی, منطقی, قضاوتی, مسئولیت پذیر, منظم", "بازرس" },
                    { 12, "ISTP", "درون گرا, حسی, منطقی, ادراکی, کنجکاو, ماجراجو, مستقل", "چیره دست" },
                    { 13, "ESTJ", "برون گرا, حسی, منطقی, قضاوتی, منظم, رهبر, قاطع", "مدیر" },
                    { 14, "ENTJ", "برون گرا, شهودی, منطقی, قضاوتی, قاطع, برنامه ریز, ریسک پذیر", "فرمانده" },
                    { 15, "ENTP", "برون گرا, شهودی, منطقی, ادراکی, نو اندیش, چالش پذیر, ماجراجو", "مبتکر" },
                    { 16, "ESTP", "برون گرا, حسی, منطقی, ادراکی, پرانرژی, ماجراجو, ریسک پذیر", "کارآفرین" }
                });

            _ = migrationBuilder.InsertData(
                table: "TourTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "دورهمی" },
                    { 2, "دوست داران محیط زیست" },
                    { 3, "بوم گردی" },
                    { 4, "ورزشی" },
                    { 5, "بقا در طبیعت و کمپینگ" },
                    { 6, "تفریحی" },
                    { 7, "سرگرمی" },
                    { 8, "ارواح و مکان‌های اسرارآمیز" },
                    { 9, "ماجراجویی" },
                    { 10, "تاریخی" },
                    { 11, "فرهنگی" },
                    { 12, "زیارتی" },
                    { 13, "سفر لوکس" },
                    { 14, "سفر جاده‌ای" },
                    { 15, "سفر انفرادی" },
                    { 16, "سفر خانوادگی" },
                    { 17, "سفر کاری" },
                    { 18, "سفر داوطلبانه" },
                    { 19, "سفر سلامت و یوگا" },
                    { 20, "علمی" },
                    { 21, "عکاسی" },
                    { 22, "ساحلی" },
                    { 23, "طبیعت‌گردی" },
                    { 24, "آشپزی و غذای محلی" },
                    { 25, "صنایع دستی و کارگاه‌های هنری" },
                    { 26, "موسیقی و رقص محلی" },
                    { 27, "نجومی و تماشای ستارگان" },
                    { 28, "ادبی و کتاب‌خوانی" },
                    { 29, "سینمایی" },
                    { 30, "گل‌دهی و طبیعت بهاری" },
                    { 31, "برف و زمستانی" },
                    { 32, "کارناوال‌ها و فستیوال‌ها" },
                    { 33, "نوجوانان و جوانان" },
                    { 34, "سالمندان" },
                    { 35, "حیوانات خانگی" },
                    { 36, "مدیتیشن و ریلکسیشن" },
                    { 37, "بازسازی انرژی (رتریت)" }
                });

            _ = migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "Gender", "ImageProfile", "LastName", "NationalCode", "Password", "PersonalityId", "PhoneNumber", "Role", "UserName", "WalletAmount" },
                values: new object[,]
                {
                    { 4, new DateTime(1992, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatemeh.hosseini@outlook.com", "فاطمه", 2, "DefaultImage.png", "حسینی", "3456789012", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", null, "09345678901", 0, "user-4", 320000.0 },
                    { 8, new DateTime(1993, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "narges.rahmani@gmail.com", "نرگس", 2, "DefaultImage.png", "رحمانی", "7890123456", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", null, "09789012345", 0, "user-8", 190000.0 },
                    { 13, new DateTime(1994, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "hamid.mahdavi@hotmail.com", "حمید", 1, "DefaultImage.png", "مهدوی", "2233445566", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", null, "09223344556", 0, "user-13", 230000.0 },
                    { 18, new DateTime(1995, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "elahe.sadeqi@yahoo.com", "الهه", 2, "DefaultImage.png", "صادقی", "7788990011", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", null, "09778899001", 0, "user-18", 220000.0 }
                });

            _ = migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "Description", "DestinationTypeId", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "سنگ‌های اسرارآمیز دوران نوسنگی که رازهای هزاران ساله را در خود پنهان کرده‌اند.", 30, "استون‌هنژ.jpg", "استون‌هنژ" },
                    { 2, "جنگل بارانی پهناور با تنوع زیستی خیره‌کننده و قبایل بومی اسرارآمیز.", 35, "آمازون.jpg", "آمازون" },
                    { 3, "سرزمین یخ و آتش با چشمه‌های آبگرم، یخچال‌های طبیعی و شفق‌های قطبی.", 8, "ایسلند.jpg", "ایسلند" },
                    { 4, "تجربه‌ای منحصر به فرد از خرید و زندگی بر روی آب در تایلند.", 31, "بازارهای شناور.jpg", "بازارهای شناور" },
                    { 5, "شهری پرجنب و جوش با ترکیبی از مدرنیته و معابد باستانی.", 13, "بانکوک.jpg", "بانکوک" },
                    { 6, "پایتخت فرهنگی آلمان با تاریخ پر فراز و نشیب و معماری خیره‌کننده.", 13, "برلین.jpg", "برلین" },
                    { 7, "جزیره‌ای با جنگل‌های بارانی بکر و حیات وحش منحصر به فرد.", 22, "بورنئو.jpg", "بورنئو" },
                    { 8, "سرزمین بکر با مناظر خیره‌کننده کوهستانی و یخچال‌های طبیعی.", 5, "پاتاگونیا.jpg", "پاتاگونیا" },
                    { 9, "تراس‌های سفید پنبهای از سنگ آهک با چشمه‌های آبگرم درمانی.", 24, "پاموکاله ترکیه.jpg", "پاموکاله" },
                    { 10, "شهر گمشده نبطی‌ها که در دل صخره‌های سرخ تراشیده شده است.", 30, "پترا.jpg", "پترا" },
                    { 11, "شهر ارواح پس از فاجعه چرنوبیل، نمادی از طبیعت پیروز بر تمدن.", 33, "پرپیات در اوکراین.jpg", "پرپیات" },
                    { 12, "تالابی زیبا با نیزارهای گسترده و پرندگان مهاجر بی‌نظیر.", 19, "تالاب انزلی.jpg", "تالاب انزلی" },
                    { 13, "نمایشگاه روباز هنر خیابانی در پایتخت ایران.", 15, "تهرانِ گرافیتی.jpg", "تهرانِ گرافیتی" },
                    { 14, "منطقه‌ای رویایی با تپه‌های سرسبز، تاکستان‌ها و روستاهای قرون وسطایی.", 7, "توسکانی ایتالیا.jpg", "توسکانی" },
                    { 15, "شهری آینده‌نگر با ترکیبی از فناوری پیشرفته و سنت‌های دیرینه.", 13, "توکیو.jpg", "توکیو" },
                    { 16, "جزیره‌ای با جاذبه‌های طبیعی منحصر به فرد مانند دره ستاره‌ها و جنگل‌های حرا.", 4, "جزیره قشم.jpg", "جزیره قشم" },
                    { 17, "جزیره‌ای رنگارنگ با مجسمه‌های عروسکی و مناظر سورئال.", 39, "جزیرهٔ گانکنجو در کره با مجسمه‌های عروسکی.jpg", "جزیره گانکنجو" },
                    { 18, "پناهگاه گوریلاهای کوهی در خطر انقراض در قلب آفریقا.", 22, "جزیرهٔ گوریلاهای رواندا.jpg", "جزیره گوریلاهای رواندا" },
                    { 19, "جزیره‌ای رنگین‌کمانی با خاک‌های معدنی خیره‌کننده در خلیج فارس.", 4, "جزیره هرمز.jpg", "جزیره هرمز" },
                    { 20, "جزیره‌ای آرام با سواحل بکر و دلفین‌های بازیگوش.", 4, "جزیره هنگام.jpg", "جزیره هنگام" },
                    { 21, "جنگلی اسرارآمیز با درختان پوشیده از خزه و نورهای فانوس‌مانند.", 2, "جنگل مشعل.jpg", "جنگل مشعل" },
                    { 22, "چشمه‌های گِل‌آب درمانی با خواص شفابخش برای پوست و بدن.", 24, "چشمه های گِل‌آب سرعین.jpg", "چشمه‌های گِل‌آب سرعین" },
                    { 23, "زیگورات باستانی ایلامی‌ها، یادگاری از تمدن کهن بین‌النهرین.", 30, "چغازنبیل.jpg", "چغازنبیل" },
                    { 24, "منطقه‌ای با لایه‌های خاکی رنگارنگ و مناظر سورئال.", 21, "درهٔ رنگین کمان در ایران.jpg", "درهٔ رنگین‌کمان" },
                    { 25, "بی‌نهایت آبی که آرامش و هیجان را یکجا به انسان هدیه می‌دهد.", 1, "دریا.jpg", "دریا" },
                    { 26, "دریاچه‌ای آرام با مناظر بکر و طبیعتی دست‌نخورده.", 12, "دریاچه الیمالات.jpg", "دریاچه الیمالات" },
                    { 27, "دریاچه‌ای زیبا در دل کوهستان با آب زلال و طبیعتی بکر.", 12, "دریاچه اویدر.jpg", "دریاچه اویدر" },
                    { 28, "شهر زیرزمینی باستانی با معماری شگفت‌انگیز و تونل‌های پیچ در پیچ.", 27, "درینکویو در ترکیه.jpg", "درینکویو" },
                    { 29, "چشماندازهای وسیع و خیره‌کننده از نمکزارهای درخشان.", 20, "دشت‌های نمک ایران.jpg", "دشت‌های نمک ایران" },
                    { 30, "شهری از آینده با آسمان‌خراش‌های بلند و جزایر مصنوعی خیره‌کننده.", 13, "دوبی.jpg", "دوبی" },
                    { 31, "شهر باران‌های نقره‌ای با فرهنگ غنی و غذاهای لذیذ شمالی.", 7, "رشت.jpg", "رشت" },
                    { 32, "روستاهایی شاد و رنگین که گویی از یک نقاشی کودکانه بیرون آمده‌اند.", 39, "روستاهای رنگ‌آمیزی‌شده در هند.jpg", "روستاهای رنگارنگ هند" },
                    { 33, "روستایی سنتی با خانه‌های چوبی و باغ‌های خزه‌ای صلح‌آمیز.", 7, "روستای کیوتو در ژاپن.jpg", "روستای کیوتو" },
                    { 34, "منطقه‌ای با صخره‌های رنگارنگ و مناظری که گویی از سیاره دیگری هستند.", 21, "ژانگیه در چین.jpg", "ژانگیه" },
                    { 35, "خط ساحلی دل‌انگیز دریای خزر با جنگل‌های سرسبز پشت سر.", 1, "ساحل دریا مازندران.jpg", "ساحل مازندران" },
                    { 36, "بزرگترین دشت نمک جهان که آسمان را بر روی زمین منعکس می‌کند.", 20, "سالار دو اویونی در بولیوی.jpg", "سالار دو اویونی" },
                    { 37, "شهری مدرن با ترکیبی از فرهنگ‌های مختلف و معماری آینده‌نگر.", 13, "سنگاپور.jpg", "سنگاپور" },
                    { 38, "رقص نورهای سبز و بنفش در آسمان شب‌های قطبی.", 38, "شفق قطبی در نروژ.jpg", "شفق قطبی نروژ" },
                    { 39, "شهر باستانی زیرزمینی با معماری هوشمندانه برای پناه گرفتن.", 27, "شهر زیرزمینی نوش آباد در ایران.jpg", "شهر زیرزمینی نوش آباد" },
                    { 40, "قدیمی‌ترین صحرای جهان با تپه‌های شنی سرخ و مناظر سورئال.", 36, "صحرای نامیب.jpg", "صحرای نامیب" },
                    { 41, "منطقه‌ای سرسبز با جنگل‌های انبوه و تپه‌های دیدنی.", 16, "فومن گیلان.jpg", "فومن" },
                    { 42, "دژ افسانه‌ای حسن صباح و فرقه اسماعیلیه بر فراز کوه‌های البرز.", 28, "قلعه الموت.jpg", "قلعه الموت" },
                    { 43, "قلعه‌ای تاریخی در دل جنگل‌های انبوه شمال ایران.", 28, "قلعه رودخان.jpg", "قلعه رودخان" },
                    { 44, "مسیر زیارتی تاریخی با مناظر طبیعی و تجربه‌های معنوی.", 29, "کامینو د سانتیاگو در اسپانیا.jpg", "کامینو د سانتیاگو" },
                    { 45, "زیبایی خشن و سکوت بیکران شن‌های روان زیر آسمان پرستاره.", 3, "کویر.jpg", "کویر" },
                    { 46, "شهری در حاشیه کویر با آب و هوای گرم و جاذبه‌های بیابانی.", 3, "گرمسار.jpg", "گرمسار" },
                    { 47, "شگفتی طبیعت با دره‌های عمیق و لایه‌های سنگی رنگارنگ.", 21, "گرند کنیون.jpg", "گرند کنیون" },
                    { 48, "کوهستانی با چشماندازهای خیره‌کننده و طبیعتی بکر.", 5, "مخمل کوه.jpg", "مخمل کوه" },
                    { 49, "تالابی رویایی پوشیده از گل‌های نیلوفر آبی در نور طلوع آفتاب.", 19, "مرداب های پوشیده از گل نیلوفر آبی.jpg", "مرداب نیلوفر آبی" },
                    { 50, "تالابی اسرارآمیز با درختان خم شده و مه‌های صبحگاهی.", 19, "مرداب هسل چالوس.jpg", "مرداب هسل" },
                    { 51, "مزارع سرسبز چای در ارتفاعات خنک اندونزی.", 40, "مزارع بوگور در اندونزی.jpg", "مزارع بوگور" },
                    { 52, "چای معروف دارجلینگ در دامنه کوه‌های هیمالیا کشت می‌شود.", 40, "مزارع چای دارجلینگ.jpg", "مزارع چای دارجلینگ" },
                    { 53, "شهری پرجنب و جوش با ترکیبی از فرهنگ، هنر و طبیعت.", 13, "ملبورن.jpg", "ملبورن" },
                    { 54, "دره‌ای زیبا با تاکستان‌های گسترده و چشم‌اندازهای آرامش‌بخش.", 16, "ناپا ولی آمریکا.jpg", "ناپا ولی" },
                    { 55, "دشت نمکی وسیع با بلورهای درخشان نمک زیر آفتاب.", 20, "نمک ابرود.jpg", "نمک ابرود" },
                    { 56, "پدیده‌ای خیره‌کننده از نورهای آبی فیتوپلانکتون‌ها در ساحل.", 38, "نورهای درخشان مالدیو.jpg", "نورهای درخشان مالدیو" },
                    { 57, "جزایر آتشفشانی با سواحل بکر، آبشارها و فرهنگ پولی‌نزیایی.", 4, "هاوایی.jpg", "هاوایی" },
                    { 58, "سازه‌های مرموز هرمی‌شکل که بحث‌های بسیاری را برانگیخته‌اند.", 30, "هرم‌های بوسنی.jpg", "هرم‌های بوسنی" },
                    { 59, "شهر رمانتیک کانال‌ها و گوندولاها که گویی بر آب شناور است.", 31, "ونیز.jpg", "ونیز" },
                    { 60, "پارک ملی با صخره‌های گرانیتی غول‌پیکر و آبشارهای خیره‌کننده.", 34, "یوسمیتی.jpg", "یوسمیتی" }
                });

            _ = migrationBuilder.InsertData(
                table: "PersonalityCategories",
                columns: new[] { "Id", "CategoryId", "PersonalityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 4, 1 },
                    { 3, 5, 1 },
                    { 4, 6, 1 },
                    { 5, 15, 1 },
                    { 6, 18, 1 },
                    { 7, 21, 1 },
                    { 8, 20, 1 },
                    { 9, 37, 1 },
                    { 10, 2, 2 },
                    { 11, 4, 2 },
                    { 12, 16, 2 },
                    { 13, 19, 2 },
                    { 14, 23, 2 },
                    { 15, 25, 2 },
                    { 16, 3, 3 },
                    { 17, 4, 3 },
                    { 18, 6, 3 },
                    { 19, 9, 3 },
                    { 20, 15, 3 },
                    { 21, 16, 3 },
                    { 22, 2, 4 },
                    { 23, 3, 4 },
                    { 24, 7, 4 },
                    { 25, 11, 4 },
                    { 26, 12, 4 },
                    { 27, 23, 4 },
                    { 28, 4, 5 },
                    { 29, 28, 5 },
                    { 30, 16, 5 },
                    { 31, 17, 5 },
                    { 32, 30, 5 },
                    { 33, 6, 5 },
                    { 34, 29, 5 },
                    { 35, 4, 6 },
                    { 36, 10, 6 },
                    { 37, 16, 6 },
                    { 38, 17, 6 },
                    { 39, 22, 6 },
                    { 40, 36, 6 },
                    { 41, 30, 6 },
                    { 42, 2, 7 },
                    { 43, 5, 7 },
                    { 44, 8, 7 },
                    { 45, 13, 7 },
                    { 46, 14, 7 },
                    { 47, 32, 7 },
                    { 48, 34, 7 },
                    { 49, 2, 8 },
                    { 50, 5, 8 },
                    { 51, 13, 8 },
                    { 52, 29, 8 },
                    { 53, 30, 8 },
                    { 54, 33, 8 },
                    { 55, 35, 8 },
                    { 56, 1, 9 },
                    { 57, 6, 9 },
                    { 58, 15, 9 },
                    { 59, 16, 9 },
                    { 60, 9, 9 },
                    { 61, 18, 9 },
                    { 62, 1, 10 },
                    { 63, 4, 10 },
                    { 64, 10, 10 },
                    { 65, 19, 10 },
                    { 66, 22, 10 },
                    { 67, 4, 11 },
                    { 68, 5, 11 },
                    { 69, 7, 11 },
                    { 70, 8, 11 },
                    { 71, 12, 11 },
                    { 72, 14, 11 },
                    { 73, 2, 12 },
                    { 74, 7, 12 },
                    { 75, 8, 12 },
                    { 76, 24, 12 },
                    { 77, 31, 12 },
                    { 78, 5, 13 },
                    { 79, 8, 13 },
                    { 80, 12, 13 },
                    { 81, 14, 13 },
                    { 82, 32, 13 },
                    { 83, 34, 13 },
                    { 84, 2, 14 },
                    { 85, 12, 14 },
                    { 86, 13, 14 },
                    { 87, 14, 14 },
                    { 88, 31, 14 },
                    { 89, 34, 14 },
                    { 90, 8, 15 },
                    { 91, 2, 15 },
                    { 92, 13, 15 },
                    { 93, 29, 15 },
                    { 94, 33, 15 },
                    { 95, 35, 15 },
                    { 96, 2, 16 },
                    { 97, 7, 16 },
                    { 98, 11, 16 },
                    { 99, 12, 16 },
                    { 100, 24, 16 },
                    { 101, 31, 16 }
                });

            _ = migrationBuilder.InsertData(
                table: "PersonalityDestinationTypes",
                columns: new[] { "Id", "DestinationTypeId", "PersonalityId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 11, 1 },
                    { 3, 13, 1 },
                    { 4, 14, 1 },
                    { 5, 17, 1 },
                    { 6, 39, 1 },
                    { 7, 40, 1 },
                    { 8, 2, 2 },
                    { 9, 3, 2 },
                    { 10, 4, 2 },
                    { 11, 7, 2 },
                    { 12, 21, 2 },
                    { 13, 28, 2 },
                    { 14, 32, 2 },
                    { 15, 35, 2 },
                    { 16, 1, 3 },
                    { 17, 2, 3 },
                    { 18, 7, 3 },
                    { 19, 11, 3 },
                    { 20, 14, 3 },
                    { 21, 24, 3 },
                    { 22, 40, 3 },
                    { 23, 1, 4 },
                    { 24, 4, 4 },
                    { 25, 13, 4 },
                    { 26, 22, 4 },
                    { 27, 25, 4 },
                    { 28, 39, 4 },
                    { 29, 2, 5 },
                    { 30, 5, 5 },
                    { 31, 6, 5 },
                    { 32, 27, 5 },
                    { 33, 37, 5 },
                    { 34, 38, 5 },
                    { 35, 2, 6 },
                    { 36, 5, 6 },
                    { 37, 14, 6 },
                    { 38, 17, 6 },
                    { 39, 21, 6 },
                    { 40, 28, 6 },
                    { 41, 30, 6 },
                    { 42, 37, 6 },
                    { 43, 3, 7 },
                    { 44, 6, 7 },
                    { 45, 8, 7 },
                    { 46, 10, 7 },
                    { 47, 27, 7 },
                    { 48, 29, 7 },
                    { 49, 32, 7 },
                    { 50, 3, 8 },
                    { 51, 6, 8 },
                    { 52, 8, 8 },
                    { 53, 14, 8 },
                    { 54, 23, 8 },
                    { 55, 30, 8 },
                    { 56, 33, 8 },
                    { 57, 38, 8 },
                    { 58, 7, 9 },
                    { 59, 9, 9 },
                    { 60, 11, 9 },
                    { 61, 12, 9 },
                    { 62, 16, 9 },
                    { 63, 19, 9 },
                    { 64, 1, 10 },
                    { 65, 2, 10 },
                    { 66, 4, 10 },
                    { 67, 5, 10 },
                    { 68, 16, 10 },
                    { 69, 21, 10 },
                    { 70, 24, 10 },
                    { 71, 39, 10 },
                    { 72, 5, 11 },
                    { 73, 10, 11 },
                    { 74, 13, 11 },
                    { 75, 14, 11 },
                    { 76, 22, 11 },
                    { 77, 29, 11 },
                    { 78, 1, 12 },
                    { 79, 2, 12 },
                    { 80, 5, 12 },
                    { 81, 23, 12 },
                    { 82, 26, 12 },
                    { 83, 34, 12 },
                    { 84, 36, 12 },
                    { 85, 10, 13 },
                    { 86, 13, 13 },
                    { 87, 14, 13 },
                    { 88, 22, 13 },
                    { 89, 32, 13 },
                    { 90, 1, 14 },
                    { 91, 5, 14 },
                    { 92, 14, 14 },
                    { 93, 18, 14 },
                    { 94, 31, 14 },
                    { 95, 32, 14 },
                    { 96, 34, 14 },
                    { 97, 5, 15 },
                    { 98, 6, 15 },
                    { 99, 18, 15 },
                    { 100, 23, 15 },
                    { 101, 27, 15 },
                    { 102, 30, 15 },
                    { 103, 33, 15 },
                    { 104, 38, 15 },
                    { 105, 1, 16 },
                    { 106, 4, 16 },
                    { 107, 5, 16 },
                    { 108, 13, 16 },
                    { 109, 34, 16 },
                    { 110, 36, 16 }
                });

            _ = migrationBuilder.InsertData(
                table: "PersonalityTourTypes",
                columns: new[] { "Id", "PersonalityId", "TourTypeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 10 },
                    { 3, 1, 11 },
                    { 4, 1, 16 },
                    { 5, 1, 18 },
                    { 6, 1, 19 },
                    { 7, 1, 26 },
                    { 8, 2, 6 },
                    { 9, 2, 7 },
                    { 10, 2, 9 },
                    { 11, 2, 18 },
                    { 12, 2, 23 },
                    { 13, 2, 25 },
                    { 14, 2, 32 },
                    { 15, 3, 1 },
                    { 16, 3, 3 },
                    { 17, 3, 6 },
                    { 18, 3, 11 },
                    { 19, 3, 12 },
                    { 20, 3, 16 },
                    { 21, 3, 24 },
                    { 22, 4, 4 },
                    { 23, 4, 6 },
                    { 24, 4, 7 },
                    { 25, 4, 22 },
                    { 26, 4, 32 },
                    { 27, 5, 12 },
                    { 28, 5, 19 },
                    { 29, 5, 27 },
                    { 30, 5, 28 },
                    { 31, 5, 36 },
                    { 32, 5, 37 },
                    { 33, 6, 11 },
                    { 34, 6, 18 },
                    { 35, 6, 19 },
                    { 36, 6, 28 },
                    { 37, 6, 25 },
                    { 38, 6, 30 },
                    { 39, 6, 27 },
                    { 40, 6, 2 },
                    { 41, 7, 9 },
                    { 42, 7, 10 },
                    { 43, 7, 20 },
                    { 44, 7, 15 },
                    { 45, 7, 29 },
                    { 46, 7, 14 },
                    { 47, 8, 8 },
                    { 48, 8, 20 },
                    { 49, 8, 27 },
                    { 50, 8, 10 },
                    { 51, 8, 15 },
                    { 52, 9, 3 },
                    { 53, 9, 12 },
                    { 54, 9, 16 },
                    { 55, 9, 24 },
                    { 56, 9, 19 },
                    { 57, 10, 6 },
                    { 58, 10, 21 },
                    { 59, 10, 25 },
                    { 60, 10, 30 },
                    { 61, 10, 23 },
                    { 62, 10, 15 },
                    { 63, 11, 10 },
                    { 64, 11, 11 },
                    { 65, 11, 13 },
                    { 66, 11, 17 },
                    { 67, 11, 5 },
                    { 68, 11, 14 },
                    { 69, 12, 4 },
                    { 70, 12, 5 },
                    { 71, 12, 9 },
                    { 72, 12, 12 },
                    { 73, 12, 31 },
                    { 74, 13, 13 },
                    { 75, 13, 17 },
                    { 76, 13, 10 },
                    { 77, 13, 14 },
                    { 78, 13, 4 },
                    { 79, 14, 9 },
                    { 80, 14, 14 },
                    { 81, 14, 17 },
                    { 82, 14, 20 },
                    { 83, 14, 13 },
                    { 84, 15, 5 },
                    { 85, 15, 8 },
                    { 86, 15, 9 },
                    { 87, 15, 15 },
                    { 88, 15, 20 },
                    { 89, 15, 29 },
                    { 90, 15, 32 },
                    { 91, 16, 4 },
                    { 92, 16, 9 },
                    { 93, 16, 13 },
                    { 94, 16, 16 },
                    { 95, 16, 22 },
                    { 96, 16, 31 }
                });

            _ = migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDay", "Email", "FirstName", "Gender", "ImageProfile", "LastName", "NationalCode", "Password", "PersonalityId", "PhoneNumber", "Role", "UserName", "WalletAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmed2002q@gmail.com", "محمد صادق", 1, "34dac24d-3b74-47c3-9d24-55ed90e5a696__sadeq.png", "کیومرثی", "0372234471", "lRAGD8HN16CHGzRRShARPaA8mFDFpd3PYydbnoBg0Hk=", 3, "09217074647", 1, "sadeq", 1000000.0 },
                    { 2, new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "maryam.mohammadi@gmail.com", "مریم", 2, "DefaultImage.png", "محمدی", "1234567890", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 6, "09123456789", 0, "user-2", 250000.0 },
                    { 3, new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.rezaei@yahoo.com", "علی", 1, "DefaultImage.png", "رضایی", "2345678901", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 7, "09234567890", 0, "user-3", 180000.0 },
                    { 5, new DateTime(1990, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "hossein.karimi@gmail.com", "حسین", 1, "DefaultImage.png", "کریمی", "4567890123", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 14, "09456789012", 0, "user-5", 420000.0 },
                    { 6, new DateTime(1985, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "zahra.mosavi@yahoo.com", "زهرا", 2, "DefaultImage.png", "موسوی", "5678901234", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 9, "09567890123", 0, "user-6", 150000.0 },
                    { 7, new DateTime(1998, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohammad.jafary@hotmail.com", "محمد", 1, "DefaultImage.png", "جعفری", "6789012345", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 11, "09678901234", 0, "user-7", 275000.0 },
                    { 9, new DateTime(1987, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "reza.fallahi@yahoo.com", "رضا", 1, "DefaultImage.png", "فلاحی", "8901234567", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 16, "09890123456", 0, "user-9", 360000.0 },
                    { 10, new DateTime(1996, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.omidi@outlook.com", "سارا", 2, "DefaultImage.png", "امیدی", "9012345678", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 2, "09901234567", 0, "user-10", 210000.0 },
                    { 11, new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "amir.nory@gmail.com", "امیر", 1, "DefaultImage.png", "نوری", "0123456789", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 5, "09111234567", 0, "user-11", 290000.0 },
                    { 12, new DateTime(1989, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "leila.asadi@yahoo.com", "لیلا", 2, "DefaultImage.png", "اسدی", "1122334455", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 4, "09122334455", 0, "user-12", 175000.0 },
                    { 14, new DateTime(1997, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "nazanin.zare@gmail.com", "نازنین", 2, "DefaultImage.png", "زارع", "3344556677", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 10, "09334455667", 0, "user-14", 310000.0 },
                    { 15, new DateTime(1999, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "parsa.akbari@yahoo.com", "پارسا", 1, "DefaultImage.png", "اکبری", "4455667788", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 8, "09445566778", 0, "user-15", 195000.0 },
                    { 16, new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mina.ghasemi@outlook.com", "مینا", 2, "DefaultImage.png", "قاسمی", "5566778899", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 1, "09556677889", 0, "user-16", 280000.0 },
                    { 17, new DateTime(1986, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "kamran.mohammadi@gmail.com", "کامران", 1, "DefaultImage.png", "محمدی", "6677889900", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 12, "09667788990", 0, "user-17", 340000.0 },
                    { 19, new DateTime(1988, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "farhad.sharifi@hotmail.com", "فرهاد", 1, "DefaultImage.png", "شریفی", "8899001122", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 15, "09889900112", 0, "user-19", 380000.0 },
                    { 20, new DateTime(1993, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "taraneh.yazdani@gmail.com", "ترانه", 2, "DefaultImage.png", "یزدانی", "9900112233", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", 13, "09900112233", 0, "user-20", 260000.0 }
                });

            _ = migrationBuilder.InsertData(
                table: "DestinationCategories",
                columns: new[] { "Id", "CategoryId", "DestinationId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 29, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 },
                    { 5, 1, 3 },
                    { 6, 24, 3 },
                    { 7, 3, 4 },
                    { 8, 19, 4 },
                    { 9, 4, 5 },
                    { 10, 12, 5 },
                    { 11, 5, 6 },
                    { 12, 4, 6 },
                    { 13, 1, 7 },
                    { 14, 35, 7 },
                    { 15, 2, 8 },
                    { 16, 34, 8 },
                    { 17, 18, 9 },
                    { 18, 10, 9 },
                    { 19, 5, 10 },
                    { 20, 10, 10 },
                    { 21, 29, 11 },
                    { 22, 13, 11 },
                    { 23, 1, 12 },
                    { 24, 22, 12 },
                    { 25, 4, 13 },
                    { 26, 10, 13 },
                    { 27, 3, 14 },
                    { 28, 9, 14 },
                    { 29, 13, 15 },
                    { 30, 25, 15 },
                    { 31, 1, 16 },
                    { 32, 8, 16 },
                    { 33, 4, 17 },
                    { 34, 10, 17 },
                    { 35, 35, 18 },
                    { 36, 36, 18 },
                    { 37, 10, 19 },
                    { 38, 16, 19 },
                    { 39, 15, 20 },
                    { 40, 30, 20 },
                    { 41, 1, 21 },
                    { 42, 29, 21 },
                    { 43, 18, 22 },
                    { 44, 3, 22 },
                    { 45, 5, 23 },
                    { 46, 13, 23 },
                    { 47, 1, 24 },
                    { 48, 10, 24 },
                    { 49, 3, 25 },
                    { 50, 28, 25 },
                    { 51, 1, 26 },
                    { 52, 15, 26 },
                    { 53, 1, 27 },
                    { 54, 30, 27 },
                    { 55, 5, 28 },
                    { 56, 27, 28 },
                    { 57, 1, 29 },
                    { 58, 10, 29 },
                    { 59, 12, 30 },
                    { 60, 32, 30 },
                    { 61, 9, 31 },
                    { 62, 16, 31 },
                    { 63, 4, 32 },
                    { 64, 21, 32 },
                    { 65, 7, 33 },
                    { 66, 28, 33 },
                    { 67, 1, 34 },
                    { 68, 2, 34 },
                    { 69, 3, 35 },
                    { 70, 15, 35 },
                    { 71, 1, 36 },
                    { 72, 10, 36 },
                    { 73, 12, 37 },
                    { 74, 13, 37 },
                    { 75, 1, 38 },
                    { 76, 30, 38 },
                    { 77, 5, 39 },
                    { 78, 29, 39 },
                    { 79, 1, 40 },
                    { 80, 2, 40 },
                    { 81, 1, 41 },
                    { 82, 16, 41 },
                    { 83, 5, 42 },
                    { 84, 2, 42 },
                    { 85, 5, 43 },
                    { 86, 7, 43 },
                    { 87, 6, 44 },
                    { 88, 28, 44 },
                    { 89, 1, 45 },
                    { 90, 30, 45 },
                    { 91, 1, 46 },
                    { 92, 8, 46 },
                    { 93, 1, 47 },
                    { 94, 31, 47 },
                    { 95, 1, 48 },
                    { 96, 7, 48 },
                    { 97, 1, 49 },
                    { 98, 22, 49 },
                    { 99, 1, 50 },
                    { 100, 29, 50 },
                    { 101, 38, 51 },
                    { 102, 9, 51 },
                    { 103, 38, 52 },
                    { 104, 16, 52 },
                    { 105, 4, 53 },
                    { 106, 13, 53 },
                    { 107, 9, 54 },
                    { 108, 3, 54 },
                    { 109, 1, 55 },
                    { 110, 10, 55 },
                    { 111, 1, 56 },
                    { 112, 12, 56 },
                    { 113, 1, 57 },
                    { 114, 11, 57 },
                    { 115, 5, 58 },
                    { 116, 29, 58 },
                    { 117, 4, 59 },
                    { 118, 11, 59 },
                    { 119, 1, 60 },
                    { 120, 2, 60 }
                });

            _ = migrationBuilder.InsertData(
                table: "DestinationObserves",
                columns: new[] { "Id", "ObserveType", "ObservedDestinationId", "ObserverUserId" },
                values: new object[,]
                {
                    { 1, 0, 2, 1 },
                    { 2, 1, 10, 1 },
                    { 3, 0, 15, 1 },
                    { 4, 1, 3, 2 },
                    { 5, 0, 14, 2 },
                    { 6, 0, 5, 3 },
                    { 7, 1, 16, 3 },
                    { 8, 0, 20, 3 },
                    { 9, 0, 7, 4 },
                    { 10, 1, 12, 4 },
                    { 11, 1, 9, 5 },
                    { 12, 0, 18, 5 },
                    { 13, 1, 25, 5 },
                    { 14, 1, 6, 6 },
                    { 15, 0, 13, 6 },
                    { 16, 0, 8, 7 },
                    { 17, 1, 22, 7 },
                    { 18, 0, 30, 7 },
                    { 19, 1, 11, 8 },
                    { 20, 0, 19, 8 },
                    { 21, 1, 17, 9 },
                    { 22, 1, 21, 9 },
                    { 23, 0, 28, 9 },
                    { 24, 0, 23, 10 },
                    { 25, 1, 29, 10 },
                    { 26, 1, 24, 11 },
                    { 27, 0, 32, 11 },
                    { 28, 1, 36, 11 },
                    { 29, 1, 26, 12 },
                    { 30, 0, 34, 12 },
                    { 31, 1, 27, 13 },
                    { 32, 0, 35, 13 },
                    { 33, 1, 39, 13 },
                    { 34, 0, 31, 14 },
                    { 35, 1, 37, 14 },
                    { 36, 1, 33, 15 },
                    { 37, 0, 40, 15 },
                    { 38, 1, 38, 16 },
                    { 39, 0, 41, 16 },
                    { 40, 1, 44, 16 },
                    { 41, 0, 42, 17 },
                    { 42, 1, 43, 17 },
                    { 43, 1, 45, 18 },
                    { 44, 0, 46, 18 },
                    { 45, 0, 47, 19 },
                    { 46, 1, 49, 19 },
                    { 47, 1, 50, 19 },
                    { 48, 1, 51, 20 },
                    { 49, 0, 53, 20 }
                });

            _ = migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "DaysCount", "Description", "DestinationId", "EndTime", "Image", "MaximumAge", "MaximumPassenger", "MinimumAge", "Price", "SleepNightsCount", "StartTime", "Title", "TourTypeId" },
                values: new object[,]
                {
                    { 1, 2, "تور ویژه شب‌های مهتابی برای تجربه انرژی‌های مرموز این سنگ‌های باستانی", 1, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "استون‌هنژ2.jpg", 45, 30, 18, 1200000.0, 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "کشف اسرار استون‌هنژ", 8 },
                    { 2, 7, "اکوتور 7 روزه با اقامت در لاج‌های جنگلی و بازدید از قبایل بومی", 2, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "آمازون2.jpg", 50, 15, 21, 3800000.0, 6, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماجراجویی در قلب آمازون", 2 },
                    { 3, 5, "تور ویژه تماشای شفق قطبی و چشمه‌های آبگرم طبیعی", 3, new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ایسلند2.jpg", 45, 25, 20, 4200000.0, 4, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "سفر به سرزمین یخ و آتش", 31 },
                    { 4, 1, "تور یک روزه قایق‌سواری و خرید از بازارهای شناور بانکوک", 4, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "بازارهای شناور2.jpg", 60, 40, 15, 650000.0, 0, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "تجربه خرید در بازارهای آبی", 6 },
                    { 5, 3, "تور 3 روزه فرهنگی با بازدید از معابد بودایی و کاخ پادشاهی", 5, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "بانکوک2.jpg", 50, 35, 18, 1800000.0, 2, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "کشف معابد بانکوک", 11 },
                    { 6, 4, "گردش در دیوار برلین و موزه‌های جنگ جهانی دوم", 6, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "برلین2.jpg", 55, 30, 20, 2500000.0, 3, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "برلین تاریخی", 10 },
                    { 7, 5, "تور 5 روزه حیات وحش در جنگل‌های بارانی بورنئو", 7, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "بورنئو2.jpg", 45, 20, 18, 3200000.0, 4, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "سفری به دنیای اورانگوتان‌ها", 23 },
                    { 8, 8, "تور 8 روزه ماجراجویی برای علاقه‌مندان به کوهنوردی حرفه‌ای", 8, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "پاتاگونیا2.jpg", 50, 15, 25, 4500000.0, 7, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "کوهنوردی در پاتاگونیا", 4 },
                    { 9, 3, "تور 3 روزه سلامت با حمام آبگرم و ماساژ درمانی", 9, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "پاموکاله ترکیه2.jpg", 60, 25, 20, 1500000.0, 2, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "آرامش در تراس‌های سفید", 19 },
                    { 10, 4, "اکتشاف 4 روزه در شهر تاریخی نبطی‌ها با راهنمایان محلی", 10, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "پترا2.jpg", 50, 30, 18, 2200000.0, 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهر گمشده پترا", 10 },
                    { 11, 2, "تور ویژه بازدید از منطقه محرومه با تجهیزات ایمنی کامل", 11, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "پرپیات در اوکراین2.jpg", 45, 20, 21, 1800000.0, 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهر ارواح چرنوبیل", 8 },
                    { 12, 1, "تور یک روزه طبیعت‌گردی با تماشای پرندگان مهاجر", 12, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تالاب انزلی2.jpg", 60, 40, 10, 500000.0, 0, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قایق‌سواری در تالاب", 22 },
                    { 13, 1, "گردش شهری برای کشف بهترین نقاشی‌های دیواری تهران", 13, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "تهرانِ گرافیتی2.jpg", 40, 25, 15, 300000.0, 0, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور خیابان‌های هنری", 25 },
                    { 14, 4, "گشت 4 روزه در تاکستان‌های معروف با چشیدن بهترین شراب‌های ایتالیا", 14, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "توسکانی ایتالیا2.jpg", 50, 20, 21, 2800000.0, 3, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور شراب توسکانی", 24 },
                    { 15, 5, "تور فناوری و فرهنگ ژاپن با بازدید از مراکز مدرن و معابد سنتی", 15, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "توکیو2.jpg", 45, 30, 18, 3500000.0, 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تجربه آینده در توکیو", 13 },
                    { 16, 2, "کشف جاذبه‌های طبیعی جزیره از دره ستاره‌ها تا جنگل‌های حرا", 16, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیره قشم2.jpg", 50, 35, 12, 850000.0, 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "اکوتور قشم", 3 },
                    { 17, 3, "تور عکاسی در جزیره رنگارنگ با مجسمه‌های غول‌پیکر", 17, new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیرهٔ گانکنجو در کره با مجسمه‌های عروسکی2.jpg", 40, 25, 15, 1200000.0, 2, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "دنیای عروسکی", 21 },
                    { 18, 4, "تور ویژه تماشای گوریلاهای کوهی در زیستگاه طبیعی", 18, new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیرهٔ گوریلاهای رواندا2.jpg", 50, 15, 18, 3800000.0, 3, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماجراجویی با گوریلاها", 35 },
                    { 19, 2, "تور 2 روزه عکاسی از خاک‌های رنگی و طبیعت بی‌نظیر", 19, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیره هرمز2.jpg", 45, 30, 15, 900000.0, 1, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیره رنگین‌کمان", 21 },
                    { 20, 2, "تور خانوادگی با قایق‌سواری و تماشای دلفین‌ها", 20, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "جزیره هنگام2.jpg", 60, 40, 5, 750000.0, 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "آرامش در هنگام", 16 },
                    { 21, 1, "تور ویژه شب‌گردی با نور فانوس‌ها در جنگل مه‌آلود", 21, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "جنگل مشعل2.jpg", 40, 20, 18, 400000.0, 0, new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "پیاده‌روی شبانه در جنگل اسرارآمیز", 29 },
                    { 22, 2, "تور 2 روزه سلامت با حمام گل و ماساژ سنتی", 22, new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "چشمه های گِل‌آب سرعین2.jpg", 60, 25, 20, 800000.0, 1, new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "آبگرم درمانی سرعین", 19 },
                    { 23, 1, "بازدید علمی از زیگورات چغازنبیل با راهنمایان متخصص", 23, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چغازنبیل2.jpg", 50, 35, 15, 450000.0, 0, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تماشای اولین اثر ثبت شده ایران", 20 },
                    { 24, 2, "تور عکاسی از لایه‌های رنگارنگ زمین در ساعات طلایی", 24, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "درهٔ رنگین کمان در ایران2.jpg", 45, 20, 18, 950000.0, 1, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "رنگین‌کمان زمینی", 21 },
                    { 25, 1, "تور یک روزه قایق‌سواری و تفریحات آبی", 25, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "دریا2.jpg", 60, 50, 10, 600000.0, 0, new DateTime(2026, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "کروز تفریحی", 22 },
                    { 26, 1, "تور یک روزه استراحت در کنار دریاچه با امکانات تفریحی", 26, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دریاچه الیمالات2.jpg", 70, 40, 5, 350000.0, 0, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "پیک‌نیک خانوادگی", 16 },
                    { 27, 1, "تور نجومی شبانه با تلسکوپ‌های حرفه‌ای", 27, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "دریاچه اویدر2.jpg", 50, 30, 15, 500000.0, 0, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "تماشای ستارگان", 27 },
                    { 28, 2, "اکتشاف در عمق 85 متری زمین در شهر باستانی", 28, new DateTime(2026, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "درینکویو در ترکیه2.jpg", 45, 25, 18, 1100000.0, 1, new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهر زیرزمینی", 27 },
                    { 29, 1, "تور عکاسی از دشت‌های نمکی در نور صبحگاهی", 29, new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "دشت‌های نمک ایران2.jpg", 50, 30, 15, 400000.0, 0, new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "سفید تا بینهایت", 21 },
                    { 30, 5, "تور 5 ستاره با اقامت در هتل‌های لوکس و تفریحات VIP", 30, new DateTime(2027, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "دوبی2.jpg", 60, 20, 25, 5000000.0, 4, new DateTime(2027, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "تجربه لوکس دوبی", 13 },
                    { 31, 2, "چشیدن بهترین غذاهای محلی گیلان با راهنمایان محلی", 31, new DateTime(2027, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "رشت2.jpg", 50, 25, 18, 850000.0, 1, new DateTime(2027, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور غذایی رشت", 24 },
                    { 32, 3, "گشت 3 روزه در روستاهای رنگارنگ با اقامت در خانه‌های محلی", 32, new DateTime(2027, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "روستاهای رنگ‌آمیزی‌شده در هند2.jpg", 45, 20, 18, 1200000.0, 2, new DateTime(2027, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "رنگ‌های شاد هند", 30 },
                    { 33, 4, "تور مدیتیشن و آرامش در معابد بودایی", 33, new DateTime(2027, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "روستای کیوتو در ژاپن2.jpg", 50, 15, 20, 2800000.0, 3, new DateTime(2027, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ذن در کیوتو", 36 },
                    { 34, 3, "تور 3 روزه ماجراجویی در میان صخره‌های رنگارنگ", 34, new DateTime(2027, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ژانگیه در چین2.jpg", 45, 25, 18, 1500000.0, 2, new DateTime(2027, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مناظر فرازمینی", 9 },
                    { 35, 3, "تور 3 روزه خانوادگی با تفریحات ساحلی و جنگلی", 35, new DateTime(2027, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ساحل دریا مازندران2.jpg", 60, 40, 5, 900000.0, 2, new DateTime(2027, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "خاطرات شمالی", 16 },
                    { 36, 3, "تور عکاسی از بزرگترین دشت نمک جهان", 36, new DateTime(2027, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "سالار دو اویونی در بولیوی2.jpg", 45, 20, 18, 1800000.0, 2, new DateTime(2027, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "آینه آسمان", 21 },
                    { 37, 4, "تور 4 روزه در مدرن‌ترین شهر جهان", 37, new DateTime(2027, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "سنگاپور2.jpg", 50, 30, 18, 3200000.0, 3, new DateTime(2027, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهری از آینده", 13 },
                    { 38, 5, "تور 5 روزه تماشای شفق قطبی در نروژ", 38, new DateTime(2027, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "شفق قطبی در نروژ2.jpg", 45, 25, 18, 4500000.0, 4, new DateTime(2027, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "رقص نورهای شمالی", 27 },
                    { 39, 1, "اکتشاف در شهر باستانی زیرزمینی", 39, new DateTime(2027, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهر زیرزمینی نوش آباد در ایران2.jpg", 50, 30, 15, 350000.0, 0, new DateTime(2027, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "رازهای زیرزمین", 8 },
                    { 40, 4, "تور 4 روزه ماجراجویی در تپه‌های شنی سرخ", 40, new DateTime(2028, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "صحرای نامیب2.jpg", 45, 15, 21, 2800000.0, 3, new DateTime(2028, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "سفری به قدیمی‌ترین صحرا", 9 },
                    { 41, 2, "تور 2 روزه پیاده‌روی در جنگل‌های انبوه شمال", 41, new DateTime(2028, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "فومن گیلان2.jpg", 50, 25, 18, 750000.0, 1, new DateTime(2028, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "جنگل‌های اسرارآمیز", 23 },
                    { 42, 2, "کوهپیمایی و بازدید از قلعه تاریخی حسن صباح", 42, new DateTime(2028, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "قلعه الموت2.jpg", 45, 30, 18, 850000.0, 1, new DateTime(2028, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دژ افسانه‌ای", 10 },
                    { 43, 2, "تور ورزشی و تاریخی با پیاده‌روی در جنگل", 43, new DateTime(2028, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "قلعه رودخان2.jpg", 50, 35, 15, 700000.0, 1, new DateTime(2028, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "قلعه هزار پله", 4 },
                    { 44, 7, "پیاده‌روی معنوی در مسیر تاریخی زائران", 44, new DateTime(2028, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "کامینو د سانتیاگو در اسپانیا2.jpg", 60, 20, 18, 2200000.0, 6, new DateTime(2028, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "مسیر زیارتی", 12 },
                    { 45, 2, "تور 2 روزه کویرنوردی و تماشای آسمان شب", 45, new DateTime(2028, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "کویر2.jpg", 45, 25, 18, 800000.0, 1, new DateTime(2028, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شب‌های ستاره‌ای", 27 },
                    { 46, 2, "تور 2 روزه با شترسواری و شب‌مانی در بیابان", 46, new DateTime(2028, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرمسار2.jpg", 50, 20, 18, 750000.0, 1, new DateTime(2028, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماجراجویی در کویر", 5 },
                    { 47, 3, "تور هلیکوپتری و پیاده‌روی در گرند کنیون", 47, new DateTime(2028, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "گرند کنیون2.jpg", 50, 15, 18, 3800000.0, 2, new DateTime(2028, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "پرواز بر فراز دره", 31 },
                    { 48, 2, "تور 2 روزه برای علاقه‌مندان به ورزش‌های زمستانی", 48, new DateTime(2028, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "مخمل کوه2.jpg", 45, 20, 20, 950000.0, 1, new DateTime(2028, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "کوهنوردی زمستانی", 4 },
                    { 49, 1, "تور یک روزه قایق‌سواری در میان گل‌های نیلوفر", 49, new DateTime(2028, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرداب های پوشیده از گل نیلوفر آبی2.jpg", 60, 35, 10, 450000.0, 0, new DateTime(2028, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "گل‌های بهشتی", 30 },
                    { 50, 1, "تور عکاسی از مناظر سورئال مرداب", 50, new DateTime(2028, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرداب هسل چالوس2.jpg", 50, 25, 15, 400000.0, 0, new DateTime(2028, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "مه‌های صبحگاهی", 21 },
                    { 51, 3, "تور 3 روزه بازدید از مزارع چای و فرآوری سنتی", 51, new DateTime(2029, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "مزارع بوگور در اندونزی2.jpg", 50, 20, 18, 1200000.0, 2, new DateTime(2029, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "طعم چای تازه", 30 },
                    { 52, 4, "گشت 4 روزه در مزارع مرتفع چای", 52, new DateTime(2029, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "مزارع چای دارجلینگ2.jpg", 45, 25, 18, 1500000.0, 3, new DateTime(2029, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "چای دارجلینگ", 30 },
                    { 53, 5, "تور 5 روزه فرهنگی در پایتخت هنر استرالیا", 53, new DateTime(2029, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ملبورن2.jpg", 50, 30, 18, 3200000.0, 4, new DateTime(2029, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "شهر فرهنگ‌ها", 11 },
                    { 54, 3, "گشت 3 روزه در تاکستان‌های معروف کالیفرنیا", 54, new DateTime(2029, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ناپا ولی آمریکا2.jpg", 50, 20, 21, 2500000.0, 2, new DateTime(2029, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور شراب‌نوشی", 24 },
                    { 55, 1, "تور عکاسی از دشت نمک در نور طلایی", 55, new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "نمک ابرود2.jpg", 50, 30, 15, 350000.0, 0, new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "بلورهای نمکی", 21 },
                    { 56, 5, "تور 5 روزه لاکچری با تماشای پلانکتون‌های نورانی", 56, new DateTime(2029, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "نورهای درخشان مالدیو2.jpg", 45, 20, 18, 4800000.0, 4, new DateTime(2029, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نورهای آبی", 13 },
                    { 57, 7, "تور 7 روزه با تفریحات آبی و کوهنوردی", 57, new DateTime(2029, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "هاوایی2.jpg", 50, 25, 18, 5200000.0, 6, new DateTime(2029, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "بهشت آتشفشانی", 9 },
                    { 58, 3, "تور 3 روزه تحقیقاتی درباره هرم‌های مرموز", 58, new DateTime(2029, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "هرم‌های بوسنی2.jpg", 45, 20, 18, 1500000.0, 2, new DateTime(2029, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "اسرار هرم‌ها", 8 },
                    { 59, 4, "تور 4 روزه قایق‌سواری در کانال‌ها", 59, new DateTime(2029, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ونیز2.jpg", 50, 30, 18, 2800000.0, 3, new DateTime(2029, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "رمانتیک‌ترین شهر جهان", 11 },
                    { 60, 5, "تور 5 روزه کوهنوردی و سنگ‌نوردی", 60, new DateTime(2029, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "یوسمیتی2.jpg", 45, 15, 20, 3200000.0, 4, new DateTime(2029, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ماجراجویی در پارک ملی", 4 },
                    { 61, 1, "✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 27, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "e1dd9ae1-acd4-49b4-9adb-584a5d7ecdde__دریاچه اویدر2.jpg", 45, 40, 15, 1100000.0, 0, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور یک روزه دریاچه اویدر", 23 },
                    { 62, 1, "بریم ‌دریا😍🌊    ✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 35, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "71681f8a-d73a-468e-b997-ba26c570ccd6__ساحل دریا مازندران.jpg", 45, 23, 15, 1450000.0, 0, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور یک روزه ساحل دریا مازندران", 22 },
                    { 63, 6, "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ", 16, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f8c2b2dd-ea10-4ce6-93ab-8a8873ef2d59__جزیره قشم2.jpg", 48, 40, 18, 9900000.0, 5, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "🏝 تور پنج و نیم روزه جزیره زیبای قشم", 4 },
                    { 64, 6, "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ", 20, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "e2ad5f5c-377f-4729-ad6d-6081a109b1ab__جزیره هنگام2.jpg", 48, 40, 18, 9900000.0, 5, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "🏝 تور پنج و نیم روزه جزیره زیبای هنگام", 4 },
                    { 65, 6, "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ", 19, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "a042011a-0bbd-4765-977f-c2d30e308fbb__جزیره قشم2.jpg", 50, 40, 18, 0.0, 5, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "🏝 تور پنج و نیم روزه جزیره زیبای هرمز ", 4 },
                    { 66, 1, "بازدید از:  📌 ساحل و دریا 🌊  📌 دریاچه الیمالات  (سافاری ببر و زیپ بایک و...)      ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 26, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "f2e84ae8-9afe-4a55-b75e-87b3cb9b6453__دریاچه الیمالات2.jpg", 45, 32, 20, 1450000.0, 0, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "😌 تور یک روزه شمال", 16 },
                    { 67, 1, "بازدید از:  📌 شهر زیبای رشت    📌 باز پر رنگ و بوی رشت  📌 میدان شهرداری  📌 مرداب و جنگل رویایی سراوان  📌 موزه خاص و زیبای گیلان      ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...    ", 31, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "e87199f3-a2cb-4c4b-ab75-87394b0257a6__رشت.jpg 2.jpg", 60, 32, 20, 1450000.0, 0, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "😌 تور یک روزه رشت گردی", 3 },
                    { 68, 1, "✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 27, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "edd78542-0b59-4f5b-ba82-9f2d4766fbce__دریاچه اویدر3.jpg", 40, 40, 15, 0.0, 0, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور یک روزه دریاچه اویدر", 23 },
                    { 69, 1, "بریم ‌دریا😍🌊    ✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 35, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ee153ebd-5bcb-4919-829f-a2a9b16000bf__ساحل دریامازندران.jpg 2.jpg", 40, 23, 18, 1250000.0, 0, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "تور یک روزه ساحل دریا مازندران", 22 },
                    { 70, 1, "  بازدید از:  📌 شهر زیبای رشت    📌 باز پر رنگ و بوی رشت  📌 میدان شهرداری  📌 مرداب و جنگل رویایی سراوان  📌 موزه خاص و زیبای گیلان    ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍    🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 31, new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "a0cf51be-d227-467c-8f20-52cfedfecedb__رشت 3.jpg", 40, 23, 20, 1500000.0, 0, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "😌 تور یک روزه رشت گردی", 3 },
                    { 71, 1, "  ✔ خدمات:    👈 پذیرایی عصرانه  👈 یک وعده شام  👈 شب نشینی دور آتش به همراه چای آتشی🔥   👈 برنامه موزیک🎸🎤  👈 پرداخت ورودیه ها💰  👈 بیمه مسافرتی⛑  👈 مجوز رسمی سازمانی📃  👈 تورلیدر🕵  👈 اتوبوس ۴۴ صندلی در اختیار 🚌      🔴 ثبت نام فقط تا ۲۱ اسفند امکان پذیر می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.    🔴فقط یک اتوبوس ۴۰ نفره میریم و ماشین شخصی و غیره هم نمیتونند همراهمون بیایند پس ظرفیت واقعا محدود      👌 با کیفیت سفر کنید...    ", 46, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "560bd7a9-db78-4bf5-a54c-8c10afbc983a__گرمسار 2.jpg", 40, 40, 20, 1300000.0, 0, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "🔥تور چهارشنبه سوری گرمسار 🔥", 32 },
                    { 72, 1, "  ✔ خدمات:    👈 پذیرایی عصرانه  👈 یک وعده شام  👈 شب نشینی دور آتش به همراه چای آتشی🔥   👈 برنامه موزیک🎸🎤  👈 پرداخت ورودیه ها💰  👈 بیمه مسافرتی⛑  👈 مجوز رسمی سازمانی📃  👈 تورلیدر🕵  👈 اتوبوس ۴۴ صندلی در اختیار 🚌      🔴 ثبت نام فقط تا ۲۱ اسفند امکان پذیر می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.    🔴فقط یک اتوبوس ۴۰ نفره میریم و ماشین شخصی و غیره هم نمیتونند همراهمون بیایند پس ظرفیت واقعا محدود      👌 با کیفیت سفر کنید...    ", 45, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "1f1e35f1-491b-44a8-8359-d501fb173e51__کویر 2.jpg", 40, 40, 20, 1390000.0, 0, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "🔥تور چهارشنبه سوری کویر 🔥", 32 },
                    { 73, 1, "  ✔ خدمات:    👈 صبحانه سلف🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد و نوشابه)🌯🥤  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 وسیله نقلیه توریستی در اختیار🚍    👌 با کیفیت سفر کنید...    ", 55, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "46d19ca0-8e7d-492e-9026-0d240ccc2932__نمک ابرود2.jpg", 36, 23, 20, 1790000.0, 0, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "😍 تور یک روزه نمک ابرود", 21 },
                    { 74, 1, "  ✔ خدمات:    👈 صبحانه سلف🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد و نوشابه)🌯🥤  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 وسیله نقلیه توریستی در اختیار🚍    👌 با کیفیت سفر کنید...    ", 25, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d7285dc9-f414-42e3-a6eb-36773e5a3da3__دریا2.jpg", 48, 40, 18, 1450000.0, 0, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "😍 تور یک روزه دریا", 22 },
                    { 75, 1, "  ✔ خدمات:    👈 صبحانه سلف 🧀🍯🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 43, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3b85f11c-0290-4efd-849b-a5a980a1f74b__قلعه رودخان2.jpg", 39, 40, 19, 1550000.0, 0, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "📌 تور يكروزه قلعه رودخان", 10 },
                    { 76, 1, "  ✔ خدمات:    👈 صبحانه سلف 🧀🍯🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 41, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "60834f36-ab76-45ed-8054-85d59e33dcb6__فومن گیلان2.jpg", 48, 32, 18, 1550000.0, 0, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "📌 تور يكروزه فومن گیلان", 3 },
                    { 77, 1, "✔ خدمات:    👈 میز صبحانه 🍳🧀  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 وسیله نقلیه توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ", 48, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "aff94c10-750a-4b4b-bc70-35156be586a0__مخمل کوه2.jpg", 40, 32, 20, 1790000.0, 0, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "😌 تور یک روزه مخمل کوه لرستان", 4 },
                    { 78, 3, "📌 خدمات:    👈 چادر ستاره ای برای دورهمی  👈 صندلی اختصاصی برای هر نفر  👈 برق رسانی + نورپردازی شب  👈 باند و موزیک  👈اجرای بازی های گروهی  👈دورهمی و شب نشینی بهمراه چای آتیشی  👈چادر سرویس بهداشتی  👈 آب شستشو و...    📌پذیرایی:😍    ۵ وعده مفصل + ۱ وعده عصرانه   🔸۲ وعده صبحانه سلف سرویس با آیتم های سرد و گرم  🔸۲ وعده ناهار(چلومرغ+خوراک‌جوجه) + ماست موسیر + نوشابه  🔸۱ وعده شام چیزبرگر + سیب زمینی سرخ کرده + نوشابه  🔸چای آتیشی هم که کلا توی سفر به راهه  🔸سیب زمینی آتیشی یا بلال هم در خدمتیم    📌 وسایل مورد نیازی که باید همراهتون باشه:  🔸چادر مسافرتی + نایلون (محض احتیاط)  🔸زیرانداز (برای داخل و زیر چادر)  🔸کیسه خواب    🔴 ظرفیت کل ۴۰ نفر میباشد و اولویت با عزیزانیست که زودتر ثبت نام کنند.        👌 با کیفیت سفر کنید...  ", 21, new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "17ba8889-3adb-4c86-a846-e1bbf6667017__جنگل مشعل 2.jpg", 40, 40, 20, 2850000.0, 2, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "😍 سفر ۲/۵ روزه کمپی جنگل مشعل", 5 },
                    { 79, 3, "📌 خدمات:    👈 چادر ستاره ای برای دورهمی  👈 صندلی اختصاصی برای هر نفر  👈 برق رسانی + نورپردازی شب  👈 باند و موزیک  👈اجرای بازی های گروهی  👈دورهمی و شب نشینی بهمراه چای آتیشی  👈چادر سرویس بهداشتی  👈 آب شستشو و...    📌پذیرایی:😍    ۵ وعده مفصل + ۱ وعده عصرانه   🔸۲ وعده صبحانه سلف سرویس با آیتم های سرد و گرم  🔸۲ وعده ناهار(چلومرغ+خوراک‌جوجه) + ماست موسیر + نوشابه  🔸۱ وعده شام چیزبرگر + سیب زمینی سرخ کرده + نوشابه  🔸چای آتیشی هم که کلا توی سفر به راهه  🔸سیب زمینی آتیشی یا بلال هم در خدمتیم    📌 وسایل مورد نیازی که باید همراهتون باشه:  🔸چادر مسافرتی + نایلون (محض احتیاط)  🔸زیرانداز (برای داخل و زیر چادر)  🔸کیسه خواب    🔴 ظرفیت کل ۴۰ نفر میباشد و اولویت با عزیزانیست که زودتر ثبت نام کنند.        👌 با کیفیت سفر کنید...  ", 50, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "57cc189d-0408-4779-bad4-ab8259bae87e__مرداب هسل چالوس2.jpg", 30, 40, 20, 1900000.0, 2, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "😍 سفر ۲/۵ روزه کمپی مرداب هسل چالوس", 5 }
                });

            _ = migrationBuilder.InsertData(
                table: "TourCategories",
                columns: new[] { "Id", "CategoryId", "TourId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 12 },
                    { 5, 1, 21 },
                    { 6, 2, 2 },
                    { 7, 2, 8 },
                    { 8, 2, 34 },
                    { 9, 2, 40 },
                    { 10, 3, 4 },
                    { 11, 3, 25 },
                    { 12, 3, 35 },
                    { 13, 4, 5 },
                    { 14, 4, 59 },
                    { 15, 4, 53 },
                    { 16, 5, 1 },
                    { 17, 5, 10 },
                    { 18, 5, 42 },
                    { 19, 5, 75 },
                    { 20, 15, 7 },
                    { 21, 15, 20 },
                    { 22, 15, 26 },
                    { 23, 16, 16 },
                    { 24, 16, 31 },
                    { 25, 16, 76 },
                    { 26, 10, 6 },
                    { 27, 10, 19 },
                    { 28, 10, 29 },
                    { 29, 10, 50 },
                    { 30, 27, 27 },
                    { 31, 27, 38 },
                    { 32, 27, 45 },
                    { 33, 4, 8 },
                    { 34, 4, 43 },
                    { 35, 4, 48 },
                    { 36, 18, 9 },
                    { 37, 18, 22 },
                    { 38, 4, 16 },
                    { 39, 4, 17 },
                    { 40, 4, 19 },
                    { 41, 23, 71 },
                    { 42, 23, 72 },
                    { 43, 5, 78 },
                    { 44, 5, 79 },
                    { 45, 9, 14 },
                    { 46, 9, 31 },
                    { 47, 9, 54 },
                    { 48, 22, 3 },
                    { 49, 22, 35 },
                    { 50, 22, 57 },
                    { 51, 29, 11 },
                    { 52, 29, 39 },
                    { 53, 12, 30 },
                    { 54, 12, 56 },
                    { 55, 13, 23 },
                    { 56, 13, 58 },
                    { 57, 19, 13 },
                    { 58, 19, 17 },
                    { 59, 24, 3 },
                    { 60, 24, 38 },
                    { 61, 25, 15 },
                    { 62, 25, 33 },
                    { 63, 28, 33 },
                    { 64, 28, 44 },
                    { 65, 22, 7 },
                    { 66, 22, 18 },
                    { 67, 30, 51 },
                    { 68, 30, 52 },
                    { 69, 22, 12 },
                    { 70, 22, 49 },
                    { 71, 34, 8 },
                    { 72, 34, 60 },
                    { 73, 7, 14 },
                    { 74, 7, 32 },
                    { 75, 14, 6 },
                    { 76, 14, 10 },
                    { 77, 13, 15 },
                    { 78, 13, 37 },
                    { 79, 31, 47 }
                });

            _ = migrationBuilder.InsertData(
                table: "TourObserves",
                columns: new[] { "Id", "ObserveType", "ObservedTourId", "ObserverUserId" },
                values: new object[,]
                {
                    { 1, 0, 5, 1 },
                    { 2, 1, 12, 1 },
                    { 3, 0, 22, 1 },
                    { 4, 1, 2, 2 },
                    { 5, 0, 17, 2 },
                    { 6, 1, 7, 3 },
                    { 7, 0, 14, 3 },
                    { 8, 1, 31, 3 },
                    { 9, 0, 9, 4 },
                    { 10, 1, 18, 4 },
                    { 11, 1, 4, 5 },
                    { 12, 0, 19, 5 },
                    { 13, 1, 36, 5 },
                    { 14, 0, 3, 6 },
                    { 15, 1, 20, 6 },
                    { 16, 0, 8, 7 },
                    { 17, 1, 27, 7 },
                    { 18, 0, 34, 7 },
                    { 19, 1, 6, 8 },
                    { 20, 0, 15, 8 },
                    { 21, 1, 13, 9 },
                    { 22, 1, 21, 9 },
                    { 23, 0, 29, 9 },
                    { 24, 0, 10, 10 },
                    { 25, 1, 25, 10 },
                    { 26, 1, 11, 11 },
                    { 27, 0, 26, 11 },
                    { 28, 1, 33, 11 },
                    { 29, 1, 16, 12 },
                    { 30, 0, 28, 12 },
                    { 31, 1, 23, 13 },
                    { 32, 0, 30, 13 },
                    { 33, 1, 38, 13 },
                    { 34, 0, 24, 14 },
                    { 35, 1, 37, 14 },
                    { 36, 1, 32, 15 },
                    { 37, 0, 39, 15 },
                    { 38, 1, 35, 16 },
                    { 39, 0, 40, 16 },
                    { 40, 1, 41, 16 },
                    { 41, 0, 42, 17 },
                    { 42, 1, 43, 17 },
                    { 43, 1, 44, 18 },
                    { 44, 0, 45, 18 },
                    { 45, 0, 46, 19 },
                    { 46, 1, 47, 19 },
                    { 47, 1, 48, 19 },
                    { 48, 1, 49, 20 },
                    { 49, 0, 50, 20 }
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_DestinationCategories_CategoryId",
                table: "DestinationCategories",
                column: "CategoryId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DestinationCategories_DestinationId",
                table: "DestinationCategories",
                column: "DestinationId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DestinationObserves_ObservedDestinationId",
                table: "DestinationObserves",
                column: "ObservedDestinationId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DestinationObserves_ObserverUserId",
                table: "DestinationObserves",
                column: "ObserverUserId");

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
                name: "IX_SuggestedTours_PersonalityId",
                table: "SuggestedTours",
                column: "PersonalityId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SuggestedTours_TourId",
                table: "SuggestedTours",
                column: "TourId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SuggestedTours_UserId",
                table: "SuggestedTours",
                column: "UserId");

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
                name: "DestinationCategories");

            _ = migrationBuilder.DropTable(
                name: "DestinationObserves");

            _ = migrationBuilder.DropTable(
                name: "Passengers");

            _ = migrationBuilder.DropTable(
                name: "PersonalityCategories");

            _ = migrationBuilder.DropTable(
                name: "PersonalityDestinationTypes");

            _ = migrationBuilder.DropTable(
                name: "PersonalityTourTypes");

            _ = migrationBuilder.DropTable(
                name: "SuggestedTours");

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
