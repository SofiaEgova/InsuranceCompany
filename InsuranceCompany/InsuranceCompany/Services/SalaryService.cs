using InsuranceCompany.BindingModels;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly InsuranceCompanyDbContext _context;

        public SalaryService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<SalaryViewModel> GetSalary(SalaryGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateSalary(SalarySetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateSalary(SalarySetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteSalary(SalaryGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
