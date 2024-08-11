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
    public partial class frmComprascs : Form
    {
        public frmComprascs()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(CDatos.conect);
        DataTable dt = new DataTable();

        private void Borrar()
        {
            txtNombre.Text = string.Empty;
            txtMontoTotal.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void SumarSubTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCompras.Rows)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtMontoTotal.Text))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCompras);
                row.Cells[0].Value = txtNombre.Text;
                row.Cells[1].Value = txtDescripcion.Text;
                row.Cells[2].Value = double.Parse(txtMontoTotal.Text).ToString();
                row.Cells[3].Value = dtpCompras.Value;
                dgvCompras.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SumarSubTotal();
            Borrar();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();
            Mainfrm mainfrm = new Mainfrm(usuario);
            mainfrm.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count > 0)
            {
                // Verificar que la fila actual no sea nula y que la celda tenga un valor
                if (dgvCompras.CurrentRow != null && dgvCompras.CurrentRow.Cells["SubTotal"].Value != null)
                {
                    double sub;
                    // Intentar convertir el valor de la celda a un double
                    if (double.TryParse(dgvCompras.CurrentRow.Cells["SubTotal"].Value.ToString(), out sub))
                    {
                        // Limpiar el valor del Label eliminando cualquier símbolo de moneda
                        string totalText = lblTotal.Text.Replace("$", "").Replace("€", "").Replace("£", "").Trim();
                        double total;
                        // Intentar convertir el valor del Label a un double
                        if (double.TryParse(totalText, out total))
                        {
                            // Remover la fila seleccionada
                            dgvCompras.Rows.RemoveAt(dgvCompras.SelectedRows[0].Index);

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
                        MessageBox.Show($"Error al convertir el SubTotal a un número. Valor de la celda: '{dgvCompras.CurrentRow.Cells["SubTotal"].Value}'");
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


        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMontoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' ||
                (e.KeyChar == '.' && txtMontoTotal.Text.Contains('.')))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtMontoTotal.Text))
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCompras);
                    row.Cells[0].Value = txtNombre.Text;
                    row.Cells[1].Value = txtDescripcion.Text;
                    row.Cells[2].Value = double.Parse(txtMontoTotal.Text).ToString();
                    dgvCompras.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("Hay campos vacios!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SumarSubTotal();
                Borrar();
                txtNombre.Focus();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count > 0)
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvCompras.Rows)
                        {
                            // Verificar que la fila no esté vacía
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                            {
                                string producto = row.Cells[0].Value.ToString();
                                string descripcion = row.Cells[1].Value.ToString();
                                DateTime fecha = Convert.ToDateTime(row.Cells[3].Value);
                                double preciocompra;

                                if (double.TryParse(row.Cells[2].Value.ToString(), out preciocompra))
                                {
                                    string query = "insert into Compras(Producto,Descripcion,PrecioCompra,FechaRegistro) values(@Producto,@Descripcion,@PrecioCompra,@FechaRegistro)";
                                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@Producto", producto);
                                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                                        cmd.Parameters.AddWithValue("@PrecioCompra", preciocompra);
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
                        MessageBox.Show("Compras registradas exitosamente!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        dgvCompras.Rows.Clear();
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para registrar!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmComprascs_Load(object sender, EventArgs e)
        {

        }
    }
}
