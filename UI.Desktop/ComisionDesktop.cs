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
    public partial class ComisionDesktop : ApplicationForm
    {
        Comision _ComisionActual = new Comision();

        public Comision ComisionActual
        {
            get
            {
                return _ComisionActual;
            }

            set
            {
                _ComisionActual = value;
            }
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public ComisionDesktop(int ID, ModoForm modo)
        {
            this.Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            _ComisionActual = cl.GetOne(ID);
            this.MapearADatos();
        }

        public ComisionDesktop()
        {
            InitializeComponent();
        }
        public override void MapearDeDatos()
        {
            this.txtIDComision.Text = Convert.ToString(this.ComisionActual.ID);
            this.txtDescripcion.Text = Convert.ToString(this.ComisionActual.Descripcion);
            this.txtAnioEspecialidad.Text = Convert.ToString(this.ComisionActual.AnioEspecialidad);
            this.txtIDPlan.Text = Convert.ToString(this.ComisionActual.IDPlan);

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
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    _ComisionActual = new Comision();
                    ComisionActual.State = BusinessEntity.States.New;
                }
                else if (this.Modo == ModoForm.Modificacion)
                {
                    ComisionActual.State = BusinessEntity.States.Modified;
                    _ComisionActual.ID = Convert.ToInt32(this.txtIDComision.Text);
                }
                _ComisionActual.Descripcion = this.txtDescripcion.Text;
                _ComisionActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);
                _ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                }
            else if (this.Modo == ModoForm.Baja)
            {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                ComisionActual.State = BusinessEntity.States.Unmodified;
            }
            
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(_ComisionActual);
        }
        public override bool Validar()
        {
            if (this.txtDescripcion.Text == null)
            {
                this.Notificar("Descripcion Incompleta", "La descripcion no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtIDPlan.Text == null)
            {
                this.Notificar("ID Plan Incompleto", "El ID del Plan no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtAnioEspecialidad.Text == null)
            {
                this.Notificar("Año Especialidad Incompleto", "El Año de Especialidad no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
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
