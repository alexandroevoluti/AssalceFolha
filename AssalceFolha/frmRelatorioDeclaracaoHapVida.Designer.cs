namespace AssalceFolha
{
    partial class frmRelatorioDeclaracaoHapVida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioDeclaracaoHapVida));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnAlterarCPF = new System.Windows.Forms.Button();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ucAssociado1 = new AssalceFolha.ucAssociado();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 25);
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
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(542, 20);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(26, 13);
            this.lbCompetencia.TabIndex = 0;
            this.lbCompetencia.Text = "Ano";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDados);
            this.panel1.Controls.Add(this.btnAlterarCPF);
            this.panel1.Controls.Add(this.txtAno);
            this.panel1.Controls.Add(this.ucAssociado1);
            this.panel1.Controls.Add(this.btnVisualizar);
            this.panel1.Controls.Add(this.lbCompetencia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 289);
            this.panel1.TabIndex = 83;
            // 
            // dgvDados
            // 
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 41);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(869, 245);
            this.dgvDados.TabIndex = 5;
            // 
            // btnAlterarCPF
            // 
            this.btnAlterarCPF.Location = new System.Drawing.Point(769, 12);
            this.btnAlterarCPF.Name = "btnAlterarCPF";
            this.btnAlterarCPF.Size = new System.Drawing.Size(112, 29);
            this.btnAlterarCPF.TabIndex = 6;
            this.btnAlterarCPF.Text = "Alterar CPF";
            this.btnAlterarCPF.UseVisualStyleBackColor = true;
            this.btnAlterarCPF.Click += new System.EventHandler(this.brnAlterarCPF_Click);
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(575, 15);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 4;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(688, 15);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 2;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 320);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(869, 374);
            this.reportViewer1.TabIndex = 84;
            // 
            // ucAssociado1
            // 
            this.ucAssociado1.Associado = null;
            this.ucAssociado1.Location = new System.Drawing.Point(5, 10);
            this.ucAssociado1.Name = "ucAssociado1";
            this.ucAssociado1.Size = new System.Drawing.Size(532, 32);
            this.ucAssociado1.TabIndex = 3;
            // 
            // frmRelatorioDeclaracaoHapVida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmRelatorioDeclaracaoHapVida";
            this.Text = "Declaração Hap Vida";
            this.Load += new System.EventHandler(this.frmRelatorioAssociadoCompetencia_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private ucAssociado ucAssociado1;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVisualizar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnAlterarCPF;
    }
}