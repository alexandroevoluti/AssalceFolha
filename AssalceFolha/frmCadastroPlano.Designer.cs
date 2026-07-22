namespace AssalceFolha
{
    partial class frmCadastroPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroPlano));
            AssalceFolha.Entity.Convenio convenio1 = new AssalceFolha.Entity.Convenio();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboAcomodacao = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboTipoUsuario = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucConvenio1 = new AssalceFolha.Componentes.ucConvenio();
            this.label5 = new System.Windows.Forms.Label();
            this.cboParentesco = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mskDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mskDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.mskDatNascimento = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.txtStatus.Location = new System.Drawing.Point(98, 269);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(290, 20);
            this.txtStatus.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(318, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Acomodação";
            // 
            // cboAcomodacao
            // 
            this.cboAcomodacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAcomodacao.FormattingEnabled = true;
            this.cboAcomodacao.Location = new System.Drawing.Point(394, 135);
            this.cboAcomodacao.Name = "cboAcomodacao";
            this.cboAcomodacao.Size = new System.Drawing.Size(185, 21);
            this.cboAcomodacao.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Tipo Usuário";
            // 
            // cboTipoUsuario
            // 
            this.cboTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoUsuario.FormattingEnabled = true;
            this.cboTipoUsuario.Location = new System.Drawing.Point(99, 135);
            this.cboTipoUsuario.Name = "cboTipoUsuario";
            this.cboTipoUsuario.Size = new System.Drawing.Size(166, 21);
            this.cboTipoUsuario.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(99, 105);
            this.txtUsuario.MaxLength = 100;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(480, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Usuário";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(99, 166);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 4;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigo.Location = new System.Drawing.Point(99, 39);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 36;
            this.txtCodigo.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Código";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvar,
            this.toolStripSeparator1,
            this.btnExcluir,
            this.btnSeparador,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 34;
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
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(65, 22);
            this.btnExcluir.Text = "&Excluir";
            // 
            // btnSeparador
            // 
            this.btnSeparador.Name = "btnSeparador";
            this.btnSeparador.Size = new System.Drawing.Size(6, 25);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Início";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Término";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Convênio";
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
            this.ucConvenio1.Location = new System.Drawing.Point(99, 69);
            this.ucConvenio1.Name = "ucConvenio1";
            this.ucConvenio1.Size = new System.Drawing.Size(490, 26);
            this.ucConvenio1.TabIndex = 0;
            this.ucConvenio1.TipoConvenio = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Parentesco";
            // 
            // cboParentesco
            // 
            this.cboParentesco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentesco.FormattingEnabled = true;
            this.cboParentesco.Location = new System.Drawing.Point(394, 166);
            this.cboParentesco.Name = "cboParentesco";
            this.cboParentesco.Size = new System.Drawing.Size(185, 21);
            this.cboParentesco.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Dt Nascimento";
            // 
            // mskDataFim
            // 
            this.mskDataFim.Location = new System.Drawing.Point(279, 231);
            this.mskDataFim.Mask = "##/##/####";
            this.mskDataFim.Name = "mskDataFim";
            this.mskDataFim.Size = new System.Drawing.Size(100, 20);
            this.mskDataFim.TabIndex = 8;
            // 
            // mskDataInicio
            // 
            this.mskDataInicio.Location = new System.Drawing.Point(98, 231);
            this.mskDataInicio.Mask = "##/##/####";
            this.mskDataInicio.Name = "mskDataInicio";
            this.mskDataInicio.Size = new System.Drawing.Size(100, 20);
            this.mskDataInicio.TabIndex = 7;
            // 
            // mskDatNascimento
            // 
            this.mskDatNascimento.Location = new System.Drawing.Point(99, 198);
            this.mskDatNascimento.Mask = "##/##/####";
            this.mskDatNascimento.Name = "mskDatNascimento";
            this.mskDatNascimento.Size = new System.Drawing.Size(100, 20);
            this.mskDatNascimento.TabIndex = 49;
            // 
            // frmCadastroPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 305);
            this.Controls.Add(this.mskDatNascimento);
            this.Controls.Add(this.mskDataInicio);
            this.Controls.Add(this.mskDataFim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboParentesco);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboAcomodacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboTipoUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucConvenio1);
            this.Name = "frmCadastroPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Plano";
            this.Load += new System.EventHandler(this.frmCadastroPlano_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator btnSeparador;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.ucConvenio ucConvenio1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipoUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboAcomodacao;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboParentesco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskDataFim;
        private System.Windows.Forms.MaskedTextBox mskDataInicio;
        private System.Windows.Forms.MaskedTextBox mskDatNascimento;
    }
}