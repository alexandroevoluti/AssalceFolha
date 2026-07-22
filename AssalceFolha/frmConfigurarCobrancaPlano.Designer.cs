namespace AssalceFolha
{
    partial class frmConfigurarCobrancaPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarCobrancaPlano));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.btnExcluriItem = new System.Windows.Forms.Button();
            this.btnSalvarItem = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtFolha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTipoCobranca = new System.Windows.Forms.ComboBox();
            this.lbQtde = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCobranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 52;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMatricula,
            this.colFolha,
            this.colNome,
            this.colTipoCobranca});
            this.dgDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDados.Location = new System.Drawing.Point(0, 191);
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDados.Size = new System.Drawing.Size(800, 309);
            this.dgDados.TabIndex = 53;
            this.dgDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDados_CellDoubleClick);
            // 
            // btnExcluriItem
            // 
            this.btnExcluriItem.Location = new System.Drawing.Point(673, 89);
            this.btnExcluriItem.Name = "btnExcluriItem";
            this.btnExcluriItem.Size = new System.Drawing.Size(54, 23);
            this.btnExcluriItem.TabIndex = 73;
            this.btnExcluriItem.Text = "Excluir";
            this.btnExcluriItem.UseVisualStyleBackColor = true;
            this.btnExcluriItem.Click += new System.EventHandler(this.btnExcluriItem_Click);
            // 
            // btnSalvarItem
            // 
            this.btnSalvarItem.Location = new System.Drawing.Point(613, 89);
            this.btnSalvarItem.Name = "btnSalvarItem";
            this.btnSalvarItem.Size = new System.Drawing.Size(54, 23);
            this.btnSalvarItem.TabIndex = 72;
            this.btnSalvarItem.Text = "Salvar";
            this.btnSalvarItem.UseVisualStyleBackColor = true;
            this.btnSalvarItem.Click += new System.EventHandler(this.btnSalvarItem_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigo.Location = new System.Drawing.Point(9, 50);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 70;
            this.txtCodigo.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Código";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(12, 140);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(430, 20);
            this.txtFiltro.TabIndex = 65;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Filtro (Informe Matrícula ou Nome)";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.Control;
            this.txtNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(107, 89);
            this.txtNome.MaxLength = 6;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(335, 23);
            this.txtNome.TabIndex = 80;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(104, 73);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(41, 16);
            this.lblNome.TabIndex = 79;
            this.lblNome.Text = "Nome";
            // 
            // txtFolha
            // 
            this.txtFolha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFolha.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolha.Location = new System.Drawing.Point(74, 91);
            this.txtFolha.MaxLength = 2;
            this.txtFolha.Name = "txtFolha";
            this.txtFolha.ReadOnly = true;
            this.txtFolha.Size = new System.Drawing.Size(27, 23);
            this.txtFolha.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "Fl";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(9, 91);
            this.txtMatricula.MaxLength = 6;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(59, 23);
            this.txtMatricula.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "Matrícula";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(453, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Tipo Cobrança";
            // 
            // cboTipoCobranca
            // 
            this.cboTipoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranca.FormattingEnabled = true;
            this.cboTipoCobranca.Location = new System.Drawing.Point(456, 91);
            this.cboTipoCobranca.Name = "cboTipoCobranca";
            this.cboTipoCobranca.Size = new System.Drawing.Size(151, 21);
            this.cboTipoCobranca.TabIndex = 81;
            // 
            // lbQtde
            // 
            this.lbQtde.AutoSize = true;
            this.lbQtde.ForeColor = System.Drawing.Color.Blue;
            this.lbQtde.Location = new System.Drawing.Point(12, 163);
            this.lbQtde.Name = "lbQtde";
            this.lbQtde.Size = new System.Drawing.Size(38, 13);
            this.lbQtde.TabIndex = 83;
            this.lbQtde.Text = "lbQtde";
            this.lbQtde.Visible = false;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colMatricula
            // 
            this.colMatricula.HeaderText = "Matrícula";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.ReadOnly = true;
            // 
            // colFolha
            // 
            this.colFolha.HeaderText = "Folha";
            this.colFolha.Name = "colFolha";
            this.colFolha.ReadOnly = true;
            // 
            // colNome
            // 
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 300;
            // 
            // colTipoCobranca
            // 
            this.colTipoCobranca.HeaderText = "Tipo Cobrança";
            this.colTipoCobranca.Name = "colTipoCobranca";
            this.colTipoCobranca.ReadOnly = true;
            // 
            // frmConfigurarCobrancaPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lbQtde);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboTipoCobranca);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtFolha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExcluriItem);
            this.Controls.Add(this.btnSalvarItem);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDados);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConfigurarCobrancaPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurarCobrancaPlano";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Button btnExcluriItem;
        private System.Windows.Forms.Button btnSalvarItem;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtFolha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTipoCobranca;
        private System.Windows.Forms.Label lbQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCobranca;
    }
}