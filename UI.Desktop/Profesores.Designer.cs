namespace UI.Desktop
{
    partial class Profesores
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
            this.tcProfesores = new System.Windows.Forms.ToolStripContainer();
            this.tsProfesores = new System.Windows.Forms.ToolStrip();
            this.tlProfesores = new System.Windows.Forms.TableLayoutPanel();
            this.dgvProfesores = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tcProfesores.ContentPanel.SuspendLayout();
            this.tcProfesores.TopToolStripPanel.SuspendLayout();
            this.tcProfesores.SuspendLayout();
            this.tlProfesores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesores)).BeginInit();
            this.SuspendLayout();
            // 
            // tcProfesores
            // 
            // 
            // tcProfesores.ContentPanel
            // 
            this.tcProfesores.ContentPanel.Controls.Add(this.tlProfesores);
            this.tcProfesores.ContentPanel.Size = new System.Drawing.Size(549, 321);
            this.tcProfesores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcProfesores.Location = new System.Drawing.Point(0, 0);
            this.tcProfesores.Name = "tcProfesores";
            this.tcProfesores.Size = new System.Drawing.Size(549, 346);
            this.tcProfesores.TabIndex = 0;
            this.tcProfesores.Text = "toolStripContainer1";
            // 
            // tcProfesores.TopToolStripPanel
            // 
            this.tcProfesores.TopToolStripPanel.Controls.Add(this.tsProfesores);
            // 
            // tsProfesores
            // 
            this.tsProfesores.Dock = System.Windows.Forms.DockStyle.None;
            this.tsProfesores.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsProfesores.Location = new System.Drawing.Point(3, 0);
            this.tsProfesores.Name = "tsProfesores";
            this.tsProfesores.Size = new System.Drawing.Size(111, 25);
            this.tsProfesores.TabIndex = 0;
            // 
            // tlProfesores
            // 
            this.tlProfesores.ColumnCount = 2;
            this.tlProfesores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlProfesores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlProfesores.Controls.Add(this.dgvProfesores, 0, 0);
            this.tlProfesores.Controls.Add(this.btnActualizar, 0, 1);
            this.tlProfesores.Controls.Add(this.btnSalir, 1, 1);
            this.tlProfesores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlProfesores.Location = new System.Drawing.Point(0, 0);
            this.tlProfesores.Name = "tlProfesores";
            this.tlProfesores.RowCount = 2;
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlProfesores.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlProfesores.Size = new System.Drawing.Size(549, 321);
            this.tlProfesores.TabIndex = 0;
            // 
            // dgvProfesores
            // 
            this.dgvProfesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlProfesores.SetColumnSpan(this.dgvProfesores, 2);
            this.dgvProfesores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProfesores.Location = new System.Drawing.Point(3, 3);
            this.dgvProfesores.Name = "dgvProfesores";
            this.dgvProfesores.RowTemplate.Height = 24;
            this.dgvProfesores.Size = new System.Drawing.Size(543, 286);
            this.dgvProfesores.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(378, 295);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(87, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(471, 295);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // Profesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 346);
            this.Controls.Add(this.tcProfesores);
            this.Name = "Profesores";
            this.Text = "Profesores";
            this.tcProfesores.ContentPanel.ResumeLayout(false);
            this.tcProfesores.TopToolStripPanel.ResumeLayout(false);
            this.tcProfesores.TopToolStripPanel.PerformLayout();
            this.tcProfesores.ResumeLayout(false);
            this.tcProfesores.PerformLayout();
            this.tlProfesores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcProfesores;
        private System.Windows.Forms.TableLayoutPanel tlProfesores;
        private System.Windows.Forms.ToolStrip tsProfesores;
        private System.Windows.Forms.DataGridView dgvProfesores;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}