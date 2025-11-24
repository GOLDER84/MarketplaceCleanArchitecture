using Marketplace.Domain;

namespace Marketplace.Application.Interfaces
{
    public interface IUserSessionService
    {
        User? GetCurrentUser();
        void SetCurrentUser(User? user);
    }
}