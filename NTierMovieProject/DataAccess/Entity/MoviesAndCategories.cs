using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class MoviesAndCategories:BaseEntity
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }
        //Mapping
        public Category Category { get; set; }
        public Movie Movie { get; set; }
    }
}
