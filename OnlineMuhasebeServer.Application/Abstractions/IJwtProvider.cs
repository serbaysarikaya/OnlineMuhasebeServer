using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsyn(AppUser user, List<string> roles);
    }
}
