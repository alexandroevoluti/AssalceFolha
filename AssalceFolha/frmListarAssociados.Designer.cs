namespace AssalceFolha
{
    partial class frmListarAssociados
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
            this.cblFolha = new System.Windows.Forms.CheckedListBox();
            this.cblSituacao = new System.Windows.Forms.CheckedListBox();
            this.cblSituacaoDRH = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGerarExcel = new System.Windows.Forms.Button();
            this.Progresso = new System.Windows.Forms.ProgressBar();
            this.ckTodasFolhas = new System.Windows.Forms.CheckBox();
            this.ckTodasSituacoes = new System.Windows.Forms.CheckBox();
            this.ckTodasSituacoesDRH = new System.Windows.Forms.CheckBox();
            this.btnGerarExcelListagem = new System.Windows.Forms.Button();
            this.ckTodosCampos = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cblCampos = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTodosSexos = new System.Windows.Forms.RadioButton();
            this.rbFeminino = new System.Windows.Forms.RadioButton();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.ckExcluidos = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cblFolha
            // 
            this.cblFolha.FormattingEnabled = true;
            this.cblFolha.Location = new System.Drawing.Point(12, 25);
            this.cblFolha.Name = "cblFolha";
            this.cblFolha.Size = new System.Drawing.Size(184, 244);
            this.cblFolha.TabIndex = 0;
            // 
            // cblSituacao
            // 
            this.cblSituacao.FormattingEnabled = true;
            this.cblSituacao.Location = new System.Drawing.Point(202, 25);
            this.cblSituacao.Name = "cblSituacao";
            this.cblSituacao.Size = new System.Drawing.Size(187, 244);
            this.cblSituacao.TabIndex = 1;
            // 
            // cblSituacaoDRH
            // 
            this.cblSituacaoDRH.FormattingEnabled = true;
            this.cblSituacaoDRH.Location = new System.Drawing.Point(395, 25);
            this.cblSituacaoDRH.Name = "cblSituacaoDRH";
            this.cblSituacaoDRH.Size = new System.Drawing.Size(227, 244);
            this.cblSituacaoDRH.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Situação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Situação DRH";
            // 
            // btnGerarExcel
            // 
            this.btnGerarExcel.Location = new System.Drawing.Point(354, 348);
            this.btnGerarExcel.Name = "btnGerarExcel";
            this.btnGerarExcel.Size = new System.Drawing.Size(224, 42);
            this.btnGerarExcel.TabIndex = 6;
            this.btnGerarExcel.Text = "Gerar Arquivo Excel Sorteio";
            this.btnGerarExcel.UseVisualStyleBackColor = true;
            this.btnGerarExcel.Click += new System.EventHandler(this.btnGerarExcel_Click);
            // 
            // Progresso
            // 
            this.Progresso.Location = new System.Drawing.Point(12, 319);
            this.Progresso.Name = "Progresso";
            this.Progresso.Size = new System.Drawing.Size(843, 23);
            this.Progresso.TabIndex = 7;
            this.Progresso.Visible = false;
            // 
            // ckTodasFolhas
            // 
            this.ckTodasFolhas.AutoSize = true;
            this.ckTodasFolhas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckTodasFolhas.Location = new System.Drawing.Point(48, 7);
            this.ckTodasFolhas.Name = "ckTodasFolhas";
            this.ckTodasFolhas.Size = new System.Drawing.Size(56, 17);
            this.ckTodasFolhas.TabIndex = 8;
            this.ckTodasFolhas.Text = "Todas";
            this.ckTodasFolhas.UseVisualStyleBackColor = true;
            this.ckTodasFolhas.CheckedChanged += new System.EventHandler(this.ckTodasFolhas_CheckedChanged);
            // 
            // ckTodasSituacoes
            // 
            this.ckTodasSituacoes.AutoSize = true;
            this.ckTodasSituacoes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckTodasSituacoes.Location = new System.Drawing.Point(254, 6);
            this.ckTodasSituacoes.Name = "ckTodasSituacoes";
            this.ckTodasSituacoes.Size = new System.Drawing.Size(56, 17);
            this.ckTodasSituacoes.TabIndex = 9;
            this.ckTodasSituacoes.Text = "Todas";
            this.ckTodasSituacoes.UseVisualStyleBackColor = true;
            this.ckTodasSituacoes.CheckedChanged += new System.EventHandler(this.ckTodasSituacoes_CheckedChanged);
            // 
            // ckTodasSituacoesDRH
            // 
            this.ckTodasSituacoesDRH.AutoSize = true;
            this.ckTodasSituacoesDRH.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckTodasSituacoesDRH.Location = new System.Drawing.Point(474, 6);
            this.ckTodasSituacoesDRH.Name = "ckTodasSituacoesDRH";
            this.ckTodasSituacoesDRH.Size = new System.Drawing.Size(56, 17);
            this.ckTodasSituacoesDRH.TabIndex = 10;
            this.ckTodasSituacoesDRH.Text = "Todas";
            this.ckTodasSituacoesDRH.UseVisualStyleBackColor = true;
            this.ckTodasSituacoesDRH.CheckedChanged += new System.EventHandler(this.ckTodasSituacoesDRH_CheckedChanged);
            // 
            // btnGerarExcelListagem
            // 
            this.btnGerarExcelListagem.Location = new System.Drawing.Point(631, 348);
            this.btnGerarExcelListagem.Name = "btnGerarExcelListagem";
            this.btnGerarExcelListagem.Size = new System.Drawing.Size(224, 42);
            this.btnGerarExcelListagem.TabIndex = 11;
            this.btnGerarExcelListagem.Text = "Gerar Arquivo Excel Listagem";
            this.btnGerarExcelListagem.UseVisualStyleBackColor = true;
            this.btnGerarExcelListagem.Click += new System.EventHandler(this.btnGerarExcelListagem_Click);
            // 
            // ckTodosCampos
            // 
            this.ckTodosCampos.AutoSize = true;
            this.ckTodosCampos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckTodosCampos.Location = new System.Drawing.Point(721, 6);
            this.ckTodosCampos.Name = "ckTodosCampos";
            this.ckTodosCampos.Size = new System.Drawing.Size(56, 17);
            this.ckTodosCampos.TabIndex = 14;
            this.ckTodosCampos.Text = "Todas";
            this.ckTodosCampos.UseVisualStyleBackColor = true;
            this.ckTodosCampos.CheckedChanged += new System.EventHandler(this.ckTodosCampos_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Campos Listagem";
            // 
            // cblCampos
            // 
            this.cblCampos.FormattingEnabled = true;
            this.cblCampos.Location = new System.Drawing.Point(628, 25);
            this.cblCampos.Name = "cblCampos";
            this.cblCampos.Size = new System.Drawing.Size(227, 244);
            this.cblCampos.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbTodosSexos);
            this.panel1.Controls.Add(this.rbFeminino);
            this.panel1.Controls.Add(this.rbMasculino);
            this.panel1.Location = new System.Drawing.Point(12, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 37);
            this.panel1.TabIndex = 16;
            // 
            // rbTodosSexos
            // 
            this.rbTodosSexos.AutoSize = true;
            this.rbTodosSexos.Checked = true;
            this.rbTodosSexos.Location = new System.Drawing.Point(163, 10);
            this.rbTodosSexos.Name = "rbTodosSexos";
            this.rbTodosSexos.Size = new System.Drawing.Size(55, 17);
            this.rbTodosSexos.TabIndex = 2;
            this.rbTodosSexos.TabStop = true;
            this.rbTodosSexos.Text = "Todos";
            this.rbTodosSexos.UseVisualStyleBackColor = true;
            // 
            // rbFeminino
            // 
            this.rbFeminino.AutoSize = true;
            this.rbFeminino.Location = new System.Drawing.Point(90, 10);
            this.rbFeminino.Name = "rbFeminino";
            this.rbFeminino.Size = new System.Drawing.Size(67, 17);
            this.rbFeminino.TabIndex = 1;
            this.rbFeminino.Text = "Feminino";
            this.rbFeminino.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Location = new System.Drawing.Point(11, 10);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbMasculino.TabIndex = 0;
            this.rbMasculino.Text = "Masculino";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // ckExcluidos
            // 
            this.ckExcluidos.AutoSize = true;
            this.ckExcluidos.Location = new System.Drawing.Point(285, 287);
            this.ckExcluidos.Name = "ckExcluidos";
            this.ckExcluidos.Size = new System.Drawing.Size(104, 17);
            this.ckExcluidos.TabIndex = 17;
            this.ckExcluidos.Text = "Incluir Excluídos";
            this.ckExcluidos.UseVisualStyleBackColor = true;
            // 
            // frmListarAssociados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 405);
            this.Controls.Add(this.ckExcluidos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckTodosCampos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cblCampos);
            this.Controls.Add(this.btnGerarExcelListagem);
            this.Controls.Add(this.ckTodasSituacoesDRH);
            this.Controls.Add(this.ckTodasSituacoes);
            this.Controls.Add(this.ckTodasFolhas);
            this.Controls.Add(this.Progresso);
            this.Controls.Add(this.btnGerarExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblSituacaoDRH);
            this.Controls.Add(this.cblSituacao);
            this.Controls.Add(this.cblFolha);
            this.Name = "frmListarAssociados";
            this.Text = "Listar Associados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cblFolha;
        private System.Windows.Forms.CheckedListBox cblSituacao;
        private System.Windows.Forms.CheckedListBox cblSituacaoDRH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGerarExcel;
        private System.Windows.Forms.ProgressBar Progresso;
        private System.Windows.Forms.CheckBox ckTodasFolhas;
        private System.Windows.Forms.CheckBox ckTodasSituacoes;
        private System.Windows.Forms.CheckBox ckTodasSituacoesDRH;
        private System.Windows.Forms.Button btnGerarExcelListagem;
        private System.Windows.Forms.CheckBox ckTodosCampos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox cblCampos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTodosSexos;
        private System.Windows.Forms.RadioButton rbFeminino;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.CheckBox ckExcluidos;
    }
}