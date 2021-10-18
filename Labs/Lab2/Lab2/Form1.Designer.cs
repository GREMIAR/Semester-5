
namespace Lab2
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedDiploma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.livesFarAway = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.needsApartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PushForwardBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam1_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam2_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exam3_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedDiploma2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.livesFarAway2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.needsApartment2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Refresh = new System.Windows.Forms.Button();
            this.FilterAllExams5 = new System.Windows.Forms.Button();
            this.FilterDiploma = new System.Windows.Forms.Button();
            this.ForeignCity = new System.Windows.Forms.Button();
            this.NeedsHousing = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1326, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PushForwardBtn,
            this.id2,
            this.Lastname2,
            this.Exam1_2,
            this.Exam2_2,
            this.Exam3_2,
            this.RedDiploma2,
            this.livesFarAway2,
            this.needsApartment2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 671);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1070, 94);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.id,
            this.Lastname,
            this.Exam1,
            this.Exam2,
            this.Exam3,
            this.RedDiploma,
            this.livesFarAway,
            this.needsApartment});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1070, 662);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Remove.HeaderText = "Удалить";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Width = 56;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // Lastname
            // 
            this.Lastname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Lastname.HeaderText = "Фамилия";
            this.Lastname.Name = "Lastname";
            this.Lastname.ReadOnly = true;
            this.Lastname.Width = 81;
            // 
            // Exam1
            // 
            this.Exam1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam1.HeaderText = "1 экзамен";
            this.Exam1.Name = "Exam1";
            this.Exam1.ReadOnly = true;
            this.Exam1.Width = 78;
            // 
            // Exam2
            // 
            this.Exam2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam2.HeaderText = "2 экзамен";
            this.Exam2.Name = "Exam2";
            this.Exam2.ReadOnly = true;
            this.Exam2.Width = 78;
            // 
            // Exam3
            // 
            this.Exam3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam3.HeaderText = "3 экзамен";
            this.Exam3.Name = "Exam3";
            this.Exam3.ReadOnly = true;
            this.Exam3.Width = 78;
            // 
            // RedDiploma
            // 
            this.RedDiploma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RedDiploma.HeaderText = "Наличие красного диплома";
            this.RedDiploma.Name = "RedDiploma";
            this.RedDiploma.ReadOnly = true;
            this.RedDiploma.Width = 157;
            // 
            // livesFarAway
            // 
            this.livesFarAway.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.livesFarAway.HeaderText = "Наличие жилья в городе";
            this.livesFarAway.Name = "livesFarAway";
            this.livesFarAway.ReadOnly = true;
            this.livesFarAway.Width = 112;
            // 
            // needsApartment
            // 
            this.needsApartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.needsApartment.HeaderText = "Нуждается в общежитии";
            this.needsApartment.Name = "needsApartment";
            this.needsApartment.ReadOnly = true;
            this.needsApartment.Width = 144;
            // 
            // PushForwardBtn
            // 
            this.PushForwardBtn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PushForwardBtn.HeaderText = "Добавить";
            this.PushForwardBtn.Name = "PushForwardBtn";
            this.PushForwardBtn.Width = 63;
            // 
            // id2
            // 
            this.id2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id2.HeaderText = "ID";
            this.id2.Name = "id2";
            this.id2.Width = 43;
            // 
            // Lastname2
            // 
            this.Lastname2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Lastname2.HeaderText = "Фамилия";
            this.Lastname2.Name = "Lastname2";
            this.Lastname2.Width = 81;
            // 
            // Exam1_2
            // 
            this.Exam1_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam1_2.HeaderText = "1 экзамен";
            this.Exam1_2.Name = "Exam1_2";
            this.Exam1_2.Width = 85;
            // 
            // Exam2_2
            // 
            this.Exam2_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam2_2.HeaderText = "2 экзамен";
            this.Exam2_2.Name = "Exam2_2";
            this.Exam2_2.Width = 85;
            // 
            // Exam3_2
            // 
            this.Exam3_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Exam3_2.HeaderText = "3 экзамен";
            this.Exam3_2.Name = "Exam3_2";
            this.Exam3_2.Width = 85;
            // 
            // RedDiploma2
            // 
            this.RedDiploma2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RedDiploma2.HeaderText = "Наличие красного диплома";
            this.RedDiploma2.Name = "RedDiploma2";
            this.RedDiploma2.Width = 157;
            // 
            // livesFarAway2
            // 
            this.livesFarAway2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.livesFarAway2.HeaderText = "Наличие жилья в городе";
            this.livesFarAway2.Name = "livesFarAway2";
            this.livesFarAway2.Width = 112;
            // 
            // needsApartment2
            // 
            this.needsApartment2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.needsApartment2.HeaderText = "Нуждается в общежитии";
            this.needsApartment2.Name = "needsApartment2";
            this.needsApartment2.Width = 144;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.NeedsHousing, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.ForeignCity, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.FilterDiploma, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.FilterAllExams5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Refresh, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1079, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 662);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // Refresh
            // 
            this.Refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Refresh.Location = new System.Drawing.Point(3, 3);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(238, 44);
            this.Refresh.TabIndex = 0;
            this.Refresh.Text = "Показать все";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // FilterAllExams5
            // 
            this.FilterAllExams5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterAllExams5.Location = new System.Drawing.Point(3, 53);
            this.FilterAllExams5.Name = "FilterAllExams5";
            this.FilterAllExams5.Size = new System.Drawing.Size(238, 44);
            this.FilterAllExams5.TabIndex = 1;
            this.FilterAllExams5.Text = "Экзамены на отлично";
            this.FilterAllExams5.UseVisualStyleBackColor = true;
            this.FilterAllExams5.Click += new System.EventHandler(this.FilterAllExams5_Click);
            // 
            // FilterDiploma
            // 
            this.FilterDiploma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterDiploma.Location = new System.Drawing.Point(3, 103);
            this.FilterDiploma.Name = "FilterDiploma";
            this.FilterDiploma.Size = new System.Drawing.Size(238, 44);
            this.FilterDiploma.TabIndex = 2;
            this.FilterDiploma.Text = "Аттестат с отличием";
            this.FilterDiploma.UseVisualStyleBackColor = true;
            this.FilterDiploma.Click += new System.EventHandler(this.FilterDiploma_Click);
            // 
            // ForeignCity
            // 
            this.ForeignCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForeignCity.Location = new System.Drawing.Point(3, 153);
            this.ForeignCity.Name = "ForeignCity";
            this.ForeignCity.Size = new System.Drawing.Size(238, 44);
            this.ForeignCity.TabIndex = 3;
            this.ForeignCity.Text = "Проживает в другом городе";
            this.ForeignCity.UseVisualStyleBackColor = true;
            this.ForeignCity.Click += new System.EventHandler(this.ForeignCity_Click);
            // 
            // NeedsHousing
            // 
            this.NeedsHousing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NeedsHousing.Location = new System.Drawing.Point(3, 203);
            this.NeedsHousing.Name = "NeedsHousing";
            this.NeedsHousing.Size = new System.Drawing.Size(238, 44);
            this.NeedsHousing.TabIndex = 4;
            this.NeedsHousing.Text = "Нуждается в общежитии";
            this.NeedsHousing.UseVisualStyleBackColor = true;
            this.NeedsHousing.Click += new System.EventHandler(this.NeedsHousing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1340, 800);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam3;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedDiploma;
        private System.Windows.Forms.DataGridViewTextBoxColumn livesFarAway;
        private System.Windows.Forms.DataGridViewTextBoxColumn needsApartment;
        private System.Windows.Forms.DataGridViewButtonColumn PushForwardBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam1_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam2_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exam3_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedDiploma2;
        private System.Windows.Forms.DataGridViewTextBoxColumn livesFarAway2;
        private System.Windows.Forms.DataGridViewTextBoxColumn needsApartment2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button NeedsHousing;
        private System.Windows.Forms.Button ForeignCity;
        private System.Windows.Forms.Button FilterDiploma;
        private System.Windows.Forms.Button FilterAllExams5;
        private System.Windows.Forms.Button Refresh;
    }
}

