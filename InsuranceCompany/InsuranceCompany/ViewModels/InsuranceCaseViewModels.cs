using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class InsuranceCasePageViewModel : PageViewModel<InsuranceCaseViewModel> { }

    public class InsuranceCaseViewModel
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
