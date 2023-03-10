using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public class CursosDB
    {
        public List<Cursos> Listar()
        {
            var listado = new List<Cursos>();
            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Cursos", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Cursos tipo;
                            while (lector.Read())
                            {
                                tipo = new Cursos()
                                {
                                    ID = int.Parse(lector["ID"].ToString()),
                                    Nombres = lector["Nombres"].ToString()
                                };
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }

            return listado;

        }
}
}
