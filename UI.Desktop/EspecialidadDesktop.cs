using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public Especialidad _EspecialidadActual;

        public Especialidad EspecialidadActual
        {
            get
            {
                return _EspecialidadActual;
            }

            set
            {
                _EspecialidadActual = value;
            }
        }

        //Constructor para Altas
        public EspecialidadDesktop(ModoForm modo): this()
        {

        }
        //Constructor para Eliminar y Editar
        public EspecialidadDesktop(int ID, ModoForm modo): this()
        {
            EspecialidadLogic espLog = new EspecialidadLogic();
            this._EspecialidadActual = espLog.GetOne(ID);
            this.MapearDeDatos();

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = Convert.ToString(this._EspecialidadActual.ID);
            this.txtDescripcion.Text = Convert.ToString(this._EspecialidadActual.Descripcion);
            if ((this.Modo == ModoForm.Alta) | (this.Modo == ModoForm.Modificacion))
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                Especialidad esp = new Especialidad();
                EspecialidadActual = esp;
                this.EspecialidadActual.State = Especialidad.States.New;
            }
            if ((this.Modo == ModoForm.Alta) | (this.Modo == ModoForm.Modificacion))
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    EspecialidadActual.ID = Convert.ToInt32(this.txtID);
                    this._EspecialidadActual.State = Especialidad.States.Modified;
                }
                EspecialidadActual.Descripcion = Convert.ToString(this.txtDescripcion);
            }        
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic espLog = new EspecialidadLogic();
            espLog.Save(_EspecialidadActual);

        }
        public override bool Validar()
        {
            if (this.txtDescripcion.Text == null)
            {
                this.Notificar("Descripcion Incompleta", "La Descripcion no puede quedar en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.txtID.Text == null)
            {
                this.Notificar("ID Incompleta", "La ID no puede quedar en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                this.Notificar("Se realizó la operación correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
