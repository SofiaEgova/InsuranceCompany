namespace InsuranceCompany.Forms.Agent
{
    partial class ContractControl
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
            this.buttonDiagram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // standartControl1
            // 
            this.standartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standartControl1.Location = new System.Drawing.Point(0, 0);
            this.standartControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.standartControl1.Name = "standartControl1";
            this.standartControl1.Size = new System.Drawing.Size(876, 593);
            this.standartControl1.TabIndex = 0;
            // 
            // buttonDiagram
            // 
            this.buttonDiagram.Location = new System.Drawing.Point(536, 0);
            this.buttonDiagram.Name = "buttonDiagram";
            this.buttonDiagram.Size = new System.Drawing.Size(255, 28);
            this.buttonDiagram.TabIndex = 1;
            this.buttonDiagram.Text = "Диаграмма по видам страхования";
            this.buttonDiagram.UseVisualStyleBackColor = true;
            this.buttonDiagram.Click += new System.EventHandler(this.buttonDiagram_Click);
            // 
            // ContractControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDiagram);
            this.Controls.Add(this.standartControl1);
            this.Name = "ContractControl";
            this.Size = new System.Drawing.Size(876, 593);
            this.ResumeLayout(false);

        }

        #endregion

        private StandartControl standartControl1;
        private System.Windows.Forms.Button buttonDiagram;
    }
}
