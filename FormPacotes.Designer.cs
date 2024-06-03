namespace SystemTravelAgency
{
    partial class FormPacotes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btnatualizarpacote = new System.Windows.Forms.Button();
            this.BtnEcluirPacote = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewpacotes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewpacotes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerenciar Pacotes de Viagens";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.Btnatualizarpacote);
            this.panel1.Controls.Add(this.BtnEcluirPacote);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 143);
            this.panel1.TabIndex = 1;
            // 
            // Btnatualizarpacote
            // 
            this.Btnatualizarpacote.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnatualizarpacote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Btnatualizarpacote.Location = new System.Drawing.Point(674, 83);
            this.Btnatualizarpacote.Name = "Btnatualizarpacote";
            this.Btnatualizarpacote.Size = new System.Drawing.Size(261, 47);
            this.Btnatualizarpacote.TabIndex = 3;
            this.Btnatualizarpacote.Text = "Atualizar Lista de Pacotes";
            this.Btnatualizarpacote.UseVisualStyleBackColor = true;
            this.Btnatualizarpacote.Click += new System.EventHandler(this.Btnatualizarpacote_Click);
            // 
            // BtnEcluirPacote
            // 
            this.BtnEcluirPacote.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEcluirPacote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnEcluirPacote.Location = new System.Drawing.Point(450, 83);
            this.BtnEcluirPacote.Name = "BtnEcluirPacote";
            this.BtnEcluirPacote.Size = new System.Drawing.Size(189, 47);
            this.BtnEcluirPacote.TabIndex = 1;
            this.BtnEcluirPacote.Text = "Gerenciar Pacote";
            this.BtnEcluirPacote.UseVisualStyleBackColor = true;
            this.BtnEcluirPacote.Click += new System.EventHandler(this.BtnEcluirPacote_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(221, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Adicionar Pacote";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewpacotes
            // 
            this.dataGridViewpacotes.AllowUserToAddRows = false;
            this.dataGridViewpacotes.AllowUserToDeleteRows = false;
            this.dataGridViewpacotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewpacotes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewpacotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewpacotes.Location = new System.Drawing.Point(33, 232);
            this.dataGridViewpacotes.Name = "dataGridViewpacotes";
            this.dataGridViewpacotes.ReadOnly = true;
            this.dataGridViewpacotes.RowHeadersWidth = 51;
            this.dataGridViewpacotes.RowTemplate.Height = 24;
            this.dataGridViewpacotes.Size = new System.Drawing.Size(1072, 386);
            this.dataGridViewpacotes.TabIndex = 2;
            this.dataGridViewpacotes.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(28, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lista de Pacotes Cadastrados:";
            // 
            // FormPacotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1144, 646);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewpacotes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPacotes";
            this.Text = "FormPacotes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewpacotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnEcluirPacote;
        private System.Windows.Forms.DataGridView dataGridViewpacotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btnatualizarpacote;
    }
}