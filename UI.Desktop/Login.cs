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
        private object txtUsuario;

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
                Persona per = pl.GetOne(usr.ID);
                
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
