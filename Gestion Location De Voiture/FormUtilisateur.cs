using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_Location_De_Voiture.BL;
using Gestion_Location_De_Voiture.DAL.Reposetory;

namespace Gestion_Location_De_Voiture
{
    public partial class FormUtilisateur : Form
    {
        UtilisateurRepository utilisateurrepository = new UtilisateurRepository();
        public FormUtilisateur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( textBox3.IsEmpty() || textBox4.IsEmpty() )
            {
                MessageBox.Show("Veuilez saisir les information requises");
            }
            else
            {
                var id= textBox1.Text;
                var username = textBox3.Text;
                var password = textBox4.Text;
                
               

                var repository = new UtilisateurRepository();
                repository.Create(id, username, password);
                MessageBox.Show("Créé avec succès");
                textBox1.Text = utilisateurrepository.ID();
                textBox3.Clear();
                textBox4.Clear();
               

                dataGridView1.DataSource = utilisateurrepository.GetAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectCellValue = dataGridView1.CurrentCell.Value.ToString();
                DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    utilisateurrepository.Supprim(SelectCellValue);
                    dataGridView1.DataSource = utilisateurrepository.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Préciser l'identifiant ou l'option dans la relation!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FormUtilisateur_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = utilisateurrepository.GetAll();
            textBox1.Text = utilisateurrepository.ID();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
