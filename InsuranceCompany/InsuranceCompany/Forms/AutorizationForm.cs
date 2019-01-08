using InsuranceCompany.BindingModels;
using InsuranceCompany.IServices;
using InsuranceCompany.Services;
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

namespace InsuranceCompany.Forms
{
    public partial class AutorizationForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IUserService _service;

        private UserViewModel user;
        private string login;
        private string password;


        public AutorizationForm(IUserService service)
        {
            _service = service;
            InitializeComponent();
        }

        private bool CheckFields()
        {
            return true;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            login = textBoxLogin.Text;
            password = textBoxPassword.Text;

            user = AutorizationService.Login(login, password);
            _service.UpdateUser(new UserSetBindingModel
            {
                Id = user.Id,
                FullName = user.FullName,
                IsActive = user.IsActive,
                Login = user.Login,
                Password = user.Password,
                UserRole = user.UserRole
            });
            Form form = Container.Resolve<MainForm>();
            form.Show();
            this.Hide();
        }
    }
}
