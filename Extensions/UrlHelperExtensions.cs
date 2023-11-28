using Microsoft.AspNetCore.Mvc;

namespace Try.Extensions
{
    public static class UrlHelperExtensions
    {
        // extensao IUrlHelper
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return $"{scheme}://localhost:11447/api/AuthManagement/resetPassword?userId={userId}&code={code}";
        }
    }
}
