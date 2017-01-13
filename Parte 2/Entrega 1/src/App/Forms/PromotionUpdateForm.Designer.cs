namespace App
{
    partial class PromotionUpdateForm
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
            this.buttonUpdateDesconto = new System.Windows.Forms.Button();
            this.buttonUpdateTempo = new System.Windows.Forms.Button();
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
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxPromotionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpdateDesconto
            // 
            this.buttonUpdateDesconto.Location = new System.Drawing.Point(9, 249);
            this.buttonUpdateDesconto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdateDesconto.Name = "buttonUpdateDesconto";
            this.buttonUpdateDesconto.Size = new System.Drawing.Size(139, 28);
            this.buttonUpdateDesconto.TabIndex = 5;
            this.buttonUpdateDesconto.Text = "Actualizar Desconto";
            this.buttonUpdateDesconto.UseVisualStyleBackColor = true;
            this.buttonUpdateDesconto.Click += new System.EventHandler(this.buttonUpdateDesconto_Click);
            // 
            // buttonUpdateTempo
            // 
            this.buttonUpdateTempo.Location = new System.Drawing.Point(162, 249);
            this.buttonUpdateTempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpdateTempo.Name = "buttonUpdateTempo";
            this.buttonUpdateTempo.Size = new System.Drawing.Size(171, 28);
            this.buttonUpdateTempo.TabIndex = 4;
            this.buttonUpdateTempo.Text = "Actualizar Promoção Tempo";
            this.buttonUpdateTempo.UseVisualStyleBackColor = true;
            this.buttonUpdateTempo.Click += new System.EventHandler(this.buttonUpdateTempo_Click);
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
            this.groupBoxPromotionInfo.Controls.Add(this.labelId);
            this.groupBoxPromotionInfo.Controls.Add(this.textBoxId);
            this.groupBoxPromotionInfo.Location = new System.Drawing.Point(9, 8);
            this.groupBoxPromotionInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPromotionInfo.Name = "groupBoxPromotionInfo";
            this.groupBoxPromotionInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPromotionInfo.Size = new System.Drawing.Size(324, 236);
            this.groupBoxPromotionInfo.TabIndex = 3;
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
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(5, 20);
            this.labelId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(83, 13);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID da promoção";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(91, 17);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(230, 20);
            this.textBoxId.TabIndex = 0;
            // 
            // PromotionUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 284);
            this.Controls.Add(this.buttonUpdateDesconto);
            this.Controls.Add(this.buttonUpdateTempo);
            this.Controls.Add(this.groupBoxPromotionInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PromotionUpdateForm";
            this.Text = "UpdatePromotionForm";
            this.groupBoxPromotionInfo.ResumeLayout(false);
            this.groupBoxPromotionInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateDesconto;
        private System.Windows.Forms.Button buttonUpdateTempo;
        private System.Windows.Forms.GroupBox groupBoxPromotionInfo;
        private System.Windows.Forms.TextBox textBoxTempoExtra;
        private System.Windows.Forms.TextBox textBoxDesconto;
        private System.Windows.Forms.TextBox textBoxFim;
        private System.Windows.Forms.TextBox textBoxInicio;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelDesconto;
        private System.Windows.Forms.Label labelTempoExtra;
        private System.Windows.Forms.Label labelFim;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}