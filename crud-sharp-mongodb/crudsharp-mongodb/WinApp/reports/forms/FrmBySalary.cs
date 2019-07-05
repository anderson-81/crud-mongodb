using libCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp.reports.forms
{
    public partial class FrmBySalary : Form
    {
        public FrmBySalary(List<Person> list)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Salary");

            list.ForEach(delegate(Person p)
            {
                DataRow row = dt.NewRow();
                row["Name"] = p.Name;
                row["Salary"] = p.PhysicalPerson.Salary;
                dt.Rows.Add(row);
            });

            this.PhysicalPersonBindingSource.DataSource = dt;
        }

        private void FrmBySalary_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
