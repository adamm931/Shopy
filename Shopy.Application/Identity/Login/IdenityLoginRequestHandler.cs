using Shopy.Application.Base;
using Shopy.Application.Models;
using Shopy.Core.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Identity.Login
{
    public class IdenityLoginRequestHandler : ShopyRequestHandler<IdentityLoginRequest, IdentityLoginResponse>
    {
        public IdenityLoginRequestHandler(IShopyContext context) : base(context)
        {
        }

        public override Task<IdentityLoginResponse> Handle(IdentityLoginRequest request, CancellationToken cancellationToken)
        {
            var domainResponse = new LoginResponse
            {
                IsAuthenticated = request.Username == "Admin" && request.Password == "1234"
            };

            return Task.FromResult(new IdentityLoginResponse(domainResponse));
        }
    }
}
