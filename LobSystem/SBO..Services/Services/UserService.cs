using Microsoft.EntityFrameworkCore;
using SBO.Lobsystem.Domain.Data;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.ExtensionMethods;
using SBO.LobSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SBO.LobSystem.Services.Services
{
    public class UserService : IUserService
    {
        readonly ApplicationDBContext _lobsContext;
        public UserService(ApplicationDBContext lobsContext)
        {
            _lobsContext = lobsContext;
        }


        #region User


        public List<User> UserPagination(int page, int totalItem) => _lobsContext.Users
            .Where(e => e.IsDeleted == false)
            //.Include(e => e)
            .Paging(page, totalItem).AsNoTracking().ToList();

        public List<User> SearchUser(int page, int totalItem, string search) => _lobsContext.Users
            .Where(x => x.UserName.Contains(search) || x.Name.Contains(search) && x.IsDeleted == false)
            //.Include(e => e.Role)
            .Paging(page, totalItem)
            .AsNoTracking().ToList();

        public List<User> GetAllUsers() => _lobsContext.Users.Where(e => e.IsDeleted == false).AsNoTracking().ToList();

        public void DeleteUser(string ID)
        {
            User user = _lobsContext.Users.Where(c => c.Id == ID).AsNoTracking().FirstOrDefault();

            user.IsDeleted = true;

            _lobsContext.Users.Update(user);
            _lobsContext.SaveChanges();
        }

        public bool UserExists(string username, string name, string oldUsername, string oldName)
        {
            bool exists = false;

            if ( username != oldUsername && name != oldName )
            {
                User userNameCheck = _lobsContext.Users.Where(c => c.UserName == username && c.IsDeleted == false).AsNoTracking().FirstOrDefault();
                User NameCheck = _lobsContext.Users.Where(c => c.Name == name && c.IsDeleted == false).AsNoTracking().FirstOrDefault();

                if ( userNameCheck != null || NameCheck != null )
                {
                    exists = true;
                }
            }

            return exists;
        }

        public bool UserExists(string username, string name)
        {
            bool exists = false;

            User userNameCheck = _lobsContext.Users.Where(c => c.UserName == username && c.IsDeleted == false).AsNoTracking().FirstOrDefault();
            User NameCheck = _lobsContext.Users.Where(c => c.Name == name && c.IsDeleted == false).AsNoTracking().FirstOrDefault();

            if ( userNameCheck != null || NameCheck != null )
            {
                exists = true;
            }
            return exists;
        }

        public string GetUsernameByID(string id) => _lobsContext.Users.Where(x => x.Id == id).AsNoTracking().FirstOrDefault().Name;

        #endregion

        #region Role

        //public void AddRole(string roles)
        //{
        //    Role role = new();

            

        //    _lobsContext.Roles.Add(role);
        //    _lobsContext.SaveChanges();
        //}

        //public void UpdateRole(Role roles)
        //{
        //    Role role = _lobsContext.Roles.Where(c => c.Id == roles.Id).AsNoTracking().FirstOrDefault();

        //    role.RoleName = roles.RoleName;

        //    _lobsContext.Roles.Update(role);
        //    _lobsContext.SaveChanges();
        //}

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            List<IdentityRole> list = await _lobsContext.Roles.ToListAsync();
           
            return list;
        }

        public  List<IdentityRole> RolePagination(int page, int totalItem)
        {
            var list =  _lobsContext.Roles.Paging(page,totalItem).ToList();
            return list;
        }

        //public Role GetRoleByRoleID(string id)
        //{
        //    var role = _lobsContext.Roles.Where(c => c.Id == id).AsNoTracking().FirstOrDefault();
        //    Role roleDTO = new Role
        //    {
        //        Id = role.Id,
        //        RoleName = role.RoleName
        //    };
        //    return roleDTO;
        //}

        #endregion

        #region HashAndSalt
        public string CreateSalt()
        {
            int size = 13; //Size of the salt, toke a random number.
            RNGCryptoServiceProvider rngC = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rngC.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string GenerateHash(string password, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool PasswordAreEqual(string plainTextPassword, string hashedPassword, string salt)
        {
            string newHashedPin = GenerateHash(plainTextPassword, salt);
            return newHashedPin.Equals(hashedPassword);
        }

        #endregion
    }
}
