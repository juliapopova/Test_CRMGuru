
namespace Test_CRMGuru
{
    partial class FormMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCountry = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.but_LoadFromBD = new System.Windows.Forms.Button();
            this.but_SearchCountry = new System.Windows.Forms.Button();
            this.textBox_Country = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCountry
            // 
            this.dataGridViewCountry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCountry.Location = new System.Drawing.Point(3, 75);
            this.dataGridViewCountry.Name = "dataGridViewCountry";
            this.dataGridViewCountry.Size = new System.Drawing.Size(1241, 523);
            this.dataGridViewCountry.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewCountry, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1247, 601);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.but_LoadFromBD);
            this.panel1.Controls.Add(this.but_SearchCountry);
            this.panel1.Controls.Add(this.textBox_Country);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 66);
            this.panel1.TabIndex = 4;
            // 
            // but_LoadFromBD
            // 
            this.but_LoadFromBD.Location = new System.Drawing.Point(9, 36);
            this.but_LoadFromBD.Name = "but_LoadFromBD";
            this.but_LoadFromBD.Size = new System.Drawing.Size(433, 23);
            this.but_LoadFromBD.TabIndex = 2;
            this.but_LoadFromBD.Text = "Вывести все страны из базы данных";
            this.but_LoadFromBD.UseVisualStyleBackColor = true;
            this.but_LoadFromBD.Click += new System.EventHandler(this.but_LoadFromBD_Click);
            // 
            // but_SearchCountry
            // 
            this.but_SearchCountry.Location = new System.Drawing.Point(295, 8);
            this.but_SearchCountry.Name = "but_SearchCountry";
            this.but_SearchCountry.Size = new System.Drawing.Size(147, 22);
            this.but_SearchCountry.TabIndex = 1;
            this.but_SearchCountry.Text = "Найти страну";
            this.but_SearchCountry.UseVisualStyleBackColor = true;
            this.but_SearchCountry.Click += new System.EventHandler(this.but_SearchCountry_Click);
            // 
            // textBox_Country
            // 
            this.textBox_Country.ForeColor = System.Drawing.Color.Gray;
            this.textBox_Country.Location = new System.Drawing.Point(9, 9);
            this.textBox_Country.Name = "textBox_Country";
            this.textBox_Country.Size = new System.Drawing.Size(280, 20);
            this.textBox_Country.TabIndex = 0;
            this.textBox_Country.Text = "Введите название страны";
            this.textBox_Country.Click += new System.EventHandler(this.textBox_Country_Click);
            this.textBox_Country.Leave += new System.EventHandler(this.textBox_Country_Leave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Информация о странах";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCountry;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_LoadFromBD;
        private System.Windows.Forms.Button but_SearchCountry;
        private System.Windows.Forms.TextBox textBox_Country;
    }
}

