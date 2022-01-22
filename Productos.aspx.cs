using Marketwebform.Publico;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marketwebform
{
    public partial class Productos : System.Web.UI.Page
    {
        CrudPro Pro = new CrudPro();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = (string)Session["usuario"];

               if (!IsPostBack)
               {
                   if (userid == "" || userid == null)
                   {
                       Response.Redirect("~/Login.aspx");
                   }

               }
            Opentable();
        }

       protected void vaciar()
        {
            Proid.Value = Pro.NumberPro().ToString();
            NombrePro.Disabled = false;
            NombrePro.Value = "";
            precio.Disabled = false;
            precio.Value = "";
            Cantidad.Disabled = false;
            Cantidad.Value = "";
            selcateg.Value = "";
            nombreimagen.Value = "";
            Image1.ImageUrl = "~/Imagenes/default.jpg";
            UpdatePaneldetalle.Update();
           
        }

        protected void NuevoProClick(object sender, EventArgs a)
        {
            vaciar();
            guardarPro.Enabled = true;
            modificarPro.Enabled = false;
        }
        
        protected void GuardarProClick(object sender, EventArgs a)
        {
            /* int tamanio = FileUpload1.PostedFile.ContentLength;
             ImagenOrigen = new byte[tamanio];
             FileUpload1.PostedFile.InputStream.Read(ImagenOrigen, 0, tamanio);
             Bitmap imagenOrBinaria = new Bitmap(FileUpload1.PostedFile.InputStream);*/
            string nombredireccion = "";
            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();
                int tamanio = FileUpload1.PostedFile.ContentLength;

               // Response.Write(ext + " , " + tamanio);

                if(ext == ".jpg" && tamanio <= 1080000)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Imagenes/" + FileUpload1.FileName));
                    nombredireccion = FileUpload1.FileName;
                }
                Pro.GuardarPro(selcateg.Value, NombrePro.Value, nombredireccion, Cantidad.Value, precio.Value);

                guardarPro.Enabled = false;
                vaciar();
            }
            else
            {
                Response.Write("Debes adjuntar una imagen");
            }
            GridPro.DataBind();
            UpdatePanelPro.Update();
          
            
           // string ImagenDataUrl64 = "data:imagen/jpg;base64," + Convert.ToBase64String(ImagenOrigen);
           // Image1.ImageUrl = ImagenDataUrl64; 
        }

        protected void ModificarProClick(object sender, EventArgs a)
        {
            string nombredireccion = "";
            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                ext = ext.ToLower();
                int tamanio = FileUpload1.PostedFile.ContentLength;

                Response.Write(ext + " , " + tamanio);

                if (ext == ".jpg" && tamanio <= 1080000)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Imagenes/" + FileUpload1.FileName));
                    nombredireccion = FileUpload1.FileName;
                }
            }
            else
            {
                nombredireccion = nombreimagen.Value; 
            }

            Pro.UpdatePro(Proid.Value, selcateg.Value, NombrePro.Value, nombredireccion, Cantidad.Value, precio.Value);
            modificarPro.Enabled = false;
            vaciar();
            

        }

        protected void GridPro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Selectedrow")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridPro.Rows[row].Cells[0].Text;
                string nombre = GridPro.Rows[row].Cells[1].Text;
                string stock = GridPro.Rows[row].Cells[2].Text;
                string price = GridPro.Rows[row].Cells[3].Text;
                string categ = GridPro.Rows[row].Cells[4].Text;
                string imagen = Pro.Nombreimagen(id);
                Proid.Value = id.ToString();
                NombrePro.Value = nombre.ToString();
                Cantidad.Value = stock.ToString();
                precio.Value = price.ToString();
                selcateg.Value = categ.ToString();
                nombreimagen.Value = imagen.ToString();
                Image1.ImageUrl = "~/Imagenes/" + imagen;
                modificarPro.Enabled = true;
                modificarPro.DataBind();
                UpdatePanelBottons.Update();  
                UpdatePaneldetalle.Update();
            }

            if (e.CommandName == "EliminarPro")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridPro.Rows[row].Cells[0].Text;
                Pro.EliminarPro(id);
                GridPro.DataBind();
                UpdatePanelPro.Update();
            }

        }

        protected void findcat()
        {
            Label1.Text = Pro.NombreCategoria(selcateg.Value);
            UpdatePaneldetalle.Update(); 
        }

        protected void Opentable()
        {
            String sql = "SELECT * FROM productos";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    // int val = 0;
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                    SqlDataAdapter dat = new SqlDataAdapter(command);
                    DataTable bus = new DataTable();
                    dat.Fill(bus);
                    GridPro.DataSource = bus;
                    GridPro.DataBind();
                    UpdatePanelPro.Update();


                    conx.Close();
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

        protected void filtroBus(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM productos WHERE nombre LIKE '" + filtro.Value + "%'";
            try
            {
                using (SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["ConcormarketConnectionString"].ToString()))
                {
                    // int val = 0;
                    conx.Open();
                    SqlCommand command = new SqlCommand(sql, conx);
                   // command.Parameters.Add(new SqlParameter("@nomb", filtro.Value));
                    SqlDataAdapter dat = new SqlDataAdapter(command);
                    DataTable bus = new DataTable();
                    dat.Fill(bus);
                    GridPro.DataSource = bus;
                    GridPro.DataBind();
                    UpdatePanelPro.Update(); 
                   
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