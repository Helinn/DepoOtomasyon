using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class listLocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lstLocationsView.DataSource = new bllLocation().GetAll();
                lstLocationsView.DataBind();
            }
        }

        protected void btnListUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("listUsers.aspx");
        }

        protected void btnListProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("listProducts.aspx");
        }

        protected void btnListMovements_Click(object sender, EventArgs e)
        {
            Response.Redirect("listOperations.aspx");
        }

        protected void btnFiltre_Click(object sender, EventArgs e)
        {
            try
            {
                List<Location> lst = new bllLocation().GetAll();
                lst = lst.Where(x => (string.IsNullOrEmpty(txtStore.Text) || (x.StoreType.IndexOf(txtStore.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                     (string.IsNullOrEmpty(txtHall.Text) || (x.HallType.IndexOf(txtHall.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                     (string.IsNullOrEmpty(txtColon.Text) || (x.Column.CompareTo(int.Parse(txtColon.Text)) == 0)) &&
                                     (string.IsNullOrEmpty(txtShelf.Text) || (x.Shelf.CompareTo(int.Parse(txtShelf.Text)) == 0))
                ).ToList();
                lstLocationsView.DataSource = lst;
                lstLocationsView.DataBind();
            }catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", ex.Message, true);
                Response.Write(ex.Message);

            }
            
        }

        protected void txtStore_TextChanged(object sender, EventArgs e)
        {
            lstLocationsView.DataSource = new bllLocation().GetAll();
            lstLocationsView.DataBind();
        }
    }
}