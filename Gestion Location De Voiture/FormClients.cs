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
    public partial class FormClients : Form
    {
        ClassClientsReposetory classclt = new ClassClientsReposetory();
        public FormClients()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.IsEmpty() || textBox2.IsEmpty()|| textBox3.IsEmpty()|| textBox4.IsEmpty()|| textBox5.IsEmpty())
            {
                MessageBox.Show("Veuilez saisir les information requises");
            }
            else
            {
                var idclt = textBox6.Text;
                var name = textBox1.Text;
                var preno = textBox2.Text;
                var N_Permi = textBox3.Text;
                var tel = textBox4.Text;
                var ident = textBox5.Text;
                var nissance = DateTime.Parse( dateTimePicker1.Text);

                var repository = new ClassClientsReposetory();
                repository.Create(idclt, name, preno, N_Permi, tel, ident, nissance);
                MessageBox.Show("Créé avec succès");
                textBox6.Text = classclt.ID();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                dataGridView1.DataSource =classclt.GetAll();
            }
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            textBox6.Text = classclt.ID();
            dataGridView1.DataSource = classclt.GetAll();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectCellValue = dataGridView1.CurrentCell.Value.ToString();
                DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    classclt.Supprim(SelectCellValue);
                    dataGridView1.DataSource = classclt.GetAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Préciser l'identifiant ou l'option dans la relation!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = classclt.Search(textBox7.Text);
        }
    }
}
