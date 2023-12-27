using BusinessLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using PresentationLayer.Services.Interfaces;
using Microsoft.Extensions.Logging;
using PresentationLayer;
using PresentationLayer.Helpers;
using PresentationLayer.Models.View;
using PresentationLayer.Response;
using System.Security.Claims;

namespace MeetingPlanner.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly DataManager _dataManager;
        private readonly ILogger<AccountService> _logger;
        private IUserService _userService;

        public AccountService(DataManager dataManager, ILogger<AccountService> logger, IUserService userService)
        {
            _dataManager = dataManager;
            _logger = logger;
            _userService = userService;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var user = await _dataManager.UserRepository.GetUserByLoginAsync(model.Login);
                if(user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Користувач з таким логіном вже існує"
                    };
                }

                user = _userService.Create(model);
                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Об'єкт був доданий",
                    StatusCode = StatusCode.OK
                };
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _dataManager.UserRepository.GetUserByLoginAsync(model.Login);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Користувач не знайден"
                    };
                }

                if(user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Невірний пароль"
                    };
                }

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            } catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
