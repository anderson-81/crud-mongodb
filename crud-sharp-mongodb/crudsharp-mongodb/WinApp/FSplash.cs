using libCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinApp.login;

namespace WinApp
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            FrmLogin fl = new FrmLogin();
            this.Visible = false;
            //Create user if it does not exist.
            if (Crud.Login("Admin", "121181") == 0)
            {
                if (Crud.Insert_UserSys("Admin", "121181") != 1)
                {
                    MessageBox.Show("Error creating user for system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            fl.ShowDialog(this);
        }
    }
}
