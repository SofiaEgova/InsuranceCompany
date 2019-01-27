using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IContractService
    {
        /// <summary>
        /// Получение списка страховых случаев по контракту
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<InsuranceCasePageViewModel> GetInsuranceCases(InsuranceCaseGetBindingModel model);

        /// <summary>
        /// Получение списка контрактов
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model);

        /// <summary>
        /// Получение контракта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ContractViewModel> GetContract(ContractGetBindingModel model);

        /// <summary>
        /// Создание нового контракта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateContract(ContractSetBindingModel model);

        /// <summary>
		/// Изменение контракта
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateContract(ContractSetBindingModel model);

        /// <summary>
        /// Удаление контракта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteContract(ContractGetBindingModel model);

        /// <summary>
        /// Закрытие котрактов
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CloseContracts();
    }
}
