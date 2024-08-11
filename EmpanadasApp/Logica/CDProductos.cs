using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmpanadasApp.Modelos;
using System.Data;

namespace EmpanadasApp.Logica
{
    public class CDProductos
    {
        public List<Productos> Listar()
        {
            List<Productos> cProductos = new List<Productos>();
          

            using (SqlConnection con = new SqlConnection(CDatos.conect))
            {
                string query = "select Codigo,Nombre,Descripcion,PrecioVenta from Productos";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Productos pr = new Productos
                            {
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),    
                                Descripcion = reader["Descripcion"].ToString(),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"].ToString()),

                            };
                            cProductos.Add(pr);

                        }

                        }

                    }
                    con.Close();
            }
            return cProductos;
        }
    }
}
