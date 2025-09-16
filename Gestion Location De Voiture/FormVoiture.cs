using Gestion_Location_De_Voiture.BL;
using Gestion_Location_De_Voiture.DAL.Reposetory;
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
    public partial class FormVoiture : Form
    {
        VoitureRepository voiturrepository = new VoitureRepository();
        public FormVoiture()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.IsEmpty() || textBox3.IsEmpty() || textBox2.IsEmpty() || textBox4.IsEmpty() || comboBox2.IsEmptyCombobox()||comboBox3.IsEmptyCombobox())
            {
                MessageBox.Show("Veuilez saisir les information requises");
            }
            else
            {
                var matricule = textBox1.Text;
                var marque = textBox3.Text;
                var model = textBox2.Text;
                var prix =decimal.Parse( textBox4.Text);
                var carburant = comboBox2.Text;
                var Status = comboBox3.Text;
                

                var repository = new VoitureRepository();
                repository.Create(matricule, marque, model, prix, carburant, Status);
                MessageBox.Show("Créé avec succès");
                textBox1.Clear();
              
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
               

                dataGridView1.DataSource = voiturrepository.GetAll();
            }
        }

        private void FormVoiture_Load(object sender, EventArgs e)
        {
            //
            List<string> option = new List<string>() { "essence", "diesel"};
            comboBox2.DataSource = option;
            //
            List<string> options2 = new List<string>() { "OUI", "NO" };
            comboBox3.DataSource = options2;
            //
            dataGridView1.DataSource = voiturrepository.GetAll();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = voiturrepository.Search(textBox7.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectCellValue = dataGridView1.CurrentCell.Value.ToString();
                DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    voiturrepository.Supprim(SelectCellValue);
                    dataGridView1.DataSource = voiturrepository.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Préciser l'identifiant ou l'option dans la relation!");
            }
        }
    }
}
