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
using System.Data.Entity.Infrastructure;


namespace EmpanadasApp
{
    public partial class TipoE : Form
    {
        public TipoE()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(CDatos.conect);
        CTipoE cte = new CDTipoE().Leer();
        DataTable dt = new DataTable();
      
        private void TipoE_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            using (SqlCommand cmd = new SqlCommand("selectEsta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            dgvEst.DataSource = dt;

            List<CTipoE> list = new CNTipoE().Listar();

            foreach (CTipoE item in list)
            {
                cmbTipoE.Items.Add(new OpcionCombo() { Valor = item.IdTipo, Texto = item.TipoE });
                cmbTipoE.DisplayMember = "Texto";
                cmbTipoE.ValueMember = "Valor";
                cmbTipoE.SelectedIndex = 0;
            }
            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();
            Mainfrm mainfrm = new Mainfrm(usuario);
            mainfrm.Show();
            this.Hide();
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
                using (SqlCommand cmd = new SqlCommand("selectEsta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
                dgvEst.DataSource = dt;
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error al refrescar los datos: " + ex.Message);
            }
        }
        private void LimpiarC()
        {
            txtNombre.Text = "";
            txtNombreRe.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text)
                && !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtNombreRe.Text))
            {
                OpcionCombo selectedTipoE = (OpcionCombo)cmbTipoE.SelectedItem;
                using (SqlCommand cmd = new SqlCommand("insertIE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipo", selectedTipoE.Valor);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Responsable", txtNombreRe.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Datos ingresados exisosamente!");
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

        private void dgvEst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string nombre = dgvEst.CurrentRow.Cells["Nombre"].Value.ToString();
            string query = "SELECT IdEst FROM Establecimientos WHERE Nombre = @Nombre";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = Convert.ToInt32(reader["IdEst"]).ToString();
             
                }

            }
            con.Close();
        }

        private void dgvEst_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string nombre = dgvEst.CurrentRow.Cells["Nombre"].Value.ToString();
            string query = "SELECT IdESt, Nombre,Responsable,Telefono,Direccion FROM Establecimientos WHERE Nombre = @Nombre";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = Convert.ToInt32(reader["IdESt"]).ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtNombreRe.Text = reader["Responsable"].ToString();
                    txtDireccion.Text = reader["Direccion"].ToString();
                }

            }
            con.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text)
                && !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtNombreRe.Text))
            {
                OpcionCombo selectedTipoE = (OpcionCombo)cmbTipoE.SelectedItem;
                using (SqlCommand cmd = new SqlCommand("updateest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipo", selectedTipoE.Valor);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@Responsable", txtNombreRe.Text);
                    cmd.Parameters.AddWithValue("@IdEst", txtId.Text);


                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Datos actualizados exisosamente!");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtId.Text) && dgvEst.Rows.Count > 0)
            {
                DialogResult dr = System.Windows.Forms.MessageBox.Show("Seguro desea eliminar el establecimiento", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string id = txtId.Text ?? "";
                    string query = "delete from Establecimientos where IdEst = @IdEst ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IdEst", id);
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
                System.Windows.Forms.MessageBox.Show("No hay datos seleccionados!","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Ref();
            con.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string query = "select TipoE.Tipo_Establecimiento, Establecimientos.Nombre, Establecimientos.Responsable, Establecimientos.Telefono,Establecimientos.Direccion \r\nfrom Establecimientos inner join TipoE on TipoE.IdTipo = Establecimientos.IdTipo \r\nWHERE Establecimientos.Nombre LIKE @searchTerm OR TipoE.Tipo_Establecimiento LIKE @searchTerm OR Establecimientos.Direccion  LIKE @searchTerm";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEst.DataSource = dt;
            }

            con.Close();
        }
    }
    }

