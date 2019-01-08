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
    public class ClientService : IClientService
    {
        private readonly InsuranceCompanyDbContext _context;

        private readonly IContractService _serviceContract;

        public ClientService(InsuranceCompanyDbContext context, IContractService serviceContract)
        {
            _context = context;
            _serviceContract = serviceContract;
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ClientPageViewModel> GetClients(ClientGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ClientViewModel> GetClient(ClientGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateClient(ClientSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateClient(ClientSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteClient(ClientGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
