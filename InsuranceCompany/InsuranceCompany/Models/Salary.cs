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
    public class Salary
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public DateTime Date { get; set; }

        [Required]
        [DataMember]
        public int Amount { get; set; }

        //-----------------------

        public virtual User User { get; set; }
    }
}
