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
using Gestion_Location_De_Voiture.DAL;

namespace Gestion_Location_De_Voiture.rapport

{
    public partial class FormRapport : Form
    {
        MLR4Entities1 db = new MLR4Entities1();
        private string idcontrat;

        public FormRapport(string id )
        {
            InitializeComponent();
            idcontrat = id;
        }

        private void FormRapport_Load(object sender, EventArgs e)
        {
            //var db = new Classcontrat();
            var client = (from x in db.CLIENTS
                          join c in db.CONTRATs on x.ID_CLT equals c.ID_CLT
                          join v in db.VOITUREs on c.MATRICULE equals v.MATRICULE
                          where c.ID == idcontrat
                          select new { 
                              NOM = x.NOM ?? "", 
                              PRENOM = x.PRENOM ?? "", 
                              N_CART_NATIONAL = x.N_CART_NATIONAL ?? "", 
                              N_PERMIS = x.N_PERMIS ?? "" ,
                              MODEL = v.MODELE ?? "", 
                              MATRCULE = v.MATRICULE ?? "",
                              DATE_DEBUT = c.DATE_DEBUT ?? DateTime.MinValue, 
                              DATE_FIN = c.DATE_FIN ??  DateTime.MinValue,
                              MONTAN_TOTAL = c.MONTAN_TOTAL ?? 0,
                              ID = c.ID ?? ""

                          }).ToList();
            
            CrystalReportContrat contrats = new CrystalReportContrat();

            contrats.SetDataSource(client);

            crystalReportViewer1.ReportSource = contrats;
            crystalReportViewer1.RefreshReport();
        }
    }
}
