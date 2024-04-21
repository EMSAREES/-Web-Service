using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace Biblioteca
{
    /// <summary>
    /// Descripción breve de wbLibros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wbLibros : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-7LSE7ES\SQLEXPRESS; Initial Catalog = Biblioteca; User = sa; Password = 6870021");
       

        [WebMethod]   
        public DataSet obtener(int id)
        {
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Libros WHERE id = {id}", con);
                da.Fill(ds);       

            }
            catch (Exception ex) 
            {
            
            }
            finally 
            { 
                con.Close();

            }

            return ds;
        }

        [WebMethod]
        public string guardar(int id, int isbn, string titulo, string autor, string genero)
        {
            string msj = "";
            SqlCommand comand = new SqlCommand("spLibros", con);
            comand.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Clear();
            comand.Parameters.AddWithValue("@OP", 2);
            comand.Parameters.AddWithValue("@id", id);
            comand.Parameters.AddWithValue("@ISBN", isbn);
            comand.Parameters.AddWithValue("@Titulo", titulo);
            comand.Parameters.AddWithValue("@Autor", autor);
            comand.Parameters.AddWithValue("@Genero", genero);

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                comand.ExecuteNonQuery();
                msj = "Proceso Exitosos";
            }
            catch (Exception e)
            {
                msj = "Proceso fallido " + e.ToString();
            }
            finally
            {
                con.Close();
            }

            return msj;
        }

        [WebMethod]
        public string eliminar(int id)
        {
            string msj = "";
            SqlCommand comando = new SqlCommand("spLibros", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@OP", 3);
            comando.Parameters.AddWithValue("@id", id);

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                comando.ExecuteNonQuery();
                msj = "Proceso exitoso";
            }
            catch (Exception e)
            {
                msj = "Proceso fallido" + e.ToString();
            } 
            finally
            {
                con.Close();
            }
            
            return msj;
        }

        [WebMethod]
        public DataSet buscar(string filtro) 
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter($"select * from Libros where Titulo LIKE '%{filtro}%'", con);
            da.Fill(ds);
            return ds;


        }

    }
}
