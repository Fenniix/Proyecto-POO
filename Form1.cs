using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Usuario_Admin objRegresa = new Usuario_Admin();
            objRegresa.Show();
            this.Hide();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Cadena de conexión
            string connectionString = "Data Source=127.0.0.1:3308;Initial Catalog=pasteleria_2_amigos;User ID=Juan;Password=password1;";

            // Consulta SQL para verificar las credenciales
            string query = "SELECT COUNT(*) FROM Usuario WHERE usuario = @usuario AND contraseña = @contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Agregar parámetros para el usuario y la contraseña
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@uontraseña", contraseña);

                try
                {
                    // Abrir conexión
                    connection.Open();

                    // Ejecutar consulta
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Credenciales válidas, permitir el acceso al siguiente formulario
                        Inicio formularioSiguiente = new Inicio();
                        formularioSiguiente.Show();
                        this.Hide(); // O puedes cerrar el formulario actual (this.Close())
                    }
                    else
                    {
                        // Credenciales inválidas, mostrar un mensaje de error
                        MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones
                    MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
