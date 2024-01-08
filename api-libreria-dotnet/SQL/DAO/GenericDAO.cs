using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSantiAPI_REST.SQL.DAO
{
    public interface GenericDAO<T, ID>
    {
        void create(T entity);
        T read(ID id_entity);
        void update(T entity);
        void delete(ID id_entity);
        List<T> findAll();
    }
}
