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
            return _serviceContract.GetContracts(model);
        }

        public ResultService<DirectoryPageViewModel> GetDirectories(DirectoryGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Directories.AsQueryable();

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                var result = new DirectoryPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateDirectoryViewModel).ToList()
                };

                return ResultService<DirectoryPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<DirectoryPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<DirectoryPageViewModel>.Error(ex);
            }
        }

        public ResultService<DirectoryViewModel> GetDirectory(int type, int term)
        {
            try
            {
                var entity = _context.Directories
                                .FirstOrDefault(c => c.InsuranceTerm==term&&c.InsuranceType==type);
                if (entity == null)
                {
                    return ResultService<DirectoryViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<DirectoryViewModel>.Success(ModelFactoryToViewModel.CreateDirectoryViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<DirectoryViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<DirectoryViewModel>.Error(ex);
            }
        }

        public ResultService CreateDirectory(DirectorySetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateDirectory(model);

                _context.Directories.Add(entity);
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

        public ResultService UpdateDirectory(DirectorySetBindingModel model)
        {
            try
            {
                var entity = _context.Directories.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateDirectory(model, entity);

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

        public ResultService DeleteDirectory(DirectoryGetBindingModel model)
        {
            try
            {
                var entity = _context.Directories.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Directories.Remove(entity);
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

        public ResultService<DirectoryViewModel> GetDirectory(DirectoryGetBindingModel model)
        {
            try
            {
                var entity = _context.Directories
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<DirectoryViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<DirectoryViewModel>.Success(ModelFactoryToViewModel.CreateDirectoryViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<DirectoryViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<DirectoryViewModel>.Error(ex);
            }
        }
    }
}
