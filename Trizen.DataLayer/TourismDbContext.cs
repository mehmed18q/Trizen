using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.DataLayer;
public class TrizenDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Destination> Destinations => Set<Destination>();
    public DbSet<DestinationCategory> DestinationCategories => Set<DestinationCategory>();
    public DbSet<DestinationType> DestinationTypes => Set<DestinationType>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Personality> Personalities => Set<Personality>();
    public DbSet<PersonalityCategory> PersonalityCategories => Set<PersonalityCategory>();
    public DbSet<PersonalityDestinationType> PersonalityDestinationTypes => Set<PersonalityDestinationType>();
    public DbSet<PersonalityTourType> PersonalityTourTypes => Set<PersonalityTourType>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<SuggestedTour> SuggestedTours => Set<SuggestedTour>();
    public DbSet<TourCategory> TourCategories => Set<TourCategory>();
    public DbSet<TourObserve> TourObserves => Set<TourObserve>();
    public DbSet<DestinationObserve> DestinationObserves => Set<DestinationObserve>();
    public DbSet<TourType> TourTypes => Set<TourType>();
    public DbSet<Travel> Travels => Set<Travel>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Personality>().HasData(
            new Personality { Id = 1, Title = "رهبر الهام بخش", Code = "ENFJ", Description = "برون گرا, شهودی, احساسی, قضاوتی, کاریزماتیک, اجتماعی, دلسوز" },
            new Personality { Id = 2, Title = "مبارز", Code = "ENFP", Description = "برون گرا, شهودی, احساسی, ادراکی, خلاق, پر انرژی, اجتماعی" },
            new Personality { Id = 3, Title = "مشاور اجتماعی", Code = "ESFJ", Description = "برون گرا, حسی, احساسی, قضاوتی, وفادار, مردم دار, سازمان ده" },
            new Personality { Id = 4, Title = "مجری", Code = "ESFP", Description = "برون گرا, حسی, احساسی, ادراکی, اجتماعی, هیجان دوست, سرزنده" },
            new Personality { Id = 5, Title = "مشاور", Code = "INFJ", Description = "درون گرا, حسی, احسایسی, ادراکی, آرامان گرا, الهام بخش" },
            new Personality { Id = 6, Title = "ایده آل گرا", Code = "INFP", Description = "درون گرا, شهودی, احساسی, قضاوتی, خلاق, الهام بخش" },
            new Personality { Id = 7, Title = "معمار", Code = "INTJ", Description = "درون گرا, شهودی, منطقی, قضاوتی, استراتژیک, مستقل, تحلیلگر" },
            new Personality { Id = 8, Title = "متفکر", Code = "INTP", Description = "درون گرا, شهودی, منطقی, ادراکی, تحلیلی, کنجکاو" },
            new Personality { Id = 9, Title = "مدافع", Code = "ISFJ", Description = "درون گرا, حسی, احساسی, قضاوتی, وفادار, مهربان, دقیق" },
            new Personality { Id = 10, Title = "هنرمند", Code = "ISFP", Description = "درون گرا, حسی, احساسی,  قضاوتی, هنرمند, انعطاف پذیر" },
            new Personality { Id = 11, Title = "بازرس", Code = "ISTJ", Description = "درون گرا, حسی, منطقی, قضاوتی, مسئولیت پذیر, منظم" },
            new Personality { Id = 12, Title = "چیره دست", Code = "ISTP", Description = "درون گرا, حسی, منطقی, ادراکی, کنجکاو, ماجراجو, مستقل" },
            new Personality { Id = 13, Title = "مدیر", Code = "ESTJ", Description = "برون گرا, حسی, منطقی, قضاوتی, منظم, رهبر, قاطع" },
            new Personality { Id = 14, Title = "فرمانده", Code = "ENTJ", Description = "برون گرا, شهودی, منطقی, قضاوتی, قاطع, برنامه ریز, ریسک پذیر" },
            new Personality { Id = 15, Title = "مبتکر", Code = "ENTP", Description = "برون گرا, شهودی, منطقی, ادراکی, نو اندیش, چالش پذیر, ماجراجو" },
            new Personality { Id = 16, Title = "کارآفرین", Code = "ESTP", Description = "برون گرا, حسی, منطقی, ادراکی, پرانرژی, ماجراجو, ریسک پذیر" }
        );

        _ = modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "sadeq",
                Password = "lRAGD8HN16CHGzRRShARPaA8mFDFpd3PYydbnoBg0Hk=",
                FirstName = "محمد صادق",
                LastName = "کیومرثی",
                BirthDay = new DateTime(2002, 1, 8),
                NationalCode = "0372234471",
                PersonalityId = 3,
                Role = UserRoles.Admin,
                Gender = UserGenders.Man,
                PhoneNumber = "09217074647",
                Email = "mehmed2002q@gmail.com",
                WalletAmount = 1000000,
                ImageProfile = "34dac24d-3b74-47c3-9d24-55ed90e5a696__sadeq.png",
            },
            new User
            {
                Id = 2,
                UserName = "user-2",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "مریم",
                LastName = "محمدی",
                BirthDay = new DateTime(1995, 5, 12),
                NationalCode = "1234567890",
                PersonalityId = 6,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09123456789",
                Email = "maryam.mohammadi@gmail.com",
                WalletAmount = 250000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 3,
                UserName = "user-3",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "علی",
                LastName = "رضایی",
                BirthDay = new DateTime(1988, 8, 22),
                NationalCode = "2345678901",
                PersonalityId = 7,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09234567890",
                Email = "ali.rezaei@yahoo.com",
                WalletAmount = 180000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 4,
                UserName = "user-4",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "فاطمه",
                LastName = "حسینی",
                BirthDay = new DateTime(1992, 3, 15),
                NationalCode = "3456789012",
                PersonalityId = null,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09345678901",
                Email = "fatemeh.hosseini@outlook.com",
                WalletAmount = 320000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 5,
                UserName = "user-5",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "حسین",
                LastName = "کریمی",
                BirthDay = new DateTime(1990, 11, 5),
                NationalCode = "4567890123",
                PersonalityId = 14,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09456789012",
                Email = "hossein.karimi@gmail.com",
                WalletAmount = 420000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 6,
                UserName = "user-6",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "زهرا",
                LastName = "موسوی",
                BirthDay = new DateTime(1985, 7, 30),
                NationalCode = "5678901234",
                PersonalityId = 9,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09567890123",
                Email = "zahra.mosavi@yahoo.com",
                WalletAmount = 150000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 7,
                UserName = "user-7",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "محمد",
                LastName = "جعفری",
                BirthDay = new DateTime(1998, 2, 18),
                NationalCode = "6789012345",
                PersonalityId = 11,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09678901234",
                Email = "mohammad.jafary@hotmail.com",
                WalletAmount = 275000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 8,
                UserName = "user-8",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "نرگس",
                LastName = "رحمانی",
                BirthDay = new DateTime(1993, 9, 25),
                NationalCode = "7890123456",
                PersonalityId = null,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09789012345",
                Email = "narges.rahmani@gmail.com",
                WalletAmount = 190000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 9,
                UserName = "user-9",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "رضا",
                LastName = "فلاحی",
                BirthDay = new DateTime(1987, 4, 10),
                NationalCode = "8901234567",
                PersonalityId = 16,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09890123456",
                Email = "reza.fallahi@yahoo.com",
                WalletAmount = 360000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 10,
                UserName = "user-10",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "سارا",
                LastName = "امیدی",
                BirthDay = new DateTime(1996, 12, 8),
                NationalCode = "9012345678",
                PersonalityId = 2,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09901234567",
                Email = "sara.omidi@outlook.com",
                WalletAmount = 210000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 11,
                UserName = "user-11",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "امیر",
                LastName = "نوری",
                BirthDay = new DateTime(1991, 6, 14),
                NationalCode = "0123456789",
                PersonalityId = 5,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09111234567",
                Email = "amir.nory@gmail.com",
                WalletAmount = 290000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 12,
                UserName = "user-12",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "لیلا",
                LastName = "اسدی",
                BirthDay = new DateTime(1989, 10, 3),
                NationalCode = "1122334455",
                PersonalityId = 4,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09122334455",
                Email = "leila.asadi@yahoo.com",
                WalletAmount = 175000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 13,
                UserName = "user-13",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "حمید",
                LastName = "مهدوی",
                BirthDay = new DateTime(1994, 7, 19),
                NationalCode = "2233445566",
                PersonalityId = null,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09223344556",
                Email = "hamid.mahdavi@hotmail.com",
                WalletAmount = 230000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 14,
                UserName = "user-14",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "نازنین",
                LastName = "زارع",
                BirthDay = new DateTime(1997, 1, 28),
                NationalCode = "3344556677",
                PersonalityId = 10,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09334455667",
                Email = "nazanin.zare@gmail.com",
                WalletAmount = 310000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 15,
                UserName = "user-15",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "پارسا",
                LastName = "اکبری",
                BirthDay = new DateTime(1999, 5, 7),
                NationalCode = "4455667788",
                PersonalityId = 8,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09445566778",
                Email = "parsa.akbari@yahoo.com",
                WalletAmount = 195000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 16,
                UserName = "user-16",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "مینا",
                LastName = "قاسمی",
                BirthDay = new DateTime(1990, 8, 15),
                NationalCode = "5566778899",
                PersonalityId = 1,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09556677889",
                Email = "mina.ghasemi@outlook.com",
                WalletAmount = 280000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 17,
                UserName = "user-17",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "کامران",
                LastName = "محمدی",
                BirthDay = new DateTime(1986, 11, 22),
                NationalCode = "6677889900",
                PersonalityId = 12,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09667788990",
                Email = "kamran.mohammadi@gmail.com",
                WalletAmount = 340000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 18,
                UserName = "user-18",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "الهه",
                LastName = "صادقی",
                BirthDay = new DateTime(1995, 4, 5),
                NationalCode = "7788990011",
                PersonalityId = null,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09778899001",
                Email = "elahe.sadeqi@yahoo.com",
                WalletAmount = 220000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 19,
                UserName = "user-19",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "فرهاد",
                LastName = "شریفی",
                BirthDay = new DateTime(1988, 12, 17),
                NationalCode = "8899001122",
                PersonalityId = 15,
                Role = UserRoles.User,
                Gender = UserGenders.Man,
                PhoneNumber = "09889900112",
                Email = "farhad.sharifi@hotmail.com",
                WalletAmount = 380000,
                ImageProfile = Resource.DefaultImage,
            },
            new User
            {
                Id = 20,
                UserName = "user-20",
                Password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=",
                FirstName = "ترانه",
                LastName = "یزدانی",
                BirthDay = new DateTime(1993, 2, 9),
                NationalCode = "9900112233",
                PersonalityId = 13,
                Role = UserRoles.User,
                Gender = UserGenders.Woman,
                PhoneNumber = "09900112233",
                Email = "taraneh.yazdani@gmail.com",
                WalletAmount = 260000,
                ImageProfile = Resource.DefaultImage,
            }
        );

        _ = modelBuilder.Entity<TourType>().HasData(
            new TourType { Id = 1, Title = "دورهمی" },
            new TourType { Id = 2, Title = "دوست داران محیط زیست" },
            new TourType { Id = 3, Title = "بوم گردی" },
            new TourType { Id = 4, Title = "ورزشی" },
            new TourType { Id = 5, Title = "بقا در طبیعت و کمپینگ" },
            new TourType { Id = 6, Title = "تفریحی" },
            new TourType { Id = 7, Title = "سرگرمی" },
            new TourType { Id = 8, Title = "ارواح و مکان‌های اسرارآمیز" },
            new TourType { Id = 9, Title = "ماجراجویی" },
            new TourType { Id = 10, Title = "تاریخی" },
            new TourType { Id = 11, Title = "فرهنگی" },
            new TourType { Id = 12, Title = "زیارتی" },
            new TourType { Id = 13, Title = "سفر لوکس" },
            new TourType { Id = 14, Title = "سفر جاده‌ای" },
            new TourType { Id = 15, Title = "سفر انفرادی" },
            new TourType { Id = 16, Title = "سفر خانوادگی" },
            new TourType { Id = 17, Title = "سفر کاری" },
            new TourType { Id = 18, Title = "سفر داوطلبانه" },
            new TourType { Id = 19, Title = "سفر سلامت و یوگا" },
            new TourType { Id = 20, Title = "علمی" },
            new TourType { Id = 21, Title = "عکاسی" },
            new TourType { Id = 22, Title = "ساحلی" },
            new TourType { Id = 23, Title = "طبیعت‌گردی" },
            new TourType { Id = 24, Title = "آشپزی و غذای محلی" },
            new TourType { Id = 25, Title = "صنایع دستی و کارگاه‌های هنری" },
            new TourType { Id = 26, Title = "موسیقی و رقص محلی" },
            new TourType { Id = 27, Title = "نجومی و تماشای ستارگان" },
            new TourType { Id = 28, Title = "ادبی و کتاب‌خوانی" },
            new TourType { Id = 29, Title = "سینمایی" },
            new TourType { Id = 30, Title = "گل‌دهی و طبیعت بهاری" },
            new TourType { Id = 31, Title = "برف و زمستانی" },
            new TourType { Id = 32, Title = "کارناوال‌ها و فستیوال‌ها" },
            new TourType { Id = 33, Title = "نوجوانان و جوانان" },
            new TourType { Id = 34, Title = "سالمندان" },
            new TourType { Id = 35, Title = "حیوانات خانگی" },
            new TourType { Id = 36, Title = "مدیتیشن و ریلکسیشن" },
            new TourType { Id = 37, Title = "بازسازی انرژی (رتریت)" }
        );

        _ = modelBuilder.Entity<DestinationType>().HasData(
            new DestinationType { Id = 1, Title = "دریا" },
            new DestinationType { Id = 2, Title = "جنگل" },
            new DestinationType { Id = 3, Title = "کویر" },
            new DestinationType { Id = 4, Title = "جزایر" },
            new DestinationType { Id = 5, Title = "کوهستان" },
            new DestinationType { Id = 6, Title = "غارها" },
            new DestinationType { Id = 7, Title = "روستاهای بوم‌گردی" },
            new DestinationType { Id = 8, Title = "مناطق قطبی" },
            new DestinationType { Id = 9, Title = "چشمه‌های آبگرم" },
            new DestinationType { Id = 10, Title = "موزه" },
            new DestinationType { Id = 11, Title = "مقاصد مذهبی و زیارتی" },
            new DestinationType { Id = 12, Title = "رودخانه و دریاچه" },
            new DestinationType { Id = 13, Title = "شهرهای مدرن" },
            new DestinationType { Id = 14, Title = "شهرهای تاریخی" },
            new DestinationType { Id = 15, Title = "سایر" },
            new DestinationType { Id = 16, Title = "طبیعت" },
            new DestinationType { Id = 17, Title = "معابد" },
            new DestinationType { Id = 18, Title = "مناطق خاص" },
            new DestinationType { Id = 19, Title = "تالاب‌ و مرداب" },
            new DestinationType { Id = 20, Title = "دشت‌های نمکی و آیینه‌ای" },
            new DestinationType { Id = 21, Title = "دره‌های رنگارنگ" },
            new DestinationType { Id = 22, Title = "پارک‌های ملی حیات وحش" },
            new DestinationType { Id = 23, Title = "آتشفشان‌های نیمه‌فعال" },
            new DestinationType { Id = 24, Title = "چشمه‌های آب معدنی و گِلی" },
            new DestinationType { Id = 25, Title = "صخره‌های مرجانی و دنیای زیر آب" },
            new DestinationType { Id = 26, Title = "بیابان‌های یخی و یخچال‌های طبیعی" },
            new DestinationType { Id = 27, Title = "شهرهای زیرزمینی" },
            new DestinationType { Id = 28, Title = "قلعه‌های مخروبه و افسانه‌ای" },
            new DestinationType { Id = 29, Title = "مسیرهای باستانی و جاده‌های تاریخی" },
            new DestinationType { Id = 30, Title = "سایت‌های باستان‌شناسی مرموز" },
            new DestinationType { Id = 31, Title = "شهرهای شناور و آبی" },
            new DestinationType { Id = 32, Title = "شهرهای آینده‌نگر و تکنولوژیک" },
            new DestinationType { Id = 33, Title = "شهرهای ارواح و متروکه" },
            new DestinationType { Id = 34, Title = "پارک‌های ملی با مسیرهای تراولینگ و سنگ‌نوردی" },
            new DestinationType { Id = 35, Title = "تونل‌های درختی و جنگل‌های بارانی" },
            new DestinationType { Id = 36, Title = "مناطق بیابانی با تپه‌های شنی بلند" },
            new DestinationType { Id = 37, Title = "مکان‌های انرژی‌های ماورایی " },
            new DestinationType { Id = 38, Title = "مناطق با پدیده‌های نوری" },
            new DestinationType { Id = 39, Title = "روستاهای رنگارنگ" },
            new DestinationType { Id = 40, Title = "مزارع چای و قهوه" }
        );

        _ = modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Title = "طبیعت‌گردی" },
            new Category { Id = 2, Title = "ماجراجویی و هیجان" },
            new Category { Id = 3, Title = "تفریحی و استراحتی" },
            new Category { Id = 4, Title = "فرهنگی و هنری" },
            new Category { Id = 5, Title = "تاریخی" },
            new Category { Id = 6, Title = "زیارتی" },
            new Category { Id = 7, Title = "ورزشی" },
            new Category { Id = 8, Title = "کمپینگ و بقا در طبیعت" },
            new Category { Id = 9, Title = "تورهای غذایی و آشپزی" },
            new Category { Id = 10, Title = "تورهای عکاسی" },
            new Category { Id = 11, Title = "تورهای کشتی و کروز" },
            new Category { Id = 12, Title = "تورهای خاص و لاکچری" },
            new Category { Id = 13, Title = "سفرهای علمی و آموزشی" },
            new Category { Id = 14, Title = "سفر های کاری" },
            new Category { Id = 15, Title = "خانوادگی" },
            new Category { Id = 16, Title = "بوم گردی" },
            new Category { Id = 17, Title = "یوگا" },
            new Category { Id = 18, Title = "سلامت" },
            new Category { Id = 19, Title = "صنایع دستی و کارگاه‌های محلی" },
            new Category { Id = 20, Title = "موسیقی و رقص‌های فولکلور" },
            new Category { Id = 21, Title = "مشارکتی با جوامع محلی" },
            new Category { Id = 22, Title = "گل‌دهی و طبیعت بهاری" },
            new Category { Id = 23, Title = "فستیوال‌ها و کارناوال‌ها" },
            new Category { Id = 24, Title = "زمستانی و برفی " },
            new Category { Id = 25, Title = "نوجوانان و جوانان" },
            new Category { Id = 26, Title = "سالمندان" },
            new Category { Id = 27, Title = "حیوانات خانگی" },
            new Category { Id = 28, Title = "مدیتیشن و ریلکسیشن" },
            new Category { Id = 29, Title = "ارواح و مکان‌های اسرارآمیز" },
            new Category { Id = 30, Title = "نجومی و تماشای ستارگان" },
            new Category { Id = 31, Title = "هلیکوپتری " },
            new Category { Id = 32, Title = "اقامت در هتل‌های بی‌نظیر" },
            new Category { Id = 33, Title = "زبان‌آموزی" },
            new Category { Id = 34, Title = "کسب‌وکار و استارتاپی" },
            new Category { Id = 35, Title = "زیست‌شناس" },
            new Category { Id = 36, Title = "تورهای اکوولنتیرینگ" },
            new Category { Id = 37, Title = "انسان‌دوستانه" },
            new Category { Id = 38, Title = "صنایع دستی و کارگاه‌های محلی" }
        );

        _ = modelBuilder.Entity<PersonalityTourType>().HasData(
            // ENFJ - رهبر الهام بخش (کاریزماتیک، اجتماعی، دلسوز)
            new PersonalityTourType { Id = 1, PersonalityId = 1, TourTypeId = 1 },  // دورهمی
            new PersonalityTourType { Id = 2, PersonalityId = 1, TourTypeId = 10 }, // تاریخی
            new PersonalityTourType { Id = 3, PersonalityId = 1, TourTypeId = 11 }, // فرهنگی
            new PersonalityTourType { Id = 4, PersonalityId = 1, TourTypeId = 16 }, // خانوادگی
            new PersonalityTourType { Id = 5, PersonalityId = 1, TourTypeId = 18 }, // داوطلبانه
            new PersonalityTourType { Id = 6, PersonalityId = 1, TourTypeId = 19 }, // سفر سلامت و یوگا
            new PersonalityTourType { Id = 7, PersonalityId = 1, TourTypeId = 26 }, // موسیقی و رقص

            // ENFP - مبارز (خلاق، پرانرژی، اجتماعی)
            new PersonalityTourType { Id = 8, PersonalityId = 2, TourTypeId = 6 },  // تفریحی
            new PersonalityTourType { Id = 9, PersonalityId = 2, TourTypeId = 7 },  // سرگرمی
            new PersonalityTourType { Id = 10, PersonalityId = 2, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 11, PersonalityId = 2, TourTypeId = 18 }, // سفر داوطلبانه
            new PersonalityTourType { Id = 12, PersonalityId = 2, TourTypeId = 23 }, // طبیعت‌گردی
            new PersonalityTourType { Id = 13, PersonalityId = 2, TourTypeId = 25 }, // صنایع دستی
            new PersonalityTourType { Id = 14, PersonalityId = 2, TourTypeId = 32 }, // کارناوال‌ها

            // ESFJ - مشاور اجتماعی (مردم دار، سازمان ده)
            new PersonalityTourType { Id = 15, PersonalityId = 3, TourTypeId = 1 },  // دورهمی
            new PersonalityTourType { Id = 16, PersonalityId = 3, TourTypeId = 3 },  // بوم گردی
            new PersonalityTourType { Id = 17, PersonalityId = 3, TourTypeId = 6 },  // تفریحی
            new PersonalityTourType { Id = 18, PersonalityId = 3, TourTypeId = 11 }, // فرهنگی
            new PersonalityTourType { Id = 19, PersonalityId = 3, TourTypeId = 12 }, // زیارتی
            new PersonalityTourType { Id = 20, PersonalityId = 3, TourTypeId = 16 }, // خانوادگی
            new PersonalityTourType { Id = 21, PersonalityId = 3, TourTypeId = 24 }, // آشپزی

            // ESFP - مجری (اجتماعی، هیجان دوست)
            new PersonalityTourType { Id = 22, PersonalityId = 4, TourTypeId = 4 },  // ورزشی
            new PersonalityTourType { Id = 23, PersonalityId = 4, TourTypeId = 6 },  // تفریحی
            new PersonalityTourType { Id = 24, PersonalityId = 4, TourTypeId = 7 },  // سرگرمی
            new PersonalityTourType { Id = 25, PersonalityId = 4, TourTypeId = 22 }, // ساحلی
            new PersonalityTourType { Id = 26, PersonalityId = 4, TourTypeId = 32 }, // کارناوال‌ها

            // INFJ - مشاور (آرام، الهام بخش)
            new PersonalityTourType { Id = 27, PersonalityId = 5, TourTypeId = 12 }, // زیارتی
            new PersonalityTourType { Id = 28, PersonalityId = 5, TourTypeId = 19 }, // سفر سلامت و یوگا
            new PersonalityTourType { Id = 29, PersonalityId = 5, TourTypeId = 27 }, // نجومی
            new PersonalityTourType { Id = 30, PersonalityId = 5, TourTypeId = 28 }, // ادبی
            new PersonalityTourType { Id = 31, PersonalityId = 5, TourTypeId = 36 }, // مدیتیشن
            new PersonalityTourType { Id = 32, PersonalityId = 5, TourTypeId = 37 }, // رتریت

            // INFP - ایده‌آل گرا (خلاق، الهام بخش)
            new PersonalityTourType { Id = 33, PersonalityId = 6, TourTypeId = 11 }, // فرهنگی
            new PersonalityTourType { Id = 34, PersonalityId = 6, TourTypeId = 18 }, // سفر داوطلبانه
            new PersonalityTourType { Id = 35, PersonalityId = 6, TourTypeId = 19 }, // سفر سلامت و یوگا
            new PersonalityTourType { Id = 36, PersonalityId = 6, TourTypeId = 28 }, // ادبی
            new PersonalityTourType { Id = 37, PersonalityId = 6, TourTypeId = 25 }, // صنایع دستی
            new PersonalityTourType { Id = 38, PersonalityId = 6, TourTypeId = 30 }, // گل‌دهی
            new PersonalityTourType { Id = 39, PersonalityId = 6, TourTypeId = 27 }, // نجومی
            new PersonalityTourType { Id = 40, PersonalityId = 6, TourTypeId = 2 },  // محیط زیست

            // INTJ - معمار (استراتژیک، تحلیلگر)
            new PersonalityTourType { Id = 41, PersonalityId = 7, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 42, PersonalityId = 7, TourTypeId = 10 }, // تاریخی
            new PersonalityTourType { Id = 43, PersonalityId = 7, TourTypeId = 20 }, // علمی
            new PersonalityTourType { Id = 44, PersonalityId = 7, TourTypeId = 15 }, // انفرادی
            new PersonalityTourType { Id = 45, PersonalityId = 7, TourTypeId = 29 }, // سینمایی
            new PersonalityTourType { Id = 46, PersonalityId = 7, TourTypeId = 14 }, // جاده‌ای

            // INTP - متفکر (تحلیلی، کنجکاو)
            new PersonalityTourType { Id = 47, PersonalityId = 8, TourTypeId = 8 },  // ارواح
            new PersonalityTourType { Id = 48, PersonalityId = 8, TourTypeId = 20 }, // علمی
            new PersonalityTourType { Id = 49, PersonalityId = 8, TourTypeId = 27 }, // نجومی
            new PersonalityTourType { Id = 50, PersonalityId = 8, TourTypeId = 10 }, // تاریخی
            new PersonalityTourType { Id = 51, PersonalityId = 8, TourTypeId = 15 }, // انفرادی

            // ISFJ - مدافع (مهربان، دقیق)
            new PersonalityTourType { Id = 52, PersonalityId = 9, TourTypeId = 3 },  // بوم گردی
            new PersonalityTourType { Id = 53, PersonalityId = 9, TourTypeId = 12 }, // زیارتی
            new PersonalityTourType { Id = 54, PersonalityId = 9, TourTypeId = 16 }, // خانوادگی
            new PersonalityTourType { Id = 55, PersonalityId = 9, TourTypeId = 24 }, // آشپزی
            new PersonalityTourType { Id = 56, PersonalityId = 9, TourTypeId = 19 }, // یوگا

            // ISFP - هنرمند (انعطاف پذیر)
            new PersonalityTourType { Id = 57, PersonalityId = 10, TourTypeId = 6 },  // تفریحی
            new PersonalityTourType { Id = 58, PersonalityId = 10, TourTypeId = 21 }, // عکاسی
            new PersonalityTourType { Id = 59, PersonalityId = 10, TourTypeId = 25 }, // صنایع دستی
            new PersonalityTourType { Id = 60, PersonalityId = 10, TourTypeId = 30 }, // گل‌دهی
            new PersonalityTourType { Id = 61, PersonalityId = 10, TourTypeId = 23 }, // طبیعت‌گردی
            new PersonalityTourType { Id = 62, PersonalityId = 10, TourTypeId = 15 }, // انفرادی

            // ISTJ - بازرس (مسئولیت پذیر، منظم)
            new PersonalityTourType { Id = 63, PersonalityId = 11, TourTypeId = 10 }, // تاریخی
            new PersonalityTourType { Id = 64, PersonalityId = 11, TourTypeId = 11 }, // فرهنگی
            new PersonalityTourType { Id = 65, PersonalityId = 11, TourTypeId = 13 }, // لوکس
            new PersonalityTourType { Id = 66, PersonalityId = 11, TourTypeId = 17 }, // سفر کاری
            new PersonalityTourType { Id = 67, PersonalityId = 11, TourTypeId = 5 },  // بقا در طبیعت
            new PersonalityTourType { Id = 68, PersonalityId = 11, TourTypeId = 14 }, // جاده‌ای

            // ISTP - چیره دست (ماجراجو، مستقل)
            new PersonalityTourType { Id = 69, PersonalityId = 12, TourTypeId = 4 },  // ورزشی
            new PersonalityTourType { Id = 70, PersonalityId = 12, TourTypeId = 5 },  // بقا در طبیعت
            new PersonalityTourType { Id = 71, PersonalityId = 12, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 72, PersonalityId = 12, TourTypeId = 12 }, // زیارتی
            new PersonalityTourType { Id = 73, PersonalityId = 12, TourTypeId = 31 }, // زمستانی

            // ESTJ - مدیر (منظم، رهبر)
            new PersonalityTourType { Id = 74, PersonalityId = 13, TourTypeId = 13 }, // لوکس
            new PersonalityTourType { Id = 75, PersonalityId = 13, TourTypeId = 17 }, // سفر کاری
            new PersonalityTourType { Id = 76, PersonalityId = 13, TourTypeId = 10 }, // تاریخی
            new PersonalityTourType { Id = 77, PersonalityId = 13, TourTypeId = 14 }, // جاده‌ای
            new PersonalityTourType { Id = 78, PersonalityId = 13, TourTypeId = 4 },  // ورزشی

            // ENTJ - فرمانده (قاطع، برنامه‌ریز)
            new PersonalityTourType { Id = 79, PersonalityId = 14, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 80, PersonalityId = 14, TourTypeId = 14 }, // جاده‌ای
            new PersonalityTourType { Id = 81, PersonalityId = 14, TourTypeId = 17 }, // کاری
            new PersonalityTourType { Id = 82, PersonalityId = 14, TourTypeId = 20 }, // علمی
            new PersonalityTourType { Id = 83, PersonalityId = 14, TourTypeId = 13 }, // لوکس

            // ENTP - مبتکر (نو اندیش، چالش پذیر)
            new PersonalityTourType { Id = 84, PersonalityId = 15, TourTypeId = 5 },  // بقا در طبیعت
            new PersonalityTourType { Id = 85, PersonalityId = 15, TourTypeId = 8 },  // ارواح
            new PersonalityTourType { Id = 86, PersonalityId = 15, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 87, PersonalityId = 15, TourTypeId = 15 }, // انفرادی
            new PersonalityTourType { Id = 88, PersonalityId = 15, TourTypeId = 20 }, // علمی
            new PersonalityTourType { Id = 89, PersonalityId = 15, TourTypeId = 29 }, // سینمایی
            new PersonalityTourType { Id = 90, PersonalityId = 15, TourTypeId = 32 }, // کارناوال‌ها

            // ESTP - کارآفرین (پرانرژی، ریسک پذیر)
            new PersonalityTourType { Id = 91, PersonalityId = 16, TourTypeId = 4 },  // ورزشی
            new PersonalityTourType { Id = 92, PersonalityId = 16, TourTypeId = 9 },  // ماجراجویی
            new PersonalityTourType { Id = 93, PersonalityId = 16, TourTypeId = 13 }, // لوکس
            new PersonalityTourType { Id = 94, PersonalityId = 16, TourTypeId = 16 }, // خانوادگی
            new PersonalityTourType { Id = 95, PersonalityId = 16, TourTypeId = 22 }, // ساحلی
            new PersonalityTourType { Id = 96, PersonalityId = 16, TourTypeId = 31 }  // زمستانی
        );

        _ = modelBuilder.Entity<PersonalityDestinationType>().HasData(
            // ENFJ - رهبر الهام بخش (کاریزماتیک، اجتماعی، دلسوز)
            new PersonalityDestinationType { Id = 1, PersonalityId = 1, DestinationTypeId = 5 }, // کوهستان
            new PersonalityDestinationType { Id = 2, PersonalityId = 1, DestinationTypeId = 11 }, // مقاصد مذهبی
            new PersonalityDestinationType { Id = 3, PersonalityId = 1, DestinationTypeId = 13 }, // شهرهای مدرن
            new PersonalityDestinationType { Id = 4, PersonalityId = 1, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 5, PersonalityId = 1, DestinationTypeId = 17 }, // معابد
            new PersonalityDestinationType { Id = 6, PersonalityId = 1, DestinationTypeId = 39 }, // روستاهای رنگارنگ
            new PersonalityDestinationType { Id = 7, PersonalityId = 1, DestinationTypeId = 40 }, // مزارع چای

            // ENFP - مبارز (خلاق، پرانرژی، اجتماعی)
            new PersonalityDestinationType { Id = 8, PersonalityId = 2, DestinationTypeId = 2 }, // جنگل
            new PersonalityDestinationType { Id = 9, PersonalityId = 2, DestinationTypeId = 3 }, // کویر
            new PersonalityDestinationType { Id = 10, PersonalityId = 2, DestinationTypeId = 4 },  // جزایر
            new PersonalityDestinationType { Id = 11, PersonalityId = 2, DestinationTypeId = 7 }, // روستاهای بوم‌گردی
            new PersonalityDestinationType { Id = 12, PersonalityId = 2, DestinationTypeId = 21 }, // دره‌های رنگارنگ
            new PersonalityDestinationType { Id = 13, PersonalityId = 2, DestinationTypeId = 28 }, // قلعه‌های افسانه‌ای
            new PersonalityDestinationType { Id = 14, PersonalityId = 2, DestinationTypeId = 32 }, // شهرهای آینده‌نگر
            new PersonalityDestinationType { Id = 15, PersonalityId = 2, DestinationTypeId = 35 }, // تونل‌های درختی

            // ESFJ - مشاور اجتماعی (مردم دار، سازمان ده)
            new PersonalityDestinationType { Id = 16, PersonalityId = 3, DestinationTypeId = 1 },  // دریا
            new PersonalityDestinationType { Id = 17, PersonalityId = 3, DestinationTypeId = 2 },  // جنگل
            new PersonalityDestinationType { Id = 18, PersonalityId = 3, DestinationTypeId = 7 },  // روستاهای بوم‌گردی
            new PersonalityDestinationType { Id = 19, PersonalityId = 3, DestinationTypeId = 11 }, // مقاصد مذهبی و زیارتی
            new PersonalityDestinationType { Id = 20, PersonalityId = 3, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 21, PersonalityId = 3, DestinationTypeId = 24 }, // چشمه‌های گِلی
            new PersonalityDestinationType { Id = 22, PersonalityId = 3, DestinationTypeId = 40 }, // مزارع چای

            // ESFP - مجری (اجتماعی، هیجان دوست)
            new PersonalityDestinationType { Id = 23, PersonalityId = 4, DestinationTypeId = 1 },  // دریا
            new PersonalityDestinationType { Id = 24, PersonalityId = 4, DestinationTypeId = 4 },  // جزایر
            new PersonalityDestinationType { Id = 25, PersonalityId = 4, DestinationTypeId = 13 }, // شهرهای مدرن
            new PersonalityDestinationType { Id = 26, PersonalityId = 4, DestinationTypeId = 22 }, // پارک‌های حیات وحش
            new PersonalityDestinationType { Id = 27, PersonalityId = 4, DestinationTypeId = 25 }, // صخره‌های مرجانی
            new PersonalityDestinationType { Id = 28, PersonalityId = 4, DestinationTypeId = 39 }, // روستاهای رنگارنگ

            // INFJ - مشاور (آرام، الهام بخش)
            new PersonalityDestinationType { Id = 29, PersonalityId = 5, DestinationTypeId = 2 },  // جنگل
            new PersonalityDestinationType { Id = 30, PersonalityId = 5, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 31, PersonalityId = 5, DestinationTypeId = 6 },  // غارها
            new PersonalityDestinationType { Id = 32, PersonalityId = 5, DestinationTypeId = 27 }, // شهرهای زیرزمینی
            new PersonalityDestinationType { Id = 33, PersonalityId = 5, DestinationTypeId = 37 }, // مکان‌های ماورایی
            new PersonalityDestinationType { Id = 34, PersonalityId = 5, DestinationTypeId = 38 }, // پدیده‌های نوری

            // INFP - ایده‌آل گرا (خلاق، الهام بخش)
            new PersonalityDestinationType { Id = 35, PersonalityId = 6, DestinationTypeId = 2 },  // جنگل
            new PersonalityDestinationType { Id = 36, PersonalityId = 6, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 37, PersonalityId = 6, DestinationTypeId = 14 },  // شهرهای تاریخی
            new PersonalityDestinationType { Id = 38, PersonalityId = 6, DestinationTypeId = 17 }, // معابد
            new PersonalityDestinationType { Id = 39, PersonalityId = 6, DestinationTypeId = 21 }, // دره‌های رنگارنگ
            new PersonalityDestinationType { Id = 40, PersonalityId = 6, DestinationTypeId = 28 }, // قلعه‌های افسانه‌ای
            new PersonalityDestinationType { Id = 41, PersonalityId = 6, DestinationTypeId = 30 }, // سایت‌های باستان‌شناسی
            new PersonalityDestinationType { Id = 42, PersonalityId = 6, DestinationTypeId = 37 }, // مکان‌های ماورایی

            // INTJ - معمار (استراتژیک، تحلیلگر)
            new PersonalityDestinationType { Id = 43, PersonalityId = 7, DestinationTypeId = 3 },  // کویر
            new PersonalityDestinationType { Id = 44, PersonalityId = 7, DestinationTypeId = 6 },  // غارها
            new PersonalityDestinationType { Id = 45, PersonalityId = 7, DestinationTypeId = 8 },  // مناطق قطبی
            new PersonalityDestinationType { Id = 46, PersonalityId = 7, DestinationTypeId = 10 }, // موزه
            new PersonalityDestinationType { Id = 47, PersonalityId = 7, DestinationTypeId = 27 }, // شهرهای زیرزمینی
            new PersonalityDestinationType { Id = 48, PersonalityId = 7, DestinationTypeId = 29 }, // مسیرهای باستانی
            new PersonalityDestinationType { Id = 49, PersonalityId = 7, DestinationTypeId = 32 }, // شهرهای تکنولوژیک

            // INTP - متفکر (تحلیلی، کنجکاو)
            new PersonalityDestinationType { Id = 50, PersonalityId = 8, DestinationTypeId = 3 },  // کویر
            new PersonalityDestinationType { Id = 51, PersonalityId = 8, DestinationTypeId = 6 },  // غارها
            new PersonalityDestinationType { Id = 52, PersonalityId = 8, DestinationTypeId = 8 },  // مناطق قطبی
            new PersonalityDestinationType { Id = 53, PersonalityId = 8, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 54, PersonalityId = 8, DestinationTypeId = 23 }, // آتشفشان‌ها
            new PersonalityDestinationType { Id = 55, PersonalityId = 8, DestinationTypeId = 30 }, // سایت‌های باستان‌شناسی
            new PersonalityDestinationType { Id = 56, PersonalityId = 8, DestinationTypeId = 33 }, // شهرهای ارواح
            new PersonalityDestinationType { Id = 57, PersonalityId = 8, DestinationTypeId = 38 }, // پدیده‌های نوری

            // ISFJ - مدافع (مهربان، دقیق)
            new PersonalityDestinationType { Id = 58, PersonalityId = 9, DestinationTypeId = 7 },  // روستاهای بوم‌گردی
            new PersonalityDestinationType { Id = 59, PersonalityId = 9, DestinationTypeId = 9 },  // چشمه‌های آبگرم
            new PersonalityDestinationType { Id = 60, PersonalityId = 9, DestinationTypeId = 11 }, // مقاصد مذهبی
            new PersonalityDestinationType { Id = 61, PersonalityId = 9, DestinationTypeId = 12 }, // رودخانه و دریاچه
            new PersonalityDestinationType { Id = 62, PersonalityId = 9, DestinationTypeId = 16 }, // طبیعت
            new PersonalityDestinationType { Id = 63, PersonalityId = 9, DestinationTypeId = 19 }, // تالاب‌ها

            // ISFP - هنرمند (انعطاف پذیر)
            new PersonalityDestinationType { Id = 64, PersonalityId = 10, DestinationTypeId = 1 }, // دریا
            new PersonalityDestinationType { Id = 65, PersonalityId = 10, DestinationTypeId = 2 }, // جنگل
            new PersonalityDestinationType { Id = 66, PersonalityId = 10, DestinationTypeId = 4 }, // جزایر
            new PersonalityDestinationType { Id = 67, PersonalityId = 10, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 68, PersonalityId = 10, DestinationTypeId = 16 }, // طبیعت
            new PersonalityDestinationType { Id = 69, PersonalityId = 10, DestinationTypeId = 21 }, // دره‌های رنگارنگ
            new PersonalityDestinationType { Id = 70, PersonalityId = 10, DestinationTypeId = 24 }, // چشمه‌های گِلی
            new PersonalityDestinationType { Id = 71, PersonalityId = 10, DestinationTypeId = 39 }, // روستاهای رنگارنگ

            // ISTJ - بازرس (مسئولیت پذیر، منظم)
            new PersonalityDestinationType { Id = 72, PersonalityId = 11, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 73, PersonalityId = 11, DestinationTypeId = 10 }, // موزه
            new PersonalityDestinationType { Id = 74, PersonalityId = 11, DestinationTypeId = 13 }, // شهرهای مدرن
            new PersonalityDestinationType { Id = 75, PersonalityId = 11, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 76, PersonalityId = 11, DestinationTypeId = 22 }, // پارک‌های حیات وحش
            new PersonalityDestinationType { Id = 77, PersonalityId = 11, DestinationTypeId = 29 }, // مسیرهای باستانی

            // ISTP - چیره دست (ماجراجو، مستقل)
            new PersonalityDestinationType { Id = 78, PersonalityId = 12, DestinationTypeId = 1 }, // دریا
            new PersonalityDestinationType { Id = 79, PersonalityId = 12, DestinationTypeId = 2 }, // جنگل
            new PersonalityDestinationType { Id = 80, PersonalityId = 12, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 81, PersonalityId = 12, DestinationTypeId = 23 }, // آتشفشان‌ها
            new PersonalityDestinationType { Id = 82, PersonalityId = 12, DestinationTypeId = 26 }, // بیابان‌های یخی
            new PersonalityDestinationType { Id = 83, PersonalityId = 12, DestinationTypeId = 34 }, // پارک‌های ملی
            new PersonalityDestinationType { Id = 84, PersonalityId = 12, DestinationTypeId = 36 }, // تپه‌های شنی

            // ESTJ - مدیر (منظم، رهبر)
            new PersonalityDestinationType { Id = 85, PersonalityId = 13, DestinationTypeId = 10 }, // موزه
            new PersonalityDestinationType { Id = 86, PersonalityId = 13, DestinationTypeId = 13 }, // شهرهای مدرن
            new PersonalityDestinationType { Id = 87, PersonalityId = 13, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 88, PersonalityId = 13, DestinationTypeId = 22 }, // پارک‌های حیات وحش
            new PersonalityDestinationType { Id = 89, PersonalityId = 13, DestinationTypeId = 32 }, // شهرهای تکنولوژیک

            // ENTJ - فرمانده (قاطع، برنامه‌ریز)
            new PersonalityDestinationType { Id = 90, PersonalityId = 14, DestinationTypeId = 1 }, // دریا
            new PersonalityDestinationType { Id = 91, PersonalityId = 14, DestinationTypeId = 5 }, // کوهستان
            new PersonalityDestinationType { Id = 92, PersonalityId = 14, DestinationTypeId = 14 }, // شهرهای تاریخی
            new PersonalityDestinationType { Id = 93, PersonalityId = 14, DestinationTypeId = 18 }, // مناطق خاص
            new PersonalityDestinationType { Id = 94, PersonalityId = 14, DestinationTypeId = 31 }, // شهرهای شناور
            new PersonalityDestinationType { Id = 95, PersonalityId = 14, DestinationTypeId = 32 }, // شهرهای تکنولوژیک
            new PersonalityDestinationType { Id = 96, PersonalityId = 14, DestinationTypeId = 34 }, // پارک‌های ملی

            // ENTP - مبتکر (نو اندیش، چالش پذیر)
            new PersonalityDestinationType { Id = 97, PersonalityId = 15, DestinationTypeId = 5 }, // کوهستان
            new PersonalityDestinationType { Id = 98, PersonalityId = 15, DestinationTypeId = 6 }, // غارها
            new PersonalityDestinationType { Id = 99, PersonalityId = 15, DestinationTypeId = 18 }, //مناطق خاص
            new PersonalityDestinationType { Id = 100, PersonalityId = 15, DestinationTypeId = 23 }, // آتشفشان‌ها
            new PersonalityDestinationType { Id = 101, PersonalityId = 15, DestinationTypeId = 27 }, // شهرهای زیرزمینی
            new PersonalityDestinationType { Id = 102, PersonalityId = 15, DestinationTypeId = 30 }, // سایت‌های باستان‌شناسی
            new PersonalityDestinationType { Id = 103, PersonalityId = 15, DestinationTypeId = 33 }, // شهرهای ارواح
            new PersonalityDestinationType { Id = 104, PersonalityId = 15, DestinationTypeId = 38 }, // پدیده‌های نوری

            // ESTP - کارآفرین (پرانرژی، ریسک پذیر)
            new PersonalityDestinationType { Id = 105, PersonalityId = 16, DestinationTypeId = 1 },  // دریا
            new PersonalityDestinationType { Id = 106, PersonalityId = 16, DestinationTypeId = 4 },  // جزایر
            new PersonalityDestinationType { Id = 107, PersonalityId = 16, DestinationTypeId = 5 },  // کوهستان
            new PersonalityDestinationType { Id = 108, PersonalityId = 16, DestinationTypeId = 13 },  // شهرهای مدرن
            new PersonalityDestinationType { Id = 109, PersonalityId = 16, DestinationTypeId = 34 }, // پارک‌های ملی
            new PersonalityDestinationType { Id = 110, PersonalityId = 16, DestinationTypeId = 36 }  // تپه‌های شنی
        );

        _ = modelBuilder.Entity<PersonalityCategory>().HasData(
            // ENFJ - رهبر الهام بخش (کاریزماتیک، اجتماعی، دلسوز)
            new PersonalityCategory { Id = 1, PersonalityId = 1, CategoryId = 1 }, // طبیعت‌گردی
            new PersonalityCategory { Id = 2, PersonalityId = 1, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 3, PersonalityId = 1, CategoryId = 5 },  // تاریخی
            new PersonalityCategory { Id = 4, PersonalityId = 1, CategoryId = 6 },  // زیارتی
            new PersonalityCategory { Id = 5, PersonalityId = 1, CategoryId = 15 }, // خانوادگی
            new PersonalityCategory { Id = 6, PersonalityId = 1, CategoryId = 18 }, // سلامت
            new PersonalityCategory { Id = 7, PersonalityId = 1, CategoryId = 21 }, // مشارکتی با جوامع محلی
            new PersonalityCategory { Id = 8, PersonalityId = 1, CategoryId = 20 }, // موسیقی و رقص‌های فولکلور
            new PersonalityCategory { Id = 9, PersonalityId = 1, CategoryId = 37 }, // انسان‌دوستانه

            // ENFP - مبارز (خلاق، پرانرژی، اجتماعی)
            new PersonalityCategory { Id = 10, PersonalityId = 2, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 11, PersonalityId = 2, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 12, PersonalityId = 2, CategoryId = 16 }, // بوم گردی
            new PersonalityCategory { Id = 13, PersonalityId = 2, CategoryId = 19 }, // صنایع دستی
            new PersonalityCategory { Id = 14, PersonalityId = 2, CategoryId = 23 }, // فستیوال‌ها
            new PersonalityCategory { Id = 15, PersonalityId = 2, CategoryId = 25 }, // نوجوانان و جوانان

            // ESFJ - مشاور اجتماعی (مردم دار، سازمان ده)
            new PersonalityCategory { Id = 16, PersonalityId = 3, CategoryId = 3 },  // تفریحی و استراحتی
            new PersonalityCategory { Id = 17, PersonalityId = 3, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 18, PersonalityId = 3, CategoryId = 6 },  // زیارتی
            new PersonalityCategory { Id = 19, PersonalityId = 3, CategoryId = 9 },  // تورهای غذایی
            new PersonalityCategory { Id = 20, PersonalityId = 3, CategoryId = 15 }, // خانوادگی
            new PersonalityCategory { Id = 21, PersonalityId = 3, CategoryId = 16 }, // بوم گردی

            // ESFP - مجری (اجتماعی، هیجان دوست)
            new PersonalityCategory { Id = 22, PersonalityId = 4, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 23, PersonalityId = 4, CategoryId = 3 },  // تفریحی
            new PersonalityCategory { Id = 24, PersonalityId = 4, CategoryId = 7 },  // ورزشی
            new PersonalityCategory { Id = 25, PersonalityId = 4, CategoryId = 11 }, // کشتی و کروز
            new PersonalityCategory { Id = 26, PersonalityId = 4, CategoryId = 12 }, // لاکچری
            new PersonalityCategory { Id = 27, PersonalityId = 4, CategoryId = 23 }, // فستیوال‌ها

            // INFJ - مشاور (آرام، الهام بخش)
            new PersonalityCategory { Id = 28, PersonalityId = 5, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 29, PersonalityId = 5, CategoryId = 28 }, // مدیتیشن
            new PersonalityCategory { Id = 30, PersonalityId = 5, CategoryId = 16 }, // بوم گردی
            new PersonalityCategory { Id = 31, PersonalityId = 5, CategoryId = 17 }, // یوگا
            new PersonalityCategory { Id = 32, PersonalityId = 5, CategoryId = 30 }, // نجومی
            new PersonalityCategory { Id = 33, PersonalityId = 5, CategoryId = 6 },  // زیارتی
            new PersonalityCategory { Id = 34, PersonalityId = 5, CategoryId = 29 }, // ارواح و اسرارآمیز

            // INFP - ایده‌آل گرا (خلاق، الهام بخش)
            new PersonalityCategory { Id = 35, PersonalityId = 6, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 36, PersonalityId = 6, CategoryId = 10 }, // عکاسی
            new PersonalityCategory { Id = 37, PersonalityId = 6, CategoryId = 16 }, // بوم گردی
            new PersonalityCategory { Id = 38, PersonalityId = 6, CategoryId = 17 }, // یوگا
            new PersonalityCategory { Id = 39, PersonalityId = 6, CategoryId = 22 }, // گل‌دهی
            new PersonalityCategory { Id = 40, PersonalityId = 6, CategoryId = 36 }, // اکوولنتیرینگ
            new PersonalityCategory { Id = 41, PersonalityId = 6, CategoryId = 30 }, // نجومی

            // INTJ - معمار (استراتژیک، مستقل)
            new PersonalityCategory { Id = 42, PersonalityId = 7, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 43, PersonalityId = 7, CategoryId = 5 },  // تاریخی
            new PersonalityCategory { Id = 44, PersonalityId = 7, CategoryId = 8 },  // کمپینگ
            new PersonalityCategory { Id = 45, PersonalityId = 7, CategoryId = 13 }, // علمی
            new PersonalityCategory { Id = 46, PersonalityId = 7, CategoryId = 14 }, // کاری
            new PersonalityCategory { Id = 47, PersonalityId = 7, CategoryId = 32 }, // هتل‌های بی‌نظیر
            new PersonalityCategory { Id = 48, PersonalityId = 7, CategoryId = 34 }, // کسب‌وکار

            // INTP - متفکر (تحلیلی، کنجکاو)
            new PersonalityCategory { Id = 49, PersonalityId = 8, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 50, PersonalityId = 8, CategoryId = 5 },  // تاریخی
            new PersonalityCategory { Id = 51, PersonalityId = 8, CategoryId = 13 }, // علمی
            new PersonalityCategory { Id = 52, PersonalityId = 8, CategoryId = 29 }, // ارواح و اسرارآمیز
            new PersonalityCategory { Id = 53, PersonalityId = 8, CategoryId = 30 }, // نجومی
            new PersonalityCategory { Id = 54, PersonalityId = 8, CategoryId = 33 }, // زبان‌آموزی
            new PersonalityCategory { Id = 55, PersonalityId = 8, CategoryId = 35 }, // زیست‌شناس

            // ISFJ - مدافع (وفادار، مهربان)
            new PersonalityCategory { Id = 56, PersonalityId = 9, CategoryId = 1 },  // طبیعت‌گردی
            new PersonalityCategory { Id = 57, PersonalityId = 9, CategoryId = 6 },  // زیارتی
            new PersonalityCategory { Id = 58, PersonalityId = 9, CategoryId = 15 }, // خانوادگی
            new PersonalityCategory { Id = 59, PersonalityId = 9, CategoryId = 16 }, // بوم گردی
            new PersonalityCategory { Id = 60, PersonalityId = 9, CategoryId = 9 },  // تورهای غذایی
            new PersonalityCategory { Id = 61, PersonalityId = 9, CategoryId = 18 }, // سلامت

            // ISFP - هنرمند (انعطاف پذیر، هنرمند)
            new PersonalityCategory { Id = 62, PersonalityId = 10, CategoryId = 1 },  // طبیعت‌گردی
            new PersonalityCategory { Id = 63, PersonalityId = 10, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 64, PersonalityId = 10, CategoryId = 10 }, // عکاسی
            new PersonalityCategory { Id = 65, PersonalityId = 10, CategoryId = 19 }, // صنایع دستی
            new PersonalityCategory { Id = 66, PersonalityId = 10, CategoryId = 22 }, // گل‌دهی

            // ISTJ - بازرس (مسئولیت پذیر، منظم)
            new PersonalityCategory { Id = 67, PersonalityId = 11, CategoryId = 4 },  // فرهنگی و هنری
            new PersonalityCategory { Id = 68, PersonalityId = 11, CategoryId = 5 },  // تاریخی
            new PersonalityCategory { Id = 69, PersonalityId = 11, CategoryId = 7 },  // ورزشی
            new PersonalityCategory { Id = 70, PersonalityId = 11, CategoryId = 8 },  // کمپینگ
            new PersonalityCategory { Id = 71, PersonalityId = 11, CategoryId = 12 }, // لاکچری
            new PersonalityCategory { Id = 72, PersonalityId = 11, CategoryId = 14 }, // کاری

            // ISTP - چیره دست (ماجراجو، مستقل)
            new PersonalityCategory { Id = 73, PersonalityId = 12, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 74, PersonalityId = 12, CategoryId = 7 },  // ورزشی
            new PersonalityCategory { Id = 75, PersonalityId = 12, CategoryId = 8 },  // کمپینگ
            new PersonalityCategory { Id = 76, PersonalityId = 12, CategoryId = 24 }, // زمستانی
            new PersonalityCategory { Id = 77, PersonalityId = 12, CategoryId = 31 }, // هلیکوپتری

            // ESTJ - مدیر (منظم، رهبر)
            new PersonalityCategory { Id = 78, PersonalityId = 13, CategoryId = 5 },  // تاریخی
            new PersonalityCategory { Id = 79, PersonalityId = 13, CategoryId = 8 },  // کمپینگ
            new PersonalityCategory { Id = 80, PersonalityId = 13, CategoryId = 12 }, // لاکچری
            new PersonalityCategory { Id = 81, PersonalityId = 13, CategoryId = 14 }, // کاری
            new PersonalityCategory { Id = 82, PersonalityId = 13, CategoryId = 32 }, // هتل‌های بی‌نظیر
            new PersonalityCategory { Id = 83, PersonalityId = 13, CategoryId = 34 }, // کسب‌وکار

            // ENTJ - فرمانده (قاطع، برنامه‌ریز)
            new PersonalityCategory { Id = 84, PersonalityId = 14, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 85, PersonalityId = 14, CategoryId = 12 }, // لاکچری
            new PersonalityCategory { Id = 86, PersonalityId = 14, CategoryId = 13 }, // علمی
            new PersonalityCategory { Id = 87, PersonalityId = 14, CategoryId = 14 }, // کاری
            new PersonalityCategory { Id = 88, PersonalityId = 14, CategoryId = 31 }, // هلیکوپتری
            new PersonalityCategory { Id = 89, PersonalityId = 14, CategoryId = 34 }, // کسب‌وکار

            // ENTP - مبتکر (نو اندیش، چالش پذیر)
            new PersonalityCategory { Id = 90, PersonalityId = 15, CategoryId = 8 },  // کمپینگ
            new PersonalityCategory { Id = 91, PersonalityId = 15, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 92, PersonalityId = 15, CategoryId = 13 }, // علمی
            new PersonalityCategory { Id = 93, PersonalityId = 15, CategoryId = 29 }, // ارواح و اسرارآمیز
            new PersonalityCategory { Id = 94, PersonalityId = 15, CategoryId = 33 }, // زبان‌آموزی
            new PersonalityCategory { Id = 95, PersonalityId = 15, CategoryId = 35 }, // زیست‌شناس

            // ESTP - کارآفرین (پرانرژی، ریسک پذیر)
            new PersonalityCategory { Id = 96, PersonalityId = 16, CategoryId = 2 },  // ماجراجویی
            new PersonalityCategory { Id = 97, PersonalityId = 16, CategoryId = 7 },  // ورزشی
            new PersonalityCategory { Id = 98, PersonalityId = 16, CategoryId = 11 }, // کشتی و کروز
            new PersonalityCategory { Id = 99, PersonalityId = 16, CategoryId = 12 }, // لاکچری
            new PersonalityCategory { Id = 100, PersonalityId = 16, CategoryId = 24 }, // زمستانی
            new PersonalityCategory { Id = 101, PersonalityId = 16, CategoryId = 31 }  // هلیکوپتری
        );

        _ = modelBuilder.Entity<Destination>().HasData(
            new Destination { Id = 1, Title = "استون‌هنژ", DestinationTypeId = 30, Description = "سنگ‌های اسرارآمیز دوران نوسنگی که رازهای هزاران ساله را در خود پنهان کرده‌اند.", Image = "استون‌هنژ.jpg" },
            new Destination { Id = 2, Title = "آمازون", DestinationTypeId = 35, Description = "جنگل بارانی پهناور با تنوع زیستی خیره‌کننده و قبایل بومی اسرارآمیز.", Image = "آمازون.jpg" },
            new Destination { Id = 3, Title = "ایسلند", DestinationTypeId = 8, Description = "سرزمین یخ و آتش با چشمه‌های آبگرم، یخچال‌های طبیعی و شفق‌های قطبی.", Image = "ایسلند.jpg" },
            new Destination { Id = 4, Title = "بازارهای شناور", DestinationTypeId = 31, Description = "تجربه‌ای منحصر به فرد از خرید و زندگی بر روی آب در تایلند.", Image = "بازارهای شناور.jpg" },
            new Destination { Id = 5, Title = "بانکوک", DestinationTypeId = 13, Description = "شهری پرجنب و جوش با ترکیبی از مدرنیته و معابد باستانی.", Image = "بانکوک.jpg" },
            new Destination { Id = 6, Title = "برلین", DestinationTypeId = 13, Description = "پایتخت فرهنگی آلمان با تاریخ پر فراز و نشیب و معماری خیره‌کننده.", Image = "برلین.jpg" },
            new Destination { Id = 7, Title = "بورنئو", DestinationTypeId = 22, Description = "جزیره‌ای با جنگل‌های بارانی بکر و حیات وحش منحصر به فرد.", Image = "بورنئو.jpg" },
            new Destination { Id = 8, Title = "پاتاگونیا", DestinationTypeId = 5, Description = "سرزمین بکر با مناظر خیره‌کننده کوهستانی و یخچال‌های طبیعی.", Image = "پاتاگونیا.jpg" },
            new Destination { Id = 9, Title = "پاموکاله", DestinationTypeId = 24, Description = "تراس‌های سفید پنبهای از سنگ آهک با چشمه‌های آبگرم درمانی.", Image = "پاموکاله ترکیه.jpg" },
            new Destination { Id = 10, Title = "پترا", DestinationTypeId = 30, Description = "شهر گمشده نبطی‌ها که در دل صخره‌های سرخ تراشیده شده است.", Image = "پترا.jpg" },
            new Destination { Id = 11, Title = "پرپیات", DestinationTypeId = 33, Description = "شهر ارواح پس از فاجعه چرنوبیل، نمادی از طبیعت پیروز بر تمدن.", Image = "پرپیات در اوکراین.jpg" },
            new Destination { Id = 12, Title = "تالاب انزلی", DestinationTypeId = 19, Description = "تالابی زیبا با نیزارهای گسترده و پرندگان مهاجر بی‌نظیر.", Image = "تالاب انزلی.jpg" },
            new Destination { Id = 13, Title = "تهرانِ گرافیتی", DestinationTypeId = 15, Description = "نمایشگاه روباز هنر خیابانی در پایتخت ایران.", Image = "تهرانِ گرافیتی.jpg" },
            new Destination { Id = 14, Title = "توسکانی", DestinationTypeId = 7, Description = "منطقه‌ای رویایی با تپه‌های سرسبز، تاکستان‌ها و روستاهای قرون وسطایی.", Image = "توسکانی ایتالیا.jpg" },
            new Destination { Id = 15, Title = "توکیو", DestinationTypeId = 13, Description = "شهری آینده‌نگر با ترکیبی از فناوری پیشرفته و سنت‌های دیرینه.", Image = "توکیو.jpg" },
            new Destination { Id = 16, Title = "جزیره قشم", DestinationTypeId = 4, Description = "جزیره‌ای با جاذبه‌های طبیعی منحصر به فرد مانند دره ستاره‌ها و جنگل‌های حرا.", Image = "جزیره قشم.jpg" },
            new Destination { Id = 17, Title = "جزیره گانکنجو", DestinationTypeId = 39, Description = "جزیره‌ای رنگارنگ با مجسمه‌های عروسکی و مناظر سورئال.", Image = "جزیرهٔ گانکنجو در کره با مجسمه‌های عروسکی.jpg" },
            new Destination { Id = 18, Title = "جزیره گوریلاهای رواندا", DestinationTypeId = 22, Description = "پناهگاه گوریلاهای کوهی در خطر انقراض در قلب آفریقا.", Image = "جزیرهٔ گوریلاهای رواندا.jpg" },
            new Destination { Id = 19, Title = "جزیره هرمز", DestinationTypeId = 4, Description = "جزیره‌ای رنگین‌کمانی با خاک‌های معدنی خیره‌کننده در خلیج فارس.", Image = "جزیره هرمز.jpg" },
            new Destination { Id = 20, Title = "جزیره هنگام", DestinationTypeId = 4, Description = "جزیره‌ای آرام با سواحل بکر و دلفین‌های بازیگوش.", Image = "جزیره هنگام.jpg" },
            new Destination { Id = 21, Title = "جنگل مشعل", DestinationTypeId = 2, Description = "جنگلی اسرارآمیز با درختان پوشیده از خزه و نورهای فانوس‌مانند.", Image = "جنگل مشعل.jpg" },
            new Destination { Id = 22, Title = "چشمه‌های گِل‌آب سرعین", DestinationTypeId = 24, Description = "چشمه‌های گِل‌آب درمانی با خواص شفابخش برای پوست و بدن.", Image = "چشمه های گِل‌آب سرعین.jpg" },
            new Destination { Id = 23, Title = "چغازنبیل", DestinationTypeId = 30, Description = "زیگورات باستانی ایلامی‌ها، یادگاری از تمدن کهن بین‌النهرین.", Image = "چغازنبیل.jpg" },
            new Destination { Id = 24, Title = "درهٔ رنگین‌کمان", DestinationTypeId = 21, Description = "منطقه‌ای با لایه‌های خاکی رنگارنگ و مناظر سورئال.", Image = "درهٔ رنگین کمان در ایران.jpg" },
            new Destination { Id = 25, Title = "دریا", DestinationTypeId = 1, Description = "بی‌نهایت آبی که آرامش و هیجان را یکجا به انسان هدیه می‌دهد.", Image = "دریا.jpg" },
            new Destination { Id = 26, Title = "دریاچه الیمالات", DestinationTypeId = 12, Description = "دریاچه‌ای آرام با مناظر بکر و طبیعتی دست‌نخورده.", Image = "دریاچه الیمالات.jpg" },
            new Destination { Id = 27, Title = "دریاچه اویدر", DestinationTypeId = 12, Description = "دریاچه‌ای زیبا در دل کوهستان با آب زلال و طبیعتی بکر.", Image = "دریاچه اویدر.jpg" },
            new Destination { Id = 28, Title = "درینکویو", DestinationTypeId = 27, Description = "شهر زیرزمینی باستانی با معماری شگفت‌انگیز و تونل‌های پیچ در پیچ.", Image = "درینکویو در ترکیه.jpg" },
            new Destination { Id = 29, Title = "دشت‌های نمک ایران", DestinationTypeId = 20, Description = "چشماندازهای وسیع و خیره‌کننده از نمکزارهای درخشان.", Image = "دشت‌های نمک ایران.jpg" },
            new Destination { Id = 30, Title = "دوبی", DestinationTypeId = 13, Description = "شهری از آینده با آسمان‌خراش‌های بلند و جزایر مصنوعی خیره‌کننده.", Image = "دوبی.jpg" },
            new Destination { Id = 31, Title = "رشت", DestinationTypeId = 7, Description = "شهر باران‌های نقره‌ای با فرهنگ غنی و غذاهای لذیذ شمالی.", Image = "رشت.jpg" },
            new Destination { Id = 32, Title = "روستاهای رنگارنگ هند", DestinationTypeId = 39, Description = "روستاهایی شاد و رنگین که گویی از یک نقاشی کودکانه بیرون آمده‌اند.", Image = "روستاهای رنگ‌آمیزی‌شده در هند.jpg" },
            new Destination { Id = 33, Title = "روستای کیوتو", DestinationTypeId = 7, Description = "روستایی سنتی با خانه‌های چوبی و باغ‌های خزه‌ای صلح‌آمیز.", Image = "روستای کیوتو در ژاپن.jpg" },
            new Destination { Id = 34, Title = "ژانگیه", DestinationTypeId = 21, Description = "منطقه‌ای با صخره‌های رنگارنگ و مناظری که گویی از سیاره دیگری هستند.", Image = "ژانگیه در چین.jpg" },
            new Destination { Id = 35, Title = "ساحل مازندران", DestinationTypeId = 1, Description = "خط ساحلی دل‌انگیز دریای خزر با جنگل‌های سرسبز پشت سر.", Image = "ساحل دریا مازندران.jpg" },
            new Destination { Id = 36, Title = "سالار دو اویونی", DestinationTypeId = 20, Description = "بزرگترین دشت نمک جهان که آسمان را بر روی زمین منعکس می‌کند.", Image = "سالار دو اویونی در بولیوی.jpg" },
            new Destination { Id = 37, Title = "سنگاپور", DestinationTypeId = 13, Description = "شهری مدرن با ترکیبی از فرهنگ‌های مختلف و معماری آینده‌نگر.", Image = "سنگاپور.jpg" },
            new Destination { Id = 38, Title = "شفق قطبی نروژ", DestinationTypeId = 38, Description = "رقص نورهای سبز و بنفش در آسمان شب‌های قطبی.", Image = "شفق قطبی در نروژ.jpg" },
            new Destination { Id = 39, Title = "شهر زیرزمینی نوش آباد", DestinationTypeId = 27, Description = "شهر باستانی زیرزمینی با معماری هوشمندانه برای پناه گرفتن.", Image = "شهر زیرزمینی نوش آباد در ایران.jpg" },
            new Destination { Id = 40, Title = "صحرای نامیب", DestinationTypeId = 36, Description = "قدیمی‌ترین صحرای جهان با تپه‌های شنی سرخ و مناظر سورئال.", Image = "صحرای نامیب.jpg" },
            new Destination { Id = 41, Title = "فومن", DestinationTypeId = 16, Description = "منطقه‌ای سرسبز با جنگل‌های انبوه و تپه‌های دیدنی.", Image = "فومن گیلان.jpg" },
            new Destination { Id = 42, Title = "قلعه الموت", DestinationTypeId = 28, Description = "دژ افسانه‌ای حسن صباح و فرقه اسماعیلیه بر فراز کوه‌های البرز.", Image = "قلعه الموت.jpg" },
            new Destination { Id = 43, Title = "قلعه رودخان", DestinationTypeId = 28, Description = "قلعه‌ای تاریخی در دل جنگل‌های انبوه شمال ایران.", Image = "قلعه رودخان.jpg" },
            new Destination { Id = 44, Title = "کامینو د سانتیاگو", DestinationTypeId = 29, Description = "مسیر زیارتی تاریخی با مناظر طبیعی و تجربه‌های معنوی.", Image = "کامینو د سانتیاگو در اسپانیا.jpg" },
            new Destination { Id = 45, Title = "کویر", DestinationTypeId = 3, Description = "زیبایی خشن و سکوت بیکران شن‌های روان زیر آسمان پرستاره.", Image = "کویر.jpg" },
            new Destination { Id = 46, Title = "گرمسار", DestinationTypeId = 3, Description = "شهری در حاشیه کویر با آب و هوای گرم و جاذبه‌های بیابانی.", Image = "گرمسار.jpg" },
            new Destination { Id = 47, Title = "گرند کنیون", DestinationTypeId = 21, Description = "شگفتی طبیعت با دره‌های عمیق و لایه‌های سنگی رنگارنگ.", Image = "گرند کنیون.jpg" },
            new Destination { Id = 48, Title = "مخمل کوه", DestinationTypeId = 5, Description = "کوهستانی با چشماندازهای خیره‌کننده و طبیعتی بکر.", Image = "مخمل کوه.jpg" },
            new Destination { Id = 49, Title = "مرداب نیلوفر آبی", DestinationTypeId = 19, Description = "تالابی رویایی پوشیده از گل‌های نیلوفر آبی در نور طلوع آفتاب.", Image = "مرداب های پوشیده از گل نیلوفر آبی.jpg" },
            new Destination { Id = 50, Title = "مرداب هسل", DestinationTypeId = 19, Description = "تالابی اسرارآمیز با درختان خم شده و مه‌های صبحگاهی.", Image = "مرداب هسل چالوس.jpg" },
            new Destination { Id = 51, Title = "مزارع بوگور", DestinationTypeId = 40, Description = "مزارع سرسبز چای در ارتفاعات خنک اندونزی.", Image = "مزارع بوگور در اندونزی.jpg" },
            new Destination { Id = 52, Title = "مزارع چای دارجلینگ", DestinationTypeId = 40, Description = "چای معروف دارجلینگ در دامنه کوه‌های هیمالیا کشت می‌شود.", Image = "مزارع چای دارجلینگ.jpg" },
            new Destination { Id = 53, Title = "ملبورن", DestinationTypeId = 13, Description = "شهری پرجنب و جوش با ترکیبی از فرهنگ، هنر و طبیعت.", Image = "ملبورن.jpg" },
            new Destination { Id = 54, Title = "ناپا ولی", DestinationTypeId = 16, Description = "دره‌ای زیبا با تاکستان‌های گسترده و چشم‌اندازهای آرامش‌بخش.", Image = "ناپا ولی آمریکا.jpg" },
            new Destination { Id = 55, Title = "نمک ابرود", DestinationTypeId = 20, Description = "دشت نمکی وسیع با بلورهای درخشان نمک زیر آفتاب.", Image = "نمک ابرود.jpg" },
            new Destination { Id = 56, Title = "نورهای درخشان مالدیو", DestinationTypeId = 38, Description = "پدیده‌ای خیره‌کننده از نورهای آبی فیتوپلانکتون‌ها در ساحل.", Image = "نورهای درخشان مالدیو.jpg" },
            new Destination { Id = 57, Title = "هاوایی", DestinationTypeId = 4, Description = "جزایر آتشفشانی با سواحل بکر، آبشارها و فرهنگ پولی‌نزیایی.", Image = "هاوایی.jpg" },
            new Destination { Id = 58, Title = "هرم‌های بوسنی", DestinationTypeId = 30, Description = "سازه‌های مرموز هرمی‌شکل که بحث‌های بسیاری را برانگیخته‌اند.", Image = "هرم‌های بوسنی.jpg" },
            new Destination { Id = 59, Title = "ونیز", DestinationTypeId = 31, Description = "شهر رمانتیک کانال‌ها و گوندولاها که گویی بر آب شناور است.", Image = "ونیز.jpg" },
            new Destination { Id = 60, Title = "یوسمیتی", DestinationTypeId = 34, Description = "پارک ملی با صخره‌های گرانیتی غول‌پیکر و آبشارهای خیره‌کننده.", Image = "یوسمیتی.jpg" }
        );

        _ = modelBuilder.Entity<DestinationCategory>().HasData(
            new DestinationCategory { Id = 1, DestinationId = 1, CategoryId = 5 }, // استون‌هنژ - تاریخی
            new DestinationCategory { Id = 2, DestinationId = 1, CategoryId = 29 }, // استون‌هنژ - ارواح و مکان‌های اسرارآمیز
            new DestinationCategory { Id = 3, DestinationId = 2, CategoryId = 1 }, // آمازون - طبیعت‌گردی
            new DestinationCategory { Id = 4, DestinationId = 2, CategoryId = 2 }, // آمازون - ماجراجویی
            new DestinationCategory { Id = 5, DestinationId = 3, CategoryId = 1 }, // ایسلند - طبیعت‌گردی
            new DestinationCategory { Id = 6, DestinationId = 3, CategoryId = 24 }, // ایسلند - زمستانی
            new DestinationCategory { Id = 7, DestinationId = 4, CategoryId = 3 }, // بازارهای شناور - تفریحی
            new DestinationCategory { Id = 8, DestinationId = 4, CategoryId = 19 }, // بازارهای شناور - صنایع دستی
            new DestinationCategory { Id = 9, DestinationId = 5, CategoryId = 4 }, // بانکوک - فرهنگی
            new DestinationCategory { Id = 10, DestinationId = 5, CategoryId = 12 }, // بانکوک - لاکچری
            new DestinationCategory { Id = 11, DestinationId = 6, CategoryId = 5 }, // برلین - تاریخی
            new DestinationCategory { Id = 12, DestinationId = 6, CategoryId = 4 }, // برلین - فرهنگی
            new DestinationCategory { Id = 13, DestinationId = 7, CategoryId = 1 }, // بورنئو - طبیعت‌گردی
            new DestinationCategory { Id = 14, DestinationId = 7, CategoryId = 35 }, // بورنئو - زیست‌شناسی
            new DestinationCategory { Id = 15, DestinationId = 8, CategoryId = 2 }, // پاتاگونیا - ماجراجویی
            new DestinationCategory { Id = 16, DestinationId = 8, CategoryId = 34 }, // پاتاگونیا - کوهنوردی
            new DestinationCategory { Id = 17, DestinationId = 9, CategoryId = 18 }, // پاموکاله - سلامت
            new DestinationCategory { Id = 18, DestinationId = 9, CategoryId = 10 }, // پاموکاله - عکاسی
            new DestinationCategory { Id = 19, DestinationId = 10, CategoryId = 5 }, // پترا - تاریخی
            new DestinationCategory { Id = 20, DestinationId = 10, CategoryId = 10 }, // پترا - عکاسی
            new DestinationCategory { Id = 21, DestinationId = 11, CategoryId = 29 }, // پرپیات - ارواح
            new DestinationCategory { Id = 22, DestinationId = 11, CategoryId = 13 }, // پرپیات - علمی
            new DestinationCategory { Id = 23, DestinationId = 12, CategoryId = 1 }, // تالاب انزلی - طبیعت
            new DestinationCategory { Id = 24, DestinationId = 12, CategoryId = 22 }, // تالاب انزلی - گل‌دهی
            new DestinationCategory { Id = 25, DestinationId = 13, CategoryId = 4 }, // تهران گرافیتی - هنری
            new DestinationCategory { Id = 26, DestinationId = 13, CategoryId = 10 }, // تهران گرافیتی - عکاسی
            new DestinationCategory { Id = 27, DestinationId = 14, CategoryId = 3 }, // توسکانی - تفریحی
            new DestinationCategory { Id = 28, DestinationId = 14, CategoryId = 9 }, // توسکانی - غذایی
            new DestinationCategory { Id = 29, DestinationId = 15, CategoryId = 13 }, // توکیو - مدرن
            new DestinationCategory { Id = 30, DestinationId = 15, CategoryId = 25 }, // توکیو - جوانان
            new DestinationCategory { Id = 31, DestinationId = 16, CategoryId = 1 }, // قشم - طبیعت
            new DestinationCategory { Id = 32, DestinationId = 16, CategoryId = 8 }, // قشم - کمپینگ
            new DestinationCategory { Id = 33, DestinationId = 17, CategoryId = 4 }, // گانکنجو - هنری
            new DestinationCategory { Id = 34, DestinationId = 17, CategoryId = 10 }, // گانکنجو - عکاسی
            new DestinationCategory { Id = 35, DestinationId = 18, CategoryId = 35 }, // گوریلاهای رواندا - زیست‌شناسی
            new DestinationCategory { Id = 36, DestinationId = 18, CategoryId = 36 }, // گوریلاهای رواندا - اکوتوریسم
            new DestinationCategory { Id = 37, DestinationId = 19, CategoryId = 10 }, // هرمز - عکاسی
            new DestinationCategory { Id = 38, DestinationId = 19, CategoryId = 16 }, // هرمز - بوم‌گردی
            new DestinationCategory { Id = 39, DestinationId = 20, CategoryId = 15 }, // هنگام - خانوادگی
            new DestinationCategory { Id = 40, DestinationId = 20, CategoryId = 30 }, // هنگام - نجومی
            new DestinationCategory { Id = 41, DestinationId = 21, CategoryId = 1 }, // جنگل مشعل - طبیعت
            new DestinationCategory { Id = 42, DestinationId = 21, CategoryId = 29 }, // جنگل مشعل - اسرارآمیز
            new DestinationCategory { Id = 43, DestinationId = 22, CategoryId = 18 }, // سرعین - سلامت
            new DestinationCategory { Id = 44, DestinationId = 22, CategoryId = 3 }, // سرعین - تفریحی
            new DestinationCategory { Id = 45, DestinationId = 23, CategoryId = 5 }, // چغازنبیل - تاریخی
            new DestinationCategory { Id = 46, DestinationId = 23, CategoryId = 13 }, // چغازنبیل - علمی
            new DestinationCategory { Id = 47, DestinationId = 24, CategoryId = 1 }, // دره رنگین‌کمان - طبیعت
            new DestinationCategory { Id = 48, DestinationId = 24, CategoryId = 10 }, // دره رنگین‌کمان - عکاسی
            new DestinationCategory { Id = 49, DestinationId = 25, CategoryId = 3 }, // دریا - تفریحی
            new DestinationCategory { Id = 50, DestinationId = 25, CategoryId = 28 }, // دریا - ریلکسیشن
            new DestinationCategory { Id = 51, DestinationId = 26, CategoryId = 1 }, // الیمالات - طبیعت
            new DestinationCategory { Id = 52, DestinationId = 26, CategoryId = 15 }, // الیمالات - خانوادگی
            new DestinationCategory { Id = 53, DestinationId = 27, CategoryId = 1 }, // اویدر - طبیعت
            new DestinationCategory { Id = 54, DestinationId = 27, CategoryId = 30 }, // اویدر - نجومی
            new DestinationCategory { Id = 55, DestinationId = 28, CategoryId = 5 }, // درینکویو - تاریخی
            new DestinationCategory { Id = 56, DestinationId = 28, CategoryId = 27 }, // درینکویو - معماری
            new DestinationCategory { Id = 57, DestinationId = 29, CategoryId = 1 }, // دشت نمک - طبیعت
            new DestinationCategory { Id = 58, DestinationId = 29, CategoryId = 10 }, // دشت نمک - عکاسی
            new DestinationCategory { Id = 59, DestinationId = 30, CategoryId = 12 }, // دوبی - لاکچری
            new DestinationCategory { Id = 60, DestinationId = 30, CategoryId = 32 }, // دوبی - هتل‌های بی‌نظیر
            new DestinationCategory { Id = 61, DestinationId = 31, CategoryId = 9 }, // رشت - غذایی
            new DestinationCategory { Id = 62, DestinationId = 31, CategoryId = 16 }, // رشت - بوم‌گردی
            new DestinationCategory { Id = 63, DestinationId = 32, CategoryId = 4 }, // روستاهای هند - هنری
            new DestinationCategory { Id = 64, DestinationId = 32, CategoryId = 21 }, // روستاهای هند - جوامع محلی
            new DestinationCategory { Id = 65, DestinationId = 33, CategoryId = 7 }, // کیوتو - فرهنگی
            new DestinationCategory { Id = 66, DestinationId = 33, CategoryId = 28 }, // کیوتو - مدیتیشن
            new DestinationCategory { Id = 67, DestinationId = 34, CategoryId = 1 }, // ژانگیه - طبیعت
            new DestinationCategory { Id = 68, DestinationId = 34, CategoryId = 2 }, // ژانگیه - ماجراجویی
            new DestinationCategory { Id = 69, DestinationId = 35, CategoryId = 3 }, // مازندران - تفریحی
            new DestinationCategory { Id = 70, DestinationId = 35, CategoryId = 15 }, // مازندران - خانوادگی
            new DestinationCategory { Id = 71, DestinationId = 36, CategoryId = 1 }, // سالار دو اویونی - طبیعت
            new DestinationCategory { Id = 72, DestinationId = 36, CategoryId = 10 }, // سالار دو اویونی - عکاسی
            new DestinationCategory { Id = 73, DestinationId = 37, CategoryId = 12 }, // سنگاپور - لاکچری
            new DestinationCategory { Id = 74, DestinationId = 37, CategoryId = 13 }, // سنگاپور - مدرن
            new DestinationCategory { Id = 75, DestinationId = 38, CategoryId = 1 }, // شفق قطبی - طبیعت
            new DestinationCategory { Id = 76, DestinationId = 38, CategoryId = 30 }, // شفق قطبی - نجومی
            new DestinationCategory { Id = 77, DestinationId = 39, CategoryId = 5 }, // نوش آباد - تاریخی
            new DestinationCategory { Id = 78, DestinationId = 39, CategoryId = 29 }, // نوش آباد - اسرارآمیز
            new DestinationCategory { Id = 79, DestinationId = 40, CategoryId = 1 }, // نامیب - طبیعت
            new DestinationCategory { Id = 80, DestinationId = 40, CategoryId = 2 }, // نامیب - ماجراجویی
            new DestinationCategory { Id = 81, DestinationId = 41, CategoryId = 1 }, // فومن - طبیعت
            new DestinationCategory { Id = 82, DestinationId = 41, CategoryId = 16 }, // فومن - بوم‌گردی
            new DestinationCategory { Id = 83, DestinationId = 42, CategoryId = 5 }, // الموت - تاریخی
            new DestinationCategory { Id = 84, DestinationId = 42, CategoryId = 2 }, // الموت - ماجراجویی
            new DestinationCategory { Id = 85, DestinationId = 43, CategoryId = 5 }, // رودخان - تاریخی
            new DestinationCategory { Id = 86, DestinationId = 43, CategoryId = 7 }, // رودخان - ورزشی
            new DestinationCategory { Id = 87, DestinationId = 44, CategoryId = 6 }, // کامینو - زیارتی
            new DestinationCategory { Id = 88, DestinationId = 44, CategoryId = 28 }, // کامینو - مدیتیشن
            new DestinationCategory { Id = 89, DestinationId = 45, CategoryId = 1 }, // کویر - طبیعت
            new DestinationCategory { Id = 90, DestinationId = 45, CategoryId = 30 }, // کویر - نجومی
            new DestinationCategory { Id = 91, DestinationId = 46, CategoryId = 1 }, // گرمسار - طبیعت
            new DestinationCategory { Id = 92, DestinationId = 46, CategoryId = 8 }, // گرمسار - کمپینگ
            new DestinationCategory { Id = 93, DestinationId = 47, CategoryId = 1 }, // گرند کنیون - طبیعت
            new DestinationCategory { Id = 94, DestinationId = 47, CategoryId = 31 }, // گرند کنیون - هلیکوپتری
            new DestinationCategory { Id = 95, DestinationId = 48, CategoryId = 1 }, // مخمل کوه - طبیعت
            new DestinationCategory { Id = 96, DestinationId = 48, CategoryId = 7 }, // مخمل کوه - ورزشی
            new DestinationCategory { Id = 97, DestinationId = 49, CategoryId = 1 }, // نیلوفر آبی - طبیعت
            new DestinationCategory { Id = 98, DestinationId = 49, CategoryId = 22 }, // نیلوفر آبی - گل‌دهی
            new DestinationCategory { Id = 99, DestinationId = 50, CategoryId = 1 }, // هسل - طبیعت
            new DestinationCategory { Id = 100, DestinationId = 50, CategoryId = 29 }, // هسل - اسرارآمیز
            new DestinationCategory { Id = 101, DestinationId = 51, CategoryId = 38 }, // بوگور - مزارع چای
            new DestinationCategory { Id = 102, DestinationId = 51, CategoryId = 9 }, // بوگور - غذایی
            new DestinationCategory { Id = 103, DestinationId = 52, CategoryId = 38 }, // دارجلینگ - مزارع چای
            new DestinationCategory { Id = 104, DestinationId = 52, CategoryId = 16 }, // دارجلینگ - بوم‌گردی
            new DestinationCategory { Id = 105, DestinationId = 53, CategoryId = 4 }, // ملبورن - فرهنگی
            new DestinationCategory { Id = 106, DestinationId = 53, CategoryId = 13 }, // ملبورن - مدرن
            new DestinationCategory { Id = 107, DestinationId = 54, CategoryId = 9 }, // ناپا ولی - غذایی
            new DestinationCategory { Id = 108, DestinationId = 54, CategoryId = 3 }, // ناپا ولی - تفریحی
            new DestinationCategory { Id = 109, DestinationId = 55, CategoryId = 1 }, // نمک ابرود - طبیعت
            new DestinationCategory { Id = 110, DestinationId = 55, CategoryId = 10 }, // نمک ابرود - عکاسی
            new DestinationCategory { Id = 111, DestinationId = 56, CategoryId = 1 }, // مالدیو - طبیعت
            new DestinationCategory { Id = 112, DestinationId = 56, CategoryId = 12 }, // مالدیو - لاکچری
            new DestinationCategory { Id = 113, DestinationId = 57, CategoryId = 1 }, // هاوایی - طبیعت
            new DestinationCategory { Id = 114, DestinationId = 57, CategoryId = 11 }, // هاوایی - کروز
            new DestinationCategory { Id = 115, DestinationId = 58, CategoryId = 5 }, // بوسنی - تاریخی
            new DestinationCategory { Id = 116, DestinationId = 58, CategoryId = 29 }, // بوسنی - اسرارآمیز
            new DestinationCategory { Id = 117, DestinationId = 59, CategoryId = 4 }, // ونیز - فرهنگی
            new DestinationCategory { Id = 118, DestinationId = 59, CategoryId = 11 }, // ونیز - کروز
            new DestinationCategory { Id = 119, DestinationId = 60, CategoryId = 1 }, // یوسمیتی - طبیعت
            new DestinationCategory { Id = 120, DestinationId = 60, CategoryId = 2 }  // یوسمیتی - ماجراجویی
        );

        _ = modelBuilder.Entity<Tour>().HasData(
            // 1. استون‌هنژ
            new Tour
            {
                Id = 1,
                Title = "کشف اسرار استون‌هنژ",
                Description = "تور ویژه شب‌های مهتابی برای تجربه انرژی‌های مرموز این سنگ‌های باستانی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2024, 7, 10),
                EndTime = new DateTime(2024, 7, 11),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 30,
                Price = 1200000,
                Image = "استون‌هنژ2.jpg",
                TourTypeId = 8,
                DestinationId = 1
            },

            // 2. آمازون
            new Tour
            {
                Id = 2,
                Title = "ماجراجویی در قلب آمازون",
                Description = "اکوتور 7 روزه با اقامت در لاج‌های جنگلی و بازدید از قبایل بومی",
                DaysCount = 7,
                SleepNightsCount = 6,
                StartTime = new DateTime(2024, 8, 5),
                EndTime = new DateTime(2024, 8, 11),
                MinimumAge = 21,
                MaximumAge = 50,
                MaximumPassenger = 15,
                Price = 3800000,
                Image = "آمازون2.jpg",
                TourTypeId = 2,
                DestinationId = 2
            },

            // 3. ایسلند
            new Tour
            {
                Id = 3,
                Title = "سفر به سرزمین یخ و آتش",
                Description = "تور ویژه تماشای شفق قطبی و چشمه‌های آبگرم طبیعی",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2024, 9, 15),
                EndTime = new DateTime(2024, 9, 19),
                MinimumAge = 20,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 4200000,
                Image = "ایسلند2.jpg",
                TourTypeId = 31,
                DestinationId = 3
            },

            // 4. بازارهای شناور
            new Tour
            {
                Id = 4,
                Title = "تجربه خرید در بازارهای آبی",
                Description = "تور یک روزه قایق‌سواری و خرید از بازارهای شناور بانکوک",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2024, 10, 5),
                EndTime = new DateTime(2024, 10, 5),
                MinimumAge = 15,
                MaximumAge = 60,
                MaximumPassenger = 40,
                Price = 650000,
                Image = "بازارهای شناور2.jpg",
                TourTypeId = 6,
                DestinationId = 4
            },

            // 5. بانکوک
            new Tour
            {
                Id = 5,
                Title = "کشف معابد بانکوک",
                Description = "تور 3 روزه فرهنگی با بازدید از معابد بودایی و کاخ پادشاهی",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2024, 11, 10),
                EndTime = new DateTime(2024, 11, 12),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 35,
                Price = 1800000,
                Image = "بانکوک2.jpg",
                TourTypeId = 11,
                DestinationId = 5
            },

            // 6. برلین
            new Tour
            {
                Id = 6,
                Title = "برلین تاریخی",
                Description = "گردش در دیوار برلین و موزه‌های جنگ جهانی دوم",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2024, 12, 1),
                EndTime = new DateTime(2024, 12, 4),
                MinimumAge = 20,
                MaximumAge = 55,
                MaximumPassenger = 30,
                Price = 2500000,
                Image = "برلین2.jpg",
                TourTypeId = 10,
                DestinationId = 6
            },

            // 7. بورنئو
            new Tour
            {
                Id = 7,
                Title = "سفری به دنیای اورانگوتان‌ها",
                Description = "تور 5 روزه حیات وحش در جنگل‌های بارانی بورنئو",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2025, 1, 10),
                EndTime = new DateTime(2025, 1, 14),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 3200000,
                Image = "بورنئو2.jpg",
                TourTypeId = 23,
                DestinationId = 7
            },

            // 8. پاتاگونیا
            new Tour
            {
                Id = 8,
                Title = "کوهنوردی در پاتاگونیا",
                Description = "تور 8 روزه ماجراجویی برای علاقه‌مندان به کوهنوردی حرفه‌ای",
                DaysCount = 8,
                SleepNightsCount = 7,
                StartTime = new DateTime(2025, 2, 15),
                EndTime = new DateTime(2025, 2, 22),
                MinimumAge = 25,
                MaximumAge = 50,
                MaximumPassenger = 15,
                Price = 4500000,
                Image = "پاتاگونیا2.jpg",
                TourTypeId = 4,
                DestinationId = 8
            },

            // 9. پاموکاله
            new Tour
            {
                Id = 9,
                Title = "آرامش در تراس‌های سفید",
                Description = "تور 3 روزه سلامت با حمام آبگرم و ماساژ درمانی",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2025, 3, 5),
                EndTime = new DateTime(2025, 3, 7),
                MinimumAge = 20,
                MaximumAge = 60,
                MaximumPassenger = 25,
                Price = 1500000,
                Image = "پاموکاله ترکیه2.jpg",
                TourTypeId = 19,
                DestinationId = 9
            },

            // 10. پترا
            new Tour
            {
                Id = 10,
                Title = "شهر گمشده پترا",
                Description = "اکتشاف 4 روزه در شهر تاریخی نبطی‌ها با راهنمایان محلی",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2025, 4, 10),
                EndTime = new DateTime(2025, 4, 13),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 2200000,
                Image = "پترا2.jpg",
                TourTypeId = 10,
                DestinationId = 10
            },

            // 11. پرپیات
            new Tour
            {
                Id = 11,
                Title = "شهر ارواح چرنوبیل",
                Description = "تور ویژه بازدید از منطقه محرومه با تجهیزات ایمنی کامل",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2025, 5, 15),
                EndTime = new DateTime(2025, 5, 16),
                MinimumAge = 21,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 1800000,
                Image = "پرپیات در اوکراین2.jpg",
                TourTypeId = 8,
                DestinationId = 11
            },

            // 12. تالاب انزلی
            new Tour
            {
                Id = 12,
                Title = "قایق‌سواری در تالاب",
                Description = "تور یک روزه طبیعت‌گردی با تماشای پرندگان مهاجر",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 6, 1),
                EndTime = new DateTime(2025, 6, 1),
                MinimumAge = 10,
                MaximumAge = 60,
                MaximumPassenger = 40,
                Price = 500000,
                Image = "تالاب انزلی2.jpg",
                TourTypeId = 22,
                DestinationId = 12
            },

            // 13. تهران گرافیتی
            new Tour
            {
                Id = 13,
                Title = "تور خیابان‌های هنری",
                Description = "گردش شهری برای کشف بهترین نقاشی‌های دیواری تهران",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 7, 10),
                EndTime = new DateTime(2025, 7, 10),
                MinimumAge = 15,
                MaximumAge = 40,
                MaximumPassenger = 25,
                Price = 300000,
                Image = "تهرانِ گرافیتی2.jpg",
                TourTypeId = 25,
                DestinationId = 13
            },

            // 14. توسکانی
            new Tour
            {
                Id = 14,
                Title = "تور شراب توسکانی",
                Description = "گشت 4 روزه در تاکستان‌های معروف با چشیدن بهترین شراب‌های ایتالیا",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2025, 8, 5),
                EndTime = new DateTime(2025, 8, 8),
                MinimumAge = 21,
                MaximumAge = 50,
                MaximumPassenger = 20,
                Price = 2800000,
                Image = "توسکانی ایتالیا2.jpg",
                TourTypeId = 24,
                DestinationId = 14
            },

            // 15. توکیو
            new Tour
            {
                Id = 15,
                Title = "تجربه آینده در توکیو",
                Description = "تور فناوری و فرهنگ ژاپن با بازدید از مراکز مدرن و معابد سنتی",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2025, 9, 1),
                EndTime = new DateTime(2025, 9, 5),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 30,
                Price = 3500000,
                Image = "توکیو2.jpg",
                TourTypeId = 13,
                DestinationId = 15
            },

            // 16. جزیره قشم
            new Tour
            {
                Id = 16,
                Title = "اکوتور قشم",
                Description = "کشف جاذبه‌های طبیعی جزیره از دره ستاره‌ها تا جنگل‌های حرا",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2025, 10, 10),
                EndTime = new DateTime(2025, 10, 11),
                MinimumAge = 12,
                MaximumAge = 50,
                MaximumPassenger = 35,
                Price = 850000,
                Image = "جزیره قشم2.jpg",
                TourTypeId = 3,
                DestinationId = 16
            },

            // 17. جزیره گانکنجو
            new Tour
            {
                Id = 17,
                Title = "دنیای عروسکی",
                Description = "تور عکاسی در جزیره رنگارنگ با مجسمه‌های غول‌پیکر",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2025, 11, 5),
                EndTime = new DateTime(2025, 11, 7),
                MinimumAge = 15,
                MaximumAge = 40,
                MaximumPassenger = 25,
                Price = 1200000,
                Image = "جزیرهٔ گانکنجو در کره با مجسمه‌های عروسکی2.jpg",
                TourTypeId = 21,
                DestinationId = 17
            },

            // 18. جزیره گوریلاها
            new Tour
            {
                Id = 18,
                Title = "ماجراجویی با گوریلاها",
                Description = "تور ویژه تماشای گوریلاهای کوهی در زیستگاه طبیعی",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2026, 1, 10),
                EndTime = new DateTime(2026, 1, 13),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 15,
                Price = 3800000,
                Image = "جزیرهٔ گوریلاهای رواندا2.jpg",
                TourTypeId = 35,
                DestinationId = 18
            },

            // 19. جزیره هرمز
            new Tour
            {
                Id = 19,
                Title = "جزیره رنگین‌کمان",
                Description = "تور 2 روزه عکاسی از خاک‌های رنگی و طبیعت بی‌نظیر",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2026, 2, 15),
                EndTime = new DateTime(2026, 2, 16),
                MinimumAge = 15,
                MaximumAge = 45,
                MaximumPassenger = 30,
                Price = 900000,
                Image = "جزیره هرمز2.jpg",
                TourTypeId = 21,
                DestinationId = 19
            },

            // 20. جزیره هنگام
            new Tour
            {
                Id = 20,
                Title = "آرامش در هنگام",
                Description = "تور خانوادگی با قایق‌سواری و تماشای دلفین‌ها",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2026, 3, 1),
                EndTime = new DateTime(2026, 3, 2),
                MinimumAge = 5,
                MaximumAge = 60,
                MaximumPassenger = 40,
                Price = 750000,
                Image = "جزیره هنگام2.jpg",
                TourTypeId = 16,
                DestinationId = 20
            },

            // 21. جنگل مشعل
            new Tour
            {
                Id = 21,
                Title = "پیاده‌روی شبانه در جنگل اسرارآمیز",
                Description = "تور ویژه شب‌گردی با نور فانوس‌ها در جنگل مه‌آلود",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 4, 10),
                EndTime = new DateTime(2026, 4, 10),
                MinimumAge = 18,
                MaximumAge = 40,
                MaximumPassenger = 20,
                Price = 400000,
                Image = "جنگل مشعل2.jpg",
                TourTypeId = 29,
                DestinationId = 21
            },

            // 22. چشمه‌های گِل‌آب سرعین
            new Tour
            {
                Id = 22,
                Title = "آبگرم درمانی سرعین",
                Description = "تور 2 روزه سلامت با حمام گل و ماساژ سنتی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2026, 5, 5),
                EndTime = new DateTime(2026, 5, 6),
                MinimumAge = 20,
                MaximumAge = 60,
                MaximumPassenger = 25,
                Price = 800000,
                Image = "چشمه های گِل‌آب سرعین2.jpg",
                TourTypeId = 19,
                DestinationId = 22
            },

            // 23. چغازنبیل
            new Tour
            {
                Id = 23,
                Title = "تماشای اولین اثر ثبت شده ایران",
                Description = "بازدید علمی از زیگورات چغازنبیل با راهنمایان متخصص",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 6, 1),
                EndTime = new DateTime(2026, 6, 1),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 35,
                Price = 450000,
                Image = "چغازنبیل2.jpg",
                TourTypeId = 20,
                DestinationId = 23
            },

            // 24. دره رنگین‌کمان
            new Tour
            {
                Id = 24,
                Title = "رنگین‌کمان زمینی",
                Description = "تور عکاسی از لایه‌های رنگارنگ زمین در ساعات طلایی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2026, 7, 10),
                EndTime = new DateTime(2026, 7, 11),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 950000,
                Image = "درهٔ رنگین کمان در ایران2.jpg",
                TourTypeId = 21,
                DestinationId = 24
            },

            // 25. دریا
            new Tour
            {
                Id = 25,
                Title = "کروز تفریحی",
                Description = "تور یک روزه قایق‌سواری و تفریحات آبی",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 8, 5),
                EndTime = new DateTime(2026, 8, 5),
                MinimumAge = 10,
                MaximumAge = 60,
                MaximumPassenger = 50,
                Price = 600000,
                Image = "دریا2.jpg",
                TourTypeId = 22,
                DestinationId = 25
            },

            // 26. دریاچه الیمالات
            new Tour
            {
                Id = 26,
                Title = "پیک‌نیک خانوادگی",
                Description = "تور یک روزه استراحت در کنار دریاچه با امکانات تفریحی",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 9, 1),
                EndTime = new DateTime(2026, 9, 1),
                MinimumAge = 5,
                MaximumAge = 70,
                MaximumPassenger = 40,
                Price = 350000,
                Image = "دریاچه الیمالات2.jpg",
                TourTypeId = 16,
                DestinationId = 26
            },

            // 27. دریاچه اویدر
            new Tour
            {
                Id = 27,
                Title = "تماشای ستارگان",
                Description = "تور نجومی شبانه با تلسکوپ‌های حرفه‌ای",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 10, 10),
                EndTime = new DateTime(2026, 10, 10),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 500000,
                Image = "دریاچه اویدر2.jpg",
                TourTypeId = 27,
                DestinationId = 27
            },

            // 28. درینکویو
            new Tour
            {
                Id = 28,
                Title = "شهر زیرزمینی",
                Description = "اکتشاف در عمق 85 متری زمین در شهر باستانی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2026, 11, 5),
                EndTime = new DateTime(2026, 11, 6),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 1100000,
                Image = "درینکویو در ترکیه2.jpg",
                TourTypeId = 27,
                DestinationId = 28
            },

            // 29. دشت‌های نمک
            new Tour
            {
                Id = 29,
                Title = "سفید تا بینهایت",
                Description = "تور عکاسی از دشت‌های نمکی در نور صبحگاهی",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2027, 1, 10),
                EndTime = new DateTime(2027, 1, 10),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 400000,
                Image = "دشت‌های نمک ایران2.jpg",
                TourTypeId = 21,
                DestinationId = 29
            },

            // 30. دوبی
            new Tour
            {
                Id = 30,
                Title = "تجربه لوکس دوبی",
                Description = "تور 5 ستاره با اقامت در هتل‌های لوکس و تفریحات VIP",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2027, 2, 15),
                EndTime = new DateTime(2027, 2, 19),
                MinimumAge = 25,
                MaximumAge = 60,
                MaximumPassenger = 20,
                Price = 5000000,
                Image = "دوبی2.jpg",
                TourTypeId = 13,
                DestinationId = 30
            },

            // 31. رشت
            new Tour
            {
                Id = 31,
                Title = "تور غذایی رشت",
                Description = "چشیدن بهترین غذاهای محلی گیلان با راهنمایان محلی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2027, 3, 1),
                EndTime = new DateTime(2027, 3, 2),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 25,
                Price = 850000,
                Image = "رشت2.jpg",
                TourTypeId = 24,
                DestinationId = 31
            },

            // 32. روستاهای رنگارنگ هند
            new Tour
            {
                Id = 32,
                Title = "رنگ‌های شاد هند",
                Description = "گشت 3 روزه در روستاهای رنگارنگ با اقامت در خانه‌های محلی",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2027, 4, 10),
                EndTime = new DateTime(2027, 4, 12),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 1200000,
                Image = "روستاهای رنگ‌آمیزی‌شده در هند2.jpg",
                TourTypeId = 30,
                DestinationId = 32
            },

            // 33. روستای کیوتو
            new Tour
            {
                Id = 33,
                Title = "ذن در کیوتو",
                Description = "تور مدیتیشن و آرامش در معابد بودایی",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2027, 5, 5),
                EndTime = new DateTime(2027, 5, 8),
                MinimumAge = 20,
                MaximumAge = 50,
                MaximumPassenger = 15,
                Price = 2800000,
                Image = "روستای کیوتو در ژاپن2.jpg",
                TourTypeId = 36,
                DestinationId = 33
            },

            // 34. ژانگیه
            new Tour
            {
                Id = 34,
                Title = "مناظر فرازمینی",
                Description = "تور 3 روزه ماجراجویی در میان صخره‌های رنگارنگ",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2027, 6, 1),
                EndTime = new DateTime(2027, 6, 3),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 1500000,
                Image = "ژانگیه در چین2.jpg",
                TourTypeId = 9,
                DestinationId = 34
            },

            // 35. ساحل مازندران
            new Tour
            {
                Id = 35,
                Title = "خاطرات شمالی",
                Description = "تور 3 روزه خانوادگی با تفریحات ساحلی و جنگلی",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2027, 7, 10),
                EndTime = new DateTime(2027, 7, 12),
                MinimumAge = 5,
                MaximumAge = 60,
                MaximumPassenger = 40,
                Price = 900000,
                Image = "ساحل دریا مازندران2.jpg",
                TourTypeId = 16,
                DestinationId = 35
            },

            // 36. سالار دو اویونی
            new Tour
            {
                Id = 36,
                Title = "آینه آسمان",
                Description = "تور عکاسی از بزرگترین دشت نمک جهان",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2027, 8, 5),
                EndTime = new DateTime(2027, 8, 7),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 1800000,
                Image = "سالار دو اویونی در بولیوی2.jpg",
                TourTypeId = 21,
                DestinationId = 36
            },

            // 37. سنگاپور
            new Tour
            {
                Id = 37,
                Title = "شهری از آینده",
                Description = "تور 4 روزه در مدرن‌ترین شهر جهان",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2027, 9, 1),
                EndTime = new DateTime(2027, 9, 4),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 3200000,
                Image = "سنگاپور2.jpg",
                TourTypeId = 13,
                DestinationId = 37
            },

            // 38. شفق قطبی
            new Tour
            {
                Id = 38,
                Title = "رقص نورهای شمالی",
                Description = "تور 5 روزه تماشای شفق قطبی در نروژ",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2027, 10, 10),
                EndTime = new DateTime(2027, 10, 14),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 4500000,
                Image = "شفق قطبی در نروژ2.jpg",
                TourTypeId = 27,
                DestinationId = 38
            },

            // 39. شهر زیرزمینی نوش آباد
            new Tour
            {
                Id = 39,
                Title = "رازهای زیرزمین",
                Description = "اکتشاف در شهر باستانی زیرزمینی",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2027, 11, 5),
                EndTime = new DateTime(2027, 11, 5),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 350000,
                Image = "شهر زیرزمینی نوش آباد در ایران2.jpg",
                TourTypeId = 8,
                DestinationId = 39
            },

            // 40. صحرای نامیب
            new Tour
            {
                Id = 40,
                Title = "سفری به قدیمی‌ترین صحرا",
                Description = "تور 4 روزه ماجراجویی در تپه‌های شنی سرخ",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2028, 1, 10),
                EndTime = new DateTime(2028, 1, 13),
                MinimumAge = 21,
                MaximumAge = 45,
                MaximumPassenger = 15,
                Price = 2800000,
                Image = "صحرای نامیب2.jpg",
                TourTypeId = 9,
                DestinationId = 40
            },

            // 41. فومن
            new Tour
            {
                Id = 41,
                Title = "جنگل‌های اسرارآمیز",
                Description = "تور 2 روزه پیاده‌روی در جنگل‌های انبوه شمال",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 2, 15),
                EndTime = new DateTime(2028, 2, 16),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 25,
                Price = 750000,
                Image = "فومن گیلان2.jpg",
                TourTypeId = 23,
                DestinationId = 41
            },

            // 42. قلعه الموت
            new Tour
            {
                Id = 42,
                Title = "دژ افسانه‌ای",
                Description = "کوهپیمایی و بازدید از قلعه تاریخی حسن صباح",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 3, 1),
                EndTime = new DateTime(2028, 3, 2),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 30,
                Price = 850000,
                Image = "قلعه الموت2.jpg",
                TourTypeId = 10,
                DestinationId = 42
            },

            // 43. قلعه رودخان
            new Tour
            {
                Id = 43,
                Title = "قلعه هزار پله",
                Description = "تور ورزشی و تاریخی با پیاده‌روی در جنگل",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 4, 10),
                EndTime = new DateTime(2028, 4, 11),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 35,
                Price = 700000,
                Image = "قلعه رودخان2.jpg",
                TourTypeId = 4,
                DestinationId = 43
            },

            // 44. کامینو د سانتیاگو
            new Tour
            {
                Id = 44,
                Title = "مسیر زیارتی",
                Description = "پیاده‌روی معنوی در مسیر تاریخی زائران",
                DaysCount = 7,
                SleepNightsCount = 6,
                StartTime = new DateTime(2028, 5, 5),
                EndTime = new DateTime(2028, 5, 11),
                MinimumAge = 18,
                MaximumAge = 60,
                MaximumPassenger = 20,
                Price = 2200000,
                Image = "کامینو د سانتیاگو در اسپانیا2.jpg",
                TourTypeId = 12,
                DestinationId = 44
            },

            // 45. کویر
            new Tour
            {
                Id = 45,
                Title = "شب‌های ستاره‌ای",
                Description = "تور 2 روزه کویرنوردی و تماشای آسمان شب",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 6, 1),
                EndTime = new DateTime(2028, 6, 2),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 800000,
                Image = "کویر2.jpg",
                TourTypeId = 27,
                DestinationId = 45
            },

            // 46. گرمسار
            new Tour
            {
                Id = 46,
                Title = "ماجراجویی در کویر",
                Description = "تور 2 روزه با شترسواری و شب‌مانی در بیابان",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 7, 10),
                EndTime = new DateTime(2028, 7, 11),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 20,
                Price = 750000,
                Image = "گرمسار2.jpg",
                TourTypeId = 5,
                DestinationId = 46
            },

            // 47. گرند کنیون
            new Tour
            {
                Id = 47,
                Title = "پرواز بر فراز دره",
                Description = "تور هلیکوپتری و پیاده‌روی در گرند کنیون",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2028, 8, 5),
                EndTime = new DateTime(2028, 8, 7),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 15,
                Price = 3800000,
                Image = "گرند کنیون2.jpg",
                TourTypeId = 31,
                DestinationId = 47
            },

            // 48. مخمل کوه
            new Tour
            {
                Id = 48,
                Title = "کوهنوردی زمستانی",
                Description = "تور 2 روزه برای علاقه‌مندان به ورزش‌های زمستانی",
                DaysCount = 2,
                SleepNightsCount = 1,
                StartTime = new DateTime(2028, 9, 1),
                EndTime = new DateTime(2028, 9, 2),
                MinimumAge = 20,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 950000,
                Image = "مخمل کوه2.jpg",
                TourTypeId = 4,
                DestinationId = 48
            },

            // 49. مرداب نیلوفر آبی
            new Tour
            {
                Id = 49,
                Title = "گل‌های بهشتی",
                Description = "تور یک روزه قایق‌سواری در میان گل‌های نیلوفر",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2028, 10, 10),
                EndTime = new DateTime(2028, 10, 10),
                MinimumAge = 10,
                MaximumAge = 60,
                MaximumPassenger = 35,
                Price = 450000,
                Image = "مرداب های پوشیده از گل نیلوفر آبی2.jpg",
                TourTypeId = 30,
                DestinationId = 49
            },

            // 50. مرداب هسل
            new Tour
            {
                Id = 50,
                Title = "مه‌های صبحگاهی",
                Description = "تور عکاسی از مناظر سورئال مرداب",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2028, 11, 5),
                EndTime = new DateTime(2028, 11, 5),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 25,
                Price = 400000,
                Image = "مرداب هسل چالوس2.jpg",
                TourTypeId = 21,
                DestinationId = 50
            },

            // 51. مزارع بوگور
            new Tour
            {
                Id = 51,
                Title = "طعم چای تازه",
                Description = "تور 3 روزه بازدید از مزارع چای و فرآوری سنتی",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2029, 1, 10),
                EndTime = new DateTime(2029, 1, 12),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 20,
                Price = 1200000,
                Image = "مزارع بوگور در اندونزی2.jpg",
                TourTypeId = 30,
                DestinationId = 51
            },

            // 52. مزارع چای دارجلینگ
            new Tour
            {
                Id = 52,
                Title = "چای دارجلینگ",
                Description = "گشت 4 روزه در مزارع مرتفع چای",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2029, 2, 15),
                EndTime = new DateTime(2029, 2, 18),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 25,
                Price = 1500000,
                Image = "مزارع چای دارجلینگ2.jpg",
                TourTypeId = 30,
                DestinationId = 52
            },

            // 53. ملبورن
            new Tour
            {
                Id = 53,
                Title = "شهر فرهنگ‌ها",
                Description = "تور 5 روزه فرهنگی در پایتخت هنر استرالیا",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2029, 3, 1),
                EndTime = new DateTime(2029, 3, 5),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 3200000,
                Image = "ملبورن2.jpg",
                TourTypeId = 11,
                DestinationId = 53
            },

            // 54. ناپا ولی
            new Tour
            {
                Id = 54,
                Title = "تور شراب‌نوشی",
                Description = "گشت 3 روزه در تاکستان‌های معروف کالیفرنیا",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2029, 4, 10),
                EndTime = new DateTime(2029, 4, 12),
                MinimumAge = 21,
                MaximumAge = 50,
                MaximumPassenger = 20,
                Price = 2500000,
                Image = "ناپا ولی آمریکا2.jpg",
                TourTypeId = 24,
                DestinationId = 54
            },

            // 55. نمک ابرود
            new Tour
            {
                Id = 55,
                Title = "بلورهای نمکی",
                Description = "تور عکاسی از دشت نمک در نور طلایی",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2029, 5, 5),
                EndTime = new DateTime(2029, 5, 5),
                MinimumAge = 15,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 350000,
                Image = "نمک ابرود2.jpg",
                TourTypeId = 21,
                DestinationId = 55
            },

            // 56. نورهای درخشان مالدیو
            new Tour
            {
                Id = 56,
                Title = "نورهای آبی",
                Description = "تور 5 روزه لاکچری با تماشای پلانکتون‌های نورانی",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2029, 6, 1),
                EndTime = new DateTime(2029, 6, 5),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 4800000,
                Image = "نورهای درخشان مالدیو2.jpg",
                TourTypeId = 13,
                DestinationId = 56
            },

            // 57. هاوایی
            new Tour
            {
                Id = 57,
                Title = "بهشت آتشفشانی",
                Description = "تور 7 روزه با تفریحات آبی و کوهنوردی",
                DaysCount = 7,
                SleepNightsCount = 6,
                StartTime = new DateTime(2029, 7, 10),
                EndTime = new DateTime(2029, 7, 16),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 25,
                Price = 5200000,
                Image = "هاوایی2.jpg",
                TourTypeId = 9,
                DestinationId = 57
            },

            // 58. هرم‌های بوسنی
            new Tour
            {
                Id = 58,
                Title = "اسرار هرم‌ها",
                Description = "تور 3 روزه تحقیقاتی درباره هرم‌های مرموز",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2029, 8, 5),
                EndTime = new DateTime(2029, 8, 7),
                MinimumAge = 18,
                MaximumAge = 45,
                MaximumPassenger = 20,
                Price = 1500000,
                Image = "هرم‌های بوسنی2.jpg",
                TourTypeId = 8,
                DestinationId = 58
            },

            // 59. ونیز
            new Tour
            {
                Id = 59,
                Title = "رمانتیک‌ترین شهر جهان",
                Description = "تور 4 روزه قایق‌سواری در کانال‌ها",
                DaysCount = 4,
                SleepNightsCount = 3,
                StartTime = new DateTime(2029, 9, 1),
                EndTime = new DateTime(2029, 9, 4),
                MinimumAge = 18,
                MaximumAge = 50,
                MaximumPassenger = 30,
                Price = 2800000,
                Image = "ونیز2.jpg",
                TourTypeId = 11,
                DestinationId = 59
            },

            // 60. یوسمیتی
            new Tour
            {
                Id = 60,
                Title = "ماجراجویی در پارک ملی",
                Description = "تور 5 روزه کوهنوردی و سنگ‌نوردی",
                DaysCount = 5,
                SleepNightsCount = 4,
                StartTime = new DateTime(2029, 10, 10),
                EndTime = new DateTime(2029, 10, 14),
                MinimumAge = 20,
                MaximumAge = 45,
                MaximumPassenger = 15,
                Price = 3200000,
                Image = "یوسمیتی2.jpg",
                TourTypeId = 4,
                DestinationId = 60
            },
            new Tour
            {
                Id = 61,
                Title = "تور یک روزه دریاچه اویدر",
                Description = "✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 21),
                EndTime = new DateTime(2025, 4, 22),
                MaximumAge = 45,
                MinimumAge = 15,
                MaximumPassenger = 40,
                Price = 1.1e+006,
                Image = "e1dd9ae1-acd4-49b4-9adb-584a5d7ecdde__دریاچه اویدر2.jpg",
                TourTypeId = 23, // طبیعت‌گردی (به جای تفریحی)
                DestinationId = 27 // دریاچه اویدر (به جای استون‌هنژ)
            },
            new Tour
            {
                Id = 62,
                Title = "تور یک روزه ساحل دریا مازندران",
                Description = "بریم ‌دریا😍🌊    ✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 5, 28),
                EndTime = new DateTime(2025, 5, 29),
                MaximumAge = 45,
                MinimumAge = 15,
                MaximumPassenger = 23,
                Price = 1.45e+006,
                Image = "71681f8a-d73a-468e-b997-ba26c570ccd6__ساحل دریا مازندران.jpg",
                TourTypeId = 22, // ساحلی (به جای دورهمی)
                DestinationId = 35 // ساحل مازندران (به جای آمازون)
            },
            new Tour
            {
                Id = 63,
                Title = "🏝 تور پنج و نیم روزه جزیره زیبای قشم",
                Description = "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ",
                DaysCount = 6,
                SleepNightsCount = 5,
                StartTime = new DateTime(2025, 5, 29),
                EndTime = new DateTime(2025, 6, 3),
                MaximumAge = 48,
                MinimumAge = 18,
                MaximumPassenger = 40,
                Price = 9.9e+006,
                Image = "f8c2b2dd-ea10-4ce6-93ab-8a8873ef2d59__جزیره قشم2.jpg",
                TourTypeId = 4, // جزایر (به جای ماجراجویی)
                DestinationId = 16 // جزیره قشم (به جای ایسلند)
            },
            new Tour
            {
                Id = 64,
                Title = "🏝 تور پنج و نیم روزه جزیره زیبای هنگام",
                Description = "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ",
                DaysCount = 6,
                SleepNightsCount = 5,
                StartTime = new DateTime(2025, 4, 9),
                EndTime = new DateTime(2025, 4, 15),
                MaximumAge = 48,
                MinimumAge = 18,
                MaximumPassenger = 40,
                Price = 9.9e+006,
                Image = "e2ad5f5c-377f-4729-ad6d-6081a109b1ab__جزیره هنگام2.jpg",
                TourTypeId = 4, // جزایر (به جای تفریحی)
                DestinationId = 20 // جزیره هنگام (به جای بازارهای شناور)
            },
            new Tour
            {
                Id = 65,
                Title = "🏝 تور پنج و نیم روزه جزیره زیبای هرمز ",
                Description = "  ✔ خدمات:    👈 سه شب اقامت در هتل آپارتمان 🏨  👈 ۳ وعده صبحانه 🍳🍯  👈 خرید در بازارهای درگهان و قشم👖👕👗👟  👈  گشت قشم و هنگام و هرمز و ورودیه ها 💵  👈 بیمه مسافرتی ⛑  👈 مجوز گردشگری 📄  👈 تور لیدر🕵  👈 وسیله نقلیه قطار ۴ تخته🚋  👈 ترانسفر بندر به قشم و بالعکس🚎🛥  👈 گشت ها: 🚐  📌 جزیره هرمز   📌 جزیره هنگام  📌 تماشای دلفین های آزاد، اکواریوم طبیعی  📌سواحل نقره ای و سرخ  📌پارک زیبای زیتون  📌 ساحل جزایر ناز  📌دره ستاره ها  📌 خرید درگهان و سیتی سنتر  📌 قایق سواری در جنگل حرا  📌 تنگه چاهکوه  و...      ‼هزینه تمامی گشت ها،ترانسفرها و ورودیه ها به عهده تور میباشد.    ",
                DaysCount = 6,
                SleepNightsCount = 5,
                StartTime = new DateTime(2025, 4, 30),
                EndTime = new DateTime(2025, 5, 6),
                MaximumAge = 50,
                MinimumAge = 18,
                MaximumPassenger = 40,
                Price = 0,
                Image = "a042011a-0bbd-4765-977f-c2d30e308fbb__جزیره قشم2.jpg",
                TourTypeId = 4, // جزایر (به جای سفر لوکس)
                DestinationId = 19 // جزیره هرمز (به جای بانکوک)
            },
            new Tour
            {
                Id = 66,
                Title = "😌 تور یک روزه شمال",
                Description = "بازدید از:  📌 ساحل و دریا 🌊  📌 دریاچه الیمالات  (سافاری ببر و زیپ بایک و...)      ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 10),
                EndTime = new DateTime(2025, 4, 11),
                MaximumAge = 45,
                MinimumAge = 20,
                MaximumPassenger = 32,
                Price = 1.45e+006,
                Image = "f2e84ae8-9afe-4a55-b75e-87b3cb9b6453__دریاچه الیمالات2.jpg",
                TourTypeId = 16, // خانوادگی (به جای ماجراجویی)
                DestinationId = 26 // دریاچه الیمالات (به جای برلین)
            },
            new Tour
            {
                Id = 67,
                Title = "😌 تور یک روزه رشت گردی",
                Description = "بازدید از:  📌 شهر زیبای رشت    📌 باز پر رنگ و بوی رشت  📌 میدان شهرداری  📌 مرداب و جنگل رویایی سراوان  📌 موزه خاص و زیبای گیلان      ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...    ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 17),
                EndTime = new DateTime(2025, 4, 18),
                MaximumAge = 60,
                MinimumAge = 20,
                MaximumPassenger = 32,
                Price = 1.45e+006,
                Image = "e87199f3-a2cb-4c4b-ab75-87394b0257a6__رشت.jpg 2.jpg",
                TourTypeId = 3, // بوم گردی (به جای سفر خانوادگی)
                DestinationId = 31 // رشت (به جای بورنئو)
            },
            new Tour
            {
                Id = 68,
                Title = "تور یک روزه دریاچه اویدر",
                Description = "✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 5, 1),
                EndTime = new DateTime(2025, 5, 2),
                MaximumAge = 40,
                MinimumAge = 15,
                MaximumPassenger = 40,
                Price = 0,
                Image = "edd78542-0b59-4f5b-ba82-9f2d4766fbce__دریاچه اویدر3.jpg",
                TourTypeId = 23, // طبیعت‌گردی (به جای سفر جاده‌ای)
                DestinationId = 27 // دریاچه اویدر (به جای استون‌هنژ)
            },
            new Tour
            {
                Id = 69,
                Title = "تور یک روزه ساحل دریا مازندران",
                Description = "بریم ‌دریا😍🌊    ✔ خدمات:    👈 صبحانه سلف 🍞🍳  👈 ‌ناهار🍗 (در صورت سفارش)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس ۴۴ صندلی و ۳۲ صندلی توریستی در اختیار🚍    🔴 اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 5, 29),
                EndTime = new DateTime(2025, 5, 30),
                MaximumAge = 40,
                MinimumAge = 18,
                MaximumPassenger = 23,
                Price = 1.25e+006,
                Image = "ee153ebd-5bcb-4919-829f-a2a9b16000bf__ساحل دریامازندران.jpg 2.jpg",
                TourTypeId = 22, // ساحلی (به جای سرگرمی)
                DestinationId = 35 // ساحل مازندران (به جای آمازون)
            },
            new Tour
            {
                Id = 70,
                Title = "😌 تور یک روزه رشت گردی",
                Description = "  بازدید از:  📌 شهر زیبای رشت    📌 باز پر رنگ و بوی رشت  📌 میدان شهرداری  📌 مرداب و جنگل رویایی سراوان  📌 موزه خاص و زیبای گیلان    ✔ خدمات:    👈 صبحانه سلف🍳🧀  👈 میانوعده 🍎🍅  👈 شام (ساندویچ سرد)🌯🥤  👈 بیمه مسافرتی⛑   👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 اتوبوس توریستی در اختیار🚍    🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 6, 26),
                EndTime = new DateTime(2025, 6, 27),
                MaximumAge = 40,
                MinimumAge = 20,
                MaximumPassenger = 23,
                Price = 1.5e+006,
                Image = "a0cf51be-d227-467c-8f20-52cfedfecedb__رشت 3.jpg",
                TourTypeId = 3, // بوم گردی (به جای تفریحی)
                DestinationId = 31 // رشت (به جای بورنئو)
            },
            new Tour
            {
                Id = 71,
                Title = "🔥تور چهارشنبه سوری گرمسار 🔥",
                Description = "  ✔ خدمات:    👈 پذیرایی عصرانه  👈 یک وعده شام  👈 شب نشینی دور آتش به همراه چای آتشی🔥   👈 برنامه موزیک🎸🎤  👈 پرداخت ورودیه ها💰  👈 بیمه مسافرتی⛑  👈 مجوز رسمی سازمانی📃  👈 تورلیدر🕵  👈 اتوبوس ۴۴ صندلی در اختیار 🚌      🔴 ثبت نام فقط تا ۲۱ اسفند امکان پذیر می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.    🔴فقط یک اتوبوس ۴۰ نفره میریم و ماشین شخصی و غیره هم نمیتونند همراهمون بیایند پس ظرفیت واقعا محدود      👌 با کیفیت سفر کنید...    ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 3, 18),
                EndTime = new DateTime(2026, 3, 18),
                MaximumAge = 40,
                MinimumAge = 20,
                MaximumPassenger = 40,
                Price = 1.3e+006,
                Image = "560bd7a9-db78-4bf5-a54c-8c10afbc983a__گرمسار 2.jpg",
                TourTypeId = 32, // فستیوال‌ها (به جای تفریحی)
                DestinationId = 46 // گرمسار (به جای پاتاگونیا)
            },
            new Tour
            {
                Id = 72,
                Title = "🔥تور چهارشنبه سوری کویر 🔥",
                Description = "  ✔ خدمات:    👈 پذیرایی عصرانه  👈 یک وعده شام  👈 شب نشینی دور آتش به همراه چای آتشی🔥   👈 برنامه موزیک🎸🎤  👈 پرداخت ورودیه ها💰  👈 بیمه مسافرتی⛑  👈 مجوز رسمی سازمانی📃  👈 تورلیدر🕵  👈 اتوبوس ۴۴ صندلی در اختیار 🚌      🔴 ثبت نام فقط تا ۲۱ اسفند امکان پذیر می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.    🔴فقط یک اتوبوس ۴۰ نفره میریم و ماشین شخصی و غیره هم نمیتونند همراهمون بیایند پس ظرفیت واقعا محدود      👌 با کیفیت سفر کنید...    ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2026, 3, 11),
                EndTime = new DateTime(2026, 3, 11),
                MaximumAge = 40,
                MinimumAge = 20,
                MaximumPassenger = 40,
                Price = 1.39e+006,
                Image = "1f1e35f1-491b-44a8-8359-d501fb173e51__کویر 2.jpg",
                TourTypeId = 32, // فستیوال‌ها (به جای تفریحی)
                DestinationId = 45 // کویر (به جای پاموکاله)
            },
            new Tour
            {
                Id = 73,
                Title = "😍 تور یک روزه نمک ابرود",
                Description = "  ✔ خدمات:    👈 صبحانه سلف🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد و نوشابه)🌯🥤  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 وسیله نقلیه توریستی در اختیار🚍    👌 با کیفیت سفر کنید...    ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 27),
                EndTime = new DateTime(2025, 4, 28),
                MaximumAge = 36,
                MinimumAge = 20,
                MaximumPassenger = 23,
                Price = 1.79e+006,
                Image = "46d19ca0-8e7d-492e-9026-0d240ccc2932__نمک ابرود2.jpg",
                TourTypeId = 21, // عکاسی (به جای سرگرمی)
                DestinationId = 55 // نمک ابرود (به جای پترا)
            },
            new Tour
            {
                Id = 74,
                Title = "😍 تور یک روزه دریا",
                Description = "  ✔ خدمات:    👈 صبحانه سلف🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد و نوشابه)🌯🥤  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 وسیله نقلیه توریستی در اختیار🚍    👌 با کیفیت سفر کنید...    ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 30),
                EndTime = new DateTime(2025, 5, 1),
                MaximumAge = 48,
                MinimumAge = 18,
                MaximumPassenger = 40,
                Price = 1.45e+006,
                Image = "d7285dc9-f414-42e3-a6eb-36773e5a3da3__دریا2.jpg",
                TourTypeId = 22, // ساحلی (به جای بوم گردی)
                DestinationId = 25 // دریا (به جای پرپیات)
            },
            new Tour
            {
                Id = 75,
                Title = "📌 تور يكروزه قلعه رودخان",
                Description = "  ✔ خدمات:    👈 صبحانه سلف 🧀🍯🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 5, 13),
                EndTime = new DateTime(2025, 5, 14),
                MaximumAge = 39,
                MinimumAge = 19,
                MaximumPassenger = 40,
                Price = 1.55e+006,
                Image = "3b85f11c-0290-4efd-849b-a5a980a1f74b__قلعه رودخان2.jpg",
                TourTypeId = 10, // تاریخی (بدون تغییر)
                DestinationId = 43 // قلعه رودخان (به جای تالاب انزلی)
            },
            new Tour
            {
                Id = 76,
                Title = "📌 تور يكروزه فومن گیلان",
                Description = "  ✔ خدمات:    👈 صبحانه سلف 🧀🍯🍳  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر مجرب🕵  👈 اتوبوس توریستی در اختیار🚍      🔴 ظرفیت محدود می باشد و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 4, 17),
                EndTime = new DateTime(2025, 4, 18),
                MaximumAge = 48,
                MinimumAge = 18,
                MaximumPassenger = 32,
                Price = 1.55e+006,
                Image = "60834f36-ab76-45ed-8054-85d59e33dcb6__فومن گیلان2.jpg",
                TourTypeId = 3, // بوم گردی (بدون تغییر)
                DestinationId = 41 // فومن گیلان (به جای تهران گرافیتی)
            },
            new Tour
            {
                Id = 77,
                Title = "😌 تور یک روزه مخمل کوه لرستان",
                Description = "✔ خدمات:    👈 میز صبحانه 🍳🧀  👈 عصرانه🍊🍩  👈 شام (ساندویچ سرد)  👈 بیمه مسافرتی⛑  👈 مجوز رسمی گردشگری📃  👈 تورلیدر 🕵  👈 پرداخت هزینه های ورودی💰  👈 وسیله نقلیه توریستی در اختیار🚍      🔴 ظرفیت محدود و اولویت با عزیزانی است که زودتر ثبت نام کنند.      👌 با کیفیت سفر کنید...  ",
                DaysCount = 1,
                SleepNightsCount = 0,
                StartTime = new DateTime(2025, 6, 11),
                EndTime = new DateTime(2025, 6, 12),
                MaximumAge = 40,
                MinimumAge = 20,
                MaximumPassenger = 32,
                Price = 1.79e+006,
                Image = "aff94c10-750a-4b4b-bc70-35156be586a0__مخمل کوه2.jpg",
                TourTypeId = 4, // ورزشی (به جای تفریحی)
                DestinationId = 48 // مخمل کوه (به جای توسکانی)
            },
            new Tour
            {
                Id = 78,
                Title = "😍 سفر ۲/۵ روزه کمپی جنگل مشعل",
                Description = "📌 خدمات:    👈 چادر ستاره ای برای دورهمی  👈 صندلی اختصاصی برای هر نفر  👈 برق رسانی + نورپردازی شب  👈 باند و موزیک  👈اجرای بازی های گروهی  👈دورهمی و شب نشینی بهمراه چای آتیشی  👈چادر سرویس بهداشتی  👈 آب شستشو و...    📌پذیرایی:😍    ۵ وعده مفصل + ۱ وعده عصرانه   🔸۲ وعده صبحانه سلف سرویس با آیتم های سرد و گرم  🔸۲ وعده ناهار(چلومرغ+خوراک‌جوجه) + ماست موسیر + نوشابه  🔸۱ وعده شام چیزبرگر + سیب زمینی سرخ کرده + نوشابه  🔸چای آتیشی هم که کلا توی سفر به راهه  🔸سیب زمینی آتیشی یا بلال هم در خدمتیم    📌 وسایل مورد نیازی که باید همراهتون باشه:  🔸چادر مسافرتی + نایلون (محض احتیاط)  🔸زیرانداز (برای داخل و زیر چادر)  🔸کیسه خواب    🔴 ظرفیت کل ۴۰ نفر میباشد و اولویت با عزیزانیست که زودتر ثبت نام کنند.        👌 با کیفیت سفر کنید...  ",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2025, 7, 23),
                EndTime = new DateTime(2025, 7, 26),
                MaximumAge = 40,
                MinimumAge = 20,
                MaximumPassenger = 40,
                Price = 2.85e+006,
                Image = "17ba8889-3adb-4c86-a846-e1bbf6667017__جنگل مشعل 2.jpg",
                TourTypeId = 5, // کمپینگ (بدون تغییر)
                DestinationId = 21 // جنگل مشعل (بدون تغییر)
            },
            new Tour
            {
                Id = 79,
                Title = "😍 سفر ۲/۵ روزه کمپی مرداب هسل چالوس",
                Description = "📌 خدمات:    👈 چادر ستاره ای برای دورهمی  👈 صندلی اختصاصی برای هر نفر  👈 برق رسانی + نورپردازی شب  👈 باند و موزیک  👈اجرای بازی های گروهی  👈دورهمی و شب نشینی بهمراه چای آتیشی  👈چادر سرویس بهداشتی  👈 آب شستشو و...    📌پذیرایی:😍    ۵ وعده مفصل + ۱ وعده عصرانه   🔸۲ وعده صبحانه سلف سرویس با آیتم های سرد و گرم  🔸۲ وعده ناهار(چلومرغ+خوراک‌جوجه) + ماست موسیر + نوشابه  🔸۱ وعده شام چیزبرگر + سیب زمینی سرخ کرده + نوشابه  🔸چای آتیشی هم که کلا توی سفر به راهه  🔸سیب زمینی آتیشی یا بلال هم در خدمتیم    📌 وسایل مورد نیازی که باید همراهتون باشه:  🔸چادر مسافرتی + نایلون (محض احتیاط)  🔸زیرانداز (برای داخل و زیر چادر)  🔸کیسه خواب    🔴 ظرفیت کل ۴۰ نفر میباشد و اولویت با عزیزانیست که زودتر ثبت نام کنند.        👌 با کیفیت سفر کنید...  ",
                DaysCount = 3,
                SleepNightsCount = 2,
                StartTime = new DateTime(2025, 7, 31),
                EndTime = new DateTime(2025, 8, 3),
                MaximumAge = 30,
                MinimumAge = 20,
                MaximumPassenger = 40,
                Price = 1.9e+006,
                Image = "57cc189d-0408-4779-bad4-ab8259bae87e__مرداب هسل چالوس2.jpg",
                TourTypeId = 5, // کمپینگ (بدون تغییر)
                DestinationId = 50 // مرداب هسل (بدون تغییر)
            }
        );

        _ = modelBuilder.Entity<TourCategory>().HasData(
            // تورهای طبیعت‌گردی
            new TourCategory { Id = 1, TourId = 1, CategoryId = 1 }, // استون‌هنژ - طبیعت‌گردی
            new TourCategory { Id = 2, TourId = 2, CategoryId = 1 }, // آمازون - طبیعت‌گردی
            new TourCategory { Id = 3, TourId = 3, CategoryId = 1 }, // ایسلند - طبیعت‌گردی
            new TourCategory { Id = 4, TourId = 12, CategoryId = 1 }, // تالاب انزلی - طبیعت‌گردی
            new TourCategory { Id = 5, TourId = 21, CategoryId = 1 }, // جنگل مشعل - طبیعت‌گردی

            // تورهای ماجراجویی
            new TourCategory { Id = 6, TourId = 2, CategoryId = 2 }, // آمازون - ماجراجویی
            new TourCategory { Id = 7, TourId = 8, CategoryId = 2 }, // پاتاگونیا - ماجراجویی
            new TourCategory { Id = 8, TourId = 34, CategoryId = 2 }, // ژانگیه - ماجراجویی
            new TourCategory { Id = 9, TourId = 40, CategoryId = 2 }, // صحرای نامیب - ماجراجویی

            // تورهای تفریحی
            new TourCategory { Id = 10, TourId = 4, CategoryId = 3 }, // بازارهای شناور - تفریحی
            new TourCategory { Id = 11, TourId = 25, CategoryId = 3 }, // دریا - تفریحی
            new TourCategory { Id = 12, TourId = 35, CategoryId = 3 }, // ساحل مازندران - تفریحی

            // تورهای فرهنگی
            new TourCategory { Id = 13, TourId = 5, CategoryId = 4 }, // بانکوک - فرهنگی
            new TourCategory { Id = 14, TourId = 59, CategoryId = 4 }, // ونیز - فرهنگی
            new TourCategory { Id = 15, TourId = 53, CategoryId = 4 }, // ملبورن - فرهنگی

            // تورهای تاریخی
            new TourCategory { Id = 16, TourId = 1, CategoryId = 5 }, // استون‌هنژ - تاریخی
            new TourCategory { Id = 17, TourId = 10, CategoryId = 5 }, // پترا - تاریخی
            new TourCategory { Id = 18, TourId = 42, CategoryId = 5 }, // قلعه الموت - تاریخی
            new TourCategory { Id = 19, TourId = 75, CategoryId = 5 }, // قلعه رودخان - تاریخی

            // تورهای خانوادگی
            new TourCategory { Id = 20, TourId = 7, CategoryId = 15 }, // ساحل مازندران - خانوادگی
            new TourCategory { Id = 21, TourId = 20, CategoryId = 15 }, // جزیره هنگام - خانوادگی
            new TourCategory { Id = 22, TourId = 26, CategoryId = 15 }, // دریاچه الیمالات - خانوادگی

            // تورهای بوم گردی
            new TourCategory { Id = 23, TourId = 16, CategoryId = 16 }, // جزیره قشم - بوم گردی
            new TourCategory { Id = 24, TourId = 31, CategoryId = 16 }, // رشت - بوم گردی
            new TourCategory { Id = 25, TourId = 76, CategoryId = 16 }, // فومن گیلان - بوم گردی

            // تورهای عکاسی
            new TourCategory { Id = 26, TourId = 6, CategoryId = 10 }, // دره رنگین‌کمان - عکاسی
            new TourCategory { Id = 27, TourId = 19, CategoryId = 10 }, // جزیره هرمز - عکاسی
            new TourCategory { Id = 28, TourId = 29, CategoryId = 10 }, // دشت نمک - عکاسی
            new TourCategory { Id = 29, TourId = 50, CategoryId = 10 }, // مرداب هسل - عکاسی

            // تورهای نجومی
            new TourCategory { Id = 30, TourId = 27, CategoryId = 27 }, // دریاچه اویدر - نجومی
            new TourCategory { Id = 31, TourId = 38, CategoryId = 27 }, // شفق قطبی - نجومی
            new TourCategory { Id = 32, TourId = 45, CategoryId = 27 }, // کویر - نجومی

            // تورهای ورزشی
            new TourCategory { Id = 33, TourId = 8, CategoryId = 4 }, // پاتاگونیا - ورزشی
            new TourCategory { Id = 34, TourId = 43, CategoryId = 4 }, // قلعه رودخان - ورزشی
            new TourCategory { Id = 35, TourId = 48, CategoryId = 4 }, // مخمل کوه - ورزشی

            // تورهای سلامت
            new TourCategory { Id = 36, TourId = 9, CategoryId = 18 }, // پاموکاله - سلامت
            new TourCategory { Id = 37, TourId = 22, CategoryId = 18 }, // چشمه‌های گِل‌آب - سلامت

            // تورهای جزایر
            new TourCategory { Id = 38, TourId = 16, CategoryId = 4 }, // جزیره قشم - جزایر
            new TourCategory { Id = 39, TourId = 17, CategoryId = 4 }, // جزیره گانکنجو - جزایر
            new TourCategory { Id = 40, TourId = 19, CategoryId = 4 }, // جزیره هرمز - جزایر

            // تورهای فستیوال‌ها
            new TourCategory { Id = 41, TourId = 71, CategoryId = 23 }, // چهارشنبه سوری گرمسار - فستیوال
            new TourCategory { Id = 42, TourId = 72, CategoryId = 23 }, // چهارشنبه سوری کویر - فستیوال

            // تورهای کمپینگ
            new TourCategory { Id = 43, TourId = 78, CategoryId = 5 }, // جنگل مشعل - کمپینگ
            new TourCategory { Id = 44, TourId = 79, CategoryId = 5 }, // مرداب هسل - کمپینگ

            // تورهای غذایی
            new TourCategory { Id = 45, TourId = 14, CategoryId = 9 }, // توسکانی - غذایی
            new TourCategory { Id = 46, TourId = 31, CategoryId = 9 }, // رشت - غذایی
            new TourCategory { Id = 47, TourId = 54, CategoryId = 9 }, // ناپا ولی - غذایی

            // تورهای ساحلی
            new TourCategory { Id = 48, TourId = 3, CategoryId = 22 }, // جزیره قشم - ساحلی
            new TourCategory { Id = 49, TourId = 35, CategoryId = 22 }, // ساحل مازندران - ساحلی
            new TourCategory { Id = 50, TourId = 57, CategoryId = 22 }, // هاوایی - ساحلی

            // تورهای ارواح
            new TourCategory { Id = 51, TourId = 11, CategoryId = 29 }, // پرپیات - ارواح
            new TourCategory { Id = 52, TourId = 39, CategoryId = 29 }, // نوش آباد - ارواح

            // تورهای لاکچری
            new TourCategory { Id = 53, TourId = 30, CategoryId = 12 }, // دوبی - لاکچری
            new TourCategory { Id = 54, TourId = 56, CategoryId = 12 }, // مالدیو - لاکچری

            // تورهای علمی
            new TourCategory { Id = 55, TourId = 23, CategoryId = 13 }, // چغازنبیل - علمی
            new TourCategory { Id = 56, TourId = 58, CategoryId = 13 }, // هرم‌های بوسنی - علمی

            // تورهای هنری
            new TourCategory { Id = 57, TourId = 13, CategoryId = 19 }, // تهران گرافیتی - هنری
            new TourCategory { Id = 58, TourId = 17, CategoryId = 19 }, // جزیره گانکنجو - هنری

            // تورهای زمستانی
            new TourCategory { Id = 59, TourId = 3, CategoryId = 24 }, // ایسلند - زمستانی
            new TourCategory { Id = 60, TourId = 38, CategoryId = 24 }, // شفق قطبی - زمستانی

            // تورهای جوانان
            new TourCategory { Id = 61, TourId = 15, CategoryId = 25 }, // توکیو - جوانان
            new TourCategory { Id = 62, TourId = 33, CategoryId = 25 }, // کیوتو - جوانان

            // تورهای مدیتیشن
            new TourCategory { Id = 63, TourId = 33, CategoryId = 28 }, // کیوتو - مدیتیشن
            new TourCategory { Id = 64, TourId = 44, CategoryId = 28 }, // کامینو - مدیتیشن

            // تورهای حیات وحش
            new TourCategory { Id = 65, TourId = 7, CategoryId = 22 }, // بورنئو - حیات وحش
            new TourCategory { Id = 66, TourId = 18, CategoryId = 22 }, // گوریلاهای رواندا - حیات وحش

            // تورهای مزارع چای
            new TourCategory { Id = 67, TourId = 51, CategoryId = 30 }, // بوگور - مزارع چای
            new TourCategory { Id = 68, TourId = 52, CategoryId = 30 }, // دارجلینگ - مزارع چای

            // تورهای گل‌دهی
            new TourCategory { Id = 69, TourId = 12, CategoryId = 22 }, // تالاب انزلی - گل‌دهی
            new TourCategory { Id = 70, TourId = 49, CategoryId = 22 }, // نیلوفر آبی - گل‌دهی

            // تورهای کوهنوردی
            new TourCategory { Id = 71, TourId = 8, CategoryId = 34 }, // پاتاگونیا - کوهنوردی
            new TourCategory { Id = 72, TourId = 60, CategoryId = 34 }, // یوسمیتی - کوهنوردی

            // تورهای روستایی
            new TourCategory { Id = 73, TourId = 14, CategoryId = 7 }, // توسکانی - روستایی
            new TourCategory { Id = 74, TourId = 32, CategoryId = 7 }, // روستاهای هند - روستایی

            // تورهای شهرهای تاریخی
            new TourCategory { Id = 75, TourId = 6, CategoryId = 14 }, // برلین - شهر تاریخی
            new TourCategory { Id = 76, TourId = 10, CategoryId = 14 }, // پترا - شهر تاریخی

            // تورهای شهرهای مدرن
            new TourCategory { Id = 77, TourId = 15, CategoryId = 13 }, // توکیو - شهر مدرن
            new TourCategory { Id = 78, TourId = 37, CategoryId = 13 }, // سنگاپور - شهر مدرن

            // تورهای هلیکوپتری
            new TourCategory { Id = 79, TourId = 47, CategoryId = 31 } // گرند کنیون - هلیکوپتری
        );

        _ = modelBuilder.Entity<TourObserve>().HasData(
             // User 1
             new TourObserve() { Id = 1, ObservedTourId = 5, ObserverUserId = 1, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 2, ObservedTourId = 12, ObserverUserId = 1, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 3, ObservedTourId = 22, ObserverUserId = 1, ObserveType = ObserveType.Visit },

             // User 2
             new TourObserve() { Id = 4, ObservedTourId = 2, ObserverUserId = 2, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 5, ObservedTourId = 17, ObserverUserId = 2, ObserveType = ObserveType.Visit },

             // User 3
             new TourObserve() { Id = 6, ObservedTourId = 7, ObserverUserId = 3, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 7, ObservedTourId = 14, ObserverUserId = 3, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 8, ObservedTourId = 31, ObserverUserId = 3, ObserveType = ObserveType.Like },

             // User 4
             new TourObserve() { Id = 9, ObservedTourId = 9, ObserverUserId = 4, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 10, ObservedTourId = 18, ObserverUserId = 4, ObserveType = ObserveType.Like },

             // User 5
             new TourObserve() { Id = 11, ObservedTourId = 4, ObserverUserId = 5, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 12, ObservedTourId = 19, ObserverUserId = 5, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 13, ObservedTourId = 36, ObserverUserId = 5, ObserveType = ObserveType.Like },

             // User 6
             new TourObserve() { Id = 14, ObservedTourId = 3, ObserverUserId = 6, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 15, ObservedTourId = 20, ObserverUserId = 6, ObserveType = ObserveType.Like },

             // User 7
             new TourObserve() { Id = 16, ObservedTourId = 8, ObserverUserId = 7, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 17, ObservedTourId = 27, ObserverUserId = 7, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 18, ObservedTourId = 34, ObserverUserId = 7, ObserveType = ObserveType.Visit },

             // User 8
             new TourObserve() { Id = 19, ObservedTourId = 6, ObserverUserId = 8, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 20, ObservedTourId = 15, ObserverUserId = 8, ObserveType = ObserveType.Visit },

             // User 9
             new TourObserve() { Id = 21, ObservedTourId = 13, ObserverUserId = 9, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 22, ObservedTourId = 21, ObserverUserId = 9, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 23, ObservedTourId = 29, ObserverUserId = 9, ObserveType = ObserveType.Visit },

             // User 10
             new TourObserve() { Id = 24, ObservedTourId = 10, ObserverUserId = 10, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 25, ObservedTourId = 25, ObserverUserId = 10, ObserveType = ObserveType.Like },

             // User 11
             new TourObserve() { Id = 26, ObservedTourId = 11, ObserverUserId = 11, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 27, ObservedTourId = 26, ObserverUserId = 11, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 28, ObservedTourId = 33, ObserverUserId = 11, ObserveType = ObserveType.Like },

             // User 12
             new TourObserve() { Id = 29, ObservedTourId = 16, ObserverUserId = 12, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 30, ObservedTourId = 28, ObserverUserId = 12, ObserveType = ObserveType.Visit },

             // User 13
             new TourObserve() { Id = 31, ObservedTourId = 23, ObserverUserId = 13, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 32, ObservedTourId = 30, ObserverUserId = 13, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 33, ObservedTourId = 38, ObserverUserId = 13, ObserveType = ObserveType.Like },

             // User 14
             new TourObserve() { Id = 34, ObservedTourId = 24, ObserverUserId = 14, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 35, ObservedTourId = 37, ObserverUserId = 14, ObserveType = ObserveType.Like },

             // User 15
             new TourObserve() { Id = 36, ObservedTourId = 32, ObserverUserId = 15, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 37, ObservedTourId = 39, ObserverUserId = 15, ObserveType = ObserveType.Visit },

             // User 16
             new TourObserve() { Id = 38, ObservedTourId = 35, ObserverUserId = 16, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 39, ObservedTourId = 40, ObserverUserId = 16, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 40, ObservedTourId = 41, ObserverUserId = 16, ObserveType = ObserveType.Like },

             // User 17
             new TourObserve() { Id = 41, ObservedTourId = 42, ObserverUserId = 17, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 42, ObservedTourId = 43, ObserverUserId = 17, ObserveType = ObserveType.Like },

             // User 18
             new TourObserve() { Id = 43, ObservedTourId = 44, ObserverUserId = 18, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 44, ObservedTourId = 45, ObserverUserId = 18, ObserveType = ObserveType.Visit },

             // User 19
             new TourObserve() { Id = 45, ObservedTourId = 46, ObserverUserId = 19, ObserveType = ObserveType.Visit },
             new TourObserve() { Id = 46, ObservedTourId = 47, ObserverUserId = 19, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 47, ObservedTourId = 48, ObserverUserId = 19, ObserveType = ObserveType.Like },

             // User 20
             new TourObserve() { Id = 48, ObservedTourId = 49, ObserverUserId = 20, ObserveType = ObserveType.Like },
             new TourObserve() { Id = 49, ObservedTourId = 50, ObserverUserId = 20, ObserveType = ObserveType.Visit }
         );

        _ = modelBuilder.Entity<DestinationObserve>().HasData(
            // User 1
            new DestinationObserve() { Id = 1, ObservedDestinationId = 2, ObserverUserId = 1, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 2, ObservedDestinationId = 10, ObserverUserId = 1, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 3, ObservedDestinationId = 15, ObserverUserId = 1, ObserveType = ObserveType.Visit },

            // User 2
            new DestinationObserve() { Id = 4, ObservedDestinationId = 3, ObserverUserId = 2, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 5, ObservedDestinationId = 14, ObserverUserId = 2, ObserveType = ObserveType.Visit },

            // User 3
            new DestinationObserve() { Id = 6, ObservedDestinationId = 5, ObserverUserId = 3, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 7, ObservedDestinationId = 16, ObserverUserId = 3, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 8, ObservedDestinationId = 20, ObserverUserId = 3, ObserveType = ObserveType.Visit },

            // User 4
            new DestinationObserve() { Id = 9, ObservedDestinationId = 7, ObserverUserId = 4, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 10, ObservedDestinationId = 12, ObserverUserId = 4, ObserveType = ObserveType.Like },

            // User 5
            new DestinationObserve() { Id = 11, ObservedDestinationId = 9, ObserverUserId = 5, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 12, ObservedDestinationId = 18, ObserverUserId = 5, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 13, ObservedDestinationId = 25, ObserverUserId = 5, ObserveType = ObserveType.Like },

            // User 6
            new DestinationObserve() { Id = 14, ObservedDestinationId = 6, ObserverUserId = 6, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 15, ObservedDestinationId = 13, ObserverUserId = 6, ObserveType = ObserveType.Visit },

            // User 7
            new DestinationObserve() { Id = 16, ObservedDestinationId = 8, ObserverUserId = 7, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 17, ObservedDestinationId = 22, ObserverUserId = 7, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 18, ObservedDestinationId = 30, ObserverUserId = 7, ObserveType = ObserveType.Visit },

            // User 8
            new DestinationObserve() { Id = 19, ObservedDestinationId = 11, ObserverUserId = 8, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 20, ObservedDestinationId = 19, ObserverUserId = 8, ObserveType = ObserveType.Visit },

            // User 9
            new DestinationObserve() { Id = 21, ObservedDestinationId = 17, ObserverUserId = 9, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 22, ObservedDestinationId = 21, ObserverUserId = 9, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 23, ObservedDestinationId = 28, ObserverUserId = 9, ObserveType = ObserveType.Visit },

            // User 10
            new DestinationObserve() { Id = 24, ObservedDestinationId = 23, ObserverUserId = 10, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 25, ObservedDestinationId = 29, ObserverUserId = 10, ObserveType = ObserveType.Like },

            // User 11
            new DestinationObserve() { Id = 26, ObservedDestinationId = 24, ObserverUserId = 11, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 27, ObservedDestinationId = 32, ObserverUserId = 11, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 28, ObservedDestinationId = 36, ObserverUserId = 11, ObserveType = ObserveType.Like },

            // User 12
            new DestinationObserve() { Id = 29, ObservedDestinationId = 26, ObserverUserId = 12, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 30, ObservedDestinationId = 34, ObserverUserId = 12, ObserveType = ObserveType.Visit },

            // User 13
            new DestinationObserve() { Id = 31, ObservedDestinationId = 27, ObserverUserId = 13, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 32, ObservedDestinationId = 35, ObserverUserId = 13, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 33, ObservedDestinationId = 39, ObserverUserId = 13, ObserveType = ObserveType.Like },

            // User 14
            new DestinationObserve() { Id = 34, ObservedDestinationId = 31, ObserverUserId = 14, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 35, ObservedDestinationId = 37, ObserverUserId = 14, ObserveType = ObserveType.Like },

            // User 15
            new DestinationObserve() { Id = 36, ObservedDestinationId = 33, ObserverUserId = 15, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 37, ObservedDestinationId = 40, ObserverUserId = 15, ObserveType = ObserveType.Visit },

            // User 16
            new DestinationObserve() { Id = 38, ObservedDestinationId = 38, ObserverUserId = 16, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 39, ObservedDestinationId = 41, ObserverUserId = 16, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 40, ObservedDestinationId = 44, ObserverUserId = 16, ObserveType = ObserveType.Like },

            // User 17
            new DestinationObserve() { Id = 41, ObservedDestinationId = 42, ObserverUserId = 17, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 42, ObservedDestinationId = 43, ObserverUserId = 17, ObserveType = ObserveType.Like },

            // User 18
            new DestinationObserve() { Id = 43, ObservedDestinationId = 45, ObserverUserId = 18, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 44, ObservedDestinationId = 46, ObserverUserId = 18, ObserveType = ObserveType.Visit },

            // User 19
            new DestinationObserve() { Id = 45, ObservedDestinationId = 47, ObserverUserId = 19, ObserveType = ObserveType.Visit },
            new DestinationObserve() { Id = 46, ObservedDestinationId = 49, ObserverUserId = 19, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 47, ObservedDestinationId = 50, ObserverUserId = 19, ObserveType = ObserveType.Like },

            // User 20
            new DestinationObserve() { Id = 48, ObservedDestinationId = 51, ObserverUserId = 20, ObserveType = ObserveType.Like },
            new DestinationObserve() { Id = 49, ObservedDestinationId = 53, ObserverUserId = 20, ObserveType = ObserveType.Visit }
        );
    }
}
