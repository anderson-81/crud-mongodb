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
    public partial class FrmPerson : Form
    {
        public FrmPerson(List<Person> list)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Salary");
            dt.Columns.Add("DateBirth");
            dt.Columns.Add("Genre");

            list.ForEach(delegate(Person p)
            {
                DataRow row = dt.NewRow();
                row["Id"] = p.Id;
                row["Name"] = p.Name;
                row["Email"] = p.Email;
                row["Salary"] = string.Format("{0:#.00}", p.PhysicalPerson.Salary);
                row["DateBirth"] = p.PhysicalPerson.Birthday.ToShortDateString(); 
                row["Genre"] = p.PhysicalPerson.Gender;
                dt.Rows.Add(row);
            });

            this.PhysicalPersonBindingSource.DataSource = dt;
        }

        private void FrmPhysicalPerson_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
