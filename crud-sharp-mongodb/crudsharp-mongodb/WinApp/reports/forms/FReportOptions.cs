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
    public partial class FrmReportOptions : Form
    {
        public FrmReportOptions()
        {
            InitializeComponent();
        }

        private void FrmReportOptions_Load(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = true;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void txtInitialSal_TextChanged(object sender, EventArgs e)
        {
            if(this.txtInitialSal.Text != String.Empty)
            {
                try
                {
                    Decimal.Parse(this.txtInitialSal.Text);
                }
                catch (Exception)
                {
                    this.txtInitialSal.Clear();
                }
            }
        }

        private void rdSalaryRange_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = true;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdAverageWage_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = true;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdBySalary_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = true;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdBornMonth_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = true;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void rdfinancialGeneral_CheckedChanged(object sender, EventArgs e)
        {
            this.gpBornMonth.Visible = false;
            this.gpBySalary.Visible = false;
            this.gpSalaryRange.Visible = false;
            this.gpAVGSal.Visible = false;
            this.cmbAVG.SelectedIndex = 0;
            this.cmbMonth.SelectedIndex = 0;
            this.cmbSal.SelectedIndex = 0;
        }

        private void txtInitialSal_Enter(object sender, EventArgs e)
        {
            this.txtInitialSal.BackColor = Color.Yellow;
        }

        private void txtInitialSal_Leave(object sender, EventArgs e)
        {
            this.txtInitialSal.BackColor = Color.White;
        }

        private void txtFinalInitial_Enter(object sender, EventArgs e)
        {
            this.txtFinalSal.BackColor = Color.Yellow;
        }

        private void txtFinalInitial_Leave(object sender, EventArgs e)
        {
            this.txtFinalSal.BackColor = Color.White;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(rdSalaryRange.Checked)
            {
                if (this.txtInitialSal.Text != String.Empty)
                {
                    if (this.txtFinalSal.Text != String.Empty)
                    {
                        GenerateSalaryRangeReport();
                    }
                    else
                    {
                        MessageBox.Show("Final salary was not informed.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Initial salary was not informed.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (rdBySalary.Checked)
            {
                GeneraterSalaryReport();
            }

            if(rdAverageWage.Checked)
            {
                GeneraterAverageSalaryReport();
            }

            if(rdAll.Checked)
            {
                GeneraterPersonReport();
            }

            if(rdBornMonth.Checked)
            {
                GeneraterBornMonth();
            }
        }

        private void GenerateSalaryRangeReport()
        {
            List<Person> list = Crud.Get_Persons_By_Salary_Range(Decimal.Parse((this.txtInitialSal.Text).Trim()), Decimal.Parse((this.txtFinalSal.Text).Trim()));
            if (list.Count > 0)
            {
                FrmSalaryRange fsr = new FrmSalaryRange(list);
                fsr.Show();
            }
            else
            {
                MessageBox.Show("No record with this criterion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GeneraterSalaryReport()
        {
            List<Person> list = new List<Person>();

            if (this.cmbSal.SelectedIndex == 0)
            {
                list.Add(Crud.Get_Person_Higher_Salary());
            }

            if (this.cmbSal.SelectedIndex == 1)
            {
                list.Add(Crud.Get_Person_Lower_Salary());
            }

            if (list.Count() > 0)
            {
                FrmBySalary fsr = new FrmBySalary(list);
                fsr.Show();
            }
            else
            {
                MessageBox.Show("No record with this criterion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GeneraterAverageSalaryReport()
        {
            List<Person> list = null;

            if (this.cmbAVG.SelectedIndex == 0)
            {
                list = Crud.Get_Persons_Salary_Above_AVG();
            }

            if (this.cmbAVG.SelectedIndex == 1)
            {
                list = Crud.Get_Persons_Salary_Equal_AVG();
            }

            if (this.cmbAVG.SelectedIndex == 2)
            {
                list = Crud.Get_Persons_Salary_Under_AVG();
            }


            if (list.Count() > 0)
            {
                FrmAVGSalary favg = new FrmAVGSalary(list);
                favg.Show();
            }
            else
            {
                MessageBox.Show("No record with this criterion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GeneraterPersonReport()
        {
            List<Person> list = Crud.Get_Persons_By_Name("");

            if (list.Count() > 0)
            {
                FrmPerson fsr = new FrmPerson(list);
                fsr.Show();
            }
            else
            {
                MessageBox.Show("No record with this criterion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GeneraterBornMonth()
        {
            List<Person> list = Crud.Get_Persons_By_Month_Birthday(this.cmbMonth.SelectedIndex + 1);
            
            if (list.Count() > 0)
            {
                FrmBornMonth fbm = new FrmBornMonth(list);
                fbm.Show();
            }
            else
            {
                MessageBox.Show("No record with this criterion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFinalInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                this.txtFinalSal.Clear();
            }
        }

        private void txtInitialSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                this.txtInitialSal.Clear();
            }
        }

        private void txtFinalSal_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFinalSal.Text != String.Empty)
            {
                try
                {
                    Decimal.Parse(this.txtFinalSal.Text);
                }
                catch (Exception)
                {
                    this.txtFinalSal.Clear();
                }
            }
        }
    }
}
