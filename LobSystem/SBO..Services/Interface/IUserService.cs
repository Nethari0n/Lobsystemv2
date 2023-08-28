using Lobsystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface IUserService
    {
        #region User

        //User GetUserLogin(string username, string password);

        List<User> UserPagination(int page, int totalItem);

        List<User> GetAllUsers();

        List<User> SearchUser(int page, int totalItem, string search);

        string GetUsernameByID(string id);

        bool UserExists(string username, string name, string oldUsername, string oldName);

        bool UserExists(string username, string name);

        #endregion

        #region Role

        //List<Role> GetAllRoles();

        //Role GetRoleByRoleID(string id);

        #endregion

        #region HashAndSalt
        string CreateSalt();
        string GenerateHash(string password, string salt);
        bool PasswordAreEqual(string plainTextPassword, string hashedPassword, string salt);
        #endregion
    }
}
