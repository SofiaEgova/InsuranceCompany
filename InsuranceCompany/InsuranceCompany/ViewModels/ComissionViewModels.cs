using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class ComissionPageViewModel : PageViewModel<ComissionViewModel> { }

    public class ComissionViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }
    }
}
