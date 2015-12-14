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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }
        private Persona _PersonaActual;

        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public PersonaDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
            PlanLogic pl = new PlanLogic();
            this.cmbIDPlan.DataSource = pl.GetAll();
            this.cmbIDPlan.ValueMember = "ID";
            this.cmbIDPlan.DisplayMember = "ID Plan";
            this.cmbTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TipoPersonas));
        }

        public PersonaDesktop(int ID, ModoForm modo)
            : this()
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                PersonaActual = pl.GetOne(ID);
                this.Modo = modo;
                PlanLogic planL = new PlanLogic();
                this.cmbIDPlan.DataSource = planL.GetAll();
                this.cmbTipoPersona.DataSource = Enum.GetValues(typeof(Persona.TipoPersonas));
                MapearDeDatos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion.ToString();
            this.txtEmail.Text = this.PersonaActual.Email.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtFechaNacimiento.Text = Convert.ToString(this.PersonaActual.FechaNacimiento);
            this.txtTelefono.Text = this.PersonaActual.Telefono.ToString();
            this.cmbIDPlan.ValueMember = "ID";
            this.cmbIDPlan.SelectedValue = this.PersonaActual.IDPlan;
            this.cmbTipoPersona.SelectedItem = this.PersonaActual.TipoPersona;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;

            }
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    Persona persona = new Persona();
                    this.PersonaActual = persona;
                    PersonaActual.Nombre = this.txtNombre.Text;
                    PersonaActual.Apellido = this.txtApellido.Text;
                    PersonaActual.Direccion = this.txtDireccion.Text;
                    PersonaActual.Email = this.txtEmail.Text;
                    PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                    PersonaActual.Telefono = this.txtTelefono.Text;
                    PersonaActual.IDPlan = Convert.ToInt16(this.cmbIDPlan.SelectedValue);
                    PersonaActual.TipoPersona = (Persona.TipoPersonas)(this.cmbTipoPersona.SelectedItem);
                    PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
                    PersonaActual.State = BusinessEntity.States.New;
                    break;

                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Modificacion:
                    PersonaActual.Nombre = this.txtNombre.Text;
                    PersonaActual.Apellido = this.txtApellido.Text;
                    PersonaActual.Direccion = this.txtDireccion.Text;
                    PersonaActual.Email = this.txtEmail.Text;
                    PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                    PersonaActual.Telefono = this.txtTelefono.Text;
                    PersonaActual.IDPlan = Convert.ToInt16(this.cmbIDPlan.SelectedValue);
                    PersonaActual.TipoPersona = (Persona.TipoPersonas)(this.cmbTipoPersona.SelectedItem);
                    PersonaActual.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;


            }
        }
        public override bool Validar()
        {
            if ((this.txtApellido.Text == "") || (this.txtNombre.Text == ""))
            {
                string mensaje = "No se puede continuar si no completa los campos obligatorios";
                Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic al = new PersonaLogic();
            try
            {
                al.Save(PersonaActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }
    }
}
