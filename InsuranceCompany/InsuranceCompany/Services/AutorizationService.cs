using InsuranceCompany.BindingModels;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Services
{
    public static class AutorizationService
    {
        private static readonly InsuranceCompanyDbContext _context = new InsuranceCompanyDbContext();

        private static readonly IUserService service;

        private static Encoding ascii = Encoding.ASCII;

        private static UserViewModel _user;

        public static UserViewModel Login(string login, string password)
        {
            // переделать, чтобы хранилось по хешу
            //var passHash = GetPasswordHash(password);
            var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user == null)
            {
                throw new Exception("Введен неверный логин/пароль");
            }
            _user = ModelFactoryToViewModel.CreateUserViewModel(user);
            _user.IsActive = true;
            return _user;
        }

        //public static void Logout()
        //{
        //    _user = null;
        //}

        ///// <summary>
        ///// Смена пароля
        ///// </summary>
        ///// <param name="login"></param>
        ///// <param name="oldPassword"></param>
        ///// <param name="newPassword"></param>
        //public static void ChangePassword(string login, string oldPassword, string newPassword)
        //{
        //    var passHash = GetPasswordHash(oldPassword);
        //    var user = _context.Users.SingleOrDefault(u => u.Login == login && u.Password == passHash);
        //    if (user == null)
        //    {
        //        throw new Exception("Введен неверный логин/пароль");
        //    }
        //    user.Password = GetPasswordHash(newPassword);
        //    _context.SaveChanges();
        //}

        /// <summary>
		/// Получение хеша пароля
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		public static string GetPasswordHash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            return ascii.GetString(md5.ComputeHash(Encoding.ASCII.GetBytes(password)));
        }
    }
}
