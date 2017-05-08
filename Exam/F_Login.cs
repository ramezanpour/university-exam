using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        private void B_Login_Click(object sender, EventArgs e)
        {
            if (TB_Password.Text == "123qwe!@#QWE")
            {
                F_Questions questionsManager = new F_Questions();
                questionsManager.ShowDialog();
                Hide();
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
            }
        }
    }
}
