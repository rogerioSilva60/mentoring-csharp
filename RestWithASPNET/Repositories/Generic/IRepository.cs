using RestWithASPNET.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNET.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T t);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T t);
        void Delete(long id);
        bool Exists(long id);
    }
}
