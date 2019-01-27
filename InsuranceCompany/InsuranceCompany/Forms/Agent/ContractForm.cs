using InsuranceCompany.BindingModels;
using InsuranceCompany.Enums;
using InsuranceCompany.IServices;
using InsuranceCompany.ViewModels;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private readonly IDirectoryService _serviceDirectory;

        private readonly IInsuranceCaseService _serviceInsuranceCase;

        private Guid? _id = null;

        private Guid? _oldId = null;

        public ContractForm(IContractService serviceContract, IUserService serviceUser, IClientService serviceClient, IDirectoryService serviceDirectory, IInsuranceCaseService serviceInsuranceCase, Guid? id = null, Guid? oldId = null)
        {
            InitializeComponent();
            _serviceClient = serviceClient;
            _serviceContract = serviceContract;
            _serviceUser = serviceUser;
            _serviceDirectory = serviceDirectory;
            _serviceInsuranceCase = serviceInsuranceCase;

            if (id != Guid.Empty)
            {
                _id = id;
                LoadData();
            }

            if (oldId != Guid.Empty)
            {
                _oldId = oldId;
            }
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
            textBoxAmount.Enabled = false;

            if (_id == null)
            {
                buttonAddInsuranceCase.Enabled = false;
                buttonUpdateContract.Enabled = false;
                if (_oldId != null)
                {
                    var res = _serviceContract.GetContract(new ContractGetBindingModel { Id = _oldId }).Result;
                    comboBoxClients.SelectedValue = res.ClientId;
                    comboBoxType.SelectedValue = res.Type;
                    textBoxAmount.Text = res.Amount + "";
                    comboBoxClients.Enabled = false;
                    comboBoxType.Enabled = false;
                    buttonAddClient.Enabled = false;
                    buttonSum.Enabled = false;
                }
            }
            else
            {
                buttonSum.Enabled = false;
                var res = _serviceContract.GetContract(new ContractGetBindingModel { Id = _id }).Result;
                if (res.Status != 1) buttonAddInsuranceCase.Enabled = false;
            }
        }

        public void LoadData()
        {
            var res = _serviceContract.GetContract(new ContractGetBindingModel { Id = _id.Value }).Result;
            //if (!res.Succeeded)
            //{
            //    throw new Exception("При загрузке возникла ошибка: " + res.Errors);
            //}

            comboBoxClients.SelectedValue = res.ClientId;
            dateTimePickerFrom.Value = res.Date;
            dateTimePickerTo.Value = res.ExpirationDate;
            comboBoxType.SelectedValue = res.Type;
            textBoxAmount.Text = res.Amount.ToString();

            comboBoxClients.Enabled = false;
            dateTimePickerFrom.Enabled = false;
            dateTimePickerTo.Enabled = false;
            comboBoxType.Enabled = false;
            textBoxAmount.Enabled = false;
            buttonAddClient.Enabled = false;
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ClientForm>(new ParameterOverrides
                {
                    { "id", Guid.Empty }
                }
                .OnType<ClientForm>());
            if (form.ShowDialog() == DialogResult.OK)
            {
                var clients = _serviceClient.GetClients(new ClientGetBindingModel { });
                comboBoxClients.ValueMember = "Id";
                comboBoxClients.DisplayMember = "FullName";
                comboBoxClients.DataSource = clients.Result.List;
                comboBoxClients.SelectedItem = null;
            }
        }

        private bool CheckFill()
        {
            if (comboBoxClients.SelectedValue == null)
            {
                return false;
            }
            if (comboBoxType.SelectedValue == null)
            {
                return false;
            }
            if (dateTimePickerTo.Value < dateTimePickerFrom.Value)
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
                int term = 0;
                int diff = dateTimePickerTo.Value.Month - dateTimePickerFrom.Value.Month;
                if (diff <= 6) term = 1;
                else if (diff > 6 && diff <= 18) term = 2;
                else if (diff > 18) term = 3;
                result = _serviceContract.CreateContract(new ContractSetBindingModel
                {
                    UserId = ((UserViewModel)user.Result).Id,
                    ClientId = (Guid)comboBoxClients.SelectedValue,
                    Date = dateTimePickerFrom.Value,
                    ExpirationDate = dateTimePickerTo.Value,
                    Amount = Convert.ToInt32(textBoxAmount.Text),
                    Status = 1,
                    Type = (int)type,
                    DirectoryId = _serviceDirectory.GetDirectory((int)type, term).Result.Id
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

        private void buttonUpdateContract_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ContractForm>(
                new ParameterOverrides
                {
                    { "id", Guid.Empty },
                    { "oldId", _id }
                }
                .OnType<ContractForm>());
            if (form.ShowDialog() == DialogResult.OK)
            {
                var entity = _serviceContract.GetContract(new ContractGetBindingModel { Id = _id }).Result;
                var result = _serviceContract.UpdateContract(new ContractSetBindingModel
                {
                    Id = _id.Value,
                    Amount = entity.Amount,
                    ClientId = entity.ClientId,
                    Date = entity.Date,
                    DirectoryId = entity.DirectoryId,
                    ExpirationDate = entity.ExpirationDate,
                    Status = 2,
                    Type = entity.Type,
                    UserId = entity.UserId
                });
                MessageBox.Show("Договор успешно перезаключен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAddInsuranceCase_Click(object sender, EventArgs e)
        {
            var entity = _serviceContract.GetContract(new ContractGetBindingModel { Id = _id }).Result;
            var result = _serviceContract.UpdateContract(new ContractSetBindingModel
            {
                Id = _id.Value,
                Amount = entity.Amount,
                ClientId = entity.ClientId,
                Date = entity.Date,
                DirectoryId = entity.DirectoryId,
                ExpirationDate = entity.ExpirationDate,
                Status = 3,
                Type = entity.Type,
                UserId = entity.UserId
            });
            var dir = _serviceDirectory.GetDirectory(new DirectoryGetBindingModel { Id = entity.DirectoryId }).Result;
            _serviceInsuranceCase.CreateInsuranceCase(new InsuranceCaseSetBindingModel
            {
                ContractId = entity.Id,
                Amount = dir.DamageAmount,
                Date = DateTime.Now
            });
            MessageBox.Show("Сумма возмещения ущерба составляет: " + dir.DamageAmount + "руб.", "Страховой случай зафиксирован", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            if (CheckFill())
            {
                int term = 0;
                int diff = dateTimePickerTo.Value.Month - dateTimePickerFrom.Value.Month;
                if (diff <= 6) term = 1;
                else if (diff > 6 && diff <= 18) term = 2;
                else if (diff > 18) term = 3;
                Enum.TryParse<ContractTypes>(comboBoxType.SelectedValue.ToString(), out ContractTypes type);
                var directory = _serviceDirectory.GetDirectory((int)type, term).Result;
                textBoxAmount.Text = directory.InsuranceFee.ToString();
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля корректными данными", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public Document makeDoc()
        {
            Document document = null;
            if (_id.HasValue)
            {
                var model = _serviceContract.GetContract(new ContractGetBindingModel { Id = _id }).Result;

                var winword = new Microsoft.Office.Interop.Word.Application();
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);


                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем текстВ
                range.Text = "Ведомость доходов от предоставления займов";

                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();

                var paragraph12 = document.Paragraphs.Add(missing);
                var range12 = paragraph12.Range;
                //задаем текстВ
                range12.Text = "Печать от даты " + (DateTime.Now.Date).ToString("yyyy.MM.dd");

                //задаем настройки шрифта
                var font12 = range12.Font;
                font12.Size = 16;
                font12.Name = "Times New Roman";
                font12.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat12 = range12.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range12.InsertParagraphAfter();


                string FromDate = (model.Date).ToString("yyyy.MM.dd");

                var paragraph2 = document.Paragraphs.Add(missing);
                var range2 = paragraph2.Range;
                //задаем текстВ
                range2.Text = "Дата: " + FromDate;
                //задаем настройки шрифта
                var font2 = range2.Font;
                font2.Size = 12;
                font2.Name = "Times New Roman";
                font2.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat2 = range2.ParagraphFormat;
                paragraphFormat2.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat2.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat2.SpaceAfter = 10;
                paragraphFormat2.SpaceBefore = 0;
                //добавляем абзац в документ
                range2.InsertParagraphAfter();



                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs("@d:sample.doc", ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            return document;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //document.
                //pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 826, 1169);
                //pd.DefaultPageSettings.Landscape = true;
                ////pd.PrintPage += printDocument_PrintPage;
                var doc = makeDoc();
                if (doc != null)
                {
                    if (SetupThePrinting()) doc.PrintOut();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }
        }

        //private void printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    Bitmap bmp = new Bitmap(pd.DefaultPageSettings.Bounds.Width, pd.DefaultPageSettings.Bounds.Height);
            
        //    ev.Graphics.DrawImage(bmp, 0, 0);
        //}

        private bool SetupThePrinting()
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
                    return true;

                return false;
        }
    }
}
