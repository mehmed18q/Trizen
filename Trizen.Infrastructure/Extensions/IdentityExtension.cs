using System.Security.Claims;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Infrastructure.Extensions
{
    public static class IdentityExtension
    {
        public static string GetFullName(this ClaimsPrincipal? User)
        {
            string fullName = User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.FullName)?.Value ?? Resource.GuestUser;

            return fullName;
        }

        public static int GetUserId(this ClaimsPrincipal? User)
        {
            _ = int.TryParse(User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.UserId)?.Value ?? "0", out int userId);

            return userId;
        }

        public static string GetUserProfileImage(this ClaimsPrincipal? User)
        {
            string profileImage = User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.ProfileImage)?.Value ?? Resource.NoPhotoImage;

            return profileImage;
        }

        public static bool CheckRole(this ClaimsPrincipal? User, UserRoles role)
        {
            _ = int.TryParse(User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.Role)?.Value ?? "0", out int userRole);

            return userRole.ToEnum<UserRoles>() == role;
        }

        public static bool IsProfileCompleted(this ClaimsPrincipal? User)
        {
            _ = bool.TryParse(User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.IsProfileCompleted)?.Value ?? "false", out bool status);

            return status;
        }

        public static int? GetPersonality(this ClaimsPrincipal? User)
        {
            int? personalityId = null;
            string? claim = User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.Personality)?.Value;
            if (claim.IsNotEmpty())
            {
                personalityId = int.Parse(claim!);
            }

            return personalityId;
        }

        public static DateTime? GetBirthDate(this ClaimsPrincipal? User)
        {
            DateTime? birthDate = null;
            string? claim = User?.Claims?.FirstOrDefault(claim => claim.Type == IdentityClaims.BirthDate)?.Value;
            if (claim.IsNotEmpty())
            {
                birthDate = DateTime.Parse(claim!);
            }

            return birthDate;
        }

        public static int? GetAge(this ClaimsPrincipal? User)
        {
            DateTime? birthDate = User.GetBirthDate();
            if (birthDate.HasValue)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate.Value.Date > today.AddYears(-age)) { }

                return age;
            }
            return null;
        }

        public static bool CompareAge(this ClaimsPrincipal? User, int? min, int? max)
        {
            int age = User.GetAge() ?? 0;
            return (min ?? age) <= age && (max ?? age) >= age;
        }
    }
}
