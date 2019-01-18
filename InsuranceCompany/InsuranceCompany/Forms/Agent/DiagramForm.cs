using InsuranceCompany.Enums;
using InsuranceCompany.IServices;
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

namespace InsuranceCompany.Forms.Agent
{
    public partial class DiagramForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _service;

        public DiagramForm(IContractService service)
        {
            InitializeComponent();
            _service = service;

            PringDiagram();
        }

        private void PringDiagram()
        {
            var res1 = _service.GetContracts(new BindingModels.ContractGetBindingModel { }).Result.List.Where(c=>c.Type==1);
            int r1 = res1.ToArray().Length;
            var res2 = _service.GetContracts(new BindingModels.ContractGetBindingModel { }).Result.List.Where(c => c.Type == 2);
            int r2 = res2.ToArray().Length;
            var res3 = _service.GetContracts(new BindingModels.ContractGetBindingModel { }).Result.List.Where(c => c.Type == 3);
            int r3 = res3.ToArray().Length;
            chart.Series.Clear();
            chart.Series.Add(ContractTypes.Договор_личного_страхования.ToString());
            chart.Series.Add(ContractTypes.Договор_имущественного_страхования.ToString());
            chart.Series.Add(ContractTypes.Договор_страхования_риска_ответственности.ToString());
            chart.Series["Договор_личного_страхования"].Points.AddY(r1);
            chart.Series["Договор_имущественного_страхования"].Points.AddY(r2);
            chart.Series["Договор_страхования_риска_ответственности"].Points.AddY(r3);
        }
    }
}
