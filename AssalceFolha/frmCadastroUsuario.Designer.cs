namespace AssalceFolha
{
    partial class frmCadastroUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroUsuario));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btFiltrar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lstUsuarios = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboNivelSeguranca = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataCadastro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtResenha = new System.Windows.Forms.TextBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btFiltrar);
            this.panel2.Controls.Add(this.txtFiltro);
            this.panel2.Controls.Add(this.lstUsuarios);
            this.panel2.Location = new System.Drawing.Point(12, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 213);
            this.panel2.TabIndex = 25;
            // 
            // btFiltrar
            // 
            this.btFiltrar.Location = new System.Drawing.Point(205, 2);
            this.btFiltrar.Name = "btFiltrar";
            this.btFiltrar.Size = new System.Drawing.Size(31, 21);
            this.btFiltrar.TabIndex = 14;
            this.btFiltrar.Text = "...";
            this.btFiltrar.UseVisualStyleBackColor = true;
            this.btFiltrar.Click += new System.EventHandler(this.btFiltrar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(3, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(196, 20);
            this.txtFiltro.TabIndex = 13;
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.FormattingEnabled = true;
            this.lstUsuarios.Location = new System.Drawing.Point(3, 25);
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(233, 173);
            this.lstUsuarios.TabIndex = 15;
            this.lstUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstUsuarios_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckAtivo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtResenha);
            this.panel1.Controls.Add(this.cboNivelSeguranca);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDataCadastro);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Location = new System.Drawing.Point(265, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 213);
            this.panel1.TabIndex = 24;
            // 
            // cboNivelSeguranca
            // 
            this.cboNivelSeguranca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNivelSeguranca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboNivelSeguranca.FormattingEnabled = true;
            this.cboNivelSeguranca.Location = new System.Drawing.Point(102, 75);
            this.cboNivelSeguranca.Name = "cboNivelSeguranca";
            this.cboNivelSeguranca.Size = new System.Drawing.Size(271, 21);
            this.cboNivelSeguranca.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Nivel Segurança";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Data Cadastro";
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDataCadastro.Location = new System.Drawing.Point(101, 169);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(118, 20);
            this.txtDataCadastro.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(101, 138);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(118, 20);
            this.txtSenha.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(101, 107);
            this.txtLogin.MaxLength = 10;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(165, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Código";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(101, 44);
            this.txtNome.MaxLength = 255;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCodigo.Location = new System.Drawing.Point(101, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 37;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.btnSalvar,
            this.toolStripSeparator1,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(65, 22);
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btSalvar_Click);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Resenha";
            // 
            // txtResenha
            // 
            this.txtResenha.Location = new System.Drawing.Point(311, 139);
            this.txtResenha.MaxLength = 10;
            this.txtResenha.Name = "txtResenha";
            this.txtResenha.PasswordChar = '*';
            this.txtResenha.Size = new System.Drawing.Size(118, 20);
            this.txtResenha.TabIndex = 48;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAtivo.Location = new System.Drawing.Point(225, 15);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(50, 17);
            this.ckAtivo.TabIndex = 50;
            this.ckAtivo.Text = "Ativo";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(56, 22);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btLimparTela_Click);
            // 
            // frmCadastroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 265);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCadastroUsuario";
            this.Text = "Cadastro de Usuários do Sistema";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btFiltrar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ListBox lstUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboNivelSeguranca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataCadastro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtResenha;
        private System.Windows.Forms.CheckBox ckAtivo;
        private System.Windows.Forms.ToolStripButton btnNovo;
    }
}