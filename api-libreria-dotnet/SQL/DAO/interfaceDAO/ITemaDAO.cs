using MySql.Data.MySqlClient;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.DAO
{
    // Info: https://rjcodeadvance.com/patrones-de-software-que-es-patron-de-diseno-parte-2/
    // AutoMapper: https://bravedeveloper.com/2021/12/24/aplicando-el-patron-dto-y-mapeando-objetos-con-automapper-en-un-web-api-con-net-core/
    public interface ITemaDAO : GenericDAO<DTO_Tema,int>
    {
        // Aqui podran implementarse cosa mas singulares de Temas
        // Ej getTemasByAutor , auqnue haya que liar los libros por medio

    }
}