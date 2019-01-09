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
            _serviceContract = serviceContract;
            _serviceSalary = serviceSalary;
        }

        public ResultService<ComissionPageViewModel> GetComissions(ComissionGetBindingModel model)
        {
            return _serviceComission.GetComissions(model);
        }

        public ResultService<SalaryPageViewModel> GetSalaries(SalaryGetBindingModel model)
        {
            return _serviceSalary.GetSalaries(model);
        }

        public ResultService<ContractPageViewModel> GetContracts(ContractGetBindingModel model)
        {
            return _serviceContract.GetContracts(model);
        }

        public ResultService<UserPageViewModel> GetUsers(UserGetBindingModel model)
        {
            try
            {
                int countPages = 0;
                var query = _context.Users.AsQueryable();

                query = query.OrderBy(c => c.FullName);

                if (model.PageNumber.HasValue && model.PageSize.HasValue)
                {
                    countPages = (int)Math.Ceiling((double)query.Count() / model.PageSize.Value);
                    query = query
                                .Skip(model.PageSize.Value * model.PageNumber.Value)
                                .Take(model.PageSize.Value);
                }

                var result = new UserPageViewModel
                {
                    MaxCount = countPages,
                    List = query.Select(ModelFactoryToViewModel.CreateUserViewModel).ToList()
                };

                return ResultService<UserPageViewModel>.Success(result);
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<UserPageViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<UserPageViewModel>.Error(ex);
            }
        }

        public ResultService<UserViewModel> GetUser(UserGetBindingModel model)
        {
            try
            {
                var entity = _context.Users
                                .FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService<UserViewModel>.Error("Error:", "Entity not found");
                }

                return ResultService<UserViewModel>.Success(ModelFactoryToViewModel.CreateUserViewModel(entity));
            }
            catch (DbEntityValidationException ex)
            {
                return ResultService<UserViewModel>.Error(ex);
            }
            catch (Exception ex)
            {
                return ResultService<UserViewModel>.Error(ex);
            }
        }

        public ResultService CreateUser(UserSetBindingModel model)
        {
            try
            {
                var entity = ModelFacotryFromBindingModel.CreateUser(model);

                _context.Users.Add(entity);
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

        public ResultService UpdateUser(UserSetBindingModel model)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                entity = ModelFacotryFromBindingModel.CreateUser(model, entity);

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

        public ResultService DeleteUser(UserGetBindingModel model)
        {
            try
            {
                var entity = _context.Users.FirstOrDefault(c => c.Id == model.Id);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }
                _context.Users.Remove(entity);
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

        public ResultService GetActiveUser()
        {
            try
            {
                var entity = _context.Users
                                .FirstOrDefault(c => c.IsActive==true);
                if (entity == null)
                {
                    return ResultService.Error("Error:", "Entity not found");
                }

                return ResultService.Success(ModelFactoryToViewModel.CreateUserViewModel(entity));
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
