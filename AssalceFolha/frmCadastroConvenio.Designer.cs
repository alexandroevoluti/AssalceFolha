namespace AssalceFolha
{
    partial class frmCadastroConvenio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroConvenio));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lstConveniados = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVerba = new System.Windows.Forms.TextBox();
            this.txtDiaVencto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ckParcelado = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaximoParcelas = new System.Windows.Forms.TextBox();
            this.txtDescEventoDRH = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodEvento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTaxa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.ckAtivo = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(788, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(56, 22);
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtFiltro);
            this.panel2.Controls.Add(this.lstConveniados);
            this.panel2.Location = new System.Drawing.Point(-1, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 341);
            this.panel2.TabIndex = 28;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(3, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(233, 20);
            this.txtFiltro.TabIndex = 13;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lstConveniados
            // 
            this.lstConveniados.FormattingEnabled = true;
            this.lstConveniados.Location = new System.Drawing.Point(3, 25);
            this.lstConveniados.Name = "lstConveniados";
            this.lstConveniados.Size = new System.Drawing.Size(233, 264);
            this.lstConveniados.TabIndex = 15;
            this.lstConveniados.SelectedIndexChanged += new System.EventHandler(this.lstConveniados_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtVerba);
            this.panel1.Controls.Add(this.txtDiaVencto);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ckParcelado);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtMaximoParcelas);
            this.panel1.Controls.Add(this.txtDescEventoDRH);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCodEvento);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtCNPJ);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTaxa);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtContato);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTelefone);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCEP);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.ckAtivo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtEstado);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCidade);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBairro);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Location = new System.Drawing.Point(252, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 341);
            this.panel1.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(68, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 75;
            this.label16.Text = "Verba";
            // 
            // txtVerba
            // 
            this.txtVerba.Location = new System.Drawing.Point(105, 199);
            this.txtVerba.MaxLength = 10;
            this.txtVerba.Name = "txtVerba";
            this.txtVerba.Size = new System.Drawing.Size(72, 20);
            this.txtVerba.TabIndex = 48;
            this.txtVerba.Text = "664";
            // 
            // txtDiaVencto
            // 
            this.txtDiaVencto.Location = new System.Drawing.Point(270, 260);
            this.txtDiaVencto.MaxLength = 10;
            this.txtDiaVencto.Name = "txtDiaVencto";
            this.txtDiaVencto.Size = new System.Drawing.Size(72, 20);
            this.txtDiaVencto.TabIndex = 53;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 297);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 71;
            this.label15.Text = "Consignação DRH";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(199, 264);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 70;
            this.label14.Text = "Dia Vencto";
            // 
            // ckParcelado
            // 
            this.ckParcelado.AutoSize = true;
            this.ckParcelado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckParcelado.Location = new System.Drawing.Point(187, 231);
            this.ckParcelado.Name = "ckParcelado";
            this.ckParcelado.Size = new System.Drawing.Size(74, 17);
            this.ckParcelado.TabIndex = 50;
            this.ckParcelado.Text = "Parcelado";
            this.ckParcelado.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(281, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Máximo Parcelas";
            // 
            // txtMaximoParcelas
            // 
            this.txtMaximoParcelas.Location = new System.Drawing.Point(372, 229);
            this.txtMaximoParcelas.MaxLength = 10;
            this.txtMaximoParcelas.Name = "txtMaximoParcelas";
            this.txtMaximoParcelas.Size = new System.Drawing.Size(61, 20);
            this.txtMaximoParcelas.TabIndex = 51;
            // 
            // txtDescEventoDRH
            // 
            this.txtDescEventoDRH.Location = new System.Drawing.Point(105, 291);
            this.txtDescEventoDRH.MaxLength = 40;
            this.txtDescEventoDRH.Name = "txtDescEventoDRH";
            this.txtDescEventoDRH.Size = new System.Drawing.Size(328, 20);
            this.txtDescEventoDRH.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Evento";
            // 
            // txtCodEvento
            // 
            this.txtCodEvento.Location = new System.Drawing.Point(105, 260);
            this.txtCodEvento.MaxLength = 10;
            this.txtCodEvento.Name = "txtCodEvento";
            this.txtCodEvento.Size = new System.Drawing.Size(72, 20);
            this.txtCodEvento.TabIndex = 52;
            this.txtCodEvento.Text = "664";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "CNPJ";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(303, 14);
            this.txtCNPJ.MaxLength = 20;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(130, 20);
            this.txtCNPJ.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Taxa";
            // 
            // txtTaxa
            // 
            this.txtTaxa.Location = new System.Drawing.Point(105, 229);
            this.txtTaxa.MaxLength = 10;
            this.txtTaxa.Name = "txtTaxa";
            this.txtTaxa.Size = new System.Drawing.Size(72, 20);
            this.txtTaxa.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Contato";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(278, 169);
            this.txtContato.MaxLength = 15;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(155, 20);
            this.txtContato.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Telefone";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(105, 169);
            this.txtTelefone.MaxLength = 13;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(118, 20);
            this.txtTelefone.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "CEP";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(315, 107);
            this.txtCEP.MaxLength = 10;
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(118, 20);
            this.txtCEP.TabIndex = 43;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(105, 76);
            this.txtEndereco.MaxLength = 30;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(328, 20);
            this.txtEndereco.TabIndex = 41;
            // 
            // ckAtivo
            // 
            this.ckAtivo.AutoSize = true;
            this.ckAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAtivo.Location = new System.Drawing.Point(211, 16);
            this.ckAtivo.Name = "ckAtivo";
            this.ckAtivo.Size = new System.Drawing.Size(50, 17);
            this.ckAtivo.TabIndex = 38;
            this.ckAtivo.Text = "Ativo";
            this.ckAtivo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(315, 138);
            this.txtEstado.MaxLength = 2;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(118, 20);
            this.txtEstado.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Endereço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(105, 138);
            this.txtCidade.MaxLength = 15;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(165, 20);
            this.txtCidade.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(105, 107);
            this.txtBairro.MaxLength = 15;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(165, 20);
            this.txtBairro.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Código";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(105, 45);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 20);
            this.txtNome.TabIndex = 40;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCodigo.Location = new System.Drawing.Point(105, 14);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 37;
            // 
            // frmCadastroConvenio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 381);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCadastroConvenio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Convênio";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ListBox lstConveniados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckAtivo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.CheckBox ckParcelado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaximoParcelas;
        private System.Windows.Forms.TextBox txtDescEventoDRH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodEvento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTaxa;
        private System.Windows.Forms.TextBox txtDiaVencto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtVerba;
    }
}