using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UserTable user = (UserTable)Session["User"];
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lblUser.Text = user.Name.ToUpper().ToString()+" "+ user.Surname.ToUpper().ToString();
            }
        }

    }
}