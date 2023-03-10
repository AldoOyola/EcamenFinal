using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public static class UtilDB
    {
        public static string CadenaConexion()
        {
            string cadenaConexion = @"Server = localhost; DataBase = Academia; ntegrated Security=true";

            return cadenaConexion;
        }
    }
}
