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
    public class DirectoryService : IDirectoryService
    {
        private readonly InsuranceCompanyDbContext _context;

        private readonly IContractService _serviceContract;

        public DirectoryService(InsuranceCompanyDbContext context, IContractService serviceContract)
        {
            _context = context;
            _serviceContract = serviceContract;
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<DirectoryPageViewModel> GetDirectories(DirectoryGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<DirectoryViewModel> GetDirectory(DirectoryGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateDirectory(DirectorySetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateDirectory(DirectorySetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteDirectory(DirectoryGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
