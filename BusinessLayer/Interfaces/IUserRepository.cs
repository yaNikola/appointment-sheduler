using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(int userId);
        public List<User> GetUsersByArrId(int[] arr);
        public int[] GetIdByListOfUsers(List<User> users);
        void Save(User user);
        void Delete(User user);
        public Task<User> GetUserByLoginAsync(string login);
        public User GetUserByLogin(string login);
    }
}
