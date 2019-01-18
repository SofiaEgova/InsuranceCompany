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
using InsuranceCompany.Models;
using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;
using Unity.Resolution;
using InsuranceCompany.Enums;

namespace InsuranceCompany.Forms.Agent
{
    public partial class ContractControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _serviceContract;

        private readonly IUserService _serviceUser;

        private readonly IClientService _serviceClient;

        public ContractControl(IContractService serviceContract, IUserService serviceUser, IClientService serviceClient)
        {
            InitializeComponent();
            _serviceContract = serviceContract;
            _serviceUser = serviceUser;
            _serviceClient = serviceClient;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "User", Title = "Агент", Width = 200, Visible = true },
                new ColumnConfig { Name = "Client", Title = "Клиент", Width = 200, Visible = true },
                new ColumnConfig { Name = "Date", Title = "Дата заключения", Width = 150, Visible = true },
                new ColumnConfig { Name = "ExpirationDate", Title = "Дата окончания", Width = 150, Visible = true },
                new ColumnConfig { Name = "Type", Title = "Тип", Width = 180, Visible = true },
                new ColumnConfig { Name = "Amount", Title = "Сумма", Width = 100, Visible = true },
                new ColumnConfig { Name = "Status", Title = "Статус", Width = 100, Visible = true }
            };

            List<string> hideToolStripButtons = new List<string> { "toolStripDropDownButtonMoves" };

            standartControl1.Configurate(columns, hideToolStripButtons);

            standartControl1.GetPageAddEvent(LoadRecords);
            standartControl1.ToolStripButtonAddEventClickAddEvent((object sender, EventArgs e) => { AddRecord(); });
            standartControl1.ToolStripButtonUpdEventClickAddEvent((object sender, EventArgs e) => { UpdRecord(); });
            standartControl1.ToolStripButtonDelEventClickAddEvent((object sender, EventArgs e) => { DelRecord(); });
            standartControl1.DataGridViewListEventCellDoubleClickAddEvent((object sender, DataGridViewCellEventArgs e) => { UpdRecord(); });
            standartControl1.DataGridViewListEventKeyDownAddEvent((object sender, KeyEventArgs e) => {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        AddRecord();
                        break;
                    case Keys.Enter:
                        UpdRecord();
                        break;
                    case Keys.Delete:
                        DelRecord();
                        break;
                }
            });
        }

        public void LoadData()
        {
            standartControl1.LoadPage();
        }

        private int LoadRecords(int pageNumber, int pageSize)
        {
            var result = _serviceContract.GetContracts(new ContractGetBindingModel { PageNumber = pageNumber, PageSize = pageSize });
            if (!result.Succeeded)
            {
                throw new Exception("При загрузке возникла ошибка: " + result.Errors);
            }
            standartControl1.GetDataGridViewRows.Clear();
            foreach (var res in result.Result.List)
            {
                var resUser = _serviceUser.GetUsers(new UserGetBindingModel { }).Result.List.FirstOrDefault(u => u.Id == res.UserId);
                var resClient = _serviceClient.GetClients(new ClientGetBindingModel { }).Result.List.FirstOrDefault(c => c.Id == res.ClientId);
                standartControl1.GetDataGridViewRows.Add(
                    res.Id,
                    resUser.FullName,
                    resClient.FullName,
                    res.Date,
                    res.ExpirationDate,
                    (ContractTypes)res.Type,
                    res.Amount,
                    (ContractStatus)res.Status
                );
            }
            return result.Result.MaxCount;
        }

        private void AddRecord()
        {
            var form = Container.Resolve<ContractForm>(
                new ParameterOverrides
                {
                    { "id", Guid.Empty }
                }
                .OnType<ContractForm>());
            if (form.ShowDialog() == DialogResult.OK)
            {
                standartControl1.LoadPage();
            }
        }

        private void UpdRecord()
        {
            if (standartControl1.GetDataGridViewSelectedRows.Count == 1)
            {
                Guid id = new Guid(standartControl1.GetDataGridViewSelectedRows[0].Cells[0].Value.ToString());
                var form = Container.Resolve<ContractForm>(
                    new ParameterOverrides
                    {
                        { "id", id }
                    }
                    .OnType<ContractForm>());
                if (form.ShowDialog() == DialogResult.OK)
                {
                    standartControl1.LoadPage();
                }
            }
        }

        private void DelRecord()
        {
            if (standartControl1.GetDataGridViewSelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < standartControl1.GetDataGridViewSelectedRows.Count; ++i)
                    {
                        Guid id = new Guid(standartControl1.GetDataGridViewSelectedRows[i].Cells[0].Value.ToString());
                        var result = _serviceContract.DeleteContract(new ContractGetBindingModel { Id = id });
                        if (!result.Succeeded)
                        {
                            throw new Exception("При загрузке возникла ошибка: " + result.Errors);
                        }
                    }
                    standartControl1.LoadPage();
                }
            }
        }

        private void buttonDiagram_Click(object sender, EventArgs e)
        {
            Form form = Container.Resolve<DiagramForm>();
            form.Show();
        }
    }
}
