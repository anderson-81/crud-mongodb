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
    public partial class FrmRegistration : Form
    {
        public int option_clear = 0;
        private string id;
        private FrmSearch frs = null;

        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSalary.Text != String.Empty)
            {
                try
                {
                    Decimal.Parse(this.txtSalary.Text);
                }
                catch (Exception)
                {
                    this.txtSalary.Clear();
                }
            }
        }

        private void FRegistration_Load(object sender, EventArgs e)
        {
            SetIndex();
            if (this.frs != null)
            {
                this.frs.Dispose();
            }
            Clear();
        }

        private void Clear()
        {
            if (this.option_clear == 0)
            {
                this.txtName.Clear();
                this.txtEmail.Clear();
                this.txtSalary.Clear();
                this.dtBirthday.Value = DateTime.Now.AddYears(-18);
                this.rdMale.Checked = true;
                this.btnInsert.Enabled = true;
                this.btnSearch.Enabled = true;
                this.btnClear.Enabled = true;
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.id = "0";
            }
        }

        public void SetValue(string id, string name, string email, string salary, DateTime dateBirth, char genre)
        {
            this.id = id;
            this.txtName.Text = name;
            this.txtEmail.Text = email;
            this.txtSalary.Text = salary;
            this.dtBirthday.Value = dateBirth;

            if (genre == 'M')
                this.rdMale.Checked = true;
            else
                this.rdFemale.Checked = true;
        }

        private void SetIndex()
        {
            this.txtName.TabIndex = 0;
            this.txtEmail.TabIndex = 1;
            this.txtSalary.TabIndex = 2;
            this.dtBirthday.TabIndex = 3;
            this.rdMale.TabIndex = 4;
            this.rdFemale.TabIndex = 5;
            this.btnInsert.TabIndex = 6;
            this.btnSearch.TabIndex = 7;
            this.btnClear.TabIndex = 8;
            this.btnEdit.TabIndex = 9;
            this.btnDelete.TabIndex = 10;
        }

        public void SetPhysicalPerson(string id, String name, String email, Decimal salary, DateTime dateBirth, char genre, FrmSearch frs)
        {
            this.id = id;
            this.txtName.Text = name;
            this.txtEmail.Text = email;
            this.txtSalary.Text = salary.ToString();
            this.dtBirthday.Value = dateBirth;
            if (genre == 'M')
                this.rdMale.Checked = true;
            else
                this.rdFemale.Checked = true;

            this.btnInsert.Enabled = false;
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = true;
            frs.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want clear the form?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.option_clear = 0;
                this.Clear();
            }
        }



        private void txtName_Enter(object sender, EventArgs e)
        {
            this.txtName.BackColor = Color.Yellow;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            this.txtName.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            this.txtEmail.BackColor = Color.Yellow;
        }

        private void txtSalary_Enter(object sender, EventArgs e)
        {
            this.txtSalary.BackColor = Color.Yellow;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            this.txtEmail.BackColor = Color.White;
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            this.txtSalary.BackColor = Color.White;
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (this.txtEmail.Text != String.Empty)
            {
                if (this.ValidateEmail(this.txtEmail.Text))
                {
                    if (!Crud.CheckEmailPerson(this.txtEmail.Text))
                    {
                        MessageBox.Show("This email already registered.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtEmail.Clear();
                        this.txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtEmail.Clear();
                    this.txtEmail.Focus();
                }
            }
            else
            {
                MessageBox.Show("E-mail is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtEmail.Clear();
                this.txtEmail.Focus();
            }
        }

        private bool? CheckPersonEmail(string email)
        {
            return Crud.CheckEmailPerson(email);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch(this);
            frm.ShowDialog(this);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (InsertData() == 1)
            {
                MessageBox.Show("Person successfully registered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.option_clear = 0;
                this.Clear();
            }
        }

        private int InsertData()
        {
            if (this.txtName.Text == String.Empty)
            {
                MessageBox.Show("Name is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (this.txtEmail.Text == String.Empty)
            {
                MessageBox.Show("Email is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (this.txtSalary.Text == String.Empty)
            {
                MessageBox.Show("Salary is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            String gender;
            if (rdMale.Checked)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            int return_op = Crud.Insert_Person(this.txtName.Text.Trim(), this.txtEmail.Text.Trim(), Decimal.Parse(this.txtSalary.Text), this.dtBirthday.Value, gender);
            if (return_op == 1)
            {
                return return_op;
            }
            else
            {
                MessageBox.Show("Error registering Person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return return_op;
            }
        }


        private int EditData()
        {
            if (this.txtName.Text == String.Empty)
            {
                MessageBox.Show("Name is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (this.txtEmail.Text == String.Empty)
            {
                MessageBox.Show("Email is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (this.txtSalary.Text == String.Empty)
            {
                MessageBox.Show("Salary is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            String gender;
            if (rdMale.Checked)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            int return_op = Crud.Edit_Person(this.id, this.txtName.Text.Trim(), this.txtEmail.Text.Trim(), Decimal.Parse(this.txtSalary.Text), this.dtBirthday.Value, gender);
            if (return_op == 1)
            {
                return return_op;
            }
            else
            {
                MessageBox.Show("Error editing Person record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return return_op;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditData() == 1)
            {
                MessageBox.Show("Person successfully edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this record of Person?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (Crud.Delete_Person(this.id) == 1)
                {
                    MessageBox.Show("Person successfully deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.option_clear = 0;
                    this.Clear();
                }
                else
                {
                    MessageBox.Show("Error deleting Person record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void dtBirthday_Validated(object sender, EventArgs e)
        {
            if (this.dtBirthday.Value > DateTime.Now.AddYears(-18))
            {
                MessageBox.Show("Invalid birthday.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtBirthday.Value = DateTime.Now.AddYears(-18);
                this.dtBirthday.Focus();
            }
        }

        private void dtBirthday_Enter(object sender, EventArgs e)
        {
            this.dtBirthday.BackColor = Color.Yellow;
        }

        private void dtBirthday_Leave(object sender, EventArgs e)
        {
            this.dtBirthday.BackColor = Color.White;
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                this.txtSalary.Clear();
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (this.txtName.Text == String.Empty)
            {
                MessageBox.Show("Name is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtName.Focus();
            }
        }

        private void txtSalary_Validated(object sender, EventArgs e)
        {
            if (this.txtSalary.Text != String.Empty)
            {
                if (Decimal.Parse(this.txtSalary.Text) < 0)
                {
                    MessageBox.Show("Invalid salary.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtSalary.Clear();
                    this.txtSalary.Focus();
                }
            }
            else
            {
                MessageBox.Show("Salary is empty.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSalary.Focus();
            }
        }
    }
}
