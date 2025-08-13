using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommBank.Models;
using CommBank.Services;

namespace CommBank.Tests
{
    public class FakeUsersService : IUsersService
{
    private readonly List<User> _users;

    public FakeUsersService(List<User> users, User user)
    {
        _users = users;
    }

    public Task<User?> CreateAsync(User user)
    {
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task<List<User>> GetAsync()
    {
        return Task.FromResult(_users);
    }

    public Task<User?> GetAsync(string id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<bool> RemoveAsync(string id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _users.Remove(user);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<User?> UpdateAsync(string id, User updatedUser)
    {
        var userIndex = _users.FindIndex(u => u.Id == id);
        if (userIndex >= 0)
        {
            _users[userIndex] = updatedUser;
            return Task.FromResult(updatedUser);
        }
        return Task.FromResult<User?>(null);
    }

        Task IUsersService.CreateAsync(User newUser)
        {
            return CreateAsync(newUser);
        }

        Task IUsersService.RemoveAsync(string id)
        {
            return RemoveAsync(id);
        }

        Task IUsersService.UpdateAsync(string id, User updatedUser)
        {
            return UpdateAsync(id, updatedUser);
        }
    }

}
