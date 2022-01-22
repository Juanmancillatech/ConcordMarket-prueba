using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Marketwebform.Publico
{
    public class CrudCat
    {
       
        public int NumberCat()
        {
            int count = 0;
            String sql = "SELECT COUNT(id) AS rows FROM categorias";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                   // int val = 0;
                    conx.Open();

                    SqlCommand command = new SqlCommand(sql, conx);
                   // command.Parameters.Add(new SqlParameter("@rows", val));
                    count = Convert.ToInt32(command.ExecuteScalar());

                    conx.Close();
                }
            }
            catch(Exception ex)
            {
                _ = ex.Message;
            }  

            if(count == 0)
            {
                return count;
            }
            else
            {
                String sql2 = "SELECT MAX(id) FROM categorias";
                try
                {
                    using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                    {
                        // int val = 0;
                        conx.Open();

                        SqlCommand command = new SqlCommand(sql2, conx);
                        count = Convert.ToInt32(command.ExecuteScalar());

                        conx.Close();
                    }
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                return count;
            }

        }

        public void Consultardatos()
        {
            String sql = "SELECT * FROM categorias";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    // int val = 0;
                    conx.Open();

                    SqlCommand command = new SqlCommand(sql, conx);
                    // command.Parameters.Add(new SqlParameter("@rows", val));
                    command.ExecuteNonQuery();
                  
                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

        }

        public void AddCat(String nombCategoria)
        {
            String sql = "INSERT INTO categorias (nombre) VALUES (@nombrecat)";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@nombrecat", nombCategoria));
                    command.ExecuteNonQuery();
                    conx.Close();

                }
            }
            catch(Exception ex)
            {
                _ = ex.Message;
            }

        }

        public void DeleteCat(string idCat)
        {
            string sql = "DELETE FROM categorias WHERE id = @id";
            try
            {
                
                using(SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@id", idCat));
                    command.ExecuteNonQuery();
                    conx.Close();
                }
            }
            catch(Exception ex)
            {
                _ = ex.Message;
            }
        }

        public void ModificarCat(string id, string nombrecat)
        {
            string sql = "UPDATE categorias SET nombre = @nombrecat WHERE id = @id";
            try
            {
                using(SqlConnection conx = new SqlConnection (ConfigurationManager .ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.Parameters.Add(new SqlParameter("@nombrecat", nombrecat));
                    command.ExecuteNonQuery();
                    conx.Close(); 
                }
            }catch(Exception ex)
            {
              _= ex.Message;
            }
        }
    }
}