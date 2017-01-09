﻿using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AluguerRemoveForm : Form
    {
        public AluguerRemoveForm()
        {
            InitializeComponent();
        }

        private void buttonRemoverAluguer_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                AEnimaEntities ctx = new AEnimaEntities();
                ctx.RemoverAluguer(textBox1.Text);
                MessageBox.Show("Aluguer removed.");
            }
            #region ADO
            else
            {
            AdoCommand cmd = new AdoCommand();
            MessageBox.Show(cmd.executeProcedure(
                    (command) => { cmd.removeAluguerProcedure(command, textBox1.Text); },
                    "Aluguer removido com sucesso. ",
                    "Remover aluguer falhado: %s"
                ));
            }
            #endregion
            this.Close();
        }
    }
}
