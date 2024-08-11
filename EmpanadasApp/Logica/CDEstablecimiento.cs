using EmpanadasApp.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpanadasApp.Logica;
using System.Windows.Navigation;

namespace EmpanadasApp.Logica
{
    public class CDEstablecimiento
    {
        public Establecimientos Leer()
        {
            Establecimientos establecimiento = new Establecimientos();
            using (SqlConnection con = new SqlConnection(CDatos.conect))
            {
                string query = "Select * from Establecimientos";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        establecimiento = new Establecimientos
                        {
                            IdEst = Convert.ToInt32(dr["IdEst"]),
                            IdTipo = Convert.ToInt32(dr["Tipo"]),
                            Nombre = dr["Nombre"].ToString(),
                            NombreR = dr["NombreR"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Direccion = dr["Direccion"].ToString()

                        };

                    }

                }

            }
           return establecimiento;
        }
      
    }
}
