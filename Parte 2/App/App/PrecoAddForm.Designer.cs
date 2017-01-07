namespace App
{
    partial class PrecoAddForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxPreco = new System.Windows.Forms.GroupBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.textBoxDuracao = new System.Windows.Forms.TextBox();
            this.textBoxValidade = new System.Windows.Forms.TextBox();
            this.groupBoxPreco.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Inserir Preço";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Validade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Duração:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo:";
            // 
            // groupBoxPreco
            // 
            this.groupBoxPreco.Controls.Add(this.textBoxValidade);
            this.groupBoxPreco.Controls.Add(this.textBoxDuracao);
            this.groupBoxPreco.Controls.Add(this.textBoxValor);
            this.groupBoxPreco.Controls.Add(this.textBoxTipo);
            this.groupBoxPreco.Controls.Add(this.label2);
            this.groupBoxPreco.Controls.Add(this.label3);
            this.groupBoxPreco.Controls.Add(this.label4);
            this.groupBoxPreco.Controls.Add(this.label1);
            this.groupBoxPreco.Location = new System.Drawing.Point(16, 12);
            this.groupBoxPreco.Name = "groupBoxPreco";
            this.groupBoxPreco.Size = new System.Drawing.Size(205, 139);
            this.groupBoxPreco.TabIndex = 5;
            this.groupBoxPreco.TabStop = false;
            this.groupBoxPreco.Text = "Preço";
            // 
            // textBox1
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(52, 18);
            this.textBoxTipo.Name = "textBox1";
            this.textBoxTipo.Size = new System.Drawing.Size(143, 22);
            this.textBoxTipo.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBoxValor.Location = new System.Drawing.Point(58, 50);
            this.textBoxValor.Name = "textBox2";
            this.textBoxValor.Size = new System.Drawing.Size(137, 22);
            this.textBoxValor.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBoxDuracao.Location = new System.Drawing.Point(79, 79);
            this.textBoxDuracao.Name = "textBox3";
            this.textBoxDuracao.Size = new System.Drawing.Size(116, 22);
            this.textBoxDuracao.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBoxValidade.Location = new System.Drawing.Point(79, 108);
            this.textBoxValidade.Name = "textBox4";
            this.textBoxValidade.Size = new System.Drawing.Size(116, 22);
            this.textBoxValidade.TabIndex = 8;
            // 
            // PrecoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 206);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxPreco);
            this.Name = "PrecoAddForm";
            this.Text = "PrecoAddForm";
            this.groupBoxPreco.ResumeLayout(false);
            this.groupBoxPreco.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxPreco;
        private System.Windows.Forms.TextBox textBoxValidade;
        private System.Windows.Forms.TextBox textBoxDuracao;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.TextBox textBoxTipo;
    }
}