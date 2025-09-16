using System;
using System.Linq;
using Gestion_Location_De_Voiture.DAL.BaseReposetory;

namespace Gestion_Location_De_Voiture.DAL.Reposetory
{
    public class ReservationRepository :ClassBase
    {
        public void Create(string Id, string client, string voiture, DateTime datedibi, DateTime datefin, decimal montant)
        {
            var reservi = new CONTRAT();
            reservi.ID = Id;
            reservi.ID_CLT = client;
            reservi.MATRICULE = voiture;
            reservi.DATE_DEBUT = datedibi;
            reservi.DATE_FIN = datefin;
            reservi.MONTAN_TOTAL = montant;
           
            db.CONTRATs.Add(reservi);
            db.SaveChanges();
        }
        public void createpaye(string idpaye , string id , decimal prix , string modepaye)
        {
            var paye = new PAYE();
            paye.ID_PAYE = idpaye;
            paye.ID = id;
            paye.Prix_PAYE = prix;
            paye.MODE_PAYE = modepaye;

            db.PAYEs.Add(paye);
            db.SaveChanges();

        }
        public string ID()
        {
            var count = db.CONTRATs.Count();
            if (count == 0)
                return "Cont-1";
            var ids = db.CONTRATs.Select(x => x.ID).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(5, x.Length - 5)));
            var max = numbres.Max();
            var newID = "Cont-" + (max + 1);
            return newID;

        }
        public string IDpaye()
        {
            var count = db.PAYEs.Count();
            if (count == 0)
                return "1";
            var ids = db.PAYEs.Select(x => x.ID_PAYE).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
            var max = numbres.Max();
            var newID = "" + (max + 1);
            return newID;

        }
        public dynamic GetByVoiture(string id)
        {
            return (from c in db.VOITUREs
                    
                    where c.MATRICULE == id
                    
                    select c.MONTANT).FirstOrDefault();
        }
        public dynamic GetAll()
        {
            //var time = DateTime.Now.ToShortTimeString();
            var result = (from C in db.CONTRATs
                          join S in db.CLIENTS on C.ID_CLT equals S.ID_CLT
                          join V in db.VOITUREs on C.MATRICULE equals V.MATRICULE

                          select new { C.ID, S.NOM, S.PRENOM, S.N_CART_NATIONAL, S.N_PERMIS, V.MODELE, C.MATRICULE, C.DATE_DEBUT, C.DATE_FIN,C.MONTAN_TOTAL }).ToList();

            return result;
        }


        public dynamic Search(string value)
        {


            return (from C in db.CONTRATs
                    join S in db.CLIENTS on C.ID_CLT equals S.ID_CLT
                    where C.ID.Contains(value) ||
                          S.N_PERMIS.Contains(value) ||
                          C.MATRICULE.Contains(value) 
                         

                    select new { C.ID, S.N_PERMIS, C.MATRICULE, C.DATE_DEBUT, C.DATE_FIN, C.MONTAN_TOTAL }).ToList();
        }
        public void Supprim(string value)
        {
            var Obj = (from x in db.CONTRATs
                       where x.ID == value
                       select x).FirstOrDefault();
           
            
                db.CONTRATs.Remove(Obj);
                db.SaveChanges();
      
        }
        public dynamic selctBox()
        {
            return db.CLIENTS.AsEnumerable().Select(x => new { name = x.NOM+" "+x.PRENOM, x.ID_CLT }).ToList();
        }
        public dynamic selctBoxvoiture()
        {
            return db.VOITUREs.AsEnumerable().Select(x => new { name = x.MARQUE , x.MATRICULE }).ToList();
        }

    }
}
