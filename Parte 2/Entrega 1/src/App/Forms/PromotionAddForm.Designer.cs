namespace App
{
    partial class PromotionAddForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxPromotionInfo = new System.Windows.Forms.GroupBox();
            this.textBoxTempoExtra = new System.Windows.Forms.TextBox();
            this.textBoxDesconto = new System.Windows.Forms.TextBox();
            this.textBoxFim = new System.Windows.Forms.TextBox();
            this.textBoxInicio = new System.Windows.Forms.TextBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelDesconto = new System.Windows.Forms.Label();
            this.labelTempoExtra = new System.Windows.Forms.Label();
            this.labelFim = new System.Windows.Forms.Label();
            this.labelInicio = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.buttonAddTempo = new System.Windows.Forms.Button();
            this.buttonAddDesconto = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxPromotionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPromotionInfo
            // 
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxTempoExtra);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxDesconto);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxFim);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxInicio);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxDescricao);
            this.groupBoxPromotionInfo.Controls.Add(this.labelDesconto);
            this.groupBoxPromotionInfo.Controls.Add(this.labelTempoExtra);
            this.groupBoxPromotionInfo.Controls.Add(this.labelFim);
            this.groupBoxPromotionInfo.Controls.Add(this.labelInicio);
            this.groupBoxPromotionInfo.Controls.Add(this.labelDescricao);
            this.groupBoxPromotionInfo.Controls.Add(this.labelTipo);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxTipo);
            this.groupBoxPromotionInfo.Location = new System.Drawing.Point(9, 10);
            this.groupBoxPromotionInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPromotionInfo.Name = "groupBoxPromotionInfo";
            this.groupBoxPromotionInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPromotionInfo.Size = new System.Drawing.Size(324, 236);
            this.groupBoxPromotionInfo.TabIndex = 0;
            this.groupBoxPromotionInfo.TabStop = false;
            this.groupBoxPromotionInfo.Text = "Promoção";
            // 
            // textBoxTempoExtra
            // 
            this.textBoxTempoExtra.Location = new System.Drawing.Point(7, 208);
            this.textBoxTempoExtra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTempoExtra.Name = "textBoxTempoExtra";
            this.textBoxTempoExtra.Size = new System.Drawing.Size(314, 20);
            this.textBoxTempoExtra.TabIndex = 11;
            // 
            // textBoxDesconto
            // 
            this.textBoxDesconto.Location = new System.Drawing.Point(8, 171);
            this.textBoxDesconto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDesconto.Name = "textBoxDesconto";
            this.textBoxDesconto.Size = new System.Drawing.Size(313, 20);
            this.textBoxDesconto.TabIndex = 10;
            // 
            // textBoxFim
            // 
            this.textBoxFim.Location = new System.Drawing.Point(37, 134);
            this.textBoxFim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFim.Name = "textBoxFim";
            this.textBoxFim.Size = new System.Drawing.Size(284, 20);
            this.textBoxFim.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBoxFim, "YYYY-MM-DD HH:MM:SS");
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Location = new System.Drawing.Point(37, 111);
            this.textBoxInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(284, 20);
            this.textBoxInicio.TabIndex = 8;
            this.toolTip1.SetToolTip(this.textBoxInicio, "YYYY-MM-DD HH:MM:SS");
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(8, 53);
            this.textBoxDescricao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDescricao.Multiline = true;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(313, 54);
            this.textBoxDescricao.TabIndex = 7;
            // 
            // labelDesconto
            // 
            this.labelDesconto.AutoSize = true;
            this.labelDesconto.Location = new System.Drawing.Point(4, 154);
            this.labelDesconto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDesconto.Name = "labelDesconto";
            this.labelDesconto.Size = new System.Drawing.Size(53, 13);
            this.labelDesconto.TabIndex = 6;
            this.labelDesconto.Text = "Desconto";
            // 
            // labelTempoExtra
            // 
            this.labelTempoExtra.AutoSize = true;
            this.labelTempoExtra.Location = new System.Drawing.Point(4, 191);
            this.labelTempoExtra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTempoExtra.Name = "labelTempoExtra";
            this.labelTempoExtra.Size = new System.Drawing.Size(67, 13);
            this.labelTempoExtra.TabIndex = 5;
            this.labelTempoExtra.Text = "Tempo Extra";
            // 
            // labelFim
            // 
            this.labelFim.AutoSize = true;
            this.labelFim.Location = new System.Drawing.Point(4, 134);
            this.labelFim.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFim.Name = "labelFim";
            this.labelFim.Size = new System.Drawing.Size(23, 13);
            this.labelFim.TabIndex = 4;
            this.labelFim.Text = "Fim";
            this.toolTip1.SetToolTip(this.labelFim, "YYYY-MM-DD HH:MM:SS");
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(2, 114);
            this.labelInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(32, 13);
            this.labelInicio.TabIndex = 3;
            this.labelInicio.Text = "Inicio";
            this.toolTip1.SetToolTip(this.labelInicio, "YYYY-MM-DD HH:MM:SS");
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(5, 36);
            this.labelDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(55, 13);
            this.labelDescricao.TabIndex = 2;
            this.labelDescricao.Text = "Descrição";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(5, 15);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(28, 13);
            this.labelTipo.TabIndex = 1;
            this.labelTipo.Text = "Tipo";
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(37, 15);
            this.textBoxTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(284, 20);
            this.textBoxTipo.TabIndex = 0;
            // 
            // buttonAddTempo
            // 
            this.buttonAddTempo.Location = new System.Drawing.Point(162, 252);
            this.buttonAddTempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddTempo.Name = "buttonAddTempo";
            this.buttonAddTempo.Size = new System.Drawing.Size(171, 28);
            this.buttonAddTempo.TabIndex = 1;
            this.buttonAddTempo.Text = "Adicionar Promoção Tempo";
            this.buttonAddTempo.UseVisualStyleBackColor = true;
            this.buttonAddTempo.Click += new System.EventHandler(this.buttonAddTempo_Click);
            // 
            // buttonAddDesconto
            // 
            this.buttonAddDesconto.Location = new System.Drawing.Point(9, 252);
            this.buttonAddDesconto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddDesconto.Name = "buttonAddDesconto";
            this.buttonAddDesconto.Size = new System.Drawing.Size(139, 28);
            this.buttonAddDesconto.TabIndex = 2;
            this.buttonAddDesconto.Text = "Adicionar Desconto";
            this.buttonAddDesconto.UseVisualStyleBackColor = true;
            this.buttonAddDesconto.Click += new System.EventHandler(this.buttonAddDesconto_Click);
            // 
            // PromotionAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 290);
            this.Controls.Add(this.buttonAddDesconto);
            this.Controls.Add(this.buttonAddTempo);
            this.Controls.Add(this.groupBoxPromotionInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PromotionAddForm";
            this.Text = "Adicionar Promoção";
            this.groupBoxPromotionInfo.ResumeLayout(false);
            this.groupBoxPromotionInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPromotionInfo;
        private System.Windows.Forms.Button buttonAddTempo;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelDesconto;
        private System.Windows.Forms.Label labelTempoExtra;
        private System.Windows.Forms.Label labelFim;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Button buttonAddDesconto;
        private System.Windows.Forms.TextBox textBoxTempoExtra;
        private System.Windows.Forms.TextBox textBoxDesconto;
        private System.Windows.Forms.TextBox textBoxFim;
        private System.Windows.Forms.TextBox textBoxInicio;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}