using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class lists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnListUsers_Click(object sender, EventArgs e)
        {
            /*tUsersView.DataSource = new bllAuthentication().GetAllUsers();
            lstUsersView.DataBind();
            lstUsersView.Visible = true;
            lstProducts.Visible = false; 
            lstLocationsView.Visible = false;
            lstMovementsView.Visible = false;**/
            Response.Redirect("listUsers.aspx");

        }

        protected void btnListProduct_Click(object sender, EventArgs e)
        {
            /*lstUsersView.Visible = false;
            lstProducts.Visible = true;
            lstLocationsView.Visible = false;
            lstMovementsView.Visible = false;
            lstProducts.DataSource = new bllProducts().GetAllProducts();
            lstProducts.DataBind();*/
            Response.Redirect("listProducts.aspx");
        }

        protected void btnListLocations_Click(object sender, EventArgs e)
        {

            /*lstUsersView.Visible = false;
            lstProducts.Visible = false;
            lstMovementsView.Visible = false;
            lstLocationsView.Visible = true;
            lstLocationsView.DataSource = new bllLocation().GetAll();
            lstLocationsView.DataBind();*/
            Response.Redirect("listLocations.aspx");
        }

        protected void btnListMovements_Click(object sender, EventArgs e)
        {
           /* lstUsersView.Visible = false;
            lstProducts.Visible = false;
            lstLocationsView.Visible = false;
            lstMovementsView.Visible = true;
            lstMovementsView.DataSource = new bllMovements().GetAll();
            lstMovementsView.DataBind();*/
            Response.Redirect("listOperations.aspx");
        }

        protected void lstProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if(e.CommandName == "cmdFilter")
            {
                   
            }
        }
    }
}