using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApI.DAL.Interfaces;
using UserManagementApI.Services.Interfaces;
using UserManagementApI.UserModels;

namespace UserManagementApI.Services.Implementation
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<ResponseMessage> RegisterUser(UserModel model)
        {
            var result =await userRepository.RegisterUser(model);
            return result;
        }

        public async Task<bool> BlockUser(ActivateUserModel model)
        {
            var result = await userRepository.BlockUser(model);
            return result;
        }
        public async Task<List<UserModel>> GetAllHospitalUsers()
        {
            var result = await userRepository.GetAllHospitalUsers();
            return result;
        }
        public async Task<RoleModel> GetRolesById(int userId)
        {
            var result = await userRepository.GetRolesById(userId);
            return result;
        }
        public async Task<RoleModel> GetRolesByEmail(string email)
        {
            var result = await userRepository.GetRolesByEmail(email);
            return result;
        }
        

        public async Task<bool> ActivateUser(ActivateUserModel model)
        {
            var result = await userRepository.ActivateUser(model);
            return result;
        }

        public async Task<ResponseMessage> UpdateUser(UserModel model)
        {
            var result = await userRepository.UpdateUser(model);
            return result;
        }

        
        public async Task<List<RoleModel>> GetAllRoles()
        {
            var result = await userRepository.GetAllRoles();
            return result;
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public async Task<ResponseMessage> ChangePassword(LoginModel model)
        {
            var result = await userRepository.ChangePassword(model);
            return result;
        }

        public async Task<ResponseMessage> ForgotPassword(string email)
        {
            var result = await userRepository.ForgotPassword(email);
            return result;
        }

        

        public async Task<List<UserModel>> GetUser(int userId)
        {
            var result = await userRepository.GetUser(userId);
            return result;
        }
    }
}
