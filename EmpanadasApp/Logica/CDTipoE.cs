using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmpanadasApp.Modelos;
using System.Windows.Controls.Primitives;

namespace EmpanadasApp.Logica
{
    public class CDTipoE
    {
        public CTipoE Leer()
        {
            CTipoE cte = new CTipoE();
            using (SqlConnection con = new SqlConnection(CDatos.conect))
            {
                string query = "SELECT * FROM TipoE"; ;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        cte = new CTipoE
                        {
                            IdTipo = Convert.ToInt32(dr["IdTipo"]),
                            TipoE = dr["Tipo_Establecimiento"].ToString(),

                        };

                    }

                }
                return cte;
            }

        }

        public List<CTipoE> Listar()
        {
            List<CTipoE> lista = new List<CTipoE>();
            using (SqlConnection con = new SqlConnection(CDatos.conect))
            {
                string query = "SELECT * FROM TipoE"; ;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        CTipoE cTipoE = new CTipoE
                        {
                            IdTipo = Convert.ToInt32(dr["IdTipo"]),
                            TipoE = dr["Tipo_Establecimiento"].ToString(),
                        };
                       lista.Add(cTipoE);

                    }

                }
                return lista;
            }
        }
    }
}
