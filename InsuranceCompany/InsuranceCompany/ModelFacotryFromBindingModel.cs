using InsuranceCompany.BindingModels;
using InsuranceCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany
{
    public static class ModelFacotryFromBindingModel
    {
        public static Client CreateClient(ClientSetBindingModel model, Client entity = null)
        {
            if (entity == null)
            {
                entity = new Client();
            }
            entity.FullName = model.FullName;
            entity.PassportNumber = model.PassportNumber;
            entity.PassportSeria = model.PassportSeria;

            return entity;
        }

        public static Comission CreateComission(ComissionSetBindingModel model, Comission entity = null)
        {
            if (entity == null)
            {
                entity = new Comission();
            }
            entity.Amount = model.Amount;
            entity.Date = model.Date;
            entity.UserId = model.UserId;

            return entity;
        }

        public static Contract CreateContract(ContractSetBindingModel model, Contract entity = null)
        {
            if (entity == null)
            {
                entity = new Contract();
            }
            entity.Amount = model.Amount;
            entity.ClientId = model.ClientId;
            entity.Date = model.Date;
            entity.DirectoryId = model.DirectoryId;
            entity.ExpirationDate = model.ExpirationDate;
            entity.Status = model.Status;
            entity.Type = model.Type;
            entity.UserId = model.UserId;

            return entity;
        }

        public static Directory CreateDirectory(DirectorySetBindingModel model, Directory entity = null)
        {
            if (entity == null)
            {
                entity = new Directory();
            }
            entity.DamageAmount = model.DamageAmount;
            entity.InsuranceFee = model.InsuranceFee;

            return entity;
        }

        public static InsuranceCase CreateInsuranceCase(InsuranceCaseSetBindingModel model, InsuranceCase entity = null)
        {
            if (entity == null)
            {
                entity = new InsuranceCase();
            }
            entity.Amount = model.Amount;
            entity.ContractId = model.ContractId;
            entity.Date = model.Date;

            return entity;
        }

        public static Salary CreateSalary(SalarySetBindingModel model, Salary entity = null)
        {
            if (entity == null)
            {
                entity = new Salary();
            }
            entity.Amount = model.Amount;
            entity.Date = model.Date;
            entity.UserId = model.UserId;

            return entity;
        }

        public static User CreateUser(UserSetBindingModel model, User entity = null)
        {
            if (entity == null)
            {
                entity = new User();
            }
            entity.FullName = model.FullName;
            entity.Login = model.Login;
            entity.Password = model.Password;
            entity.UserRole = model.UserRole;
            entity.IsActive = model.IsActive;

            return entity;
        }
    }
}
