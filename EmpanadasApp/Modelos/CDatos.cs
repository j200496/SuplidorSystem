﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace EmpanadasApp.Modelos
{
    public class CDatos
    {
        public static string conect = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
