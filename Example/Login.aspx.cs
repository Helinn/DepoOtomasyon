using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Data;

namespace Example
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            bllAuthentication auth = new bllAuthentication();
            UserTable user = auth.Authenticate(txtUserName.Value, txtPassword.Value);
            if (user != null)
            {
                Session.Add("User", user);
                Response.Redirect("~/index.aspx");
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Kullanıcı Adı veya şifre yanlış.Tekrar deneyiniz\");", true);

            
            
        }
    }
}