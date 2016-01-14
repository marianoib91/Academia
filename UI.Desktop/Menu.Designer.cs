namespace UI.Desktop
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.smiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.smiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.smiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.smiMisCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.smiInscripcionAMateria = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiInicio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(282, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiInicio
            // 
            this.smiInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiUsuarios,
            this.smiPersonas,
            this.smiCursos,
            this.smiComisiones,
            this.smiPlanes,
            this.smiEspecialidades,
            this.smiMaterias,
            this.smiMisCursos,
            this.smiInscripcionAMateria,
            this.smiSalir});
            this.smiInicio.Name = "smiInicio";
            this.smiInicio.Size = new System.Drawing.Size(57, 24);
            this.smiInicio.Text = "Inicio";
            // 
            // smiUsuarios
            // 
            this.smiUsuarios.Name = "smiUsuarios";
            this.smiUsuarios.Size = new System.Drawing.Size(222, 26);
            this.smiUsuarios.Text = "Usuarios";
            this.smiUsuarios.Click += new System.EventHandler(this.smiUsuarios_Click);
            // 
            // smiPersonas
            // 
            this.smiPersonas.Name = "smiPersonas";
            this.smiPersonas.Size = new System.Drawing.Size(222, 26);
            this.smiPersonas.Text = "Personas";
            this.smiPersonas.Click += new System.EventHandler(this.smiPersonas_Click);
            // 
            // smiCursos
            // 
            this.smiCursos.Name = "smiCursos";
            this.smiCursos.Size = new System.Drawing.Size(222, 26);
            this.smiCursos.Text = "Cursos";
            this.smiCursos.Click += new System.EventHandler(this.smiCursos_Click);
            // 
            // smiComisiones
            // 
            this.smiComisiones.Name = "smiComisiones";
            this.smiComisiones.Size = new System.Drawing.Size(222, 26);
            this.smiComisiones.Text = "Comisiones";
            this.smiComisiones.Click += new System.EventHandler(this.smiComisiones_Click);
            // 
            // smiPlanes
            // 
            this.smiPlanes.Name = "smiPlanes";
            this.smiPlanes.Size = new System.Drawing.Size(222, 26);
            this.smiPlanes.Text = "Planes";
            this.smiPlanes.Click += new System.EventHandler(this.smiPlanes_Click);
            // 
            // smiEspecialidades
            // 
            this.smiEspecialidades.Name = "smiEspecialidades";
            this.smiEspecialidades.Size = new System.Drawing.Size(222, 26);
            this.smiEspecialidades.Text = "Especialidades";
            this.smiEspecialidades.Click += new System.EventHandler(this.smiEspecialidades_Click);
            // 
            // smiMaterias
            // 
            this.smiMaterias.Name = "smiMaterias";
            this.smiMaterias.Size = new System.Drawing.Size(222, 26);
            this.smiMaterias.Text = "Materias";
            this.smiMaterias.Click += new System.EventHandler(this.smiMaterias_Click);
            // 
            // smiMisCursos
            // 
            this.smiMisCursos.Name = "smiMisCursos";
            this.smiMisCursos.Size = new System.Drawing.Size(222, 26);
            this.smiMisCursos.Text = "Mis Cursos";
            this.smiMisCursos.Click += new System.EventHandler(this.smiMisCursos_Click);
            // 
            // smiInscripcionAMateria
            // 
            this.smiInscripcionAMateria.Name = "smiInscripcionAMateria";
            this.smiInscripcionAMateria.Size = new System.Drawing.Size(222, 26);
            this.smiInscripcionAMateria.Text = "Inscripcion a Materia";
            this.smiInscripcionAMateria.Click += new System.EventHandler(this.smiInscripcionAMateria_Click);
            // 
            // smiSalir
            // 
            this.smiSalir.Name = "smiSalir";
            this.smiSalir.Size = new System.Drawing.Size(222, 26);
            this.smiSalir.Text = "Salir";
            this.smiSalir.Click += new System.EventHandler(this.smiSalir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Shown += new System.EventHandler(this.Menu_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiInicio;
        private System.Windows.Forms.ToolStripMenuItem smiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem smiPersonas;
        private System.Windows.Forms.ToolStripMenuItem smiCursos;
        private System.Windows.Forms.ToolStripMenuItem smiComisiones;
        private System.Windows.Forms.ToolStripMenuItem smiPlanes;
        private System.Windows.Forms.ToolStripMenuItem smiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem smiMaterias;
        private System.Windows.Forms.ToolStripMenuItem smiMisCursos;
        private System.Windows.Forms.ToolStripMenuItem smiInscripcionAMateria;
        private System.Windows.Forms.ToolStripMenuItem smiSalir;
    }
}