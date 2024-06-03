namespace SystemTravelAgency
{
    partial class FormViagens
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
            this.DataGridViewPacotesDisponiveis = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnFIltrar = new System.Windows.Forms.Button();
            this.BtnAtualizarLista = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnPesquisarCpf = new System.Windows.Forms.Button();
            this.Lblsituacaocliente = new System.Windows.Forms.Label();
            this.txtpesquisaBD = new System.Windows.Forms.MaskedTextBox();
            this.BtnComprarpacote = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPacotesDisponiveis)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewPacotesDisponiveis
            // 
            this.DataGridViewPacotesDisponiveis.AllowUserToAddRows = false;
            this.DataGridViewPacotesDisponiveis.AllowUserToDeleteRows = false;
            this.DataGridViewPacotesDisponiveis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewPacotesDisponiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewPacotesDisponiveis.Location = new System.Drawing.Point(76, 218);
            this.DataGridViewPacotesDisponiveis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridViewPacotesDisponiveis.Name = "DataGridViewPacotesDisponiveis";
            this.DataGridViewPacotesDisponiveis.ReadOnly = true;
            this.DataGridViewPacotesDisponiveis.RowHeadersWidth = 51;
            this.DataGridViewPacotesDisponiveis.RowTemplate.Height = 24;
            this.DataGridViewPacotesDisponiveis.Size = new System.Drawing.Size(1131, 418);
            this.DataGridViewPacotesDisponiveis.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.BtnFIltrar);
            this.panel1.Controls.Add(this.BtnAtualizarLista);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.BtnComprarpacote);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 179);
            this.panel1.TabIndex = 2;
            // 
            // BtnFIltrar
            // 
            this.BtnFIltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFIltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnFIltrar.Location = new System.Drawing.Point(76, 111);
            this.BtnFIltrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnFIltrar.Name = "BtnFIltrar";
            this.BtnFIltrar.Size = new System.Drawing.Size(166, 45);
            this.BtnFIltrar.TabIndex = 3;
            this.BtnFIltrar.Text = "Filtrar Pacote";
            this.BtnFIltrar.UseVisualStyleBackColor = true;
            this.BtnFIltrar.Click += new System.EventHandler(this.BtnFIltrar_Click);
            // 
            // BtnAtualizarLista
            // 
            this.BtnAtualizarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAtualizarLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnAtualizarLista.Location = new System.Drawing.Point(294, 111);
            this.BtnAtualizarLista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAtualizarLista.Name = "BtnAtualizarLista";
            this.BtnAtualizarLista.Size = new System.Drawing.Size(166, 45);
            this.BtnAtualizarLista.TabIndex = 2;
            this.BtnAtualizarLista.Text = "Atualizar Lista";
            this.BtnAtualizarLista.UseVisualStyleBackColor = true;
            this.BtnAtualizarLista.Click += new System.EventHandler(this.BtnAtualizarLista_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnPesquisarCpf, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Lblsituacaocliente, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtpesquisaBD, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(866, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.62069F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.89655F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 148);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // BtnPesquisarCpf
            // 
            this.BtnPesquisarCpf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPesquisarCpf.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisarCpf.Location = new System.Drawing.Point(52, 55);
            this.BtnPesquisarCpf.Margin = new System.Windows.Forms.Padding(50, 4, 50, 4);
            this.BtnPesquisarCpf.Name = "BtnPesquisarCpf";
            this.BtnPesquisarCpf.Size = new System.Drawing.Size(237, 36);
            this.BtnPesquisarCpf.TabIndex = 11;
            this.BtnPesquisarCpf.Text = "Pesquisar CPF";
            this.BtnPesquisarCpf.UseVisualStyleBackColor = true;
            this.BtnPesquisarCpf.Click += new System.EventHandler(this.BtnPesquisarCpf_Click);
            // 
            // Lblsituacaocliente
            // 
            this.Lblsituacaocliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lblsituacaocliente.AutoSize = true;
            this.Lblsituacaocliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Lblsituacaocliente.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblsituacaocliente.ForeColor = System.Drawing.Color.White;
            this.Lblsituacaocliente.Location = new System.Drawing.Point(52, 107);
            this.Lblsituacaocliente.Margin = new System.Windows.Forms.Padding(50, 9, 50, 12);
            this.Lblsituacaocliente.Name = "Lblsituacaocliente";
            this.Lblsituacaocliente.Size = new System.Drawing.Size(237, 27);
            this.Lblsituacaocliente.TabIndex = 11;
            this.Lblsituacaocliente.Text = "Situação do Cliente...";
            this.Lblsituacaocliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpesquisaBD
            // 
            this.txtpesquisaBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpesquisaBD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpesquisaBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpesquisaBD.Location = new System.Drawing.Point(52, 10);
            this.txtpesquisaBD.Margin = new System.Windows.Forms.Padding(50, 4, 50, 4);
            this.txtpesquisaBD.Mask = "000,000,000-00";
            this.txtpesquisaBD.Name = "txtpesquisaBD";
            this.txtpesquisaBD.Size = new System.Drawing.Size(237, 30);
            this.txtpesquisaBD.TabIndex = 10;
            this.txtpesquisaBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnComprarpacote
            // 
            this.BtnComprarpacote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnComprarpacote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnComprarpacote.Location = new System.Drawing.Point(511, 111);
            this.BtnComprarpacote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnComprarpacote.Name = "BtnComprarpacote";
            this.BtnComprarpacote.Size = new System.Drawing.Size(166, 45);
            this.BtnComprarpacote.TabIndex = 1;
            this.BtnComprarpacote.Text = "Comprar";
            this.BtnComprarpacote.UseVisualStyleBackColor = true;
            this.BtnComprarpacote.Click += new System.EventHandler(this.BtnComprarpacote_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pacotes Disponiveis: ";
            // 
            // FormViagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataGridViewPacotesDisponiveis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormViagens";
            this.Text = "Formviagens";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPacotesDisponiveis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewPacotesDisponiveis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAtualizarLista;
        private System.Windows.Forms.Button BtnComprarpacote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox txtpesquisaBD;
        private System.Windows.Forms.Button BtnFIltrar;
        private System.Windows.Forms.Button BtnPesquisarCpf;
        private System.Windows.Forms.Label Lblsituacaocliente;
    }
}