using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity.Attributes;
using Unity;
using InsuranceCompany.IServices;

namespace InsuranceCompany.Forms.Booker
{
    public partial class AgentControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IUserService _serviceU;
        private readonly ISalaryService _serviceS;
        private readonly IComissionService _serviceC;

        public AgentControl(IUserService serviceU, ISalaryService serviceS, IComissionService serviceC)
        {
            InitializeComponent();
            _serviceC = serviceC;
            _serviceS = serviceS;
            _serviceU = serviceU;
        }
    }
}
