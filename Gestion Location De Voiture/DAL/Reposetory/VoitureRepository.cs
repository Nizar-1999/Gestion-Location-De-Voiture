using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Location_De_Voiture.DAL.BaseReposetory;

namespace Gestion_Location_De_Voiture.DAL.Reposetory
{
    public class VoitureRepository: ClassBase
    {
        public void Create(string matricule, string marque, string model, Decimal prix, string carburant, string Status)
        {
            var voiture = new VOITURE();
            voiture.MATRICULE = matricule;
            voiture.MARQUE = marque;
            voiture.MODELE = model;
            voiture.MONTANT = prix;
            voiture.CARBURANT = carburant;
            voiture.DISPONIBLE = Status;
            db.VOITUREs.Add(voiture);
            db.SaveChanges();
        }
       
        public dynamic GetAll()
        {
            var result = (from C in db.VOITUREs
                          select new { C.MATRICULE, C.MARQUE, C.MODELE, C.CARBURANT, C.DISPONIBLE , Prix=C.MONTANT}).ToList();

            return result;
        }


        public dynamic Search(string value)
        {


            return (from C in db.VOITUREs
                    where C.MATRICULE.Contains(value) ||
                          C.MARQUE.Contains(value) 
                         

                    select new { C.MATRICULE, C.MARQUE, C.MODELE, C.CARBURANT, C.DISPONIBLE, Prix = C.MONTANT }).ToList();
        }
        public void Supprim(string value)
        {
            var Obj = (from x in db.VOITUREs
                       where x.MATRICULE == value
                       select x).FirstOrDefault();
            db.VOITUREs.Remove(Obj);
            db.SaveChanges();

        }
    }
}
