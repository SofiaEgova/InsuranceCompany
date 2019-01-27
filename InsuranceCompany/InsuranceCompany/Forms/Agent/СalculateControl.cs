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
using InsuranceCompany.Enums;
using System.Drawing.Printing;

namespace InsuranceCompany.Forms.Agent
{
    public partial class СalculateControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _serviceContract;
        
        PrintDocument pd;

        public СalculateControl(IContractService serviceContract)
        {
            InitializeComponent();
            _serviceContract = serviceContract;
            dataGridView.Enabled = false;
        }

        public bool Check()
        {
            if (dateTimePickerFrom.Value > dateTimePickerTo.Value) return false;
            return true;
        }

        private void buttonForm_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[3];
                column[0] = new DataGridViewTextBoxColumn();
                column[0].HeaderText = ContractTypes.Договор_личного_страхования + "";
                column[0].Name = "type1";
                column[0].Width = 340;
                column[1] = new DataGridViewTextBoxColumn();
                column[1].HeaderText = ContractTypes.Договор_имущественного_страхования + "";
                column[1].Name = "type2";
                column[1].Width = 340;
                column[2] = new DataGridViewTextBoxColumn();
                column[2].HeaderText = ContractTypes.Договор_страхования_риска_ответственности + "";
                column[2].Name = "type3";
                column[2].Width = 340;

                dataGridView.Columns.AddRange(column);

                var res = _serviceContract.GetContracts(new BindingModels.ContractGetBindingModel {}).Result.List.Where(c=>c.Type==1);
                int sum1 = 0;
                foreach(var r in res)
                {
                    sum1 += r.Amount;
                }

                res = _serviceContract.GetContracts(new BindingModels.ContractGetBindingModel {}).Result.List.Where(c => c.Type == 2);
                int sum2 = 0;
                foreach (var r in res)
                {
                    sum2 += r.Amount;
                }

                res = _serviceContract.GetContracts(new BindingModels.ContractGetBindingModel {}).Result.List.Where(c => c.Type == 3);
                int sum3 = 0;
                foreach (var r in res)
                {
                    sum3 += r.Amount;
                }

                dataGridView.RowCount = 1;
                dataGridView.Rows[0].SetValues(sum1, sum2, sum3);
            }
            else
            {
                MessageBox.Show("Выберите верный отрезок времени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 826, 1169);
                pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += printDocument_PrintPage;
                printPreviewDialog.Document = pd;
                if (SetupThePrinting())pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Bitmap bmp = new Bitmap(pd.DefaultPageSettings.Bounds.Width, pd.DefaultPageSettings.Bounds.Height);
            dataGridView.DrawToBitmap(bmp, dataGridView.Bounds);
            ev.Graphics.DrawImage(bmp, 0, 0);
        }

        private bool SetupThePrinting()
        {
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDialog MyPrintDialog = new PrintDialog();
                MyPrintDialog.AllowCurrentPage = false;
                MyPrintDialog.AllowPrintToFile = false;
                MyPrintDialog.AllowSelection = false;
                MyPrintDialog.AllowSomePages = false;
                MyPrintDialog.PrintToFile = false;
                MyPrintDialog.ShowHelp = false;
                MyPrintDialog.ShowNetwork = false;
                if (MyPrintDialog.ShowDialog() == DialogResult.OK)
                    return false;

                return true;
            }
            return false;
        }
    }
}
