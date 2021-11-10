using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementApI.UserModels;

namespace UserManagementApI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseMessage> RegisterUser(UserModel model);
        Task<bool> BlockUser(ActivateUserModel model);
        Task<bool> ActivateUser(ActivateUserModel model);
        Task<RoleModel> GetRolesById(int userId);
        Task<RoleModel> GetRolesByEmail(string email);
       
        Task<ResponseMessage> UpdateUser(UserModel model);
        Task<List<UserModel>> GetUser(int userId);
        Task<List<UserModel>> GetAllHospitalUsers();
        Task<List<RoleModel>> GetAllRoles();
        Task<ResponseMessage> ChangePassword(LoginModel model);
        Task<ResponseMessage> ForgotPassword(string email);
    }
}
