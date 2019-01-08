using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IInsuranceCaseService
    {
        /// <summary>
        /// Получение списка страховых случаев
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<InsuranceCasePageViewModel> GetInsuranceCases(InsuranceCaseGetBindingModel model);

        /// <summary>
        /// Получение страхового случая
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<InsuranceCaseViewModel> GetInsuranceCase(InsuranceCaseGetBindingModel model);

        /// <summary>
        /// Создание нового страхового случая
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateInsuranceCase(InsuranceCaseSetBindingModel model);

        /// <summary>
		/// Изменение страхового случая
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateInsuranceCase(InsuranceCaseSetBindingModel model);

        /// <summary>
        /// Удаление страхового случая
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteInsuranceCase(InsuranceCaseGetBindingModel model);
    }
}
