using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio2
{
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();
        }

        private void btnsalirprogra_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            this.Hide();
            menu.Show();
        }
    }
}
