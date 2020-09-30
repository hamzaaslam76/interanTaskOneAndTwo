
using Data.DataModdels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
   public class context:DbContext
    {
       public context():base("StudentConnactionString")
        {
         
        }
        public DbSet<student> students { get; set; }
    }
}
