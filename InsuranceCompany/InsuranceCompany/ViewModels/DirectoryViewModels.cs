using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class DirectoryPageViewModel : PageViewModel<DirectoryViewModel> { }

    public class DirectoryViewModel
    {
        public Guid Id { get; set; }

        public int DamageAmount { get; set; }

        public int InsuranceFee { get; set; }
    }
}
