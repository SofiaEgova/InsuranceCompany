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

namespace InsuranceCompany.Forms.Admin
{
    public partial class UsersControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public UsersControl()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            standartControl1.LoadPage();
        }
    }
}
