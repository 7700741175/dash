using Dash_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dash_API.DAO
{
    public abstract class AbstractDAO<T> : Repository
    {
        public abstract List<T> GetAll(T param, int idEmpresa);
        public abstract T GetByID(int id, int idEmpresa);
        public abstract bool Insert(T param, int idEmpresa);
        public abstract bool Update(T param, int idEmpresa);
        public abstract bool Delete(T param, int idEmpresa);
    }
}