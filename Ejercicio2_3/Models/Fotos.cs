using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_3.Models
{
    public class Fotos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public byte[] foto { get; set; }
        public string descripcion { get; set; }
    }
}
