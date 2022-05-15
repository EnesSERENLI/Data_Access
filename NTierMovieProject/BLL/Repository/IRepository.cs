using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Concrete
        
        //Create
        string Create(T model);
        //List
        List<T> GetList();
        //Update
        string Update(T model);
        //Delete
        string Delete(int id);

        T FindById(int id);
    }
}
