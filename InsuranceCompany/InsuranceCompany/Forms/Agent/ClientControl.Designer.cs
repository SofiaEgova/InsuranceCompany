namespace InsuranceCompany.Forms.Agent
{
    partial class ClientControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFilterSum = new System.Windows.Forms.Button();
            this.buttonFilterDate = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.standartControl1 = new InsuranceCompany.Forms.StandartControl();
            this.SuspendLayout();
            // 
            // buttonFilterSum
            // 
            this.buttonFilterSum.Location = new System.Drawing.Point(3, 0);
            this.buttonFilterSum.Name = "buttonFilterSum";
            this.buttonFilterSum.Size = new System.Drawing.Size(491, 27);
            this.buttonFilterSum.TabIndex = 1;
            this.buttonFilterSum.Text = "Показ клиентов, заключивших договора на сумму свыше 1млн";
            this.buttonFilterSum.UseVisualStyleBackColor = true;
            this.buttonFilterSum.Click += new System.EventHandler(this.buttonFilterSum_Click);
            // 
            // buttonFilterDate
            // 
            this.buttonFilterDate.Location = new System.Drawing.Point(526, 0);
            this.buttonFilterDate.Name = "buttonFilterDate";
            this.buttonFilterDate.Size = new System.Drawing.Size(559, 27);
            this.buttonFilterDate.TabIndex = 2;
            this.buttonFilterDate.Text = "Показ клиентов, договора которых истекают в конце текущего года";
            this.buttonFilterDate.UseVisualStyleBackColor = true;
            this.buttonFilterDate.Click += new System.EventHandler(this.buttonFilterDate_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(1200,660);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(97, 24);
            this.buttonFind.TabIndex = 3;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(650, 660);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер паспорта или договора:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(900, 660);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(254, 22);
            this.textBoxNumber.TabIndex = 5;
            // 
            // standartControl1
            // 
            this.standartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standartControl1.Location = new System.Drawing.Point(0, 0);
            this.standartControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.standartControl1.Name = "standartControl1";
            this.standartControl1.Size = new System.Drawing.Size(884, 500);
            this.standartControl1.TabIndex = 0;
            // 
            // ClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.buttonFilterDate);
            this.Controls.Add(this.buttonFilterSum);
            this.Controls.Add(this.standartControl1);
            this.Name = "ClientControl";
            this.Size = new System.Drawing.Size(884, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StandartControl standartControl1;
        private System.Windows.Forms.Button buttonFilterSum;
        private System.Windows.Forms.Button buttonFilterDate;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumber;
    }
}
