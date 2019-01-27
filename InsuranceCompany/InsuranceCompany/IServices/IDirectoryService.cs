using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IDirectoryService
    {
        /// <summary>
        /// Получение списка договоров
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model);

        /// <summary>
        /// Получение списка расчетов
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<DirectoryPageViewModel> GetDirectories(DirectoryGetBindingModel model);

        /// <summary>
        /// Получение расчета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<DirectoryViewModel> GetDirectory(int type, int term);

        /// <summary>
        /// Получение расчета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<DirectoryViewModel> GetDirectory(DirectoryGetBindingModel model);

        /// <summary>
        /// Создание нового расчета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateDirectory(DirectorySetBindingModel model);

        /// <summary>
		/// Изменение расчета
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateDirectory(DirectorySetBindingModel model);

        /// <summary>
        /// Удаление расчета
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteDirectory(DirectoryGetBindingModel model);
    }
}
