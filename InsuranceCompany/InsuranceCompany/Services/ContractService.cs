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
    public class ContractService : IContractService
    {
        private readonly InsuranceCompanyDbContext _context;

        private readonly IInsuranceCaseService _serviceInsuranceCase;

        public ContractService(InsuranceCompanyDbContext context, IInsuranceCaseService serviceInsuranceCase)
        {
            _context = context;
            _serviceInsuranceCase = serviceInsuranceCase;
        }

        public ResultService<InsuranceCasePageViewModel> GetInsuranceCases(InsuranceCaseGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ContractViewModel> GetContract(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateContract(ContractSetBindingModel model)
        {
            throw new NotImplementedException();
        }
        
        public ResultService UpdateContract(ContractSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteContract(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
