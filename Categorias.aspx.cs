using Marketwebform.Publico;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Marketwebform
{
   
    public partial class Categorias : System.Web.UI.Page
    {
        CrudCat cat = new CrudCat();
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

         
        }

       

        protected void GridCat_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            GridCat.PageIndex = e.NewPageIndex;
        }
       

        public void NuevoClick(object sender, EventArgs e)
        {
           
            int numberid = cat.NumberCat();
            catinid.Value = numberid.ToString();
            catnombre.Value = ""; 
        }

        public void GuardarClick(object sender, EventArgs e)
        {
            cat.AddCat(catnombre.Value);

          

            GridCat.Visible = true;
           // CrudCat.Consultardatos();
            GridCat.DataBind();
            UpdatePanel1.Update();

            int numberid = cat.NumberCat();
            catinid.Value = numberid.ToString();
            catnombre.Value = "";


        }

     

        public void EliminarClick(object sender, EventArgs e)
        {
            cat.DeleteCat(catinid.Value);
            GridCat.DataBind();
            UpdatePanel1.Update();

            int numberid = cat.NumberCat();
            catinid.Value = numberid.ToString();
            catnombre.Value = "";
        }

        public void ModificarClick(object sender, EventArgs e)
        {
            
            cat.ModificarCat(catinid.Value , catnombre.Value );
            GridCat.DataBind();
            UpdatePanel1.Update();

            int numberid = cat.NumberCat();
            catinid.Value = numberid.ToString();
            catnombre.Value = "";
        }

       
        protected void GridCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Selectedrow")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                string id = GridCat.Rows[row].Cells[0].Text;
                string nombre = GridCat.Rows[row].Cells[1].Text;
                catinid.Value = id.ToString();
                catnombre.Value = nombre.ToString();
                catinid.DataBind();
                catnombre.DataBind();
                UpdatePanel2.Update();

            }
            
        }
    }
}