using InsuranceCompany.BindingModels;
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

namespace InsuranceCompany.Forms.Admin
{
    public partial class UserForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IUserService _service;

        private Guid? _id = null;

        public UserForm(IUserService service, Guid? id = null)
        {
            InitializeComponent();
            _service = service;

            if (id != Guid.Empty)
            {
                _id = id;
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            comboBoxRole.ValueMember = "Value";
            comboBoxRole.DisplayMember = "Display";
            comboBoxRole.DataSource = Enum.GetValues(typeof(UserRoles));
            comboBoxRole.SelectedItem = null;

            if (_id.HasValue)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var result = _service.GetUser(new UserGetBindingModel { Id = _id.Value });
            if (!result.Succeeded)
            {
                throw new Exception("При загрузке возникла ошибка: " + result.Errors);
            }
            var entity = result.Result;

            textBoxLogin.Text = entity.Login;
            textBoxPassword.Text = entity.Password;
            comboBoxRole.SelectedIndex = entity.UserRole;
            textBoxFullName.Text = entity.FullName;
        }

        private bool CheckFill()
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                return false;
            }
            if (comboBoxRole.SelectedValue == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(textBoxFullName.Text))
            {
                return false;
            }
            return true;
        }

        private bool Save()
        {
            if (CheckFill())
            {
                UserRoles role;
                Enum.TryParse<UserRoles>(comboBoxRole.SelectedValue.ToString(), out role);
                ResultService result;
                if (!_id.HasValue)
                {
                    result = _service.CreateUser(new UserSetBindingModel
                    {
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        UserRole = (int)role,
                        FullName = textBoxFullName.Text
                    });
                }
                else
                {
                    result = _service.UpdateUser(new UserSetBindingModel
                    {
                        Id = _id.Value,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        UserRole = (int)role,
                        FullName = textBoxFullName.Text
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
