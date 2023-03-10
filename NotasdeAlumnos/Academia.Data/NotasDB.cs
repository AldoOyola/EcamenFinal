using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public class NotasDB
    {
        public List<Notas> Listar()
        {
            var listado = new List<Notas>();

            return listado;
        }

        public string NumeroNota()
        {
            int numero = 0;
            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT ISNULL(MAX(NUMERO),0) FROM Prestamo", conexion))
                {
                    numero = int.Parse(comando.ExecuteScalar().ToString());
                    numero++;
                }
            }
            return numero.ToString().PadLeft(10, char.Parse("0"));
        }

        public int Insertar(Notas notas)
        {
            int nuevoId = 0;

            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO Notas (Eva1, Eva2, Parcial, Final, " +
                                "IdAlumno, IdCurso" +
                            "VALUES (@Eva1, @Eva2, @Parcial, @Final, " +
                                "@Tasa, @Cuotas, @FechaDeposito,@IdAlumno,@IdCurso);" +
                            "SELECT ISNULL(@@IDENTITY,0);";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Eva1", notas.Eva1);
                    comando.Parameters.AddWithValue("@Eva2", notas.Eva2);
                    comando.Parameters.AddWithValue("@Parcial", notas.Parcial);
                    comando.Parameters.AddWithValue("@Final", notas.Final);
                    comando.Parameters.AddWithValue("@IdAlumno", notas.IdAlumno);
                    comando.Parameters.AddWithValue("@IdCurso", notas.IdCurso);
                    nuevoId = int.Parse(comando.ExecuteScalar().ToString());
                }
            }
            return nuevoId;
        }
    }
}
