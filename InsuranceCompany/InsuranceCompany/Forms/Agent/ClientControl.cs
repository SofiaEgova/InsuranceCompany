using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;
using InsuranceCompany.IServices;
using InsuranceCompany.Models;
using InsuranceCompany.BindingModels;
using InsuranceCompany.ViewModels;

namespace InsuranceCompany.Forms.Agent
{
    public partial class ClientControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClientService _serviceClient;

        private readonly IContractService _serviceContract;

        private bool filterSum;
        private bool filterDate;
        private bool filter;

        public ClientControl(IClientService serviceClient, IContractService serviceContract)
        {
            InitializeComponent();
            _serviceClient = serviceClient;
            _serviceContract = serviceContract;

            List<ColumnConfig> columns = new List<ColumnConfig>
            {
                new ColumnConfig { Name = "Id", Title = "Id", Width = 100, Visible = false },
                new ColumnConfig { Name = "FullName", Title = "ФИО", Width = 200, Visible = true },
                new ColumnConfig { Name = "PassportSeria", Title = "Серия паспорта", Width = 200, Visible = true },
                new ColumnConfig { Name = "PassportNumber", Title = "Номер паспорта", Width = 200, Visible = true }
            };

            List<string> hideToolStripButtons = new List<string> {"toolStripDropDownButtonMoves", "toolStripButtonAdd", "toolStripButtonUpd", "toolStripButtonDel", "toolStripButtonRef"};

            standartControl1.Configurate(columns, hideToolStripButtons);

            standartControl1.GetPageAddEvent(LoadRecords);
            //standartControl1.ToolStripButtonAddEventClickAddEvent((object sender, EventArgs e) => { AddRecord(); });
            //standartControl1.ToolStripButtonUpdEventClickAddEvent((object sender, EventArgs e) => { UpdRecord(); });
            //standartControl1.ToolStripButtonDelEventClickAddEvent((object sender, EventArgs e) => { DelRecord(); });
            //standartControl1.DataGridViewListEventCellDoubleClickAddEvent((object sender, DataGridViewCellEventArgs e) => { UpdRecord(); });
            //standartControl1.DataGridViewListEventKeyDownAddEvent((object sender, KeyEventArgs e) => {
            //    switch (e.KeyCode)
            //    {
            //        case Keys.Insert:
            //            AddRecord();
            //            break;
            //        case Keys.Enter:
            //            UpdRecord();
            //            break;
            //        case Keys.Delete:
            //            DelRecord();
            //            break;
            //    }
            //});
        }

        public void LoadData()
        {
            filterDate = false;
            filterSum = false;
            filter = false;
            standartControl1.LoadPage();
        }

        private int LoadRecords(int pageNumber, int pageSize)
        {
            var result = new ResultService<ClientPageViewModel>();

            if (filterSum)
            {
                //var resContracts = _serviceContract.GetContracts(new ContractGetBindingModel { PageNumber = pageNumber, PageSize = pageSize }).Result.List.Where(c => c.Amount >= 1000000);
                //var resClients = _serviceClient.GetClients(new ClientGetBindingModel { PageNumber = pageNumber, PageSize = pageSize }).Result;
                //foreach(var cl in resClients.List)
                //{
                //    foreach (var con in resContracts)
                //    {
                //        if (cl.Id == con.ClientId)
                //    }
                //}
            }
            else if (filterDate)
            {

            }
            else if (filter)
            {
                //result = _serviceClient.GetClients(new ClientGetBindingModel{PageNumber = pageNumber, PageSize = pageSize }).Result.List.Where(c => c.PassportNumber == Convert.ToInt32(textBoxNumber.Text));
            }
            else result = _serviceClient.GetClients(new ClientGetBindingModel { PageNumber = pageNumber, PageSize = pageSize });
            if (!result.Succeeded)
            {
                throw new Exception("При загрузке возникла ошибка: " + result.Errors);
            }
            standartControl1.GetDataGridViewRows.Clear();
            foreach (var res in result.Result.List)
            {
                standartControl1.GetDataGridViewRows.Add(
                    res.Id,
                    res.FullName,
                    res.PassportSeria,
                    res.PassportNumber
                );
            }
            return result.Result.MaxCount;
        }

        private void buttonFilterSum_Click(object sender, EventArgs e)
        {
            filterSum = true;
            standartControl1.Refresh();
        }

        private void buttonFilterDate_Click(object sender, EventArgs e)
        {
            filterDate = true;
            standartControl1.Refresh();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            filter = true;
            standartControl1.Refresh();
        }

        //private void AddRecord()
        //{
        //    var form = Container.Resolve<UserForm>(
        //        new ParameterOverrides
        //        {
        //            { "id", Guid.Empty }
        //        }
        //        .OnType<UserForm>());
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        standartControl1.LoadPage();
        //    }
        //}

        //private void UpdRecord()
        //{
        //    if (standartControl1.GetDataGridViewSelectedRows.Count == 1)
        //    {
        //        Guid id = new Guid(standartControl1.GetDataGridViewSelectedRows[0].Cells[0].Value.ToString());
        //        var form = Container.Resolve<UserForm>(
        //            new ParameterOverrides
        //            {
        //                { "id", id }
        //            }
        //            .OnType<UserForm>());
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            standartControl1.LoadPage();
        //        }
        //    }
        //}

        //private void DelRecord()
        //{
        //    if (standartControl1.GetDataGridViewSelectedRows.Count > 0)
        //    {
        //        if (MessageBox.Show("Вы уверены, что хотите удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            for (int i = 0; i < standartControl1.GetDataGridViewSelectedRows.Count; ++i)
        //            {
        //                Guid id = new Guid(standartControl1.GetDataGridViewSelectedRows[i].Cells[0].Value.ToString());
        //                var result = _service.DeleteUser(new UserGetBindingModel { Id = id });
        //                if (!result.Succeeded)
        //                {
        //                    //Program.PrintErrorMessage("При удалении возникла ошибка: ", result.Errors);
        //                    throw new Exception("При загрузке возникла ошибка: " + result.Errors);
        //                }
        //            }
        //            standartControl1.LoadPage();
        //        }
        //    }
        //}
    }
}
