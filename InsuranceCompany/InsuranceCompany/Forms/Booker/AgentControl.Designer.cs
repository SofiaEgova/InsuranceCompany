namespace InsuranceCompany.Forms.Booker
{
    partial class AgentControl
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
            this.standartControl1 = new InsuranceCompany.Forms.StandartControl();
            this.SuspendLayout();
            // 
            // standartControl1
            // 
            this.standartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standartControl1.Location = new System.Drawing.Point(0, 0);
            this.standartControl1.Name = "standartControl";
            this.standartControl1.Size = new System.Drawing.Size(800, 500);
            this.standartControl1.TabIndex = 0;
            // 
            // AgentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.standartControl1);
            this.Name = "AgentControl";
            this.Size = new System.Drawing.Size(891, 532);
            this.ResumeLayout(false);

        }

        #endregion

        private StandartControl standartControl1;
    }
}
