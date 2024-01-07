using pruebaSantiAPI_REST.Models;
using pruebaSantiAPI_REST.SQL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.SQL.Mapper
{
    public class TemaMapper : IMapper<DTO_Tema, Tema>
    {
        public DTO_Tema MapToDto(Tema poco)
        {
            return new DTO_Tema
            {
                Id = poco.Id,
                Tipo = poco.Tipo
               
            };
        }

        public Tema MapToPoco(DTO_Tema dto)
        {
            return new Tema
            {
                Id = dto.Id,
                Tipo = dto.Tipo
                
            };
        }
    }
}