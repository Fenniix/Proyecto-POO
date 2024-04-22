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
    public partial class LoginRegistro : Form
    {
        public LoginRegistro()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Usuario_Admin objRegresa = new Usuario_Admin();
            objRegresa.Show();
            this.Hide();
        }
    }
}
