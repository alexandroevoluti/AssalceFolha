namespace AssalceFolha
{
    partial class frmRelatorioConvenioCompetecia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioConvenioCompetecia));
            AssalceFolha.Entity.Convenio convenio1 = new AssalceFolha.Entity.Convenio();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dtCompetencia = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ucConvenio1 = new AssalceFolha.Componentes.ucConvenio();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ucConvenio1);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dtCompetencia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 66);
            this.panel1.TabIndex = 88;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1013, 25);
            this.toolStrip2.TabIndex = 81;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "&Sair";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(751, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Visualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtCompetencia
            // 
            this.dtCompetencia.CustomFormat = "MM/yyyy";
            this.dtCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCompetencia.Location = new System.Drawing.Point(646, 29);
            this.dtCompetencia.Name = "dtCompetencia";
            this.dtCompetencia.ShowUpDown = true;
            this.dtCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtCompetencia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Competência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Convênio";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1013, 408);
            this.reportViewer1.TabIndex = 89;
            // 
            // ucConvenio1
            // 
            convenio1.Ativo = null;
            convenio1.DiaVencimento = null;
            convenio1.Evento = null;
            convenio1.ID = null;
            convenio1.Nome = null;
            convenio1.NomeConvenio = null;
            convenio1.Parcelado = null;
            convenio1.ParcelamentoMaximo = null;
            convenio1.UsuarioCarga = null;
            this.ucConvenio1.Convenio = convenio1;
            this.ucConvenio1.Location = new System.Drawing.Point(70, 30);
            this.ucConvenio1.Name = "ucConvenio1";
            this.ucConvenio1.Size = new System.Drawing.Size(490, 26);
            this.ucConvenio1.TabIndex = 0;
            this.ucConvenio1.TipoConvenio = null;
            // 
            // frmRelatorioConvenioCompetecia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 474);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRelatorioConvenioCompetecia";
            this.Text = "frmRelatorioConvenioCompetecia";
            this.Load += new System.EventHandler(this.frmRelatorioConvenioCompetecia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Componentes.ucConvenio ucConvenio1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtCompetencia;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}