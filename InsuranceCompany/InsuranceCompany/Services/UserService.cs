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
    public class UserService : IUserService
    {
        private readonly InsuranceCompanyDbContext _context;

        private readonly IComissionService _serviceComission;

        private readonly ISalaryService _serviceSalary;

        private readonly IContractService _serviceContract;

        public UserService(InsuranceCompanyDbContext context, IComissionService serviceComission, ISalaryService serviceSalary, IContractService serviceContract)
        {
            _context = context;
            _serviceComission = serviceComission;
            _serviceSalary = serviceSalary;
            _serviceContract = serviceContract;
        }

        public ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<UserPageViewModel> GetUsers(UserGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<UserViewModel> GetUser(UserGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateUser(UserSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateUser(UserSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteUser(UserGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
