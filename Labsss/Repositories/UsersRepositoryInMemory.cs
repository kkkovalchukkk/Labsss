// UsersRepositoryInMemory.cs
using System.Collections.Generic;
using Labsss.Data;
using Labsss.Models;

namespace Labsss.Repositories
{
    public class UsersRepositoryInMemory : IUserRepositoryInMemory
    {
        private readonly MemoryProvider _memoryProvider;

        public UsersRepositoryInMemory(MemoryProvider memoryProvider)
        {
            _memoryProvider = memoryProvider;
        }

        public List<User> GetData()
        {
            return _memoryProvider.Users;
        }

        public User GetData(int id)
        {
            return _memoryProvider.Users.Find(u => u.Id == id);
        }

        public void Add(User user)
        {
            _memoryProvider.Users.Add(user);
        }

        public void Edit(User user)
        {
            int index = _memoryProvider.Users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                _memoryProvider.Users[index] = user;
            }
        }

        public void Delete(int id)
        {
            User user = _memoryProvider.Users.Find(u => u.Id == id);
            if (user != null)
            {
                _memoryProvider.Users.Remove(user);
            }
        }
    }
}
