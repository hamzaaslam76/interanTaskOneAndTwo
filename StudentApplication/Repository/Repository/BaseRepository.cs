using Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Repository.Repository
{
    public class BaseRepository<T> : _IAllRepository<T> where T : class
    {
        private context _DbConetxt;
        private IDbSet<T> dbEntity;
        public BaseRepository()
        {
            _DbConetxt = new context();
            dbEntity = _DbConetxt.Set<T>();
           
        }
        public bool AddRange(List<T> List)
        {
            if (List != null)
            {
                _DbConetxt.Set<T>().AddRange(List);
                return true;
            }
            return false;
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
        public bool DeleteModel(T Model)
        {
            if (Model != null)
            {
                dbEntity.Remove(Model);
                Save();
                return true;
            }
            return false;
        }
        public bool DeleteRange(List<T> List)
        {
            if (List != null)
            {
                _DbConetxt.Set<T>().RemoveRange(List);
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
            _DbConetxt.Entry(Model).State =  System.Data.Entity.EntityState.Modified;
             Save();
            return true;
        }
    }
}
