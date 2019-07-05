using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libCrud;

namespace WinApp.registrations.persons
{
    public partial class FrmSearch : Form
    {
        private FrmRegistration freg;
       
        public FrmSearch()
        {
            InitializeComponent();
        }

        public FrmSearch(FrmRegistration freg)
        {
            InitializeComponent();
            this.freg = freg;
        }

        private void txtDataSearch_Load(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            this.GridPerson.Visible = false;
            this.rdName.Checked = true;
            this.txtDataSearch.Clear();
            this.txtDataSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearGrid(0);

            if (this.rdCode.Checked)
            {
                if (this.txtDataSearch.Text != String.Empty)
                {
                    List<Person> list = new List<Person>();
                    list.Add(Crud.Get_Person_By_ID(this.txtDataSearch.Text.Trim()));
                    if (list.Count > 0)
                    {
                        FillGrid(list);
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearSearch();
                    }
                }
                else
                    MessageBox.Show("Enter a code to search.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                List<Person> list = Crud.Get_Persons_By_Name(this.txtDataSearch.Text.Trim());

                if (list.Count() > 0)
                {
                    FillGrid(list);
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSearch();
                }
            }
        }

        private void FillGrid(List<Person> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("email");
            dt.Columns.Add("salary");
            dt.Columns.Add("birthday");
            dt.Columns.Add("gender");

            list.ForEach(delegate(Person p)
            {
                DataRow row = dt.NewRow();
                row["id"] = p.Id;
                row["name"] = p.Name;
                row["email"] = p.Email;
                row["salary"] = p.PhysicalPerson.Salary;
                row["birthday"] = p.PhysicalPerson.Birthday;
                row["gender"] = p.PhysicalPerson.Gender;
                dt.Rows.Add(row);
            });

            this.GridPerson.DataSource = dt;
            this.GridPerson.Visible = true;
        }

        private void txtDataSearch_Enter(object sender, EventArgs e)
        {
            this.txtDataSearch.BackColor = Color.Yellow;
        }

        private void rdCode_CheckedChanged(object sender, EventArgs e)
        {
            ClearGrid(1);
        }

        private void rdName_CheckedChanged(object sender, EventArgs e)
        {
            ClearGrid(1);
        }

        private void ClearGrid(int id)
        {
            this.GridPerson.Visible = false;
            if(id == 1)
            {
                this.txtDataSearch.Clear();
            }
        }

        private void rdCode_Click(object sender, EventArgs e)
        {
            ClearGrid(0);
        }

        private void rdName_Click(object sender, EventArgs e)
        {
            ClearGrid(0);
        }

        private void txtDataSearch_Leave(object sender, EventArgs e)
        {
            this.txtDataSearch.BackColor = Color.White;
        }

        private void GridPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.freg == null)
            {
                this.freg = new FrmRegistration();
            }

            this.freg.option_clear = 1;
            this.freg.SetPhysicalPerson(this.GridPerson.SelectedRows[0].Cells[0].Value.ToString(), this.GridPerson.SelectedRows[0].Cells[1].Value.ToString(), this.GridPerson.SelectedRows[0].Cells[2].Value.ToString(), Decimal.Parse(this.GridPerson.SelectedRows[0].Cells[3].Value.ToString()), DateTime.Parse(this.GridPerson.SelectedRows[0].Cells[4].Value.ToString()), this.GridPerson.SelectedRows[0].Cells[5].Value.ToString()[0], this);
            this.Visible = false;

            if (!this.freg.Visible)
            {
                this.freg.ShowDialog(this);
            }
        }

    }
}
