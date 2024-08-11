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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
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

        private void FechaRep(DateTime fechainicio, DateTime fechafin)
        {
            dt.Clear();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("RepVentas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@Fechafin", fechafin);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
                dgvRep.DataSource = dt;
            }
            catch (Exception ex) {

                MessageBox.Show("Error", ex.Message);
            }
            finally {
                con.Close();
            }
        }

        private void LoadComboBoxes()
        {
            using (SqlConnection con = new SqlConnection(CDatos.conect))
            {
                con.Open();

                // Cargar ComboBox1
            

                // Cargar ComboBox2
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT Nombre FROM Establecimientos", con))
                {
                    DataTable column2Table = new DataTable();
                    da.Fill(column2Table);

                    cmbE.DataSource = column2Table;
                    cmbE.DisplayMember = "Nombre";
                    cmbE.ValueMember = "Nombre";
                    cmbE.SelectedIndex = 0;
                }
            }

            
            cmbE.SelectedIndexChanged += new EventHandler(FilterData);
            SumarSubTotal();
           
        }

        private void FilterData(object sender, EventArgs e)
        {
           
           /* string filter1 = cmbTipoE.SelectedValue?.ToString();
            string filter2 = cmbE.SelectedValue?.ToString();
            string filter = "";

            if (dgvRep.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(filter1))
                {
                    filter += $"Tipo_Establecimiento = '{filter1}'";
                }

                if (!string.IsNullOrEmpty(filter2))
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filter += " AND ";
                    }
                    filter += $"Nombre = '{filter2}'";
                }

                DataView dv = dt.DefaultView;
                dv.RowFilter = filter;
                dgvRep.DataSource = dv;
                SumarSubTotal();

            }
           */
        }



        private void dtpinicio_ValueChanged(object sender, EventArgs e)
        {
            FechaRep(dtpinicio.Value.Date, dtpfin.Value.Date);
           


        }

        private void dtpfin_ValueChanged(object sender, EventArgs e)
        {
            
            FechaRep(dtpinicio.Value.Date, dtpfin.Value.Date);
            
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
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            ComboNE();
          

            //ComboCate();

            //LoadComboBoxes();
        }

        private void SumarSubTotal()
        {
            
            decimal total = 0;
            decimal tote = 0;
            decimal totd = 0;
            decimal totv = 0;

            foreach (DataGridViewRow row in dgvRep.Rows)
            {
                if (row.Cells["MontoTotal"].Value != null && row.Cells["Entregadas"].Value != null 
                    && row.Cells["Cantidad_Devuelta"].Value != null && row.Cells["Cantidad_Vendida"].Value != null) // Asegurarse de que la celda no sea nula
                {
                    decimal subTotal;
                    decimal totale;
                    decimal totald;
                    decimal totalv;
                    if (decimal.TryParse(row.Cells["MontoTotal"].Value.ToString(), 
                        out subTotal) && decimal.TryParse(row.Cells["Entregadas"].Value.ToString(), out totale)
                        && decimal.TryParse(row.Cells["Cantidad_Devuelta"].Value.ToString(), out totald) && decimal.TryParse(row.Cells["Cantidad_Vendida"].Value.ToString(), out totalv))
                    {
                      
                            total += subTotal;
                            tote += totale;
                            totd += totald;
                            totv += totalv;
                    }
                }
            }
       
            lblTotal.Text = total.ToString("C");
            lbltotale.Text = tote.ToString();
            lbltotald.Text = totd.ToString();
            lblv.Text = totv.ToString();    
           
            
                               // Formatear como moneda, puedes ajustar el formato según tus necesidades
        }
        private void btndownload_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seguro deseas descargar el reporte?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                exportaraexcel(dgvRep);

            }
        }
        private void ComboCate()
        {
           
        }
        private void ComboNE()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            string query = "select Nombre from Establecimientos";
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.Fill(dt);
            }
            con.Close();

            DataRow fila = dt.NewRow();
            fila["Nombre"] = "Buscar por nombre";
            dt.Rows.InsertAt(fila, 0);
            cmbE.ValueMember = "Nombre";
            cmbE.DisplayMember = "Nombre";
            cmbE.DataSource = dt;
          
        }
        private void cmbTipoE_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*(cmbTipoE.SelectedValue.ToString() != null)
            {
                string IdTipo = cmbTipoE.SelectedValue.ToString();
                ComboNE(IdTipo);
            }*/
            
        }

        private void cmbE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
             {
                 con.Open();
             }

             DataTable dt = new DataTable();
             string cmb = cmbE.SelectedValue.ToString();
             DateTime fechainicio = dtpinicio.Value.Date;
             DateTime fechafin = dtpfin.Value.Date;
             string query;
            if (cmb == "Buscar por nombre") 
             {
                 query = "select Productos.Nombre as Producto, Ventas.Descripcion,Ventas.PrecioVenta,Ventas.Cantidad_Vendida + Ventas.Cantidad_Devuelta as Entregadas,Ventas.Cantidad_Vendida,Ventas.Cantidad_Devuelta,TipoE.Tipo_Establecimiento, Establecimientos.Nombre, Ventas.MontoTotal,Ventas.FechaRegistro from Ventas inner join Productos on Productos.IdProducto = Ventas.IdProducto inner join TipoE on TipoE.IdTipo = Ventas.IdTipo inner join Establecimientos on Establecimientos.IdEst = Ventas.IdEst where Ventas.FechaRegistro between @fechainicio and @fechafin;";
             }
             else
             {
                 query = "select Productos.Nombre as Producto, Ventas.Descripcion,Ventas.PrecioVenta,Ventas.Cantidad_Vendida + Ventas.Cantidad_Devuelta as Entregadas,Ventas.Cantidad_Vendida,Ventas.Cantidad_Devuelta,TipoE.Tipo_Establecimiento, Establecimientos.Nombre, Ventas.MontoTotal,Ventas.FechaRegistro from Ventas \r\ninner join Productos on Productos.IdProducto = Ventas.IdProducto inner join TipoE on TipoE.IdTipo = Ventas.IdTipo inner join Establecimientos on Establecimientos.IdEst = Ventas.IdEst where Establecimientos.Nombre = @Nombre AND Ventas.FechaRegistro BETWEEN @fechainicio AND @fechafin";
             }
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@fechainicio", fechainicio);
                da.SelectCommand.Parameters.AddWithValue("@fechafin", fechafin);

                if (cmb != "Buscar por nombre")
                {
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", cmb);
                }

                da.Fill(dt);
            }

            
            con.Close();
            dgvRep.DataSource = dt;
            SumarSubTotal();
        }

        private void btndownload_MouseHover(object sender, EventArgs e)
        {
            btndownload.IconColor = Color.LightGreen;
        }

        private void btndownload_MouseLeave(object sender, EventArgs e)
        {
            btndownload.IconColor = Color.Green;
        }
    }
}
    

