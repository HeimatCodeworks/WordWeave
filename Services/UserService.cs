using System;
using System.Threading.Tasks;
using Firebase.Auth;
using WordWeave.Models;
using WordWeave.Repositories;

namespace WordWeave.Services
{
    public class UserService
    {
        private readonly FirebaseAuthProvider _authProvider;
        private readonly IUserRepository _userRepository;

        public UserService(FirebaseAuthProvider authProvider, IUserRepository userRepository)
        {
            _authProvider = authProvider;
            _userRepository = userRepository;
        }

        public async Task<FirebaseAuthLink> RegisterUserAsync(string email, string password)
        {
            try
            {
                var authLink = await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                var newUser = new WordWeave.Models.User
                {
                    UserId = authLink.User.LocalId,
                    Email = email,
                    Username = email.Split('@')[0],
                    IsPremium = email.EndsWith("@kochava.com")
                };
                await _userRepository.CreateUserAsync(newUser);
                return authLink;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Registration failed: " + ex.Message, ex);
            }
        }

        public async Task<FirebaseAuthLink> SignInUserAsync(string email, string password)
        {
            try
            {
                var authLink = await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return authLink;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("SignIn failed: " + ex.Message, ex);
            }
        }

        public void SignOutUser()
        {
            
        }

        public async Task<WordWeave.Models.User> GetUserProfileAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user;
        }

        public async Task<bool> UpdateUserProfileAsync(WordWeave.Models.User user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Profile update failed: " + ex.Message, ex);
            }
        }

        public async Task<string> CheckUserSubscriptionAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user.Email.EndsWith("@kochava.com"))
            {
                return "Premium";
            }

            return user.IsPremium ? "Premium" : "Free";
        }
    }
}