using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class InsuranceCaseGetBindingModel
    {
        public Guid? Id { get; set; }

        public Guid? ContractId { get; set; }
    }

    public class InsuranceCaseSetBindingModel
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }

        [Required(ErrorMessage = "required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "required")]
        public DateTime Date { get; set; }
    }
}
