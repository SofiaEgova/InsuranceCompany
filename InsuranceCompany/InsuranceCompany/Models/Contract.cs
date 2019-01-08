﻿using System;
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
    public class Contract
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public Guid ClientId { get; set; }

        [Required]
        [DataMember]
        public Guid DirectoryId { get; set; }

        [Required]
        [DataMember]
        public DateTime Date { get; set; }

        [Required]
        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [DataMember]
        public int Type { get; set; }

        [Required]
        [DataMember]
        public int Amount { get; set; }

        [Required]
        [DataMember]
        public int Status { get; set; }

        //-----------------------

        public virtual User User { get; set; }

        public virtual Client Client { get; set; }

        public virtual Directory Directory { get; set; }

        //-----------------------

        [ForeignKey("ContractId")]
        public virtual List<InsuranceCase> InsuranceCases { get; set; }
    }
}
