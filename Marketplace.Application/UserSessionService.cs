using Marketplace.Application.Interfaces;
using Marketplace.Domain;

namespace Marketplace.Application
{
    public class UserSessionService : IUserSessionService
    {
        private User? _currentUser;

        public User? GetCurrentUser()
        {
            return _currentUser;
        }

        public void SetCurrentUser(User? user)
        {
            _currentUser = user;
        }
    }
}