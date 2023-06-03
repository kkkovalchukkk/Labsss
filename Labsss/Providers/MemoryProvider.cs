// MemoryProvider.cs
using System.Collections.Generic;
using Labsss.Models;

namespace Labsss.Data
{
    public class MemoryProvider
    {
        public List<User> Users { get; set; }

        public MemoryProvider()
        {
            Users = new List<User>();
        }
    }
}
