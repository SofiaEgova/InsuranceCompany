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
using System.Globalization;

namespace InsuranceCompany.Forms.Agent
{
    public partial class СrossCalculateControl : UserControl
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _serviceContract;

        PrintDocument pd;

        public СrossCalculateControl(IContractService serviceContract)
        {
            InitializeComponent();
            _serviceContract = serviceContract;
            dataGridView.Enabled = false;

            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[4];
            column[0] = new DataGridViewTextBoxColumn();
            column[0].HeaderText = "Месяц";
            column[0].Name = "month";
            column[0].Width = 60;
            column[1] = new DataGridViewTextBoxColumn();
            column[1].HeaderText = ContractTypes.Договор_личного_страхования + "";
            column[1].Name = "type1";
            column[1].Width = 320;
            column[2] = new DataGridViewTextBoxColumn();
            column[2].HeaderText = ContractTypes.Договор_имущественного_страхования + "";
            column[2].Name = "type2";
            column[2].Width = 320;
            column[3] = new DataGridViewTextBoxColumn();
            column[3].HeaderText = ContractTypes.Договор_страхования_риска_ответственности + "";
            column[3].Name = "type3";
            column[3].Width = 320;

            dataGridView.Columns.AddRange(column);

            dataGridView.RowCount = 12;

            var res = _serviceContract.GetContracts(new BindingModels.ContractGetBindingModel { }).Result.List.Where(c => c.Date.Month == 1);
            int s1, s2, s3;
            for(int i = 0; i < 12; i++)
            {
                s1 = 0;
                s2 = 0;
                s3 = 0;
                res = _serviceContract.GetContracts(new BindingModels.ContractGetBindingModel { }).Result.List.Where(c => c.Date.Month==i+1);
                foreach(var r in res)
                {
                    if (r.Type == 1) s1 += r.Amount;
                    else if (r.Type == 2) s2 += r.Amount;
                    else if (r.Type == 3) s3 += r.Amount;
                }
                dataGridView.Rows[i].SetValues(DateTimeFormatInfo.CurrentInfo.MonthNames[i], s1, s2, s3);
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
                if (SetupThePrinting()) pd.Print();
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
