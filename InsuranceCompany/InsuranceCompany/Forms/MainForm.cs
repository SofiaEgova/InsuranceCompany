using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace InsuranceCompany.Forms
{
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public MainForm()
        {
            InitializeComponent();

            //ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            //fileItem.DropDownItems.Add("Создать");
            //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

            //menuStrip1.Items.Add(fileItem);
        }
    }
}
