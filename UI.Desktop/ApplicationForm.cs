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
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        //RECORDAR: 0 = Admin, 1 = Profesor, 2 = Alumno
        static private int _TipoUsuario;
        static public int TipoUsuario
        {
            get { return _TipoUsuario; }
            set { _TipoUsuario = value; }
        }
        //Defino la enumeracion
        public enum ModoForm {Alta, Baja, Modificacion, Consulta}
        //Propiedad Modo
        private ModoForm _Modo;
        public ModoForm Modo {
            get { return _Modo; } 
            set{_Modo=value;} }
        
        //Metodos a sobrecargar en las subclases
        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public virtual void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

    }
}
