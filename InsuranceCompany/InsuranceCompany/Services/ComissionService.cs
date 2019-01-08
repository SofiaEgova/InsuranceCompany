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
    public class ComissionService : IComissionService
    {
        private readonly InsuranceCompanyDbContext _context;

        public ComissionService(InsuranceCompanyDbContext context)
        {
            _context = context;
        }

        public ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Comissions.AsQueryable();

                query = query.OrderBy(c => c.Date);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                query = query.Include(c => c.User);

                var result = new ComissionPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateComissionViewModel).ToList()
                };

                return ResultService<ComissionPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ComissionPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ComissionPageViewModel>.Error(ex);
            }
        }

        public ResultService<ComissionViewModel> GetComission(ComissionGetBindingModel model)
        {
            try
            {
                var entity = _context.Comissions
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<ComissionViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<ComissionViewModel>.Success(ModelFactoryToViewModel.CreateComissionViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<ComissionViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<ComissionViewModel>.Error(ex);
            }
        }

        public ResultService CreateComission(ComissionSetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateComission(model);

                _context.Comissions.Add(entity);
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

        public ResultService UpdateComission(ComissionSetBindingModel model)
        {
            try
            {
                var entity = _context.Comissions.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateComission(model, entity);

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

        public ResultService DeleteComission(ComissionGetBindingModel model)
        {
            try
            {
                var entity = _context.Comissions.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Comissions.Remove(entity);
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
