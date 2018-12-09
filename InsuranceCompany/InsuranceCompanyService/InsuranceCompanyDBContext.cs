using InsuranceCompanyModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyService
{
    [Table("InsuranceCompanyDataBase")]
    public class InsuranceCompanyDbContext:DbContext
    {
        public InsuranceCompanyDbContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Accountant> Accountants { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<InsuranceCase> InsuranceCases { get; set; }
    }
}
