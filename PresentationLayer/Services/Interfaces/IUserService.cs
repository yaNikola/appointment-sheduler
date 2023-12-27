using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Models.Edit;
using PresentationLayer.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services.Interfaces
{
    public interface IUserService
    {
        public UserViewModel GetUserViewModel(int userId);
        public UserEditModel GetUserEditModel(int userId = 0);
        public UserViewModel SaveUserEditModelToDb(UserEditModel userEditModel);
        public UserEditModel CreateUserEditModel();
        public User Create(RegisterViewModel registerViewModel);
    }
}
