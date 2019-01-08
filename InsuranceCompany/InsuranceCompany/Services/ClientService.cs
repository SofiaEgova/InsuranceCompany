using InsuranceCompany.BindingModels;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            return _serviceContract.GetContracts(model);
        }

        public ResultService<ClientPageViewModel> GetClients(ClientGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Clients.AsQueryable();

                query = query.OrderBy(c => c.FullName);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                //query = query.Include(d => d.DisciplineBlock);    нужен там, где вверху есть еще чей-то Id

                var result = new ClientPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateClientViewModel).ToList()
                };

                return ResultService<ClientPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ClientPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ClientPageViewModel>.Error(ex);
            }
        }

        public ResultService<ClientViewModel> GetClient(ClientGetBindingModel model)
        {
            try
            {
                var entity = _context.Clients
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<ClientViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<ClientViewModel>.Success(ModelFactoryToViewModel.CreateClientViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ClientViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ClientViewModel>.Error(ex);
            }
        }

        public ResultService CreateClient(ClientSetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateClient(model);

                _context.Clients.Add(entity);
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

        public ResultService UpdateClient(ClientSetBindingModel model)
        {
            try
            {
                var entity = _context.Clients.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateClient(model, entity);

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

        public ResultService DeleteClient(ClientGetBindingModel model)
        {
            try
            {
                var entity = _context.Clients.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Clients.Remove(entity);
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
    }
}
