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
    public class User
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string Login { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public int UserRole { get; set; }

        [Required]
        [DataMember]
        public string FullName { get; set; }

        //-----------------------

        [ForeignKey("UserId")]
        public virtual List<Comission> Comissions { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Salary> Salaries { get; set; }
        
        [ForeignKey("UserId")]
        public virtual List<Contract> Contracts { get; set; }
    }
}
