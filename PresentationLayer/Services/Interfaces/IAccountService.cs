using DataLayer.Entities;
using PresentationLayer.Models.View;
using PresentationLayer.Response;
using System.Security.Claims;

namespace PresentationLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        public Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
        public ClaimsIdentity Authenticate(User user);
    }
}
