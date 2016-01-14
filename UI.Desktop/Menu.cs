using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : ApplicationForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Evento que se dispara solo la primera vez que se abre el formulario
        private void Menu_Shown(object sender, EventArgs e)
        {
            this.esAdmin(false);
            Login frmLogin = new Login(); //Ejecuta el form de Login
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                this.detMenu();
            }
        }
        //Determina que clase de usuario esta logueado
        private void detMenu()
        {
            switch (TipoUsuario)
            {
                case 0:
                    this.esAdmin(true);
                    break;
                case 1:
                    this.esProfesor(true);
                    break;
                case 2:
                    this.esAlumno(true);
                    break;
            }
        }
        private void esAdmin(bool det)
        {
            //Determina si mostrar o no estas opciones, segun se haya logueado o no Admin
            smiComisiones.Visible = det;
            smiCursos.Visible = det;
            smiEspecialidades.Visible = det;
            smiMaterias.Visible = det;
            smiPersonas.Visible = det;
            smiPlanes.Visible = det;
            //No muestra estas opciones, por no ser propias de un Admin
            smiMisCursos.Visible = false;
            smiInscripcionAMateria.Visible = false;
        }
        private void esProfesor(bool det)
        {
            //Muestra los cursos de un profesor
            smiMisCursos.Visible = det;
        }
        private void esAlumno(bool det)
        {
            //Muestra la opcion de inscripcion a materias para un alumno
            smiInscripcionAMateria.Visible = det;
        }
        private void smiSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void smiUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ShowDialog();
        }

        private void smiPersonas_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas();
            personas.ShowDialog();
        }

        private void smiCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.ShowDialog();
        }

        private void smiComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            comisiones.ShowDialog();
        }

        private void smiPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
        }

        private void smiEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            especialidades.ShowDialog();
        }

        private void smiMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
        }
        //FALTAN CLASES DocenteCurso y DocenteCursoDesktop
        private void smiMisCursos_Click(object sender, EventArgs e)
        {
            
        }
        //FALTAN CLASES AlumnoMateria y AlumnoMateriaDesktop
        private void smiInscripcionAMateria_Click(object sender, EventArgs e)
        {
            
        }

    }
}
