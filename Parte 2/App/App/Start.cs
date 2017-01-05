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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        public void GoToAddPromotion(object sender, EventArgs e)
        {
            PromotionAddForm frm = new PromotionAddForm();
            frm.Show();
        }

        public void GoToRemovePromotion(object sender, EventArgs e)
        {
            PromotionRemoveForm prf = new PromotionRemoveForm();
            prf.Show();
        }

        public void GoToUpdatePromotion(object sender, EventArgs e)
        {
            PromotionUpdateForm frm = new PromotionUpdateForm();
            frm.Show();
        }

        public void GoToRemoveAluguer(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

        public void GoToInsertAluguer(object sender, EventArgs e)
        {
            AluguerAddForm aaf = new AluguerAddForm();
            aaf.Show();
        }

        public void GoToRemovePrice(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

        public void GoToUpdatePrice(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

        public void GoToAddPrice(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

        public void GoToListEquipamentosLivres(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

        public void GoToListLastWeekFree(object sender, EventArgs e)
        {
            //Not implemented goes to point (e)
        }

    }
}
