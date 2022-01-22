using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marketwebform.Publico
{  
    
    public class CrudPro
    {
        DataSet1 datset = new DataSet1();
        public int NumberPro()
        {
            int count = 0;
            String sql = "SELECT COUNT(id) AS rows FROM productos";
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
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            if (count == 0)
            {
                return count;
            }
            else
            {
                String sql2 = "SELECT MAX(id) FROM productos";
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

        public string NombreCategoria (String idc)
        {
            String nombrecat = "";
            String sql = "SELECT nombre FROM categorias WHERE id = @idcat";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    // int val = 0;
                    conx.Open();

                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@idcat", idc));
                    SqlDataReader redid = command.ExecuteReader();
                    while (redid.Read())
                    {
                        nombrecat = redid[0].ToString();

                    }

                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            return nombrecat;
        }

        public string Nombreimagen(String idpro)
        {
           String Imagen = "";
            String sql = "SELECT imagen FROM productos WHERE id = @idcap";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    // int val = 0;
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@idcap", idpro));
                    SqlDataReader reddat = command.ExecuteReader();
                    while(reddat.Read())
                    {
                        Imagen = reddat[0].ToString();

                    }

                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            return Imagen;
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
                    SqlDataAdapter adap = new SqlDataAdapter(command);
                    adap.Fill(datset);
                    
                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

        }

        public void GuardarPro(String idcat, String nombrepro, String imagenoriginal, String stock, String precio)
        {
            String sql = "INSERT INTO productos (nombre, stock, precio, categoria, imagen) VALUES (@nombrepro, @stock, @precio, @categoria, @imagen)";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add("@nombrepro", SqlDbType.Text).Value = nombrepro;
                    command.Parameters.Add("@stock", SqlDbType.Decimal).Value = stock;
                    command.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                    command.Parameters.Add("@categoria", SqlDbType.Int).Value = idcat;
                    command.Parameters.Add("@imagen", SqlDbType.Text).Value = imagenoriginal;

                    command.ExecuteNonQuery();
                    conx.Close();

                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

        public void UpdatePro(String Id, String idcat, String nombrepro, string imagenoriginal, String stock, String precio)
        {
            String sql = "UPDATE productos SET nombre = @nombrepro, stock = @stock, precio = @precio, categoria =  @categoria, imagen = @imagen WHERE id = @id";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
                    command.Parameters.Add("@nombrepro", SqlDbType.Text).Value = nombrepro;
                    command.Parameters.Add("@stock", SqlDbType.Decimal).Value = stock;
                    command.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                    command.Parameters.Add("@categoria", SqlDbType.Int).Value = idcat;
                    command.Parameters.Add("@imagen", SqlDbType.Text).Value = imagenoriginal;

                    command.ExecuteNonQuery();
                    conx.Close();

                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

        public void EliminarPro(String id)
        {
            string sql = "DELETE FROM productos WHERE id = @id";
            try
            {

                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteNonQuery();
                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

    }
}