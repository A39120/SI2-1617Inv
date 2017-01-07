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
            this.groupBoxPromotionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpdateDesconto
            // 
            this.buttonUpdateDesconto.Location = new System.Drawing.Point(12, 307);
            this.buttonUpdateDesconto.Name = "buttonUpdateDesconto";
            this.buttonUpdateDesconto.Size = new System.Drawing.Size(185, 35);
            this.buttonUpdateDesconto.TabIndex = 5;
            this.buttonUpdateDesconto.Text = "Actualizar Desconto";
            this.buttonUpdateDesconto.UseVisualStyleBackColor = true;
            this.buttonUpdateDesconto.Click += new System.EventHandler(this.buttonUpdateDesconto_Click);
            // 
            // buttonUpdateTempo
            // 
            this.buttonUpdateTempo.Location = new System.Drawing.Point(216, 307);
            this.buttonUpdateTempo.Name = "buttonUpdateTempo";
            this.buttonUpdateTempo.Size = new System.Drawing.Size(228, 35);
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
            this.groupBoxPromotionInfo.Location = new System.Drawing.Point(12, 10);
            this.groupBoxPromotionInfo.Name = "groupBoxPromotionInfo";
            this.groupBoxPromotionInfo.Size = new System.Drawing.Size(432, 291);
            this.groupBoxPromotionInfo.TabIndex = 3;
            this.groupBoxPromotionInfo.TabStop = false;
            this.groupBoxPromotionInfo.Text = "Promoção";
            // 
            // textBoxTempoExtra
            // 
            this.textBoxTempoExtra.Location = new System.Drawing.Point(9, 256);
            this.textBoxTempoExtra.Name = "textBoxTempoExtra";
            this.textBoxTempoExtra.Size = new System.Drawing.Size(417, 22);
            this.textBoxTempoExtra.TabIndex = 11;
            // 
            // textBoxDesconto
            // 
            this.textBoxDesconto.Location = new System.Drawing.Point(10, 210);
            this.textBoxDesconto.Name = "textBoxDesconto";
            this.textBoxDesconto.Size = new System.Drawing.Size(416, 22);
            this.textBoxDesconto.TabIndex = 10;
            // 
            // textBoxFim
            // 
            this.textBoxFim.Location = new System.Drawing.Point(49, 165);
            this.textBoxFim.Name = "textBoxFim";
            this.textBoxFim.Size = new System.Drawing.Size(377, 22);
            this.textBoxFim.TabIndex = 9;
            // 
            // textBoxInicio
            // 
            this.textBoxInicio.Location = new System.Drawing.Point(49, 137);
            this.textBoxInicio.Name = "textBoxInicio";
            this.textBoxInicio.Size = new System.Drawing.Size(377, 22);
            this.textBoxInicio.TabIndex = 8;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(10, 65);
            this.textBoxDescricao.Multiline = true;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(416, 66);
            this.textBoxDescricao.TabIndex = 7;
            // 
            // labelDesconto
            // 
            this.labelDesconto.AutoSize = true;
            this.labelDesconto.Location = new System.Drawing.Point(6, 190);
            this.labelDesconto.Name = "labelDesconto";
            this.labelDesconto.Size = new System.Drawing.Size(68, 17);
            this.labelDesconto.TabIndex = 6;
            this.labelDesconto.Text = "Desconto";
            // 
            // labelTempoExtra
            // 
            this.labelTempoExtra.AutoSize = true;
            this.labelTempoExtra.Location = new System.Drawing.Point(6, 235);
            this.labelTempoExtra.Name = "labelTempoExtra";
            this.labelTempoExtra.Size = new System.Drawing.Size(88, 17);
            this.labelTempoExtra.TabIndex = 5;
            this.labelTempoExtra.Text = "Tempo Extra";
            // 
            // labelFim
            // 
            this.labelFim.AutoSize = true;
            this.labelFim.Location = new System.Drawing.Point(6, 165);
            this.labelFim.Name = "labelFim";
            this.labelFim.Size = new System.Drawing.Size(30, 17);
            this.labelFim.TabIndex = 4;
            this.labelFim.Text = "Fim";
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(3, 140);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(40, 17);
            this.labelInicio.TabIndex = 3;
            this.labelInicio.Text = "Inicio";
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.Location = new System.Drawing.Point(7, 44);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(71, 17);
            this.labelDescricao.TabIndex = 2;
            this.labelDescricao.Text = "Descrição";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(7, 24);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(108, 17);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID da promoção";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(121, 21);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(305, 22);
            this.textBoxId.TabIndex = 0;
            // 
            // UpdatePromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 349);
            this.Controls.Add(this.buttonUpdateDesconto);
            this.Controls.Add(this.buttonUpdateTempo);
            this.Controls.Add(this.groupBoxPromotionInfo);
            this.Name = "UpdatePromotionForm";
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
    }
}