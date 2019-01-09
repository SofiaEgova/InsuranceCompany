using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Models
{
    [DataContract]
    public class InsuranceCase
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public Guid ContractId { get; set; }

        [Required]
        [DataMember]
        public int Amount { get; set; }

        [Required]
        [DataMember]
        public DateTime Date { get; set; }

        //-----------------------

        public virtual Contract Contract { get; set; }

        //-----------------------

        public InsuranceCase() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}
