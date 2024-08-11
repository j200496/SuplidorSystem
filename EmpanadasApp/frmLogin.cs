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
using EmpanadasApp.Modelos;
using EmpanadasApp.Logica;

namespace EmpanadasApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(CDatos.conect);
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text))
            {
                if (txtUsuario.Text == usuario.Usuario && txtClave.Text == usuario.Clave)
                {
                    Mainfrm mainfrm = new Mainfrm(usuario);
                    mainfrm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = "";
                    txtClave.Text = "";
                    txtUsuario.Focus();
                }

            }
            else
            {
                MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seguro deseas salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void linkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DialogResult dr = MessageBox.Show("Seguro deseas resetear tus credenciales","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                string query = "update Usuarios set Usuario = 'admin',Clave = 'admin' where IdUsuario = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                            int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Datos reseteados exitosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            con.Close();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                CUsuario usuario = new CDUsuario().Leer();

                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text))
                {
                    if (txtUsuario.Text == usuario.Usuario && txtClave.Text == usuario.Clave)
                    {
                        Mainfrm mainfrm = new Mainfrm(usuario);
                        mainfrm.Show(); 
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Text = "";
                        txtClave.Text = "";
                        txtUsuario.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
