using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaSantiAPI_REST.Models
{
    public class Libro
    {
        // Atributos
        public long Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public string URL { get; set; }

        // Constructores
        public Libro() { }

        public Libro(long id, string titulo, DateTime fechaPublicacion, double precio, int stock)
        {
            Id = id;
            Titulo = titulo;
            FechaPublicacion = fechaPublicacion;
            Precio = precio;
            Stock = stock;
        }
    }

    //public class LibroDTO : Libro
    //{
    //    // Atributos adicionales
    //    public string Autor { get; set; }
    //    public string Tema { get; set; }
    //    public string Editorial { get; set; }
    //    public int Edicion { get; set; }
    //    public string Formato { get; set; }

    //    // Constructor
    //    public LibroDTO() { }

    //    public LibroDTO(long id, string titulo, DateTime fechaPublicacion, double precio, int stock,
    //                    string autor, string tema, string editorial, int edicion, string formato)
    //        : base(id, titulo, fechaPublicacion, precio, stock)
    //    {
    //        Autor = autor;
    //        Tema = tema;
    //        Editorial = editorial;
    //        Edicion = edicion;
    //        Formato = formato;
    //    }
    //}
}