using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class SalaryGetBindingModel
    {
        public Guid? Id { get; set; }

        public Guid? UserId { get; set; }
    }

    public class SalarySetBindingModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "required")]
        public int Amount { get; set; }
    }
}
