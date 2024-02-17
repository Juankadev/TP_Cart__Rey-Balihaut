using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp1
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListForm form = new ListForm();
            form.FormClosed += ListForm_FormClosed;
            form.ShowDialog();
        }

        private void ListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
