using EmpanadasApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace EmpanadasApp.Logica
{
    public class CDUsuario
    {
       public CUsuario Leer()
        {
            CUsuario cUsuario = new CUsuario();
            using(SqlConnection con = new SqlConnection(CDatos.conect))
            {
                string query = "Select * from Usuarios";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read()) {

                        cUsuario = new CUsuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            Clave = dr["Clave"].ToString()
                        };

                    }

                }
                 
            }
            return cUsuario;
        }

    }
}
