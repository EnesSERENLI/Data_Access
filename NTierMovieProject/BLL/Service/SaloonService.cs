using DataAccess.Context;
using DataAccess.Entity;
using System.Collections.Generic;
using System.Linq;
namespace BLL.Service
{
    public class SaloonService
    {
        MovieTheatherContext db = new MovieTheatherContext();
        //Create
        public string CreateSaloon(Saloon saloon)
        {
            try
            {
                db.Saloons.Add(saloon);
                db.SaveChanges();
                return "Saloon added.!";
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }
        //List
        public List<Saloon> SaloonList()
        {
            return db.Saloons.ToList();
        }
        //Delete
        public string DeleteSaloon(int id)
        {
            try
            {
                Saloon deleted = db.Saloons.Find(id);
                if (deleted != null)
                {
                    db.Saloons.Remove(deleted);
                    return "Saloon deleted!";
                }
                else
                {
                    return "No such saloon information available!";
                }
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }
        //Update
        public string UpdateSaloon(Saloon saloon)
        {
            try
            {
                //Saloon updated = db.Saloons.Find(saloon.ID);
                //updated.Capacity = saloon.Capacity;
                //updated.Name = saloon.Name;
                //db.SaveChanges();

                db.Entry(saloon).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Saloon updated";
            }
            catch (System.Exception ex)
            {

                return ex.Message;
            }
        }
        
    }
}
