using InsuranceCompany.BindingModels;
using InsuranceCompany.Forms.Admin;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
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

        private readonly IUserService _service;

        private UserViewModel user;

        public MainForm(IUserService service)
        {
            InitializeComponent();
            _service = service;

            var result = _service.GetActiveUser();
            if (!result.Succeeded)
            {
                //Program.PrintErrorMessage("При загрузке возникла ошибка: ", result.Errors);
                //return -1;
                throw new Exception("При загрузке возникла ошибка: "+ result.Errors);
            }
            user = (UserViewModel)result.Result;

            switch (user.UserRole)
            {
                case 0:
                    generateMenuAdmin();
                    break;
                case 1:
                    generateMenuAgent();
                    break;
                case 2:
                    generateMenuBooker();
                    break;
            }
        }

        #region Admin
        private void generateMenuAdmin()
        {
            ToolStripMenuItem usersItem = new ToolStripMenuItem("Пользователи");
            menuStrip.Items.Add(usersItem);
            ToolStripMenuItem archiveItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveItem);
            usersItem.Click += usersItemToolStripMenuItem_Click;
        }

        private void usersItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<UsersControl>();
            ApplyControl(control);
            control.LoadData();
        }

        private void archiveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Agent
        private void generateMenuAgent()
        {
            ToolStripMenuItem usersItem = new ToolStripMenuItem("Пользователи");
            menuStrip.Items.Add(usersItem);
            ToolStripMenuItem archiveItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveItem);
            usersItem.Click += usersItemToolStripMenuItem_Click;
        }
        #endregion

        #region Booker
        private void generateMenuBooker()
        {
            ToolStripMenuItem usersItem = new ToolStripMenuItem("Пользователи");
            menuStrip.Items.Add(usersItem);
            ToolStripMenuItem archiveItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveItem);
            usersItem.Click += usersItemToolStripMenuItem_Click;
        }
        #endregion


        private void ApplyControl(Control control)
        {
            control.Left = 0;
            control.Top = 25;
            control.Height = Height - 60;
            control.Width = Width - 15;
            control.Anchor = (((AnchorStyles.Top
                        | AnchorStyles.Bottom)
                        | AnchorStyles.Left)
                        | AnchorStyles.Right);
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            Controls.Add(control);
        }
    }
}
