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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop espDes = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            espDes.ShowDialog();
            this.Listar();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count>0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop espDes = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                espDes.ShowDialog();
                this.Listar();
            }
                
           
            
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop espDes = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                espDes.ShowDialog();
                this.Listar();
            }
           
        }
    }
}
