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
using System.Windows.Forms.DataVisualization.Charting;
using EmpanadasApp.Logica;
using EmpanadasApp.Modelos;

namespace EmpanadasApp
{
    public partial class frmtrend : Form
    {
        public frmtrend()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(CDatos.conect);
        private void btnExit_Click(object sender, EventArgs e)
        {
            CUsuario usuario = new CDUsuario().Leer();
            Mainfrm mainfrm = new Mainfrm(usuario);
            mainfrm.Show();
            this.Hide();
        }

        private void FechaRep(DateTime fechainicio, DateTime fechafin)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("Top5Prod", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
                dgvVentas.DataSource = dt;

                charttop5E.Series.Clear();
                Series series = new Series("Productos")
                {
                  
                    XValueMember = "Descripcion",
                    YValueMembers = "Cantidad_Vendida",
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.AliceBlue,

                };

                charttop5p.Series.Clear(); // Limpiar series anteriores
                charttop5p.Series.Add(series);
                charttop5p.DataSource = dt;
                charttop5p.DataBind();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void FechaPM(DateTime fechainiciopm, DateTime fechafinpm)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("Top5Prod", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fechainicio", fechainiciopm);
                    cmd.Parameters.AddWithValue("@fechafin", fechafinpm);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void Top5Est(DateTime fechainicioe, DateTime fechafine)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("top5Est", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicioe);
                    cmd.Parameters.AddWithValue("@fechafin", fechafine);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
                dgvtopE.DataSource = dt;

                charttop5E.Series.Clear();
                Series series = new Series("Establecimientos")
                {
                   
                    XValueMember = "Nombre",
                    YValueMembers = "Cantidad_Vendida",
                    ChartType = SeriesChartType.Column
                };

                charttop5E.DataSource = dt;
                charttop5E.Series.Clear();
                charttop5E.Series.Add(series);
                charttop5E.DataBind();
            }
            
    
            catch (Exception ex)
            {

                MessageBox.Show("Error", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void frmtrend_Load(object sender, EventArgs e)
        {

        }

        private void dtpinicio_ValueChanged(object sender, EventArgs e)
        {
            FechaRep(dtpinicio.Value.Date, dtpfin.Value.Date);
            Top5Est(dtpinicio.Value.Date, dtpfin.Value.Date);
            //FechaPM(dtpinicio.Value.Date, dtpfin.Value.Date);
           
        }

        private void dtpfin_ValueChanged(object sender, EventArgs e)
        {
            FechaRep(dtpinicio.Value.Date, dtpfin.Value.Date);
            Top5Est(dtpinicio.Value.Date, dtpfin.Value.Date);
            //FechaPM(dtpinicio.Value.Date, dtpfin.Value.Date);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
