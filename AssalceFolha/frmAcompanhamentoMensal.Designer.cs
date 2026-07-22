namespace AssalceFolha
{
    partial class frmAcompanhamentoMensal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcompanhamentoMensal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpCompetencia = new System.Windows.Forms.DateTimePicker();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.dtpCompetencia);
            this.panel1.Controls.Add(this.lbCompetencia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 64);
            this.panel1.TabIndex = 85;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(540, 25);
            this.toolStrip2.TabIndex = 83;
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
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(223, 30);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpCompetencia
            // 
            this.dtpCompetencia.CustomFormat = "MM/yyyy";
            this.dtpCompetencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompetencia.Location = new System.Drawing.Point(109, 31);
            this.dtpCompetencia.Name = "dtpCompetencia";
            this.dtpCompetencia.ShowUpDown = true;
            this.dtpCompetencia.Size = new System.Drawing.Size(93, 20);
            this.dtpCompetencia.TabIndex = 6;
            this.dtpCompetencia.ValueChanged += new System.EventHandler(this.dtpCompetencia_ValueChanged);
            // 
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(34, 35);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(69, 13);
            this.lbCompetencia.TabIndex = 5;
            this.lbCompetencia.Text = "Competência";
            // 
            // dgDados
            // 
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescricao,
            this.colUsuario,
            this.colQtde});
            this.dgDados.Location = new System.Drawing.Point(12, 71);
            this.dgDados.Name = "dgDados";
            this.dgDados.Size = new System.Drawing.Size(502, 308);
            this.dgDados.TabIndex = 86;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "Descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Width = 200;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuário";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Width = 150;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "QTDE";
            this.colQtde.HeaderText = "QTDE";
            this.colQtde.Name = "colQtde";
            this.colQtde.Width = 80;
            // 
            // frmAcompanhamentoMensal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 391);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.panel1);
            this.Name = "frmAcompanhamentoMensal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAcompanhamentoMensal";
            this.Load += new System.EventHandler(this.frmAcompanhamentoMensal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DateTimePicker dtpCompetencia;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}