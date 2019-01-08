using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.ViewModels
{
    public class PageViewModel<T>
    {
        public int MaxCount { get; set; }

        public List<T> List { get; set; }
    }
}
