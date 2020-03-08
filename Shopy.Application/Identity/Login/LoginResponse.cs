using Shopy.Application.Models;

namespace Shopy.Application.Identity.Login
{
    public class IdentityLoginResponse : Response<Models.LoginResponse>
    {
        public IdentityLoginResponse(Models.LoginResponse result) : base(result)
        {
        }
    }
}
