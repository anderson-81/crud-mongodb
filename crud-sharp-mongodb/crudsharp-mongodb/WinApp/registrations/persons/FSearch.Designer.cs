namespace WinApp.registrations.persons
{
    partial class FrmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.txtDataSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdCode = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.GridPerson = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(12, 92);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(129, 24);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "Data Search:";
            // 
            // txtDataSearch
            // 
            this.txtDataSearch.Location = new System.Drawing.Point(16, 119);
            this.txtDataSearch.Name = "txtDataSearch";
            this.txtDataSearch.Size = new System.Drawing.Size(440, 29);
            this.txtDataSearch.TabIndex = 2;
            this.txtDataSearch.Enter += new System.EventHandler(this.txtDataSearch_Enter);
            this.txtDataSearch.Leave += new System.EventHandler(this.txtDataSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(466, 119);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdCode
            // 
            this.rdCode.AutoSize = true;
            this.rdCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdCode.Location = new System.Drawing.Point(556, 60);
            this.rdCode.Name = "rdCode";
            this.rdCode.Size = new System.Drawing.Size(116, 28);
            this.rdCode.TabIndex = 5;
            this.rdCode.Text = "For Code";
            this.rdCode.UseVisualStyleBackColor = true;
            this.rdCode.CheckedChanged += new System.EventHandler(this.rdCode_CheckedChanged);
            this.rdCode.Click += new System.EventHandler(this.rdCode_Click);
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Checked = true;
            this.rdName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdName.Location = new System.Drawing.Point(429, 60);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(121, 28);
            this.rdName.TabIndex = 6;
            this.rdName.TabStop = true;
            this.rdName.Text = "For Name";
            this.rdName.UseVisualStyleBackColor = true;
            this.rdName.CheckedChanged += new System.EventHandler(this.rdName_CheckedChanged);
            this.rdName.Click += new System.EventHandler(this.rdName_Click);
            // 
            // GridPerson
            // 
            this.GridPerson.AllowUserToAddRows = false;
            this.GridPerson.AllowUserToDeleteRows = false;
            this.GridPerson.AllowUserToResizeColumns = false;
            this.GridPerson.AllowUserToResizeRows = false;
            this.GridPerson.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Email,
            this.Salary,
            this.Birthday,
            this.Gender});
            this.GridPerson.Location = new System.Drawing.Point(16, 154);
            this.GridPerson.MultiSelect = false;
            this.GridPerson.Name = "GridPerson";
            this.GridPerson.RowHeadersVisible = false;
            this.GridPerson.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridPerson.RowTemplate.ReadOnly = true;
            this.GridPerson.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridPerson.Size = new System.Drawing.Size(650, 440);
            this.GridPerson.TabIndex = 7;
            this.GridPerson.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPerson_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Width = 290;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "NAME";
            this.Name.Name = "Name";
            this.Name.Width = 350;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "EMAIL";
            this.Email.Name = "Email";
            this.Email.Visible = false;
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "SALARY";
            this.Salary.Name = "Salary";
            this.Salary.Visible = false;
            // 
            // Birthday
            // 
            this.Birthday.DataPropertyName = "Birthday";
            this.Birthday.HeaderText = "BIRTHDAY";
            this.Birthday.Name = "Birthday";
            this.Birthday.Visible = false;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "GENDER";
            this.Gender.Name = "Gender";
            this.Gender.Visible = false;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(674, 602);
            this.Controls.Add(this.GridPerson);
            this.Controls.Add(this.rdName);
            this.Controls.Add(this.rdCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDataSearch);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(690, 640);
            this.MinimumSize = new System.Drawing.Size(690, 640);
            //this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.txtDataSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtDataSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdCode;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.DataGridView GridPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
    }
}