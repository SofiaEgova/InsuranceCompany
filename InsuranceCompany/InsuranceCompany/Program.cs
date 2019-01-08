using InsuranceCompany.Forms;
using InsuranceCompany.IServices;
using InsuranceCompany.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace InsuranceCompany
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(container.Resolve<AutorizationForm>());
            Application.Run(container.Resolve<MainForm>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, InsuranceCompanyDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientService, ClientService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComissionService, ComissionService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IContractService, ContractService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDirectoryService, DirectoryService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IInsuranceCaseService, InsuranceCaseService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISalaryService, SalaryService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            currentContainer
        .RegisterType<MainForm>()
        .RegisterInstance<IUnityContainer>(currentContainer);
            return currentContainer;
        }
    }
}
