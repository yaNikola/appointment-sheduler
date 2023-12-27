using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class UserRepository : IUserRepository
    {
        private SchedulerDbContext context;

        public UserRepository(SchedulerDbContext context)
        {
            this.context = context;
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }


        public IEnumerable<User> GetAll()
        {
            return context.Users.AsNoTracking().ToList();
        }

        public User GetUserById(int userId)
        {
            return context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
        }

        public Task<User> GetUserByLoginAsync(string login)
        {
            return context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public User GetUserByLogin(string login)
        {
            return context.Users.FirstOrDefault(x => x.Login == login);
        }

        public List<User> GetUsersByArrId(int[] arr)
        {
            var _users = new List<User>();
            foreach (var item in arr)
            {
                _users.Add(GetUserById(item));
            }

            return _users;
        }

        public int[] GetIdByListOfUsers(List<User> users)
        {
            var idArr = new int[users.Count];
            for (int i = 0; i < users.Count; i++)
            {
                idArr[i] = users[i].Id;
            }

            return idArr;
        }

        public void Save(User user)
        {
            if (user.Id == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                context.Entry(user).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
