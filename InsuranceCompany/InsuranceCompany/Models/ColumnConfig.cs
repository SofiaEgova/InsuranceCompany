using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Models
{
    public class ColumnConfig
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public int? Width { get; set; }

        public bool Visible { get; set; }
    }
}
