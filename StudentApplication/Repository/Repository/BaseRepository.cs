using Data.Context;
using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BaseRepository<T> : _IAllRepository<T> where T : class
    {
        private context _DbConetxt;
        private DbSet<T> dbEntity;
        public BaseRepository()
        {
            _DbConetxt = new context();
            dbEntity = _DbConetxt.Set<T>();
           
        }
        public bool DeleteModel(int ModelId)
        {
            T Model = dbEntity.Find(ModelId);
            if(Model !=null)
            {
                dbEntity.Remove(Model);
                Save();
                return true;
            }
            return false;
            
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelById(int Modelid)
        {
            return dbEntity.Find(Modelid);
        }

        public bool InsertModel(T Model)
        {
            if (Model != null)
            {
                dbEntity.Add(Model);
                Save();
                return true;
            }
            return false;
        }

        public void Save()
        {
            _DbConetxt.SaveChanges();

        }

        public bool UpdateModel(T Model)
        {
            dbEntity.Attach(Model);
            _DbConetxt.Entry(Model).State =  System.Data.Entity.EntityState.Modified;
             Save();
            return true;
        }
    }
}
