namespace Lab5
{
    partial class MainForm
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
            this.treeBox = new System.Windows.Forms.TreeView();
            this.PanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.PanelMenuItem = new System.Windows.Forms.TableLayoutPanel();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.PanelMain.SuspendLayout();
            this.PanelMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBox
            // 
            this.treeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBox.HideSelection = false;
            this.treeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeBox.Location = new System.Drawing.Point(5, 5);
            this.treeBox.Margin = new System.Windows.Forms.Padding(5);
            this.treeBox.Name = "treeBox";
            this.treeBox.Size = new System.Drawing.Size(296, 234);
            this.treeBox.TabIndex = 100;
            this.treeBox.TabStop = false;
            // 
            // PanelMain
            // 
            this.PanelMain.ColumnCount = 2;
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.PanelMain.Controls.Add(this.treeBox, 0, 0);
            this.PanelMain.Controls.Add(this.PanelMenuItem, 1, 0);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.RowCount = 1;
            this.PanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMain.Size = new System.Drawing.Size(470, 244);
            this.PanelMain.TabIndex = 1;
            // 
            // PanelMenuItem
            // 
            this.PanelMenuItem.ColumnCount = 2;
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelMenuItem.Controls.Add(this.textBoxP, 0, 2);
            this.PanelMenuItem.Controls.Add(this.textBoxQ, 1, 2);
            this.PanelMenuItem.Controls.Add(this.buttonClear, 0, 4);
            this.PanelMenuItem.Controls.Add(this.labelSearch, 0, 0);
            this.PanelMenuItem.Controls.Add(this.textBoxSearch, 0, 1);
            this.PanelMenuItem.Controls.Add(this.textBoxAdd, 0, 3);
            this.PanelMenuItem.Controls.Add(this.buttonAdd, 1, 3);
            this.PanelMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMenuItem.Location = new System.Drawing.Point(311, 5);
            this.PanelMenuItem.Margin = new System.Windows.Forms.Padding(5);
            this.PanelMenuItem.Name = "PanelMenuItem";
            this.PanelMenuItem.RowCount = 6;
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelMenuItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelMenuItem.Size = new System.Drawing.Size(154, 234);
            this.PanelMenuItem.TabIndex = 1;
            // 
            // labelSearch
            // 
            this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearch.AutoSize = true;
            this.PanelMenuItem.SetColumnSpan(this.labelSearch, 2);
            this.labelSearch.Location = new System.Drawing.Point(2, 0);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(150, 13);
            this.labelSearch.TabIndex = 8;
            this.labelSearch.Text = "Поиск";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenuItem.SetColumnSpan(this.textBoxSearch, 2);
            this.textBoxSearch.Location = new System.Drawing.Point(0, 13);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(154, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(79, 62);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(73, 21);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdd.Location = new System.Drawing.Point(0, 63);
            this.textBoxAdd.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(77, 20);
            this.textBoxAdd.TabIndex = 1;
            this.textBoxAdd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenuItem.SetColumnSpan(this.buttonClear, 2);
            this.buttonClear.Location = new System.Drawing.Point(0, 87);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(152, 24);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxQ
            // 
            this.textBoxQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQ.Location = new System.Drawing.Point(77, 37);
            this.textBoxQ.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(77, 20);
            this.textBoxQ.TabIndex = 10;
            // 
            // textBoxP
            // 
            this.textBoxP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxP.Location = new System.Drawing.Point(0, 37);
            this.textBoxP.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(77, 20);
            this.textBoxP.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 244);
            this.Controls.Add(this.PanelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(348, 205);
            this.Name = "MainForm";
            this.Text = "2-3Tree";
            this.PanelMain.ResumeLayout(false);
            this.PanelMenuItem.ResumeLayout(false);
            this.PanelMenuItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeBox;
        private System.Windows.Forms.TableLayoutPanel PanelMain;
        private System.Windows.Forms.TableLayoutPanel PanelMenuItem;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Button buttonClear;
    }
}

