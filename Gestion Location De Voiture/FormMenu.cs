using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Location_De_Voiture
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormVoiture().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormClients().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormReservation().Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FormUtilisateur().Show();
        }
    }
}
