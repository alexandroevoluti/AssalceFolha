namespace AssalceFolha
{
    partial class frmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta));
            this.label10 = new System.Windows.Forms.Label();
            this.cboConsulta = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.pnlCompetencia = new System.Windows.Forms.Panel();
            this.dtpCompetencia = new System.Windows.Forms.DateTimePicker();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.lbQtde = new System.Windows.Forms.Label();
            this.pnlAno = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mskAno = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1.SuspendLayout();
            this.pnlCompetencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.pnlAno.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Consulta";
            // 
            // cboConsulta
            // 
            this.cboConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsulta.FormattingEnabled = true;
            this.cboConsulta.Location = new System.Drawing.Point(19, 57);
            this.cboConsulta.Name = "cboConsulta";
            this.cboConsulta.Size = new System.Drawing.Size(337, 21);
            this.cboConsulta.TabIndex = 41;
            this.cboConsulta.SelectedIndexChanged += new System.EventHandler(this.cboConsulta_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvar,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 25);
            this.toolStrip1.TabIndex = 42;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 22);
            this.btnSalvar.Text = "&Executar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "&Excel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // pnlCompetencia
            // 
            this.pnlCompetencia.Controls.Add(this.dtpCompetencia);
            this.pnlCompetencia.Controls.Add(this.lbCompetencia);
            this.pnlCompetencia.Location = new System.Drawing.Point(19, 84);
            this.pnlCompetencia.Name = "pnlCompetencia";
            this.pnlCompetencia.Size = new System.Drawing.Size(111, 46);
            this.pnlCompetencia.TabIndex = 46;
            this.pnlCompetencia.Visible = false;
            // 
            // dtpCompetencia
            // 
            this.dtpCompetencia.CustomFormat = "MM/yyyy";
            this.dtpCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetencia.Location = new System.Drawing.Point(3, 20);
            this.dtpCompetencia.Name = "dtpCompetencia";
            this.dtpCompetencia.ShowUpDown = true;
            this.dtpCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetencia.TabIndex = 47;
            // 
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(0, 4);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(69, 13);
            this.lbCompetencia.TabIndex = 46;
            this.lbCompetencia.Text = "Competência";
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDados.Location = new System.Drawing.Point(0, 158);
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.Size = new System.Drawing.Size(916, 309);
            this.dgDados.TabIndex = 47;
            // 
            // lbQtde
            // 
            this.lbQtde.AutoSize = true;
            this.lbQtde.ForeColor = System.Drawing.Color.Blue;
            this.lbQtde.Location = new System.Drawing.Point(16, 142);
            this.lbQtde.Name = "lbQtde";
            this.lbQtde.Size = new System.Drawing.Size(38, 13);
            this.lbQtde.TabIndex = 48;
            this.lbQtde.Text = "lbQtde";
            this.lbQtde.Visible = false;
            // 
            // pnlAno
            // 
            this.pnlAno.Controls.Add(this.mskAno);
            this.pnlAno.Controls.Add(this.label1);
            this.pnlAno.Location = new System.Drawing.Point(136, 84);
            this.pnlAno.Name = "pnlAno";
            this.pnlAno.Size = new System.Drawing.Size(71, 46);
            this.pnlAno.TabIndex = 49;
            this.pnlAno.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Ano";
            // 
            // mskAno
            // 
            this.mskAno.Location = new System.Drawing.Point(3, 20);
            this.mskAno.Mask = "0000";
            this.mskAno.Name = "mskAno";
            this.mskAno.Size = new System.Drawing.Size(46, 20);
            this.mskAno.TabIndex = 51;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 467);
            this.Controls.Add(this.pnlAno);
            this.Controls.Add(this.lbQtde);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.pnlCompetencia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboConsulta);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsulta";
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlCompetencia.ResumeLayout(false);
            this.pnlCompetencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.pnlAno.ResumeLayout(false);
            this.pnlAno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboConsulta;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Panel pnlCompetencia;
        private System.Windows.Forms.DateTimePicker dtpCompetencia;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lbQtde;
        private System.Windows.Forms.Panel pnlAno;
        private System.Windows.Forms.MaskedTextBox mskAno;
        private System.Windows.Forms.Label label1;
    }
}