using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security;

namespace DiscosConDByADONET.Clases
{
    class DiscosData
    {
        public List<Discos> Listar() 
        {
            List <Discos> lista = new List <Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server =FEDECODETRABAJO\\SQLEXPRESS; database =DISCOS_DB; integrated security =true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT D.Id, D.Titulo, D.UrlImagenTapa, E.Descripcion AS Estilos, T.Descripcion AS Tipo\r\nFROM DISCOS D\r\nJOIN ESTILOS E ON D.IdEstilo = E.Id\r\nJOIN TIPOSEDICION T ON D.IdTipoEdicion = T.Id;";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read()) 
                {
                    Discos aux = new Discos();
                    aux.Estilo = new Estilos();
                    aux.Tipo = new Tipo();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo.Descripcion = (string)lector["Estilos"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    lista.Add(aux);
                }


                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
