namespace Benner.AplicacaoCaixaEletronico
{
    partial class AppCaixaEletronico
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
            this.textoTitular = new System.Windows.Forms.TextBox();
            this.labelTitular = new System.Windows.Forms.Label();
            this.textoSaldo = new System.Windows.Forms.TextBox();
            this.textoNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textoValor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboContas = new System.Windows.Forms.ComboBox();
            this.destinoDaTransferencia = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.botaoTotalContas = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.botaoExemplos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoTitular
            // 
            this.textoTitular.Location = new System.Drawing.Point(69, 140);
            this.textoTitular.Name = "textoTitular";
            this.textoTitular.Size = new System.Drawing.Size(262, 20);
            this.textoTitular.TabIndex = 0;
            // 
            // labelTitular
            // 
            this.labelTitular.AutoSize = true;
            this.labelTitular.Location = new System.Drawing.Point(15, 143);
            this.labelTitular.Name = "labelTitular";
            this.labelTitular.Size = new System.Drawing.Size(39, 13);
            this.labelTitular.TabIndex = 2;
            this.labelTitular.Text = "Titular:";
            // 
            // textoSaldo
            // 
            this.textoSaldo.Location = new System.Drawing.Point(231, 166);
            this.textoSaldo.Name = "textoSaldo";
            this.textoSaldo.Size = new System.Drawing.Size(100, 20);
            this.textoSaldo.TabIndex = 3;
            // 
            // textoNumero
            // 
            this.textoNumero.Location = new System.Drawing.Point(69, 166);
            this.textoNumero.Name = "textoNumero";
            this.textoNumero.Size = new System.Drawing.Size(100, 20);
            this.textoNumero.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Saldo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Número:";
            // 
            // textoValor
            // 
            this.textoValor.Location = new System.Drawing.Point(62, 227);
            this.textoValor.Name = "textoValor";
            this.textoValor.Size = new System.Drawing.Size(100, 20);
            this.textoValor.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Depositar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Valor:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(175, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Sacar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboContas
            // 
            this.comboContas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboContas.FormattingEnabled = true;
            this.comboContas.Location = new System.Drawing.Point(90, 25);
            this.comboContas.Name = "comboContas";
            this.comboContas.Size = new System.Drawing.Size(190, 21);
            this.comboContas.TabIndex = 15;
            this.comboContas.SelectedIndexChanged += new System.EventHandler(this.comboContas_SelectedIndexChanged);
            // 
            // destinoDaTransferencia
            // 
            this.destinoDaTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinoDaTransferencia.FormattingEnabled = true;
            this.destinoDaTransferencia.Location = new System.Drawing.Point(23, 284);
            this.destinoDaTransferencia.Name = "destinoDaTransferencia";
            this.destinoDaTransferencia.Size = new System.Drawing.Size(156, 21);
            this.destinoDaTransferencia.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(185, 282);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(156, 23);
            this.button7.TabIndex = 17;
            this.button7.Text = "Transferir";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Lista de contas:";
            // 
            // botaoTotalContas
            // 
            this.botaoTotalContas.Location = new System.Drawing.Point(90, 81);
            this.botaoTotalContas.Name = "botaoTotalContas";
            this.botaoTotalContas.Size = new System.Drawing.Size(190, 23);
            this.botaoTotalContas.TabIndex = 21;
            this.botaoTotalContas.Text = "Total de Contas";
            this.botaoTotalContas.UseVisualStyleBackColor = true;
            this.botaoTotalContas.Click += new System.EventHandler(this.botaoTotalContas_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(90, 52);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(92, 23);
            this.button13.TabIndex = 24;
            this.button13.Text = "Adicionar Conta";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(188, 52);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(92, 23);
            this.button9.TabIndex = 25;
            this.button9.Text = "Remover Conta";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // botaoExemplos
            // 
            this.botaoExemplos.Location = new System.Drawing.Point(3, 4);
            this.botaoExemplos.Name = "botaoExemplos";
            this.botaoExemplos.Size = new System.Drawing.Size(29, 23);
            this.botaoExemplos.TabIndex = 26;
            this.botaoExemplos.Text = "EA";
            this.botaoExemplos.UseVisualStyleBackColor = true;
            this.botaoExemplos.Click += new System.EventHandler(this.botaoExemplos_Click);
            // 
            // AppCaixaEletronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 321);
            this.Controls.Add(this.botaoExemplos);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.botaoTotalContas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.destinoDaTransferencia);
            this.Controls.Add(this.comboContas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textoValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textoNumero);
            this.Controls.Add(this.textoSaldo);
            this.Controls.Add(this.labelTitular);
            this.Controls.Add(this.textoTitular);
            this.Name = "AppCaixaEletronico";
            this.Text = "Caixa Eletrônico";
            this.Load += new System.EventHandler(this.AppCaixaEletronico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoTitular;
        private System.Windows.Forms.Label labelTitular;
        private System.Windows.Forms.TextBox textoSaldo;
        private System.Windows.Forms.TextBox textoNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textoValor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboContas;
        private System.Windows.Forms.ComboBox destinoDaTransferencia;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botaoTotalContas;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button botaoExemplos;
    }
}

