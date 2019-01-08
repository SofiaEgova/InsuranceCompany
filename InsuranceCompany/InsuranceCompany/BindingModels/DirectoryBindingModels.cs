using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class DirectoryGetBindingModel
    {
        public Guid? Id { get; set; }
    }

    public class DirectorySetBindingModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "required")]
        public int DamageAmount { get; set; }

        [Required(ErrorMessage = "required")]
        public int InsuranceFee { get; set; }
    }
}
