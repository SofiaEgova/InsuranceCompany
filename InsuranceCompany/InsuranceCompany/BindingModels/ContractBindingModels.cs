using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class ContractGetBindingModel
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? DirectoryId { get; set; }
    }

    public class ContractSetBindingModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ClientId { get; set; }

        public Guid DirectoryId { get; set; }

        [Required(ErrorMessage = "required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "required")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "required")]
        public int Type { get; set; }

        [Required(ErrorMessage = "required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "required")]
        public int Status { get; set; }
    }
}
