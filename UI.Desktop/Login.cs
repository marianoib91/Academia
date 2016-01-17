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
    public partial class Login : ApplicationForm
    {

        public Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic usuario = new UsuarioLogic();
            Usuario usr = new Usuario();
            Menu formMenu = new Menu();
            if (usuario.GetOne(this.txtNombreUsuario.Text, this.txtClave.Text))
            {
                usr = usuario.GetOne(this.txtNombreUsuario.Text);
                PersonaLogic pl = new PersonaLogic();
                Persona per = pl.GetOne(usr.IDPersona);
                InfoUsuario = usr.Apellido + "," + usr.Nombre;
                IDPersona = usr.IDPersona;
                IDUsuario = usr.ID;
                Persona.TipoPersonas tipoPer = per.TipoPersona;
                this.DialogResult = DialogResult.OK;
                switch (per.TipoPersona)
                {
                    case Persona.TipoPersonas.Administrador:
                        TipoUsuario = 1;
                        this.Close();
                        break;
                    case Persona.TipoPersonas.Docente:
                        TipoUsuario = 2;
                        this.Close();
                        break;
                    case Persona.TipoPersonas.Alumno:
                        TipoUsuario = 3;
                        this.Close();
                        break;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de Usuario y/o Contraseña incorrecto/s.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        
    }
}
