using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface ISalaryService
    {
        /// <summary>
        /// Получение списка зарплат
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model);

        /// <summary>
        /// Получение зарплаты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<SalaryViewModel> GetSalary(SalaryGetBindingModel model);

        /// <summary>
        /// Создание новой зарплаты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateSalary(SalarySetBindingModel model);

        /// <summary>
		/// Изменение зарплаты
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateSalary(SalarySetBindingModel model);

        /// <summary>
        /// Удаление зарплаты
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteSalary(SalaryGetBindingModel model);
    }
}
