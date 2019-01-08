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
    public class ComissionService : IComissionService
    {
        private readonly InsuranceCompanyDbContext _context;

        public ComissionService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService<ComissionViewModel> GetComission(ComissionGetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService CreateComission(ComissionSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService UpdateComission(ComissionSetBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultService DeleteComission(ComissionGetBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
