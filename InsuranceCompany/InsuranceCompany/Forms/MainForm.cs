using InsuranceCompany.BindingModels;
using InsuranceCompany.Forms.Admin;
using InsuranceCompany.Forms.Agent;
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
                throw new Exception("При загрузке возникла ошибка: "+ result.Errors);
            }
            user = (UserViewModel)result.Result;

            switch (user.UserRole)
            {
                case 0:
                    this.Text = "Страховая компания. Администратор";
                    generateMenuAdmin();
                    break;
                case 1:
                    this.Text = "Страховая компания. Агент";
                    generateMenuAgent();
                    break;
                case 2:
                    this.Text = "Страховая компания. Бухгалтер";
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
            archiveItem.Click += archiveItemToolStripMenuItem_Click;
        }

        private void usersItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<UsersControl>();
            ApplyControl(control);
            control.LoadData();
        }

        #endregion

        #region Agent
        private void generateMenuAgent()
        {
            ToolStripMenuItem clientsItem = new ToolStripMenuItem("Клиенты");
            menuStrip.Items.Add(clientsItem);
            ToolStripMenuItem contractsItem = new ToolStripMenuItem("Договоры");
            menuStrip.Items.Add(contractsItem);
            ToolStripMenuItem printItem = new ToolStripMenuItem("Печать");
            menuStrip.Items.Add(printItem);
            ToolStripMenuItem archiveItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveItem);
            clientsItem.Click += clientsItemToolStripMenuItem_Click;
            contractsItem.Click += contractsItemToolStripMenuItem_Click;
            printItem.Click += printItemToolStripMenuItem_Click;
            archiveItem.Click += archiveItemToolStripMenuItem_Click;
        }

        private void clientsItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<ClientControl>();
            ApplyControl(control);
            control.LoadData();
        }

        private void contractsItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<ContractControl>();
            ApplyControl(control);
            control.LoadData();
        }

        private void printItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Booker
        private void generateMenuBooker()
        {
            ToolStripMenuItem agentsItem = new ToolStripMenuItem("Агенты");
            menuStrip.Items.Add(agentsItem);
            ToolStripMenuItem wageListItem = new ToolStripMenuItem("Зарплатная ведомость");
            menuStrip.Items.Add(wageListItem);
            ToolStripMenuItem archiveItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveItem);
            agentsItem.Click += agentsItemToolStripMenuItem_Click;
            wageListItem.Click += wageListItemToolStripMenuItem_Click;
            archiveItem.Click += archiveItemToolStripMenuItem_Click;
        }
        private void agentsItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void wageListItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void archiveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
