using App.ADO.NET;
using App.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    public partial class ExportAluguerXmlForm : Form
    {
        public ExportAluguerXmlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.EntityFramework)
            {
                using (EfCommand cmd = new EfCommand())
                {
                    cmd.ExportarXml(textBox1.Text, textBox2.Text);
                }
            } 
            else 
            {
                AlugueresDataAdapter ada = new AlugueresDataAdapter();
                ada.exportAlugueresToXml(textBox1.Text, textBox2.Text);
            }
        }
    }
}
