using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscosDBAdoNet.Clases
{
    class Disco
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string UrlImagenTapa { get; set; }

        //propiedad de la clase Estilo
        public Estilos Estilo { get; set; }

        //propiedad de la clase Tipo
        public Tipos Tipo { get; set; }

    }
}
