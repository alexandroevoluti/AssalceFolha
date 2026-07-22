namespace AssalceFolha
{
    partial class frmRelatorioAssociadoPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioAssociadoPeriodo));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            this.dtpCompetenciaFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCompetenciaInicial = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.ucAssociado1 = new AssalceFolha.ucAssociado();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(916, 366);
            this.reportViewer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.dtpCompetenciaFinal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpCompetenciaInicial);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.ucAssociado1);
            this.panel1.Controls.Add(this.btnVisualizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 101);
            this.panel1.TabIndex = 5;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(24, 35);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(51, 16);
            this.lblNome.TabIndex = 86;
            this.lblNome.Text = "Período";
            // 
            // dtpCompetenciaFinal
            // 
            this.dtpCompetenciaFinal.CustomFormat = "MM/yyyy";
            this.dtpCompetenciaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetenciaFinal.Location = new System.Drawing.Point(199, 35);
            this.dtpCompetenciaFinal.Name = "dtpCompetenciaFinal";
            this.dtpCompetenciaFinal.ShowUpDown = true;
            this.dtpCompetenciaFinal.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetenciaFinal.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "a";
            // 
            // dtpCompetenciaInicial
            // 
            this.dtpCompetenciaInicial.CustomFormat = "MM/yyyy";
            this.dtpCompetenciaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetenciaInicial.Location = new System.Drawing.Point(81, 35);
            this.dtpCompetenciaInicial.Name = "dtpCompetenciaInicial";
            this.dtpCompetenciaInicial.ShowUpDown = true;
            this.dtpCompetenciaInicial.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetenciaInicial.TabIndex = 83;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 25);
            this.toolStrip1.TabIndex = 81;
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
            // ucAssociado1
            // 
            this.ucAssociado1.Associado = null;
            this.ucAssociado1.Location = new System.Drawing.Point(33, 60);
            this.ucAssociado1.Name = "ucAssociado1";
            this.ucAssociado1.Size = new System.Drawing.Size(532, 32);
            this.ucAssociado1.TabIndex = 3;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(584, 60);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 2;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // frmRelatorioAssociadoPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 467);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmRelatorioAssociadoPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRelatorioAssociadoPeriodo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private ucAssociado ucAssociado1;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DateTimePicker dtpCompetenciaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCompetenciaInicial;
        private System.Windows.Forms.Label lblNome;
    }
}