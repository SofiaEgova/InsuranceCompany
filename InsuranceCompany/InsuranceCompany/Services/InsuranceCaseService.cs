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
    public class InsuranceCaseService : IInsuranceCaseService
    {
        private readonly InsuranceCompanyDbContext _context;

        public InsuranceCaseService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<InsuranceCasePageViewModel> GetInsuranceCases(InsuranceCaseGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.InsuranceCases.AsQueryable();

                query = query.OrderBy(c => c.Date);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                query = query.Include(c => c.Contract);

                var result = new InsuranceCasePageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateInsuranceCaseViewModel).ToList()
                };

                return ResultService<InsuranceCasePageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<InsuranceCasePageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<InsuranceCasePageViewModel>.Error(ex);
            }
        }

        public ResultService<InsuranceCaseViewModel> GetInsuranceCase(InsuranceCaseGetBindingModel model)
        {
            try
            {
                var entity = _context.InsuranceCases
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<InsuranceCaseViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<InsuranceCaseViewModel>.Success(ModelFactoryToViewModel.CreateInsuranceCaseViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<InsuranceCaseViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<InsuranceCaseViewModel>.Error(ex);
            }
        }

        public ResultService CreateInsuranceCase(InsuranceCaseSetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateInsuranceCase(model);

                _context.InsuranceCases.Add(entity);
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

        public ResultService UpdateInsuranceCase(InsuranceCaseSetBindingModel model)
        {
            try
            {
                var entity = _context.InsuranceCases.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateInsuranceCase(model, entity);

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

        public ResultService DeleteInsuranceCase(InsuranceCaseGetBindingModel model)
        {
            try
            {
                var entity = _context.InsuranceCases.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.InsuranceCases.Remove(entity);
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
