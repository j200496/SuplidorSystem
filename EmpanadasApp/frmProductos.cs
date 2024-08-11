using EmpanadasApp.Logica;
using EmpanadasApp.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpanadasApp
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(CDatos.conect);
        DataTable dt = new DataTable();
        private void btnExit_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();
            Mainfrm mainfrm = new Mainfrm(usuario);
            mainfrm.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {
                Productos pr = new CDProductos().Listar().Where(p => p.Codigo == txtCodigo.Text).FirstOrDefault();
                if (pr == null)
                {

                    using (SqlCommand cmd = new SqlCommand("insertPro", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@PrecioVenta", txtPrecio.Text);


                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Datos ingresados exisosamente!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El codigo ya existe!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Ref();
            LimpiarC();
            con.Close();
        }

        private void Ref()
        {
            try
            {
                dt.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("selectPro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
                dgvProd.DataSource = dt;
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error al refrescar los datos: " + ex.Message);
            }
        }
        private void LimpiarC()
        {
            txtPrecio.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            using (SqlCommand cmd = new SqlCommand("selectPro", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            dgvProd.DataSource = dt;
            con.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {

                using (SqlCommand cmd = new SqlCommand("updatepro", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", txtId.Text);
                    cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@PrecioVenta", txtPrecio.Text);


                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Datos editados exisosamente!");
                    }
                }
            
            }
            else
            {
                MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Ref();
            LimpiarC();
            con.Close();
        }

        private void dgvProd_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string Codigo = dgvProd.CurrentRow.Cells["Codigo"].Value.ToString();
            string query = "select Codigo,Nombre,Descripcion,PrecioVenta from Productos WHERE Codigo = @Codigo";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCodigo.Text = reader["Codigo"].ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtDescripcion.Text = reader["Descripcion"].ToString();
                    txtPrecio.Text = reader["PrecioVenta"].ToString();

                }

            }
            con.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' ||
                (e.KeyChar == '.' && txtPrecio.Text.Contains('.')))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                DialogResult dr = System.Windows.Forms.MessageBox.Show("Seguro desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string codigo = dgvProd.CurrentRow.Cells["Codigo"].Value.ToString();
                    string query = "delete from Productos where Codigo = @Codigo ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
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
                System.Windows.Forms.MessageBox.Show("No hay datos seleccionados!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Ref();
            con.Close();
        }
    


        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string Codigo = dgvProd.CurrentRow.Cells["Codigo"].Value.ToString();
            string query = "SELECT IdProducto FROM Productos WHERE Codigo = @Codigo";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = Convert.ToInt32(reader["IdProducto"]).ToString();

                }

            }
            con.Close();
        }
    }
    }
    

