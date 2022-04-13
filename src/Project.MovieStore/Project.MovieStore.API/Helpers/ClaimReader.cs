using Project.MovieStore.Application.Authentication;
using System.Security.Claims;

namespace Project.MovieStore.API.Helpers
{
    public static class ClaimReader
    {
        public static int ReadUserId(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claims = identity.Claims;
            
            int.TryParse(identity.FindFirst(nameof(ClaimType.Id)).Value, out int id);

            return id;

        }
    }
}
