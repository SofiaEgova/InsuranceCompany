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
    public class Directory
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public int DamageAmount { get; set; }

        [Required]
        [DataMember]
        public int InsuranceFee { get; set; }

        [Required]
        [DataMember]
        public int InsuranceType { get; set; }

        [Required]
        [DataMember]
        public int InsuranceTerm { get; set; }

        //-----------------------

        [ForeignKey("DirectoryId")]
        public virtual List<Contract> Contracts { get; set; }

        //-----------------------

        public Directory() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}
