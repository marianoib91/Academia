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
using System.Globalization;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    

    public partial class UsuarioDesktop : ApplicationForm
    {

            
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this() 
        {
            this.Modo = modo;
            int id = ID;
            UsuarioLogic usulogic = new UsuarioLogic();
            UsuarioActual = usulogic.GetOne(ID);
            this.MapearDeDatos();
        }
        public UsuarioDesktop()
        {
            InitializeComponent();
            this.fillCmbIdPersona();
        }

        /*ARREGLAR METODO PARA LLENAR COMBOBOX 
        (hacerlo con la ID de una persona y no 
        de un usuario)*/

        public void fillCmbIdPersona()
        {
            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.AddRange(ul.GetAll());
            cmbIdPersona.DataSource = usuarios;
            cmbIdPersona.DisplayMember = "_ID";
            cmbIdPersona.ValueMember = "ID";
            
        }
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

            if (UsuarioDesktop.ModoForm.Alta == this.Modo || UsuarioDesktop.ModoForm.Modificacion == this.Modo)
            {
                btnAceptar.Text = "Guardar";
            }
            if (UsuarioDesktop.ModoForm.Baja == this.Modo)
            {
                btnAceptar.Text = "Eliminar";
            }
            if (UsuarioDesktop.ModoForm.Consulta == this.Modo)
            {
                btnAceptar.Text = "Aceptar";
            }
             

        }
        public override void MapearADatos() 
        {
            if (UsuarioDesktop.ModoForm.Alta == this.Modo)
            {
                UsuarioActual = new Usuario();
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.State = Usuario.States.New;

            }
            if (UsuarioDesktop.ModoForm.Modificacion == this.Modo)
            {

                this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text);
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.State = Usuario.States.Modified;
                
            }

        }

        public override void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioLogic usulogic = new UsuarioLogic();
            usulogic.Save(UsuarioActual);
        }


        public override bool Validar() 
        {
            if (this.txtNombre.Text == null)
            {
                this.Notificar("Nombre Incompleto", "El nombre no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtApellido.Text == null)
            {
                this.Notificar("Apellido Incompleto", "El apellido no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                this.Notificar("Clave Incompleta", "La clave no puede tener menos de ocho caracteres.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (System.String.CompareOrdinal(this.txtClave.Text, this.txtConfirmarClave.Text) != 0)
            {
                this.Notificar("Clave Incorrecta", "La clave no coincide con la confirmación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!(this.IsValidEmail(this.txtEmail.Text)))
            {
                this.Notificar("Falta e-Mail", "El e-Mail no posée el formato correcto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtUsuario.Text == null)
            {
                this.Notificar("Falta Nombre de Usuario", "El nombre de usuario no puede quedar en blanco.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                this.Notificar("Se realizó la operación correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
             
        }

        /*En el método Validar debemos controlar los contenidos de los controles
del no estén vacíos, que la clave coincida con la confirmación, tenga
al menos 8 caracteres y el email sea válido. En caso de ser algo
inválido debe retornar false e informar al usuario utilizando el método
de Notificar que definimos anteriormente, y si es todo válido debe
llamar retornar true.
*/
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




        //METODO PARA VALIDAR EMAIL!

        public bool IsValidEmail(string strIn)
        {
            bool invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                bool invalid = true;
            }
            return match.Groups[1].Value + domainName;
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
