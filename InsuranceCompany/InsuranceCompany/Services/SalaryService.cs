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
    public class SalaryService : ISalaryService
    {
        private readonly InsuranceCompanyDbContext _context;

        public SalaryService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Salaries.AsQueryable();

                query = query.OrderBy(c => c.Date);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                query = query.Include(c => c.User);

                var result = new SalaryPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateSalaryViewModel).ToList()
                };

                return ResultService<SalaryPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<SalaryPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<SalaryPageViewModel>.Error(ex);
            }
        }

        public ResultService<SalaryViewModel> GetSalary(SalaryGetBindingModel model)
        {
            try
            {
                var entity = _context.Salaries
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<SalaryViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<SalaryViewModel>.Success(ModelFactoryToViewModel.CreateSalaryViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<SalaryViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<SalaryViewModel>.Error(ex);
            }
        }

        public ResultService CreateSalary(SalarySetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateSalary(model);

                _context.Salaries.Add(entity);
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

        public ResultService UpdateSalary(SalarySetBindingModel model)
        {
            try
            {
                var entity = _context.Salaries.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateSalary(model, entity);

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

        public ResultService DeleteSalary(SalaryGetBindingModel model)
        {
            try
            {
                var entity = _context.Salaries.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Salaries.Remove(entity);
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
