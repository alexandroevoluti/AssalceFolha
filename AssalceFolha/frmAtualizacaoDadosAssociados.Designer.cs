namespace AssalceFolha
{
    partial class frmAtualizacaoDadosAssociados
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.dgSituacao = new System.Windows.Forms.DataGridView();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAtualizarTodosDados = new System.Windows.Forms.Button();
            this.txtFolhaAL = new System.Windows.Forms.TextBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picFotoAL = new System.Windows.Forms.PictureBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.ucAssociado1 = new AssalceFolha.ucAssociado();
            this.lbCont = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSituacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1237, 581);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.lbTotal);
            this.tabPage1.Controls.Add(this.dgSituacao);
            this.tabPage1.Controls.Add(this.dgDados);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1229, 555);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(818, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 160);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 20);
            this.textBox1.TabIndex = 23;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTotal.Location = new System.Drawing.Point(735, 384);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(51, 20);
            this.lbTotal.TabIndex = 22;
            this.lbTotal.Text = "label1";
            // 
            // dgSituacao
            // 
            this.dgSituacao.AllowUserToAddRows = false;
            this.dgSituacao.AllowUserToDeleteRows = false;
            this.dgSituacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSituacao.Location = new System.Drawing.Point(10, 384);
            this.dgSituacao.Name = "dgSituacao";
            this.dgSituacao.ReadOnly = true;
            this.dgSituacao.Size = new System.Drawing.Size(709, 163);
            this.dgSituacao.TabIndex = 21;
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Location = new System.Drawing.Point(8, 34);
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDados.Size = new System.Drawing.Size(1209, 344);
            this.dgDados.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbCont);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btnAtualizarTodosDados);
            this.tabPage2.Controls.Add(this.txtFolhaAL);
            this.tabPage2.Controls.Add(this.btnAtualizar);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.picFotoAL);
            this.tabPage2.Controls.Add(this.picFoto);
            this.tabPage2.Controls.Add(this.ucAssociado1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1229, 555);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(966, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 66);
            this.button2.TabIndex = 85;
            this.button2.Text = "Atualizar Todos Foto de Associados que Não tenham foto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnAtualizarTodosDados
            // 
            this.btnAtualizarTodosDados.Location = new System.Drawing.Point(442, 74);
            this.btnAtualizarTodosDados.Name = "btnAtualizarTodosDados";
            this.btnAtualizarTodosDados.Size = new System.Drawing.Size(166, 37);
            this.btnAtualizarTodosDados.TabIndex = 84;
            this.btnAtualizarTodosDados.Text = "Atualizar Todos os Dados";
            this.btnAtualizarTodosDados.UseVisualStyleBackColor = true;
            this.btnAtualizarTodosDados.Click += new System.EventHandler(this.btnAtualizarTodosDados_Click);
            // 
            // txtFolhaAL
            // 
            this.txtFolhaAL.Location = new System.Drawing.Point(58, 249);
            this.txtFolhaAL.Name = "txtFolhaAL";
            this.txtFolhaAL.Size = new System.Drawing.Size(100, 20);
            this.txtFolhaAL.TabIndex = 83;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(179, 74);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(104, 23);
            this.btnAtualizar.TabIndex = 82;
            this.btnAtualizar.Text = "Atualizar Foto -->";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Foto Assembleia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Foto Atual";
            // 
            // picFotoAL
            // 
            this.picFotoAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFotoAL.Location = new System.Drawing.Point(58, 74);
            this.picFotoAL.Name = "picFotoAL";
            this.picFotoAL.Size = new System.Drawing.Size(120, 169);
            this.picFotoAL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoAL.TabIndex = 79;
            this.picFotoAL.TabStop = false;
            // 
            // picFoto
            // 
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(289, 74);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(120, 169);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 78;
            this.picFoto.TabStop = false;
            // 
            // ucAssociado1
            // 
            this.ucAssociado1.Associado = null;
            this.ucAssociado1.Location = new System.Drawing.Point(8, 6);
            this.ucAssociado1.Name = "ucAssociado1";
            this.ucAssociado1.Size = new System.Drawing.Size(532, 32);
            this.ucAssociado1.TabIndex = 5;
            this.ucAssociado1.Leave += new System.EventHandler(this.ucAssociado1_txtMatriculaLeave);
            // 
            // lbCont
            // 
            this.lbCont.AutoSize = true;
            this.lbCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbCont.Location = new System.Drawing.Point(966, 98);
            this.lbCont.Name = "lbCont";
            this.lbCont.Size = new System.Drawing.Size(95, 24);
            this.lbCont.TabIndex = 86;
            this.lbCont.Text = "Contador";
            // 
            // frmAtualizacaoDadosAssociados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 581);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAtualizacaoDadosAssociados";
            this.Text = "frmAtualizacaoDadosAssociados";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSituacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.DataGridView dgSituacao;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.TabPage tabPage2;
        private ucAssociado ucAssociado1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picFotoAL;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.TextBox txtFolhaAL;
        private System.Windows.Forms.Button btnAtualizarTodosDados;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbCont;
    }
}