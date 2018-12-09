using InsuranceCompanyModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyModel.Models
{
    /// <summary>
    /// Страховой договор
    /// </summary>
    public class Contract
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public ContractType Type { get; set; }
        
        [Required]
        public int Amount { get; set; }

        [Required]
        public ContractStatus Status { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("ContractId")]
        public virtual List<InsuranceCase> InsuranceCases { get; set; }
    }
}
