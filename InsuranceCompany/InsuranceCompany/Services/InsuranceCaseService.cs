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
    public class InsuranceCaseService : IInsuranceCaseService
    {
        private readonly InsuranceCompanyDbContext _context;

        public InsuranceCaseService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<InsuranceCasePageViewModel> GetInsuranceCases(InsuranceCaseGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<InsuranceCaseViewModel> GetInsuranceCase(InsuranceCaseGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateInsuranceCase(InsuranceCaseSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateInsuranceCase(InsuranceCaseSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteInsuranceCase(InsuranceCaseGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
