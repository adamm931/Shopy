using MediatR;

namespace Shopy.Application.Identity.Login
{
    public class IdentityLoginRequest : IRequest<IdentityLoginResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
