using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class ContractPageViewModel : PageViewModel<ContractViewModel> { }

    public class ContractViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ClientId { get; set; }

        public Guid DirectoryId { get; set; }

        public DateTime Date { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Type { get; set; }

        public int Amount { get; set; }

        public int Status { get; set; }
    }
}
