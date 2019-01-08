using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class ClientGetBindingModel: PageSettingBinidingModel
    {
        public Guid? Id { get; set; }
    }

    public class ClientSetBindingModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "required")]
        public int PassportNumber { get; set; }

        [Required(ErrorMessage = "required")]
        public int PassportSeria { get; set; }
    }
}
