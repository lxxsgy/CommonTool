namespace LeedtoolsModules
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ImageDragOCRPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rasterImageViewer1 = new Leadtools.WinForms.RasterImageViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.checkBoxLanguage = new System.Windows.Forms.CheckBox();
            this.ImageDragOCRPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageDragOCRPage
            // 
            this.ImageDragOCRPage.Controls.Add(this.panel1);
            this.ImageDragOCRPage.Location = new System.Drawing.Point(4, 22);
            this.ImageDragOCRPage.Name = "ImageDragOCRPage";
            this.ImageDragOCRPage.Padding = new System.Windows.Forms.Padding(3);
            this.ImageDragOCRPage.Size = new System.Drawing.Size(780, 450);
            this.ImageDragOCRPage.TabIndex = 0;
            this.ImageDragOCRPage.Text = "图像识别";
            this.ImageDragOCRPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 444);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.67568F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.32433F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(774, 444);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxLanguage);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.richTextBox4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 107);
            this.panel2.TabIndex = 0;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(222, 65);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(56, 23);
            this.button12.TabIndex = 26;
            this.button12.Text = "缩小";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(143, 65);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(56, 23);
            this.button11.TabIndex = 25;
            this.button11.Text = "放大";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(312, 65);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(56, 23);
            this.button8.TabIndex = 24;
            this.button8.Text = "标记";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(456, 18);
            this.richTextBox4.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(290, 87);
            this.richTextBox4.TabIndex = 23;
            this.richTextBox4.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "选择要识别的图像：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(41, 32);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(292, 21);
            this.textBox4.TabIndex = 21;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(368, 32);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 18);
            this.button7.TabIndex = 20;
            this.button7.Text = ">>>";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rasterImageViewer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(766, 322);
            this.panel3.TabIndex = 1;
            // 
            // rasterImageViewer1
            // 
            this.rasterImageViewer1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.rasterImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rasterImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.rasterImageViewer1.Name = "rasterImageViewer1";
            this.rasterImageViewer1.Size = new System.Drawing.Size(766, 322);
            this.rasterImageViewer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ImageDragOCRPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // checkBoxLanguage
            // 
            this.checkBoxLanguage.AutoSize = true;
            this.checkBoxLanguage.Location = new System.Drawing.Point(81, 71);
            this.checkBoxLanguage.Name = "checkBoxLanguage";
            this.checkBoxLanguage.Size = new System.Drawing.Size(48, 16);
            this.checkBoxLanguage.TabIndex = 27;
            this.checkBoxLanguage.Text = "中文";
            this.checkBoxLanguage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ImageDragOCRPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage ImageDragOCRPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel3;
        private Leadtools.WinForms.RasterImageViewer rasterImageViewer1;
        private System.Windows.Forms.CheckBox checkBoxLanguage;
    }
}

