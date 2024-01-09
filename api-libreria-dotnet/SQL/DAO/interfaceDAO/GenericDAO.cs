using pruebaSantiAPI_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSantiAPI_REST.SQL.DAO
{
    public interface GenericDAO<T, ID>
    {
        Response create(T entity);
        T read(ID id_entity);
        Response update(T entity);
        Response delete(ID id_entity);
        List<T> findAll();
    }
}
