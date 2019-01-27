using InsuranceCompany.BindingModels;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            return _serviceInsuranceCase.GetInsuranceCases(model);
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Contracts.AsQueryable();

                query = query.OrderBy(c => c.Date);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                query = query.Include(c => c.User);
                query = query.Include(c => c.Client);
                query = query.Include(c => c.Directory);

                var result = new ContractPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateContractViewModel).ToList()
                };

                return ResultService<ContractPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ContractPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ContractPageViewModel>.Error(ex);
            }
        }

        public ResultService<ContractViewModel> GetContract(ContractGetBindingModel model)
        {
            try
            {
                var entity = _context.Contracts
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<ContractViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<ContractViewModel>.Success(ModelFactoryToViewModel.CreateContractViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ContractViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ContractViewModel>.Error(ex);
            }
        }

        public ResultService CreateContract(ContractSetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateContract(model);

                _context.Contracts.Add(entity);
                _context.SaveChanges();

                return ResultService.Success(entity.Id);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService.Error(ex);
            }
        }

        public ResultService UpdateContract(ContractSetBindingModel model)
        {
            try
            {
                var entity = _context.Contracts.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateContract(model, entity);

                _context.SaveChanges();

                return ResultService.Success();
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService.Error(ex);
            }
        }

        public ResultService DeleteContract(ContractGetBindingModel model)
        {
            try
            {
                var entity = _context.Contracts.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Contracts.Remove(entity);
                _context.SaveChanges();

                return ResultService.Success();
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService.Error(ex);
            }
        }

        public ResultService CloseContracts()
        {
            try
            {
                var query = _context.Contracts.AsQueryable();

                query = query.OrderBy(c => c.Date);

                foreach(var c in query)
                {
                    if (c.ExpirationDate < DateTime.Now) c.Status = 0;
                }
                _context.SaveChanges();

                var result = true;

                return ResultService.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService.Error(ex);
            }
        }
    }
}
