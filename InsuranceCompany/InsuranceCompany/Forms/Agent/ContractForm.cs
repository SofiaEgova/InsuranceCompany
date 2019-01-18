using InsuranceCompany.BindingModels;
using InsuranceCompany.Enums;
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
using Unity.Resolution;

namespace InsuranceCompany.Forms.Agent
{
    public partial class ContractForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _serviceContract;

        private readonly IUserService _serviceUser;

        private readonly IClientService _serviceClient;

        public ContractForm(IContractService serviceContract, IUserService serviceUser, IClientService serviceClient)
        {
            InitializeComponent();
            _serviceClient = serviceClient;
            _serviceContract = serviceContract;
            _serviceUser = serviceUser;

        }

        private void ContractForm_Load(object sender, EventArgs e)
        {
            var clients = _serviceClient.GetClients(new ClientGetBindingModel { });
            comboBoxClients.ValueMember = "Id";
            comboBoxClients.DisplayMember = "FullName";
            comboBoxClients.DataSource = clients.Result.List;
            comboBoxClients.SelectedItem = null;
            dateTimePickerFrom.Value = DateTime.Now;
            comboBoxType.ValueMember = "Value";
            comboBoxType.DisplayMember = "Display";
            comboBoxType.DataSource = Enum.GetValues(typeof(ContractTypes));
            comboBoxType.SelectedItem = null;
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ClientForm>(new ParameterOverrides
                {
                    { "id", Guid.Empty }
                }
                .OnType<ClientForm>());
            form.ShowDialog();
        }

        private bool CheckFill()
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                try
                {
                    Convert.ToInt32(textBoxAmount.Text);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            if (comboBoxClients.SelectedValue == null)
            {
                return false;
            }
            if (comboBoxType.SelectedValue == null)
            {
                return false;
            }
            if (dateTimePickerTo.Value > dateTimePickerFrom.Value)
            {
                return false;
            }
            return true;
        }

        private bool Save()
        {
            if (CheckFill())
            {
                Enum.TryParse<ContractTypes>(comboBoxType.SelectedValue.ToString(), out ContractTypes type);
                ResultService result;
                var user = _serviceUser.GetActiveUser();
                result = _serviceContract.CreateContract(new ContractSetBindingModel
                {
                    UserId = ((UserViewModel)user.Result).Id,
                    ClientId = (Guid)comboBoxClients.SelectedValue,
                    Date = dateTimePickerFrom.Value,
                    ExpirationDate = dateTimePickerTo.Value,
                    Amount = Convert.ToInt32(textBoxAmount.Text),
                    Status = 1,
                    Type = (int)type
                    // Сделать через справочник!!!
                });
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    throw new Exception("При загрузке возникла ошибка: " + result.Errors);
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Сохранение прошло успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
