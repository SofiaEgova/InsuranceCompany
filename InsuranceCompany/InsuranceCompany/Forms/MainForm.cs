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
using System.IO;
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

        private readonly ISerializeService _serviceS;

        private UserViewModel user;

        public MainForm(IUserService service, ISerializeService serviceS)
        {
            InitializeComponent();
            _service = service;
            _serviceS = serviceS;

            var result = _service.GetActiveUser();
            if (!result.Succeeded)
            {
                throw new Exception("При загрузке возникла ошибка: " + result.Errors);
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
            ToolStripMenuItem archiveAdminItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveAdminItem);
            usersItem.Click += usersItemToolStripMenuItem_Click;
            archiveAdminItem.Click += archiveAdminItemToolStripMenuItem_Click;
        }

        private void usersItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = Container.Resolve<UsersControl>();
            ApplyControl(control);
            control.LoadData();
        }

        private void archiveAdminItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сделать резервную копию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Json files (*.json)|*.json|Word files (*.doc)|*.doc" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(sfd.FileName);
                        writer.WriteLine(_serviceS.GetDataFromAdmin());
                        writer.Dispose();

                        MessageBox.Show("Данные сохранены успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            ToolStripMenuItem archiveAgentItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveAgentItem);
            clientsItem.Click += clientsItemToolStripMenuItem_Click;
            contractsItem.Click += contractsItemToolStripMenuItem_Click;
            printItem.Click += printItemToolStripMenuItem_Click;
            archiveAgentItem.Click += archiveAgentItemToolStripMenuItem_Click;
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

        private void archiveAgentItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сделать резервную копию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Json files (*.json)|*.json|Word files (*.doc)|*.doc" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(sfd.FileName);
                        writer.WriteLine(_serviceS.GetDataFromAgent());
                        writer.Dispose();

                        MessageBox.Show("Данные сохранены успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Booker
        private void generateMenuBooker()
        {
            ToolStripMenuItem agentsItem = new ToolStripMenuItem("Агенты");
            menuStrip.Items.Add(agentsItem);
            ToolStripMenuItem wageListItem = new ToolStripMenuItem("Зарплатная ведомость");
            menuStrip.Items.Add(wageListItem);
            ToolStripMenuItem archiveBookerItem = new ToolStripMenuItem("Архивировать данные");
            menuStrip.Items.Add(archiveBookerItem);
            agentsItem.Click += agentsItemToolStripMenuItem_Click;
            wageListItem.Click += wageListItemToolStripMenuItem_Click;
            archiveBookerItem.Click += archiveBookerItemToolStripMenuItem_Click;
        }
        private void agentsItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void wageListItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archiveBookerItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сделать резервную копию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "Json files (*.json)|*.json|Word files (*.doc)|*.doc" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(sfd.FileName);
                        writer.WriteLine(_serviceS.GetDataFromBooker());
                        writer.Dispose();

                        MessageBox.Show("Данные сохранены успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
