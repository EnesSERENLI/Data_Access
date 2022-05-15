using DataAccess.Context;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class BaseRespository<T> : IRepository<T> where T : BaseEntity
    {
        MovieTheatherContext db = new MovieTheatherContext();

        //Create
        public string Create(T model)
        {
            string result = "";
            try
            {                
                db.Set(typeof(T)).Add(model);
                db.SaveChanges();
                result = $"Data added!";
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;                
            }          
        }

        //Delete
        public string Delete(int id)
        {
            try
            {
                var deleted = db.Set(typeof(T)).Find(id);
                db.Set(typeof(T)).Remove(deleted);
                db.SaveChanges();
                return "Data deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        //Search
        public T FindById(int id)
        {
            return db.Set(typeof(T)).Cast<T>().Find(id);
        }

        //List
        public List<T> GetList()
        {
            return db.Set(typeof(T)).Cast<T>().ToList();
        }

        //Update
        public string Update(T model)
        {
            try
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Data updated!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
