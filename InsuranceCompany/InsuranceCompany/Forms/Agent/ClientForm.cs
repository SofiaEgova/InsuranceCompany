using InsuranceCompany.BindingModels;
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
    public partial class ClientForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClientService _service;

        private Guid? _id = null;

        public ClientForm(IClientService service, Guid? id = null)
        {
            InitializeComponent();
            _service = service;

            if (id != Guid.Empty)
            {
                _id = id;
                LoadData();
            }
        }

        private void LoadData()
        {
            var result = _service.GetClient(new ClientGetBindingModel { Id = _id.Value });
            if (!result.Succeeded)
            {
                throw new Exception("При загрузке возникла ошибка: " + result.Errors);
            }
            var entity = result.Result;

            textBoxFullName.Text = entity.FullName;
            textBoxSeria.Text = entity.PassportSeria+"";
            textBoxNumber.Text = entity.PassportNumber + "";
        }

        private bool CheckFill()
        {
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(textBoxSeria.Text))
            {
                return false;
            }
            try
            {
                Convert.ToInt32(textBoxSeria.Text);
                Convert.ToInt32(textBoxNumber.Text);
            }
            catch (Exception)
            {
                return false;
            }
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                return false;
            }
            return true;
        }

        private bool Save()
        {
            if (CheckFill())
            {
                ResultService result;
                if (!_id.HasValue)
                {
                    result = _service.CreateClient(new ClientSetBindingModel
                    {
                        FullName = textBoxFullName.Text,
                        PassportSeria = Convert.ToInt32(textBoxSeria.Text),
                        PassportNumber = Convert.ToInt32(textBoxNumber.Text)
                    });
                }
                else
                {
                    result = _service.UpdateClient(new ClientSetBindingModel
                    {
                        Id = _id.Value,
                        FullName = textBoxFullName.Text,
                        PassportSeria = Convert.ToInt32(textBoxSeria.Text),
                        PassportNumber = Convert.ToInt32(textBoxNumber.Text)
                    });
                }
                if (result.Succeeded)
                {
                    if (result.Result != null)
                    {
                        if (result.Result is Guid)
                        {
                            _id = (Guid)result.Result;
                        }
                    }
                    return true;
                }
                else
                {
                    throw new Exception("При загрузке возникла ошибка: " + result.Errors);
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля корректными данными", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Сохранение прошло успешно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
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
