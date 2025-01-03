using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiscosDBAdoNet.Clases
{
    class DiscoNegocio
    {

        public List <Disco> Listar() 
        {
            List <Disco> listaDiscos = new List<Disco>();//lista para agrupar los discos

            //conexion a la BD MySql
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS;  database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT  D.Id, D.Titulo, D.UrlImagenTapa, E.Descripcion AS ESTILO, T.Descripcion AS TIPO FROM DISCOS D JOIN ESTILOS E ON D.IdEstilo = E.Id JOIN TIPOSEDICION T ON D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Estilo = new Estilos();
                    aux.Tipo = new Tipos();

                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.Estilo.Descripcion = (string)lector["ESTILO"];
                    aux.Tipo.Descripcion = (string)lector["TIPO"];



                    listaDiscos.Add(aux);
                }

                conexion.Close();//cerramos la conexion
                return listaDiscos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            



            
        }

    }
}
