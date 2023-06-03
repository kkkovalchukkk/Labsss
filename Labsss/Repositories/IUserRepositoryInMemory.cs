// IUserRepositoryInMemory.cs
using System.Collections.Generic;
using Labsss.Models;

namespace Labsss.Data
{
    public interface IUserRepositoryInMemory
    {
        List<User> GetData();
        User GetData(int id);
        void Add(User user);
        void Delete(int id);
        void Edit(User user);
    }
}