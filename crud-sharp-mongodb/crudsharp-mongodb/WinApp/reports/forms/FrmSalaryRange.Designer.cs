namespace WinApp.reports.forms
{
    partial class FrmSalaryRange
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalaryRange));
            this.PhysicalPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PhysicalPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PhysicalPersonBindingSource
            // 
            this.PhysicalPersonBindingSource.DataMember = "PhysicalPerson";
            // 
            // reportViewer
            // 
            this.reportViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.IsDocumentMapWidthFixed = true;
            reportDataSource1.Name = "DSPhysicalPerson";
            reportDataSource1.Value = this.PhysicalPersonBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "WinApp.reports.rdlcs.RpSalaryRange.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(584, 362);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.UseWaitCursor = true;
            // 
            // FrmSalaryRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.reportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSalaryRange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report by Salary Range";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSalaryRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhysicalPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource personbindingSource;
        private System.Windows.Forms.BindingSource PhysicalPersonBindingSource;

    }
}