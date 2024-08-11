using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpanadasApp.Logica;
using EmpanadasApp.Modelos;
using System.Data.SqlClient;

namespace EmpanadasApp
{
    public partial class frmhistorial : Form
    {
        public frmhistorial()
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
        private void FiltrarCompras(DateTime fechainicioc, DateTime fechafinc)
        {
            DataTable dt1 = new DataTable();
            dt1.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            using (SqlCommand cmd = new SqlCommand("HistCompras", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechainicioc", fechainicioc);
                cmd.Parameters.AddWithValue("@fechafinc", fechafinc);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
            }
            dgvCompras.DataSource = dt1;
            con.Close();
        }
        private void FiltrarVentas(DateTime fechainicio, DateTime fechafin)
        {
            dt.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            using (SqlCommand cmd = new SqlCommand("HistVenta", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                cmd.Parameters.AddWithValue("@fechafin", fechafin);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            dgvVentas.DataSource = dt;
            con.Close();
        }
        private void SumarSubTotal()
        {

            decimal total = 0;

            foreach (DataGridViewRow row in dgvCompras.Rows)
            {
                if (row.Cells["PrecioCompra"].Value != null) // Asegurarse de que la celda no sea nula
                {
                    decimal subTotal;
                    if (decimal.TryParse(row.Cells["PrecioCompra"].Value.ToString(), out subTotal))
                    {
                        total += subTotal;
                    }
                }
            }

            lblTotal.Text = total.ToString("C"); // Formatear como moneda, puedes ajustar el formato según tus necesidades
        }
        private void frmhistorial_Load(object sender, EventArgs e)
        {

        }

        private void dtpinicioV_ValueChanged(object sender, EventArgs e)
        {
            FiltrarVentas(dtpinicioV.Value.Date, dtpfinV.Value.Date);
        }

        private void dtpfinV_ValueChanged(object sender, EventArgs e)
        {
            FiltrarVentas(dtpinicioV.Value.Date, dtpfinV.Value.Date);
        }

        private void dtpinicioC_ValueChanged(object sender, EventArgs e)
        {
            FiltrarCompras(dtpinicioC.Value.Date, dtpfinC.Value.Date);
            SumarSubTotal();
        }

        private void dtpfinC_ValueChanged(object sender, EventArgs e)
        {
            FiltrarCompras(dtpinicioC.Value.Date, dtpfinC.Value.Date);
            SumarSubTotal();
        }

        public void exportaraexcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {

                IndeceFila++;

                IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {

                    IndiceColumna++;

                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;


        }
        private void btndownload_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seguro deseas descargar las compras?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                exportaraexcel(dgvCompras);

            }
        }

        private void btnCancelarV_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (dgvVentas.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Seguro deseas cancelar la venta?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string IdVenta = dgvVentas.CurrentRow.Cells["Id"].Value.ToString();
                    string delete = "delete from Ventas where IdVenta = @IdVenta";
                    using (SqlCommand cmd = new SqlCommand(delete, con))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", IdVenta);

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Venta cancelada!");

                        }
                    }

                }
              
               
            }
            else
            {
                MessageBox.Show("No hay venta seleccionada para borrar!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FiltrarVentas(dtpinicioV.Value.Date, dtpfinV.Value.Date);
            con.Close();
        }

        private void btncancelarC_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (dgvCompras.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Seguro deseas cancelar la compra?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string IdCompra = dgvCompras.CurrentRow.Cells["Id"].Value.ToString();
                    string delete = "delete from Compras where IdCompra = @IdCompra";
                    using (SqlCommand cmd = new SqlCommand(delete, con))
                    {
                        cmd.Parameters.AddWithValue("@IdCompra", IdCompra);

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Compra cancelada!");

                        }
                    }

                }


            }
            else
            {
                MessageBox.Show("No hay compra seleccionada para borrar!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FiltrarCompras(dtpinicioC.Value.Date, dtpfinC.Value.Date);
            SumarSubTotal();          
            con.Close();
        }

        private void btndownload_MouseHover(object sender, EventArgs e)
        {
           
                btndownload.IconColor = Color.LightGreen;
            
            
        }

        private void btndownload_MouseLeave(object sender, EventArgs e)
        {
            btndownload.IconColor = Color.Green;
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
    }

