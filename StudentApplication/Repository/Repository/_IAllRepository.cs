﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface _IAllRepository<T> where T:class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int Modelid);
        bool InsertModel(T Model);
        bool DeleteModel(int Model);
        bool UpdateModel(T Model);
        void    Save();

    }
}