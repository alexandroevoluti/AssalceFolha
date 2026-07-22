namespace AssalceFolha
{
    partial class frmRelatorioCompetenciaPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioCompetenciaPlano));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckSomentePlanos = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.dtpCompetencia = new System.Windows.Forms.DateTimePicker();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ckSomenteNovos = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckSomenteNovos);
            this.panel1.Controls.Add(this.ckSomentePlanos);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.btnVisualizar);
            this.panel1.Controls.Add(this.dtpCompetencia);
            this.panel1.Controls.Add(this.lbCompetencia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 62);
            this.panel1.TabIndex = 86;
            // 
            // ckSomentePlanos
            // 
            this.ckSomentePlanos.AutoSize = true;
            this.ckSomentePlanos.Location = new System.Drawing.Point(243, 31);
            this.ckSomentePlanos.Name = "ckSomentePlanos";
            this.ckSomentePlanos.Size = new System.Drawing.Size(147, 17);
            this.ckSomentePlanos.TabIndex = 83;
            this.ckSomentePlanos.Text = "Somente Plano de Saúde";
            this.ckSomentePlanos.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1046, 25);
            this.toolStrip1.TabIndex = 82;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = false;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(65, 22);
            this.btnSair.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(577, 29);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 2;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // dtpCompetencia
            // 
            this.dtpCompetencia.CustomFormat = "MM/yyyy";
            this.dtpCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetencia.Location = new System.Drawing.Point(113, 32);
            this.dtpCompetencia.Name = "dtpCompetencia";
            this.dtpCompetencia.ShowUpDown = true;
            this.dtpCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetencia.TabIndex = 1;
            // 
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(38, 32);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(69, 13);
            this.lbCompetencia.TabIndex = 0;
            this.lbCompetencia.Text = "Competência";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 62);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1046, 502);
            this.reportViewer1.TabIndex = 87;
            // 
            // ckSomenteNovos
            // 
            this.ckSomenteNovos.AutoSize = true;
            this.ckSomenteNovos.Location = new System.Drawing.Point(406, 32);
            this.ckSomenteNovos.Name = "ckSomenteNovos";
            this.ckSomenteNovos.Size = new System.Drawing.Size(138, 17);
            this.ckSomenteNovos.TabIndex = 84;
            this.ckSomenteNovos.Text = "Somente novas críticas";
            this.ckSomenteNovos.UseVisualStyleBackColor = true;
            // 
            // frmRelatorioCompetenciaPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 564);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRelatorioCompetenciaPlano";
            this.Text = "frmRelatorioCompetenciaPlano";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DateTimePicker dtpCompetencia;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.CheckBox ckSomentePlanos;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.CheckBox ckSomenteNovos;
    }
}