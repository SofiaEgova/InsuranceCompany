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
    public partial class ContractForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContractService _serviceContract;

        private readonly IUserService _serviceUser;

        private readonly IClientService _serviceClient;

        private Guid? _id = null;

        public ContractForm(IContractService serviceContract, IUserService serviceUser, IClientService serviceClient, Guid? id = null)
        {
            InitializeComponent();
            _serviceClient = serviceClient;
            _serviceContract = serviceContract;
            _serviceUser = serviceUser;

            if (id != Guid.Empty)
            {
                _id = id;
            }
        }

        private void ContractForm_Load(object sender, EventArgs e)
        {



            if (_id.HasValue)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            //var result = _service.GetUser(new UserGetBindingModel { Id = _id.Value });
            //if (!result.Succeeded)
            //{
            //    //Program.PrintErrorMessage("При загрузке возникла ошибка: ", result.Errors);
            //    //Close();
            //    throw new Exception("При загрузке возникла ошибка: " + result.Errors);
            //}
            //var entity = result.Result;

            //textBoxLogin.Text = entity.Login;
            //textBoxPassword.Text = entity.Password;
            //comboBoxRole.SelectedIndex = entity.UserRole;
            //textBoxFullName.Text = entity.FullName;
        }

        //private bool CheckFill()
        //{
        //    if (string.IsNullOrEmpty(textBoxLogin.Text))
        //    {
        //        return false;
        //    }
        //    if (string.IsNullOrEmpty(textBoxPassword.Text))
        //    {
        //        return false;
        //    }
        //    if (comboBoxRole.SelectedValue == null)
        //    {
        //        return false;
        //    }
        //    if (string.IsNullOrEmpty(textBoxFullName.Text))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private bool Save()
        //{
        //    if (CheckFill())
        //    {
        //        UserRoles role;
        //        Enum.TryParse<UserRoles>(comboBoxRole.SelectedValue.ToString(), out role);
        //        ResultService result;
        //        if (!_id.HasValue)
        //        {
        //            result = _service.CreateUser(new UserSetBindingModel
        //            {
        //                //Id = Guid.NewGuid(),
        //                Login = textBoxLogin.Text,
        //                Password = textBoxPassword.Text,
        //                UserRole = (int)role,
        //                FullName = textBoxFullName.Text
        //            });
        //        }
        //        else
        //        {
        //            result = _service.UpdateUser(new UserSetBindingModel
        //            {
        //                Id = _id.Value,
        //                Login = textBoxLogin.Text,
        //                Password = textBoxPassword.Text,
        //                UserRole = (int)role,
        //                FullName = textBoxFullName.Text
        //            });
        //        }
        //        if (result.Succeeded)
        //        {
        //            if (result.Result != null)
        //            {
        //                if (result.Result is Guid)
        //                {
        //                    _id = (Guid)result.Result;
        //                }
        //            }
        //            return true;
        //        }
        //        else
        //        {
        //            //Program.PrintErrorMessage("При сохранении возникла ошибка: ", result.Errors);
        //            //return false;
        //            throw new Exception("При загрузке возникла ошибка: " + result.Errors);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Заполните все обязательные поля", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}
    }
}
