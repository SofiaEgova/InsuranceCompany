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
                result = _serviceClient.GetClientsBySum(new ClientGetBindingModel { PageNumber = pageNumber, PageSize = pageSize });
                filterSum = false;
            }
            else if (filterDate)
            {
                result = _serviceClient.GetClientsByDate(new ClientGetBindingModel { PageNumber = pageNumber, PageSize = pageSize });
                filterDate = false;
            }
            else if (filter)
            {
                int n = 0;
                try
                {
                    n=Convert.ToInt32(textBoxNumber.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Нету клиента с таким паспортом", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                result = _serviceClient.GetClientsByNumber(new ClientGetBindingModel { PageNumber = pageNumber, PageSize = pageSize }, n);
                filter = false;
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
            standartControl1.LoadPage();
        }

        private void buttonFilterDate_Click(object sender, EventArgs e)
        {
            filterDate = true;
            standartControl1.LoadPage();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            filter = true;
            standartControl1.LoadPage();
        }
    }
}
