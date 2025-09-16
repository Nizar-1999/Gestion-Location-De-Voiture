using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Location_De_Voiture.DAL.Reposetory;
using Gestion_Location_De_Voiture.DAL.BaseReposetory;

namespace Gestion_Location_De_Voiture.DAL.Reposetory
{
   public class ClassClientsReposetory :ClassBase
    {
        public void Create(string Id,string Nom,string Prenom,string Permis ,string Tel,string Identite, DateTime DateNaissance)
        {
            var Clients = new CLIENT();
            Clients.ID_CLT = Id;
            Clients.NOM = Nom;
            Clients.PRENOM = Prenom;
            Clients.NUMBER_TELE = Tel;
            Clients.N_PERMIS = Permis;
            Clients.N_CART_NATIONAL = Identite;
            Clients.DATE_NISSANCE = DateNaissance;
            db.CLIENTS.Add(Clients);
            db.SaveChanges();
        }
        public string ID()
        {
            var count = db.CLIENTS.Count();
            if (count == 0)
                return "1";
            var ids = db.CLIENTS.Select(x => x.ID_CLT).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
            var max = numbres.Max();
            var newID = "" + (max + 1);
            return newID;

        }
        public dynamic GetAll()
        {
            var result = (from C in db.CLIENTS
                          select new { C.ID_CLT, C.NOM, C.PRENOM, C.N_PERMIS, C.NUMBER_TELE, C.N_CART_NATIONAL,C.DATE_NISSANCE }).ToList();

            return result;
        }


        public dynamic Search(string value)
        {
            

            return (from C in db.CLIENTS
                    where C.ID_CLT.Contains(value) ||
                          C.NOM.Contains(value) ||
                          C.PRENOM.Contains(value)||
                          C.NUMBER_TELE.Contains(value) ||
                          C.N_CART_NATIONAL.Contains(value)
                          
                    select new { C.ID_CLT, C.NOM, C.PRENOM, C.N_PERMIS, C.NUMBER_TELE, C.N_CART_NATIONAL, C.DATE_NISSANCE }).ToList();
        }
        public void Supprim(string value)
        {
            var Obj = (from x in db.CLIENTS
                       where x.ID_CLT == value
                       select x).FirstOrDefault();
            db.CLIENTS.Remove(Obj);
            db.SaveChanges();

        }
    }
}
