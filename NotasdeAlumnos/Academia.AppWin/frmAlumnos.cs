using Academia.Entidades;
using Academia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.AppWin
{
    public partial class frmAlumnos : Form
    {
        Notas notas;
        public frmAlumnos(Notas notas)
        {
            InitializeComponent();
            this.notas = notas;
        }
        void cargarDatos()
        {
            var listadoAlumnos = AlumnosBL.Listar();
            cboAlumno.DataSource = listadoAlumnos;
            cboAlumno.DisplayMember = "Aldo";
            cboAlumno.ValueMember = "ID";

            var listadoCursos = CursosBL.Listar();
            cboCurso.DataSource = listadoCursos;
            cboCurso.DisplayMember = "CCNA";
            cboCurso.ValueMember = "ID";
        }

        private void RegistrarDatos(object sender, EventArgs e)
        {
            asignarDatos();
            this.DialogResult = DialogResult.OK;
        }
        void asignarDatos()
        {
            this.notas.Eva1 =int.Parse(txtE1.Text);
            this.notas.Eva2 = int.Parse(txtE2.Text);
            this.notas.Parcial = int.Parse(txtParcial.Text);
            this.notas.Final = int.Parse(txtFinal.Text);
            this.notas.IdAlumno = int.Parse(cboAlumno.SelectedValue.ToString());
            this.notas.IdCurso = int.Parse(cboCurso.SelectedValue.ToString());
        }

        private void CargarDatos(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
