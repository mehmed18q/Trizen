namespace Trizen.Infrastructure;

public static class Resource
{
    public const string Id = "شناسه";
    public const string FirstName = "نام";
    public const string LastName = "نام خانوادگی";
    public const string FullName = "نام و نام خانوادگی";
    public const string UserName = "نام کاربری";
    public const string Email = "ایمیل";
    public const string PhoneNumber = "شماره تماس";
    public const string BirthDay = "تاریخ تولد";
    public const string Password = "کلمه عبور";
    public const string RePassword = "تکرار کلمه عبور";
    public const string NationalCode = "کد ملی";
    public const string Personality = "شخصیت";
    public const string Title = "عنوان";
    public const string Description = "توضیحات";
    public const string MinimumAge = "حداقل سن";
    public const string MaximumAge = "حداکثر سن";
    public const string DaysCount = "تعداد روز";
    public const string SleepNightsCount = "تعداد شب خواب";
    public const string Destination = "مقصد";
    public const string TourType = "نوع تور";
    public const string StartTime = "زمان شروع";
    public const string EndTime = "زمان پایان";
    public const string GeographicalLocation = "موقعیت جغرافیایی";
    public const string DestinationType = "نوع مقصد";
    public const string North = "شمال";
    public const string Northeast = "شمال-شرقی";
    public const string East = "شرق";
    public const string Southeast = "جنوب-شرقی";
    public const string South = "جنوب";
    public const string Southwest = "جنوب-غربی";
    public const string West = "غرب";
    public const string Northwest = "شمال-غربی";
    public const string Tour = "تور";
    public const string User = "کاربر";
    public const string Category = "دسته بندی";
    public const string Like = "علاقه مندی";
    public const string Visit = "مشاهده";
    public const string Status = "وضعیت";
    public const string Processing = "در حال پردازش";
    public const string Paid = "پرداخت شده";
    public const string Cancelled = "لغو شده";
    public const string RegisterTime = "تاریخ ثبت نام";
    public const string Travel = "سفر";
    public const string MaximumPassenger = "حداکثر مسافر";
    public const string Home = "خانه";
    public const string Login = "ورود";
    public const string GuestUser = "کاربر مهمان";
    public const string Register = "ثبت نام";
    public const string Profile = "حساب کاربری";
    public const string Edit = "ویرایش";
    public const string Logout = "خروج";
    public const string ImageProfile = "تصویر پروفایل";
    public const string Image = "تصویر";
    public const string Price = "قیمت";
    public const string Select = "انتخاب";
    public const string PleaseSelect = "گزینه خود را انتخاب کنید";
    public const string Admin = "مدیر";
    public const string Role = "نقش";
    public const string NoPhotoImage = "NoPhotoImage";
    public const string Tours = "تور ها";
    public const string Add = "افزودن";
    public const string List = "فهرست";
    public const string Code = "کد";
    public const string Create = "افزودن";
    public const string AgePeriod = "بازه سنی";
    public const string Duration = "بازه زمانی";
    public const string Commands = "دستورات";
    public const string NotStart = "شروع نشده";
    public const string NotEnd = "پایان نیافته";
    public const string Ended = "پایان یافته";
    public const string Delete = "حذف";
    public const string Confirm = "تایید";
    public const string GoDate = "تاریخ رفت";
    public const string BackDate = "تاریخ برگشت";
    public const string UserPanel = "پنل کاربری";
    public const string Trizen = "ترایزن";
    public const string TravelBasket = "سبد سفر";
    public const string Payment = "پرداخت";
    public const string WalletAmount = "موجودی حساب";
    public const string Passenger = "همسفران";
    public const string Center = "مرکز";
    public const string BadRequest = "درخواست اشتباه";
    public const string Forbidden = "درخواست فاقد مجوز";
    public const string NotFound = "درخواست یافت نشد";
    public const string InternalServerError = "خطای داخلی";
    public const string InviteCode = "کد دعوت";
}

public static class Message
{
    public const string EditProfileSuccess = "پروفایل شما با موفقیت ویرایش شد.";
    public const string LikeTourSuccess = "تور مورد نظر به لیست علاقه مندی ها اضافه شد.";
    public const string EditProfileFail = "خطایی در ویرایش پروفایل بوجود آمد!";
    public const string RequiredError = "{0} الزامی می باشد.";
    public const string MaxLengthError = "{0} نمی تواند بیشتر از {1} کارکتر باشد.";
    public const string MinLengthError = "{0} نمی تواند کمتر از {1} کارکتر باشد.";
    public const string EmailAddressError = "مقدار وارد شده، یک {0} معتبر نیست.";
    public const string EntityNotFound = "{0} یافت نشد.";
    public const string UserNameOrPhoneNumberIsDuplicate = "نام کاربری انتخاب شده یا شماره تماس وارد شده، تکراری می باشد.";
    public const string PasswordDoesNotMatch = "کلمه عبور با تکرار آن مطابقت ندارد.";
    public const string TourDuration = "{0} شب و {1} روز";
    public const string YouAreNotLogin = "شما وارد حساب کاربری خود نشده اید.";
    public const string InternalServerError = "خطایی رخ داده است.";
    public const string Success = "موفق";
    public const string YouAlreadyLikeTour = "شما قبلا این تور را به لیست علاقه مندی ها اضافه کرده اید.";

    public static string Format(string text, params object[] values)
    {
        return string.Format(text, values);
    }
}