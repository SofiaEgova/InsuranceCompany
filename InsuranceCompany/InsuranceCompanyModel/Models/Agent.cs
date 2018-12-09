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
    /// Страховой агент
    /// </summary>
    public class Agent
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public int Commission { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("AgentId")]
        public virtual List<Client> Clients { get; set; }
    }
}
