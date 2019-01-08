﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class ClientPageViewModel : PageViewModel<ClientViewModel> { }

    public class ClientViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public int PassportNumber { get; set; }

        public int PassportSeria { get; set; }
    }
}
