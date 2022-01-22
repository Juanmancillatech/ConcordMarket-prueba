using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marketwebform
{
    
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_click(object sender, EventArgs e)
        {
            var usuario = this.usuario.Text;
            var clave = this.clave.Text.Replace("--"," ");
            if(usuario == "Admin" && clave == "Admin")
            {
                Session["usuario"] = usuario;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (usuario == "" || clave == "")
                {
                    this.error.Text = "Debes completar todos los datos";
                }
                else
                {
                    this.error.Text = "Usuario o clave incorrecta!!";
                }
            }
            

            
        }
    }
}