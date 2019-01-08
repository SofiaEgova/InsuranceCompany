using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Получение списка комиссионных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model);

        /// <summary>
        /// Получение списка зарплат
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model);

        /// <summary>
        /// Получение списка договоров
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model);

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<UserPageViewModel> GetUsers(UserGetBindingModel model);

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<UserViewModel> GetUser(UserGetBindingModel model);

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateUser(UserSetBindingModel model);

        /// <summary>
		/// Изменение пользователя
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateUser(UserSetBindingModel model);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteUser(UserGetBindingModel model);
    }
}
