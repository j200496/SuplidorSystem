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
    public partial class Usuariofrm : Form
    {
        public Usuariofrm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(CDatos.conect);
        DataTable dt = new DataTable();
        private void btnVentas_Click(object sender, EventArgs e)
        {
            
            
        }
        private void AsignarValores()
        {
            CUsuario cUsuario = new CDUsuario().Leer();

            txtId.Text = cUsuario.IdUsuario.ToString();
            txtNombre.Text = cUsuario.Nombre.ToString();
            txtUsuario.Text = cUsuario.Usuario.ToString();
            txtClave.Text = cUsuario.Clave.ToString();

        }
        private void Refres()
        {
            try
            {
                dt.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string query = "SELECT Nombre, Usuario, Clave FROM Usuarios";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                dgvUsuarios.DataSource = dt;
                con.Close();
            }
           
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                MessageBox.Show("Error al refrescar los datos: " + ex.Message);
            }
        }


        private void Usuariofrm_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string query = "select Nombre,Usuario,Clave from Usuarios";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            dgvUsuarios.DataSource = dt;
            AsignarValores();

            DataTable dt1 = new DataTable();
            string query1 = "Select IdTipo,Tipo_Establecimiento as Establecimiento from TipoE";
            using(SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt1);
            }
            dgvTipoE.DataSource = dt1;
            con.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open) { 
            con.Open();
            }
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtClave.Text)
                && !string.IsNullOrEmpty(txtNombre.Text))
            {
                string query = "update Usuarios set Nombre = @Nombre, Usuario = @Usuario,Clave =@Clave where IdUsuario = @IdUsuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", txtId.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@Clave", txtClave.Text);

                    int i = cmd.ExecuteNonQuery();
                    if(i> 0)
                    {
                        MessageBox.Show("Datos editados exitosamente!","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            Refres();
            con.Close();
        }
        private void Refres1()
        {
            DataTable dt1 = new DataTable();
            try
            {
               
                dt1.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
              
                string query1 = "Select IdTipo,Tipo_Establecimiento as Establecimiento from TipoE";
                using (SqlCommand cmd1 = new SqlCommand(query1, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(dt1);
                }
                dgvTipoE.DataSource = dt1;
                con.Close();
            }

            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                MessageBox.Show("Error al refrescar los datos: " + ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();
            Mainfrm mainfrm = new Mainfrm(usuario);
            mainfrm.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvTipoE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void btnAddTipo_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtTipo.Text))
            {
                string query = "insert into TipoE(Tipo_Establecimiento)values(@Tipo)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) {
                        System.Windows.Forms.MessageBox.Show("Datos insertados exitosamente");
                    }
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("El campo esta vacio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTipo.Text = "";
            Refres1();
            con.Close();
        }

        private void btnDeleteTipo_Click(object sender, EventArgs e)
        {
            
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (dgvTipoE.Rows.Count > 0)
            {
                DialogResult dr = System.Windows.Forms.MessageBox.Show("Seguro desea eliminar el tipo de establecimiento", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    string id = dgvTipoE.CurrentRow.Cells["IdTipo"].Value.ToString() ?? "";
                    string query1 = "delete from Establecimientos where IdTipo = @IdTipo";
                    string query = "delete from TipoE where IdTipo = @IdTipo ";
                    string query2 = "delete from Ventas where IdTipo = @IdTipo ";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@IdTipo", id);
                        cmd2.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {
                        cmd1.Parameters.AddWithValue("@IdTipo", id);
                        cmd1.ExecuteNonQuery();
                    }
                        using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdTipo", id);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Datos eliminados exitosamente");
                        }
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay datos para eliminar!");
            }
            txtTipo.Text = "";
            Refres1();
            con.Close();
        }
    }
}
