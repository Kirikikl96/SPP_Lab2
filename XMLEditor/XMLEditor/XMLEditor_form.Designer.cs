namespace XMLEditor
{
    partial class XMLEditor_form
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.lblName = new System.Windows.Forms.Label();
            this.lblParams = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtbName = new System.Windows.Forms.TextBox();
            this.txtbParams = new System.Windows.Forms.TextBox();
            this.txtbPackage = new System.Windows.Forms.TextBox();
            this.txtbTime = new System.Windows.Forms.TextBox();
            this.lblEdit = new System.Windows.Forms.Label();
            this.bttnOK = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.lblXML = new System.Windows.Forms.Label();
            this.CloseXML = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MainMenu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(506, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile,
            this.SaveAs,
            this.CloseProgram});
            this.FileMenu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(55, 20);
            this.FileMenu.Text = "Файл";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(190, 22);
            this.OpenFile.Text = "Открыть";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Enabled = false;
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(190, 22);
            this.SaveFile.Text = "Сохранить";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Enabled = false;
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(190, 22);
            this.SaveAs.Text = "Сохранить как...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // CloseProgram
            // 
            this.CloseProgram.Name = "CloseProgram";
            this.CloseProgram.Size = new System.Drawing.Size(190, 22);
            this.CloseProgram.Text = "Выход";
            this.CloseProgram.Click += new System.EventHandler(this.CloseProgram_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML-files|*.xml";
            // 
            // tabControl
            // 
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(10, 18);
            this.tabControl.Location = new System.Drawing.Point(12, 59);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(489, 322);
            this.tabControl.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(13, 424);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // lblParams
            // 
            this.lblParams.AutoSize = true;
            this.lblParams.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblParams.Location = new System.Drawing.Point(13, 458);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(129, 18);
            this.lblParams.TabIndex = 5;
            this.lblParams.Text = "Params count:";
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPackage.Location = new System.Drawing.Point(13, 491);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(82, 18);
            this.lblPackage.TabIndex = 6;
            this.lblPackage.Text = "Package:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(13, 521);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(57, 18);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Time:";
            // 
            // txtbName
            // 
            this.txtbName.Location = new System.Drawing.Point(146, 425);
            this.txtbName.Name = "txtbName";
            this.txtbName.Size = new System.Drawing.Size(100, 20);
            this.txtbName.TabIndex = 8;
            // 
            // txtbParams
            // 
            this.txtbParams.Location = new System.Drawing.Point(146, 459);
            this.txtbParams.Name = "txtbParams";
            this.txtbParams.Size = new System.Drawing.Size(100, 20);
            this.txtbParams.TabIndex = 9;
            // 
            // txtbPackage
            // 
            this.txtbPackage.Location = new System.Drawing.Point(146, 492);
            this.txtbPackage.Name = "txtbPackage";
            this.txtbPackage.Size = new System.Drawing.Size(100, 20);
            this.txtbPackage.TabIndex = 10;
            // 
            // txtbTime
            // 
            this.txtbTime.Location = new System.Drawing.Point(146, 522);
            this.txtbTime.Name = "txtbTime";
            this.txtbTime.Size = new System.Drawing.Size(100, 20);
            this.txtbTime.TabIndex = 11;
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEdit.Location = new System.Drawing.Point(12, 384);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(217, 23);
            this.lblEdit.TabIndex = 12;
            this.lblEdit.Text = "Редактор атрибутов:";
            // 
            // bttnOK
            // 
            this.bttnOK.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnOK.Location = new System.Drawing.Point(16, 552);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 13;
            this.bttnOK.Text = "ОК";
            this.bttnOK.UseVisualStyleBackColor = false;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bttnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnCancel.Location = new System.Drawing.Point(119, 552);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 14;
            this.bttnCancel.Text = "Отмена";
            this.bttnCancel.UseVisualStyleBackColor = false;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // lblXML
            // 
            this.lblXML.AutoSize = true;
            this.lblXML.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXML.Location = new System.Drawing.Point(12, 24);
            this.lblXML.Name = "lblXML";
            this.lblXML.Size = new System.Drawing.Size(140, 23);
            this.lblXML.TabIndex = 16;
            this.lblXML.Text = "XML дерево:";
            // 
            // CloseXML
            // 
            this.CloseXML.Location = new System.Drawing.Point(407, 30);
            this.CloseXML.Name = "CloseXML";
            this.CloseXML.Size = new System.Drawing.Size(87, 23);
            this.CloseXML.TabIndex = 17;
            this.CloseXML.Text = "Закрыть XML";
            this.CloseXML.UseVisualStyleBackColor = true;
            this.CloseXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // XMLEditor_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(506, 587);
            this.Controls.Add(this.CloseXML);
            this.Controls.Add(this.lblXML);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.txtbTime);
            this.Controls.Add(this.txtbPackage);
            this.Controls.Add(this.txtbParams);
            this.Controls.Add(this.txtbName);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPackage);
            this.Controls.Add(this.lblParams);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "XMLEditor_form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPP_2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XMLEditor_form_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem CloseProgram;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtbName;
        private System.Windows.Forms.TextBox txtbParams;
        private System.Windows.Forms.TextBox txtbPackage;
        private System.Windows.Forms.TextBox txtbTime;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Label lblXML;
        private System.Windows.Forms.Button CloseXML;
    }
}

