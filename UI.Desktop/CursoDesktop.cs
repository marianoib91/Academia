using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {

        /*FALTA MANEJO DE CLAVES FORANEAS PARA CONTINUAR DESDE DEFINICION DE METODO 
        MapearDeDatos() Lab04, punto 12*/

        Curso _CursoActual = new Curso();

        public Curso CursoActual
        {
            get
            {
                return _CursoActual;
            }

            set
            {
                _CursoActual = value;
            }
        }

        public CursoDesktop()
        {
            InitializeComponent();
        }
        public void fillCmbIdMateria()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = new List<Curso>();
            cursos = cl.GetAll();
            List<String> idMaterias = new List<string>();
            foreach (Curso curso in cursos)
            {
                idMaterias.Add(Convert.ToString(curso.ID));
            }
            cmbIDMateria.DataSource = idMaterias;
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo):this()
        {
            CursoLogic cl = new CursoLogic();
            this.Modo = modo;
            _CursoActual = cl.GetOne(ID);
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {

        }
        public override void MapearADatos() { }
        public override void GuardarCambios() { }
        public override bool Validar() { return false; }
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }


    }
}
