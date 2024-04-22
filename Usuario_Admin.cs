using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Usuario_Admin : Form
    {
        public Usuario_Admin()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Login objLogin = new Login();
            objLogin.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Login objLogin1 = new Login();
            objLogin1.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            LoginRegistro objLogin2 = new LoginRegistro();
            objLogin2.Show();
            this.Hide();
        }

        private void Usuario_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseas cerrar la aplicación", "Mensaje de la aplicación",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
