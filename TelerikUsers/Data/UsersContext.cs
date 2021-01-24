using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikUsers.Models;

namespace TelerikUsers.Data
{
    public static class UsersContext
    {
        public static List<User> Users { get; private set; }

        static UsersContext()
        {
            string[] names = new string[] { "Oleg", "Andrew", "Sergey", "Dmitriy", "Anton", "Alex", "Ivan" };
            Random rnd = new Random();
            Users = Enumerable.Range(1, 200).Select(i => new User
            {
                Id = i,
                Name = names[rnd.Next(names.Length)],
                Views = rnd.Next(100, 10000)
            }).ToList();
        }

        public static void Add(User user)
        {
            user.Id = Users.Last().Id + 1;
            Users.Add(user);
        }

        public static void Update(User user)
        {
            int index = Users.FindIndex(u => u.Id == user.Id);
            if (index < 0)
                return;
            Users[index] = user;
        }

        public static void Remove(User user) => Users.RemoveAll(u => u.Id == user.Id);
    }
}
