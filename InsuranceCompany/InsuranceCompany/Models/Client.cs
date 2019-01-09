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
    public class Client
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string FullName { get; set; }

        [Required]
        [DataMember]
        public int PassportNumber { get; set; }

        [Required]
        [DataMember]
        public int PassportSeria { get; set; }
        
        //-----------------------

        [ForeignKey("ClientId")]
        public virtual List<Contract> Contracts { get; set; }

        //-----------------------

        public Client() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}
