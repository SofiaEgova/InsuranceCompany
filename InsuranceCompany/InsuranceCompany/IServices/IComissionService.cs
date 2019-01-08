using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface IComissionService
    {
        /// <summary>
        /// Получение списка комиссионных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model);

        /// <summary>
        /// Получение комиссионных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService<ComissionViewModel> GetComission(ComissionGetBindingModel model);

        /// <summary>
        /// Создание нового значения комиссионных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService CreateComission(ComissionSetBindingModel model);

        /// <summary>
		/// Изменение комиссионных
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ResultService UpdateComission(ComissionSetBindingModel model);

        /// <summary>
        /// Удаление комиссионных
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultService DeleteComission(ComissionGetBindingModel model);
    }
}
