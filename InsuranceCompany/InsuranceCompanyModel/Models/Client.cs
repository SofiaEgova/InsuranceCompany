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
    /// Клиент
    /// </summary>
    public class Client
    {
        public Guid Id { get; set; }

        public Guid AgentId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Passport { get; set; }

        public virtual Agent Agent { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Contract> Contracts { get; set; }
    }
}
