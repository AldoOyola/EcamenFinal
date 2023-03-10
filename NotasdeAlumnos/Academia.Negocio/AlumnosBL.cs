using Academia.Data;
using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Negocio
{
    public static class AlumnosBL
    {
        public static List<Alumnos> Listar()
        {
            var alumnosDB = new AlumnosDB();
            return alumnosDB.Listar();
        }
    }
}
