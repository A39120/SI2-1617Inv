namespace App
{
    partial class Start
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
            this.groupBoxPromotion = new System.Windows.Forms.GroupBox();
            this.removePromotion = new System.Windows.Forms.Button();
            this.updatePromotion = new System.Windows.Forms.Button();
            this.addPromotion = new System.Windows.Forms.Button();
            this.groupBoxAluguer = new System.Windows.Forms.GroupBox();
            this.removeAluguer = new System.Windows.Forms.Button();
            this.insertWithoutClient = new System.Windows.Forms.Button();
            this.groupBoxPrice = new System.Windows.Forms.GroupBox();
            this.removePrice = new System.Windows.Forms.Button();
            this.updatePrice = new System.Windows.Forms.Button();
            this.addPrice = new System.Windows.Forms.Button();
            this.groupBoxEquipamentos = new System.Windows.Forms.GroupBox();
            this.listEquipamentosLivres = new System.Windows.Forms.Button();
            this.listLastWeekFree = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxPromotion.SuspendLayout();
            this.groupBoxAluguer.SuspendLayout();
            this.groupBoxPrice.SuspendLayout();
            this.groupBoxEquipamentos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPromotion
            // 
            this.groupBoxPromotion.Controls.Add(this.removePromotion);
            this.groupBoxPromotion.Controls.Add(this.updatePromotion);
            this.groupBoxPromotion.Controls.Add(this.addPromotion);
            this.groupBoxPromotion.Location = new System.Drawing.Point(12, 9);
            this.groupBoxPromotion.Name = "groupBoxPromotion";
            this.groupBoxPromotion.Size = new System.Drawing.Size(672, 54);
            this.groupBoxPromotion.TabIndex = 1;
            this.groupBoxPromotion.TabStop = false;
            this.groupBoxPromotion.Text = "Promotion";
            // 
            // removePromotion
            // 
            this.removePromotion.Location = new System.Drawing.Point(445, 21);
            this.removePromotion.Name = "removePromotion";
            this.removePromotion.Size = new System.Drawing.Size(212, 23);
            this.removePromotion.TabIndex = 3;
            this.removePromotion.Text = "Remover";
            this.removePromotion.UseVisualStyleBackColor = true;
            this.removePromotion.Click += new System.EventHandler(this.GoToRemovePromotion);
            // 
            // updatePromotion
            // 
            this.updatePromotion.Location = new System.Drawing.Point(227, 21);
            this.updatePromotion.Name = "updatePromotion";
            this.updatePromotion.Size = new System.Drawing.Size(212, 23);
            this.updatePromotion.TabIndex = 2;
            this.updatePromotion.Text = "Actualizar";
            this.updatePromotion.UseVisualStyleBackColor = true;
            this.updatePromotion.Click += new System.EventHandler(this.GoToUpdatePromotion);
            // 
            // addPromotion
            // 
            this.addPromotion.Location = new System.Drawing.Point(6, 21);
            this.addPromotion.Name = "addPromotion";
            this.addPromotion.Size = new System.Drawing.Size(212, 23);
            this.addPromotion.TabIndex = 0;
            this.addPromotion.Text = "Inserir";
            this.addPromotion.UseVisualStyleBackColor = true;
            this.addPromotion.Click += new System.EventHandler(this.GoToAddPromotion);
            // 
            // groupBoxAluguer
            // 
            this.groupBoxAluguer.Controls.Add(this.removeAluguer);
            this.groupBoxAluguer.Controls.Add(this.insertWithoutClient);
            this.groupBoxAluguer.Location = new System.Drawing.Point(12, 69);
            this.groupBoxAluguer.Name = "groupBoxAluguer";
            this.groupBoxAluguer.Size = new System.Drawing.Size(672, 54);
            this.groupBoxAluguer.TabIndex = 4;
            this.groupBoxAluguer.TabStop = false;
            this.groupBoxAluguer.Text = "Aluguer";
            // 
            // removeAluguer
            // 
            this.removeAluguer.Location = new System.Drawing.Point(332, 21);
            this.removeAluguer.Name = "removeAluguer";
            this.removeAluguer.Size = new System.Drawing.Size(324, 23);
            this.removeAluguer.TabIndex = 2;
            this.removeAluguer.Text = "Remover";
            this.removeAluguer.UseVisualStyleBackColor = true;
            this.removeAluguer.Click += new System.EventHandler(this.GoToRemoveAluguer);
            // 
            // insertWithoutClient
            // 
            this.insertWithoutClient.Location = new System.Drawing.Point(7, 22);
            this.insertWithoutClient.Name = "insertWithoutClient";
            this.insertWithoutClient.Size = new System.Drawing.Size(319, 23);
            this.insertWithoutClient.TabIndex = 0;
            this.insertWithoutClient.Text = "Inserir";
            this.insertWithoutClient.UseVisualStyleBackColor = true;
            this.insertWithoutClient.Click += new System.EventHandler(this.GoToInsertAluguer);
            // 
            // groupBoxPrice
            // 
            this.groupBoxPrice.Controls.Add(this.removePrice);
            this.groupBoxPrice.Controls.Add(this.updatePrice);
            this.groupBoxPrice.Controls.Add(this.addPrice);
            this.groupBoxPrice.Location = new System.Drawing.Point(12, 129);
            this.groupBoxPrice.Name = "groupBoxPrice";
            this.groupBoxPrice.Size = new System.Drawing.Size(672, 54);
            this.groupBoxPrice.TabIndex = 5;
            this.groupBoxPrice.TabStop = false;
            this.groupBoxPrice.Text = "Preçario";
            // 
            // removePrice
            // 
            this.removePrice.Location = new System.Drawing.Point(445, 21);
            this.removePrice.Name = "removePrice";
            this.removePrice.Size = new System.Drawing.Size(211, 23);
            this.removePrice.TabIndex = 2;
            this.removePrice.Text = "Remover";
            this.removePrice.UseVisualStyleBackColor = true;
            this.removePrice.Click += new System.EventHandler(this.GoToRemovePrice);
            // 
            // updatePrice
            // 
            this.updatePrice.Location = new System.Drawing.Point(228, 21);
            this.updatePrice.Name = "updatePrice";
            this.updatePrice.Size = new System.Drawing.Size(211, 23);
            this.updatePrice.TabIndex = 1;
            this.updatePrice.Text = "Actualizar";
            this.updatePrice.UseVisualStyleBackColor = true;
            this.updatePrice.Click += new System.EventHandler(this.GoToUpdatePrice);
            // 
            // addPrice
            // 
            this.addPrice.Location = new System.Drawing.Point(7, 22);
            this.addPrice.Name = "addPrice";
            this.addPrice.Size = new System.Drawing.Size(211, 23);
            this.addPrice.TabIndex = 0;
            this.addPrice.Text = "Inserir";
            this.addPrice.UseVisualStyleBackColor = true;
            this.addPrice.Click += new System.EventHandler(this.GoToAddPrice);
            // 
            // groupBoxEquipamentos
            // 
            this.groupBoxEquipamentos.Controls.Add(this.listEquipamentosLivres);
            this.groupBoxEquipamentos.Controls.Add(this.listLastWeekFree);
            this.groupBoxEquipamentos.Location = new System.Drawing.Point(12, 189);
            this.groupBoxEquipamentos.Name = "groupBoxEquipamentos";
            this.groupBoxEquipamentos.Size = new System.Drawing.Size(672, 53);
            this.groupBoxEquipamentos.TabIndex = 6;
            this.groupBoxEquipamentos.TabStop = false;
            this.groupBoxEquipamentos.Text = "Equipamentos Livres";
            // 
            // listEquipamentosLivres
            // 
            this.listEquipamentosLivres.Location = new System.Drawing.Point(332, 21);
            this.listEquipamentosLivres.Name = "listEquipamentosLivres";
            this.listEquipamentosLivres.Size = new System.Drawing.Size(324, 23);
            this.listEquipamentosLivres.TabIndex = 1;
            this.listEquipamentosLivres.Text = "Equipamentos Livres";
            this.listEquipamentosLivres.UseVisualStyleBackColor = true;
            this.listEquipamentosLivres.Click += new System.EventHandler(this.GoToListEquipamentosLivres);
            // 
            // listLastWeekFree
            // 
            this.listLastWeekFree.Location = new System.Drawing.Point(7, 21);
            this.listLastWeekFree.Name = "listLastWeekFree";
            this.listLastWeekFree.Size = new System.Drawing.Size(319, 23);
            this.listLastWeekFree.TabIndex = 0;
            this.listLastWeekFree.Text = "Equipamentos Livres na Semana Passada";
            this.listLastWeekFree.UseVisualStyleBackColor = true;
            this.listLastWeekFree.Click += new System.EventHandler(this.GoToListLastWeekFree);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 271);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Entity Framework";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exportar Alugueres (.xml)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(330, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 56);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alugueres";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 308);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBoxEquipamentos);
            this.Controls.Add(this.groupBoxPrice);
            this.Controls.Add(this.groupBoxAluguer);
            this.Controls.Add(this.groupBoxPromotion);
            this.Name = "Start";
            this.Text = "Database Control";
            this.groupBoxPromotion.ResumeLayout(false);
            this.groupBoxAluguer.ResumeLayout(false);
            this.groupBoxPrice.ResumeLayout(false);
            this.groupBoxEquipamentos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPromotion;
        private System.Windows.Forms.Button removePromotion;
        private System.Windows.Forms.Button updatePromotion;
        private System.Windows.Forms.Button addPromotion;
        private System.Windows.Forms.GroupBox groupBoxAluguer;
        private System.Windows.Forms.Button removeAluguer;
        private System.Windows.Forms.Button insertWithoutClient;
        private System.Windows.Forms.GroupBox groupBoxPrice;
        private System.Windows.Forms.Button removePrice;
        private System.Windows.Forms.Button updatePrice;
        private System.Windows.Forms.Button addPrice;
        private System.Windows.Forms.GroupBox groupBoxEquipamentos;
        private System.Windows.Forms.Button listEquipamentosLivres;
        private System.Windows.Forms.Button listLastWeekFree;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

