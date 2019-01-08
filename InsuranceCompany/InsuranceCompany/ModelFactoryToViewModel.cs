using InsuranceCompany.Models;
using InsuranceCompany.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany
{
    public static class ModelFactoryToViewModel
    {
        public static ClientViewModel CreateClientViewModel(Client entity)
        {
            return new ClientViewModel
            {
                Id = entity.Id,
                FullName = entity.FullName,
                PassportNumber = entity.PassportNumber,
                PassportSeria = entity.PassportSeria
            };
        }

        public static ComissionViewModel CreateComissionViewModel(Comission entity)
        {
            return new ComissionViewModel
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Date = entity.Date,
                UserId = entity.UserId
            };
        }

        public static ContractViewModel CreateContractViewModel(Contract entity)
        {
            return new ContractViewModel
            {
                Id = entity.Id,
                Amount = entity.Amount,
                ClientId = entity.ClientId,
                Date = entity.Date,
                DirectoryId = entity.DirectoryId,
                ExpirationDate = entity.ExpirationDate,
                Status = entity.Status,
                Type = entity.Type,
                UserId = entity.UserId
            };
        }

        public static DirectoryViewModel CreateDirectoryViewModel(Directory entity)
        {
            return new DirectoryViewModel
            {
                Id = entity.Id,
                DamageAmount = entity.DamageAmount,
                InsuranceFee = entity.InsuranceFee
            };
        }

        public static InsuranceCaseViewModel CreateInsuranceCaseViewModel(InsuranceCase entity)
        {
            return new InsuranceCaseViewModel
            {
                Id = entity.Id,
                Amount = entity.Amount,
                ContractId = entity.ContractId,
                Date = entity.Date
            };
        }

        public static SalaryViewModel CreateSalaryViewModel(Salary entity)
        {
            return new SalaryViewModel
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Date = entity.Date,
                UserId = entity.UserId
            };
        }

        public static UserViewModel CreateUserViewModel(User entity)
        {
            return new UserViewModel
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Login = entity.Login,
                Password = entity.Password,
                UserRole = entity.UserRole
            };
        }
    }
}
