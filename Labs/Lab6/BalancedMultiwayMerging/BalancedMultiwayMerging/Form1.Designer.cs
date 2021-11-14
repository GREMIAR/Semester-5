
namespace BalancedMultiwayMerging
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Open = new System.Windows.Forms.Button();
            this.textBox_mergeWaysCount = new System.Windows.Forms.TextBox();
            this.label_mergeWays = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(12, 69);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(187, 36);
            this.button_Open.TabIndex = 0;
            this.button_Open.Text = "Открыть и сортировать";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // textBox_mergeWaysCount
            // 
            this.textBox_mergeWaysCount.Location = new System.Drawing.Point(12, 43);
            this.textBox_mergeWaysCount.Name = "textBox_mergeWaysCount";
            this.textBox_mergeWaysCount.Size = new System.Drawing.Size(187, 20);
            this.textBox_mergeWaysCount.TabIndex = 1;
            // 
            // label_mergeWays
            // 
            this.label_mergeWays.AutoSize = true;
            this.label_mergeWays.Location = new System.Drawing.Point(12, 27);
            this.label_mergeWays.Name = "label_mergeWays";
            this.label_mergeWays.Size = new System.Drawing.Size(145, 13);
            this.label_mergeWays.TabIndex = 2;
            this.label_mergeWays.Text = "Количество путей слияния:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 877);
            this.Controls.Add(this.label_mergeWays);
            this.Controls.Add(this.textBox_mergeWaysCount);
            this.Controls.Add(this.button_Open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.TextBox textBox_mergeWaysCount;
        private System.Windows.Forms.Label label_mergeWays;
    }
}

