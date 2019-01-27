using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IClientService
    {
        /// <summary>
        /// Получение списка договоров
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model);

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ClientPageViewModel> GetClients(ClientGetBindingModel model);

        /// <summary>
        /// Получение клиента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ClientViewModel> GetClient(ClientGetBindingModel model);

        /// <summary>
        /// Создание нового клиента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateClient(ClientSetBindingModel model);

        /// <summary>
		/// Изменение клиента
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateClient(ClientSetBindingModel model);

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteClient(ClientGetBindingModel model);

        /// <summary>
        /// Выборка по сумме
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ClientPageViewModel> GetClientsBySum(ClientGetBindingModel model);

        /// <summary>
        /// Выборка по дате
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ClientPageViewModel> GetClientsByDate(ClientGetBindingModel model);

        /// <summary>
        /// Выборка по номеру
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ClientPageViewModel> GetClientsByNumber(ClientGetBindingModel model, int number);
    }
}
