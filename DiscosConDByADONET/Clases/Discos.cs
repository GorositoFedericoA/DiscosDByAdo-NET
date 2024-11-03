using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscosConDByADONET.Clases
{
    public class Discos
    {
        public int Id { get; set; }

        public string Titulo { get; set; }    

        public string UrlImagenTapa { get; set; }

        public Estilos Estilo { get; set; }

        public Tipo Tipo { get; set; }

    }
}
