using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyModel.Models
{
    /// <summary>
    /// Администратор
    /// </summary>
    public class Admin
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        public virtual User User { get; set; }
    }
}
