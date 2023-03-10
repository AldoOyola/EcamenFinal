using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public class AlumnosDB
    {
        public List<Notas> Listar(Alumnos)
        {
            var listado = new List<Notas>();

            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Alumnos", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Notas notas;
                            while (lector.Read())
                            {
                                // CREAR UN NUEVO OBJETO CLIENTE
                                notas = new Notas();
                                notas.Eva1 = (int)lector["Eva1"];
                                notas.Eva2 = (int)lector["Eva2"];
                                notas.Parcial = (int)lector["Parcial"];
                                notas.Final = (int)lector["Final"];
                                notas.IdAlumno = (int)lector["IdAlumno"];
                                notas.IdCurso = (int)lector["IdCurso"];

                                // AGREGAR EL CLIENTE AL LISTADO
                                listado.Add(notas);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public int Insertar(Notas notas)
        {
            int filas = 0;
            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO [dbo].[Alumnos] " +
                    "([Eva1],[Eva2],[Parcial],[Final],[IdAlumno],,[IdCurso]" +
                    "VALUES(@Eva1,@Eva2,@Parcial,@Final,@IdCurso)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Eva1", notas.Eva1);
                    comando.Parameters.AddWithValue("@Eva2", notas.Eva2);
                    comando.Parameters.AddWithValue("@Parcial", notas.Parcial);
                    comando.Parameters.AddWithValue("@Final", notas.Final);
                    comando.Parameters.AddWithValue("@IdAlumno", notas.IdAlumno);
                    comando.Parameters.AddWithValue("@IdCurso", notas.IdCurso);
                    filas = comando.ExecuteNonQuery();
                }
            }
            return filas;
        }
}
}
