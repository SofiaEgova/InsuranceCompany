using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class SalaryPageViewModel : PageViewModel<SalaryViewModel> { }

    public class SalaryViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }
    }
}
