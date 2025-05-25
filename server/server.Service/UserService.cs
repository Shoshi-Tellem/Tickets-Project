using server.Core.Entities;
using server.Core.Repositories;
using server.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Service
{
    public class UserService(IRepositoryManager repositoryManager) : IUserService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IRepository<User> _userRepository = repositoryManager.UserRepository;

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetAsync();
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<User> AddUserAsync(User user)
        {
            User addedUser = await _userRepository.AddAsync(user);
            await _repositoryManager.SaveAsync();
            return addedUser;
        }
        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            User? existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
                return null;
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            User updatedUser = await _userRepository.UpdateAsync(existingUser);
            await _repositoryManager.SaveAsync();
            return updatedUser;
        }
        public async Task<User?> DeleteUserAsync(int id)
        {
            User? existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
                return null;
            User? deletedUser = await _userRepository.DeleteAsync(existingUser);
            await _repositoryManager.SaveAsync();
            return deletedUser;
        }
    }
}
