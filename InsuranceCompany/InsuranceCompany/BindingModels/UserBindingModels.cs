using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.BindingModels
{
    public class UserGetBindingModel : PageSettingBinidingModel
    {
        public Guid? Id { get; set; }
    }

    public class UserSetBindingModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "required")]
        public int UserRole { get; set; }

        [Required(ErrorMessage = "required")]
        public string FullName { get; set; }

        public bool IsActive { get; set; }
    }
}
