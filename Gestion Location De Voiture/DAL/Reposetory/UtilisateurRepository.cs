using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Location_De_Voiture.DAL.BaseReposetory;

namespace Gestion_Location_De_Voiture.DAL.Reposetory
{
    public class UtilisateurRepository : ClassBase
    {
        public void Create(string Id, string username, string password)
        {
            var utilis = new UTILISATEUR();
            utilis.ID = Id;
            utilis.USERNAME = username;
            utilis.PASSWORD = password;
           

            db.UTILISATEURs.Add(utilis);
            db.SaveChanges();
        }
        
        public void Supprim(string value)
        {
            var Obj = (from x in db.UTILISATEURs
                       where x.ID == value
                       select x).FirstOrDefault();


            db.UTILISATEURs.Remove(Obj);
            db.SaveChanges();

        }
        public dynamic GetAll()
        {
            var result = (from C in db.UTILISATEURs
                         
                          select new { C.ID,C.USERNAME, C.PASSWORD }).ToList();

            return result;
        }
        public string ID()
        {
            var count = db.UTILISATEURs.Count();
            if (count == 0)
                return "1";
            var ids = db.UTILISATEURs.Select(x => x.ID).ToList();
            var numbres = ids.Select(x => int.Parse(x.Substring(0, x.Length - 0)));
            var max = numbres.Max();
            var newID = "" + (max + 1);
            return newID;

        }
        
        
    }
}
