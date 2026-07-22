namespace AssalceFolha
{
    partial class frmAlterarCPFHapVida
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.lbCompetencia = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.brnPesquisar = new System.Windows.Forms.Button();
            this.brnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(50, 7);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(222, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(338, 7);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 6;
            // 
            // lbCompetencia
            // 
            this.lbCompetencia.AutoSize = true;
            this.lbCompetencia.Location = new System.Drawing.Point(305, 12);
            this.lbCompetencia.Name = "lbCompetencia";
            this.lbCompetencia.Size = new System.Drawing.Size(26, 13);
            this.lbCompetencia.TabIndex = 5;
            this.lbCompetencia.Text = "Ano";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(711, 167);
            this.dataGridView1.TabIndex = 7;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(45, 212);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(149, 20);
            this.txtCPF.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "CPF";
            // 
            // brnPesquisar
            // 
            this.brnPesquisar.Location = new System.Drawing.Point(454, 5);
            this.brnPesquisar.Name = "brnPesquisar";
            this.brnPesquisar.Size = new System.Drawing.Size(111, 23);
            this.brnPesquisar.TabIndex = 10;
            this.brnPesquisar.Text = "Pesquisar";
            this.brnPesquisar.UseVisualStyleBackColor = true;
            this.brnPesquisar.Click += new System.EventHandler(this.brnPesquisar_Click);
            // 
            // brnAtualizar
            // 
            this.brnAtualizar.Location = new System.Drawing.Point(200, 209);
            this.brnAtualizar.Name = "brnAtualizar";
            this.brnAtualizar.Size = new System.Drawing.Size(111, 23);
            this.brnAtualizar.TabIndex = 11;
            this.brnAtualizar.Text = "Atualizar";
            this.brnAtualizar.UseVisualStyleBackColor = true;
            this.brnAtualizar.Click += new System.EventHandler(this.brnAtualizar_Click);
            // 
            // frmAlterarCPFHapVida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 260);
            this.Controls.Add(this.brnAtualizar);
            this.Controls.Add(this.brnPesquisar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lbCompetencia);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Name = "frmAlterarCPFHapVida";
            this.Text = "Alterar CPF HapVida";
            this.Load += new System.EventHandler(this.frmAlterarCPFHapVida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label lbCompetencia;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button brnPesquisar;
        private System.Windows.Forms.Button brnAtualizar;
    }
}