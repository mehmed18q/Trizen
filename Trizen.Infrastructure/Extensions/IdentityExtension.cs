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
    }
}
