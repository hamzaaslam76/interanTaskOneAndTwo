using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface _IAllRepository<T> where T:class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int Modelid);
        void InsertModel(T Model);
        void DeleteModel(T Model);
        void UpdateModel(T Model);
        void    Save();

    }
}
