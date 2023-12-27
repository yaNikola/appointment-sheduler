using BusinessLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Helpers;
using PresentationLayer.Models.Edit;
using PresentationLayer.Models.View;
using PresentationLayer.Services.Interfaces;

namespace PresentationLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private static DataManager _dataManager;
        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public UserViewModel GetUserViewModel(int userId)
        {
            var _user = _dataManager.UserRepository.GetUserById(userId);

            var _userViewModel = new UserViewModel()
            {
                Id = _user.Id,
                Login = _user.Login,
                Email = _user.Email,
                Name = _user.Name,
                Surname = _user.Surname
            };

            return _userViewModel;
        }

        public UserEditModel GetUserEditModel(int userId = 0)
        {
            var _user = _dataManager.UserRepository.GetUserById(userId);

            var _userEditModel = new UserEditModel()
            {
                Id = _user.Id,
                Login = _user.Login,
                Password = _user.Password,
                Email = _user.Email,
                Name = _user.Name,
                Surname = _user.Surname
            };

            return _userEditModel;
        }

        public UserViewModel SaveUserEditModelToDb(UserEditModel userEditModel)
        {
            User _user;
            if (userEditModel.Id != 0)
            {
                _user = _dataManager.UserRepository.GetUserById(userEditModel.Id);
            }
            else
            {
                _user = new User();
            }
            _user.Login = userEditModel.Login;
            _user.Password = HashPasswordHelper.HashPassword(userEditModel.Password);
            _user.Email = userEditModel.Email;
            _user.Name = userEditModel.Name;
            _user.Surname = userEditModel.Surname;

            _dataManager.UserRepository.Save(_user);

            return GetUserViewModel(_user.Id);
        }

        public User Create(RegisterViewModel registerViewModel)
        {
            var _user = new User();

            _user.Login = registerViewModel.Login;
            _user.Password = HashPasswordHelper.HashPassword(registerViewModel.Password);
            _user.Email = registerViewModel.Email;
            _user.Name = registerViewModel.Name;
            _user.Surname = registerViewModel.Surname;
            _user.Role = Role.User;

            _dataManager.UserRepository.Save(_user);

            return _user;
        }

        public UserEditModel CreateUserEditModel()
        {
            return new UserEditModel();
        }

        public static Role GetRole(string login)
        {
            var user = _dataManager.UserRepository.GetUserByLogin(login);
            return user.Role;
        }
    }
}
