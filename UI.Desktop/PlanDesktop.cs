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
    public partial class PlanDesktop : ApplicationForm
    {
        Plan _PlanActual = new Plan();

        public Plan PlanActual
        {
            get
            {
                return _PlanActual;
            }

            set
            {
                _PlanActual = value;
            }
        }

        public PlanDesktop()
        {
            InitializeComponent();
        }
        public PlanDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.cmbIDEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
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
                PlanActual = new Plan();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    PlanActual.ID = Convert.ToInt32(this.txtID.Text);
                }
                PlanActual.Descripcion = Convert.ToString(this.txtDescripcion.Text);
                PlanActual.IdEspecialidad = Convert.ToInt32(this.cmbIDEspecialidad.SelectedText);
                
            }
            
            //DEFINIR STATE DE PLANACTUAL SEGUN EL MODO
        }
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
