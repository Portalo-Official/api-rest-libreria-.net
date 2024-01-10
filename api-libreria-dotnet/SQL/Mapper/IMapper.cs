using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public interface IMapper<T, P>
    {
        T MapToDto(P reader);
       
    }

}
