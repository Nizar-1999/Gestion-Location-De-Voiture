using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_Location_De_Voiture.DAL.Reposetory;
using System.Data.SqlClient;
using Gestion_Location_De_Voiture.DAL;
using Gestion_Location_De_Voiture.BL;
using Gestion_Location_De_Voiture.rapport;

namespace Gestion_Location_De_Voiture
{
    public partial class FormReservation : Form
    {
        ReservationRepository reservationrepository = new ReservationRepository();
     

        public FormReservation()
        {
            InitializeComponent();
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( comboBox2.IsEmptyCombobox() || textBox3.IsEmpty() || textBox4.IsEmpty() )
            {
                MessageBox.Show("Veuilez saisir les information requises");
            }
            else
            {
               
                

                var Idcontrat = textBox1.Text;
                var client = comboBox1.SelectedValue.ToString() ;
                var voiture = comboBox4.SelectedValue.ToString();
                var datedebi = DateTime.Parse(dateTimePicker1.Text);
                var datefin = DateTime.Parse(dateTimePicker2.Text);
                var montanttotal =decimal.Parse( textBox3.Text);

                var idpaye = reservationrepository.IDpaye();
                var prixpaye =decimal.Parse (textBox4.Text);
                var modepaye = comboBox2.Text;

                var repository = new ReservationRepository();
                repository.Create(Idcontrat, (string)client, voiture, datedebi, datefin, montanttotal);
                repository.createpaye(idpaye,Idcontrat, prixpaye, modepaye) ;
                MessageBox.Show("Créé avec succès");
                textBox1.Text = reservationrepository.ID();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();


                dataGridView1.DataSource = reservationrepository.GetAll();
            }
        }

        private void FormReservation_Load(object sender, EventArgs e)
        {
            //
            List<string> option = new List<string>() { "Espéces","Chéque", "Bank" };
            comboBox2.DataSource = option;
            //
            textBox1.Text = reservationrepository.ID();
            //combobox affiche client
            comboBox1.DataSource = reservationrepository.selctBox();
            comboBox1.ValueMember = "ID_CLT";
            comboBox1.DisplayMember = "name";
            //combobox affiche voiture
            comboBox4.DataSource = reservationrepository.selctBoxvoiture();
            comboBox4.ValueMember = "Matricule";
            comboBox4.DisplayMember = "name";
            //
            dataGridView1.DataSource = reservationrepository.GetAll();
        }
       

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var prix = reservationrepository.GetByVoiture(comboBox4.SelectedValue.ToString());
            
            textBox2.Text = prix.ToString();
            

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime datefins = dateTimePicker2.Value;
            DateTime datedibe = dateTimePicker1.Value;
            TimeSpan jour = datefins - datedibe;

            decimal rete =decimal.Parse( textBox2.Text);
            var numberofday = jour.Days;
            textBox3.Text = (numberofday * rete).ToString();

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var SelectCellValue = dataGridView1.CurrentCell.Value.ToString();
            //    DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (res == DialogResult.OK)
            //    {
            //        reservationrepository.Supprim(SelectCellValue);
            //        dataGridView1.DataSource = reservationrepository.GetAll();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Préciser l'identifiant ou l'option dans la relation!");
            //}
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reservationrepository.Search(textBox7.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var f = dataGridView1.CurrentCell.Value.ToString();
            FormRapport frm = new FormRapport(f);
            frm.ShowDialog();
            
        }
    }

}

