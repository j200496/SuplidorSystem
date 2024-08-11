using FontAwesome.Sharp;
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
using EmpanadasApp.Logica;
using EmpanadasApp.Modelos;

namespace EmpanadasApp
{
    public partial class FrmVenta : Form
    {
        public FrmVenta()
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

        private void ComboTipoE()
        {
            DataTable dt = new DataTable(); // Asegúrate de inicializar el DataTable

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                string query = "SELECT IdTipo, Tipo_Establecimiento FROM TipoE;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {                 
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);


                        cmbTipoE.ValueMember = "IdTipo";
                        cmbTipoE.DisplayMember = "Tipo_Establecimiento";
                        cmbTipoE.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            /*
                         if (con.State != ConnectionState.Open)
                         {
                             con.Open();
                         }

                         List<CTipoE> list = new CNTipoE().Listar();

                         foreach (CTipoE item in list)
                         {
                             cmbTipoE.Items.Add(new OpcionCombo() { Valor = item.IdTipo, Texto = item.TipoE });
                             cmbTipoE.DisplayMember = "Texto";
                             cmbTipoE.ValueMember = "Valor";

                         }

                         con.Close();
                        */
        }
        private void ComboNE(string IdTipo)
        {
            DataTable dt = new DataTable(); // Asegúrate de inicializar el DataTable

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                string query = "SELECT IdEst, Nombre FROM Establecimientos where IdTipo = @IdTipo;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdTipo", SqlDbType.VarChar) { Value = IdTipo });
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        
                        cmbE.ValueMember = "IdEst";
                        cmbE.DisplayMember = "Nombre";
                        cmbE.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
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
            ComboTipoE();
          
            con.Close();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                Productos pr = new CDProductos().Listar().Where(p => p.Codigo == txtCodigo.Text).FirstOrDefault();
                if (pr != null)
                {

                    string Codigo = txtCodigo.Text;
                    string query = "select IdProducto,Codigo,Nombre,Descripcion,PrecioVenta from Productos WHERE Codigo = @Codigo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", Codigo);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtIdPro.Text = reader["IdProducto"].ToString();
                            txtProducto.Text = reader["Nombre"].ToString();
                            txtDesc.Text = reader["Descripcion"].ToString();
                            txtPrecioV.Text = reader["PrecioVenta"].ToString();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("El codigo no existe!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
          
                     
            else
            {
                MessageBox.Show("Introduzca el codigo!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();
        }

        private void txtPrecioV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' ||
                (e.KeyChar == '.' && txtPrecioV.Text.Contains('.')))
            {
                e.Handled = true;
            }
        }

        private void cmbE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void SumarSubTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Cells["SubTotal"].Value != null) // Asegurarse de que la celda no sea nula
                {
                    decimal subTotal;
                    if (decimal.TryParse(row.Cells["SubTotal"].Value.ToString(), out subTotal))
                    {
                        total += subTotal;
                    }
                }
            }

            lblTotal.Text = total.ToString("C"); // Formatear como moneda, puedes ajustar el formato según tus necesidades
        }
        private void cmbTipoE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoE.SelectedValue.ToString() != null)
            {
                string IdTipo = cmbTipoE.SelectedValue.ToString();
                ComboNE(IdTipo);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtPrecioV.Text))
            {
                if (numericV.Value >0 && cmbE.SelectedValue != null)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvVentas);
                    row.Cells[0].Value = txtProducto.Text;
                    row.Cells[1].Value = txtIdPro.Text;
                    row.Cells[2].Value = cmbTipoE.SelectedValue.ToString();
                    row.Cells[3].Value = cmbE.SelectedValue.ToString();
                    row.Cells[4].Value = txtDesc.Text;
                    row.Cells[5].Value = double.Parse(txtPrecioV.Text).ToString("F2");
                    row.Cells[6].Value = numericV.Value.ToString();
                    row.Cells[7].Value = numericD.Value.ToString();
                    double total = double.Parse(txtPrecioV.Text) * int.Parse(numericV.Value.ToString());
                    row.Cells[8].Value = cmbTipoE.Text;
                    row.Cells[9].Value = cmbE.Text;
                    row.Cells[10].Value = total.ToString("F2");
                    row.Cells[11].Value = dtpVentas.Value;
                    dgvVentas.Rows.Add(row);

                }
                else
                {
                    MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SumarSubTotal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvVentas.SelectedRows.Count > 0)
            {
                // Verificar que la fila actual no sea nula y que la celda tenga un valor
                if (dgvVentas.CurrentRow != null && dgvVentas.CurrentRow.Cells["SubTotal"].Value != null)
                {
                    double sub;
                    // Intentar convertir el valor de la celda a un double
                    if (double.TryParse(dgvVentas.CurrentRow.Cells["SubTotal"].Value.ToString(), out sub))
                    {
                        // Limpiar el valor del Label eliminando cualquier símbolo de moneda
                        string totalText = lblTotal.Text.Replace("$", "").Replace("€", "").Replace("£", "").Trim();
                        double total;
                        // Intentar convertir el valor del Label a un double
                        if (double.TryParse(totalText, out total))
                        {
                            // Remover la fila seleccionada
                            dgvVentas.Rows.RemoveAt(dgvVentas.SelectedRows[0].Index);

                            // Calcular el nuevo total y actualizar el Label
                            double restar = total - sub;
                            lblTotal.Text = restar.ToString("C"); // Formatear como moneda
                        }
                        else
                        {
                            MessageBox.Show($"Error al convertir el total en el Label a un número. Valor actual: '{lblTotal.Text}'");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error al convertir el SubTotal a un número. Valor de la celda: '{dgvVentas.CurrentRow.Cells["SubTotal"].Value}'");
                    }
                }
                else
                {
                    MessageBox.Show("La fila actual o la celda está vacía.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (dgvVentas.Rows.Count > 0)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvVentas.Rows)
                        {
                            // Verificar que la fila no esté vacía
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                            {
                                int idproducto = Convert.ToInt32(row.Cells[1].Value.ToString());
                                string descripcion = row.Cells[4].Value.ToString();
                                decimal precioventa;
                                int cantidadv = Convert.ToInt32(row.Cells[6].Value.ToString());
                                int cantidadD = Convert.ToInt32(row.Cells[7].Value.ToString());
                                int idTipo = Convert.ToInt32(row.Cells[2].Value.ToString());
                                int Tipoe = Convert.ToInt32(row.Cells[3].Value.ToString());
                                DateTime fecha = Convert.ToDateTime(row.Cells[11].Value);
                                decimal total; ;
                                if (decimal.TryParse(row.Cells[5].Value.ToString(), out precioventa) && decimal.TryParse(row.Cells[10].Value.ToString(), out total))
                                {
                                    
                                    using (SqlCommand cmd = new SqlCommand("insertV", con, transaction))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@IdProducto", idproducto);
                                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                                        cmd.Parameters.AddWithValue("@PrecioVenta", precioventa);
                                        cmd.Parameters.AddWithValue("@Cantidad_Vendida", cantidadv);
                                        cmd.Parameters.AddWithValue("@Cantidad_Devuelta", cantidadD);
                                        cmd.Parameters.AddWithValue("@IdTipo", idTipo);
                                        cmd.Parameters.AddWithValue("@IdEst", Tipoe);
                                        cmd.Parameters.AddWithValue("@MontoTotal", total);
                                        cmd.Parameters.AddWithValue("@FechaRegistro", fecha);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Error al convertir el precio de compra en la fila {row.Index + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaction.Rollback();
                                    return;
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Venta registrada exitosamente!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dgvVentas.Rows.Clear();
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para registrar!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string query = "select Codigo,Nombre as Producto,Descripcion,PrecioVenta from Productos  WHERE Nombre LIKE @searchTerm OR Descripcion LIKE @searchTerm OR Codigo LIKE @searchTerm";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProd.DataSource = dt;
            }

            con.Close();
        }

        private void btnBuscarCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    Productos pr = new CDProductos().Listar().Where(p => p.Codigo == txtCodigo.Text).FirstOrDefault();
                    if (pr != null)
                    {

                        string Codigo = txtCodigo.Text;
                        string query = "select IdProducto,Codigo,Nombre,Descripcion,PrecioVenta from Productos WHERE Codigo = @Codigo";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Codigo", Codigo);
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                txtIdPro.Text = reader["IdProducto"].ToString();
                                txtProducto.Text = reader["Nombre"].ToString();
                                txtDesc.Text = reader["Descripcion"].ToString();
                                txtPrecioV.Text = reader["PrecioVenta"].ToString();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El codigo no existe!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


                else
                {
                    MessageBox.Show("Introduzca el codigo!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
        }
    }
    }



