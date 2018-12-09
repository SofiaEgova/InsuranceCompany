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
    /// Пользователь программы
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserRole UserRole { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Admin> Admins { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Accountant> Accountants { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Agent> Agents { get; set; }
    }
}
