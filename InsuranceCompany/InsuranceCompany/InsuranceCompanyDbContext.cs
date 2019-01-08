using InsuranceCompany.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany
{
    [Table("InsuranceCompanyDatabase")]
    public class InsuranceCompanyDbContext : DbContext
    {
        public InsuranceCompanyDbContext() : base("InsuranceCompanyDatabase")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comission> Comissions { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Directory> Directories { get; set; }
        public virtual DbSet<InsuranceCase> InsuranceCases { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
