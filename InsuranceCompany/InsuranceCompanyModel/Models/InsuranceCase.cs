using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyModel.Models
{
    /// <summary>
    /// Случай страховых выплат
    /// </summary>
    public class InsuranceCase
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Amount { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
