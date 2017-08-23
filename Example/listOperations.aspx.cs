using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class listOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lstMovementsView.DataSource = new bllMovements().GetAll();
                lstMovementsView.DataBind();
                ddlstType.DataSource = new bllOperations().GetAll();
                ddlstType.AppendDataBoundItems = true;
                ddlstType.DataTextField = "OperationType";
                ddlstType.DataValueField = "Id";
                ddlstType.DataBind();
                ddlstType.Items.Insert(0, new ListItem("", "-1"));
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

        protected void btnListLocations_Click(object sender, EventArgs e)
        {
            Response.Redirect("listLocations.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<Movements> lst = new bllMovements().GetAll();


            lst = lst.Where(x => (string.IsNullOrEmpty(txtUnit.Text) || (x.UserName.IndexOf(txtUser.Text,0,StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                           (string.IsNullOrEmpty(txtPrCode.Text) || (x.ProductCode.IndexOf(txtPrCode.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                           (string.IsNullOrEmpty(txtPrName.Text) || (x.ProductName.IndexOf(txtPrName.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                           (string.IsNullOrEmpty(ddlstType.SelectedItem.Text) || (x.MoveType.Equals(int.Parse(ddlstType.SelectedValue)))) &&
                           (string.IsNullOrEmpty(txtAmount.Text) || (x.MoveType.Equals(1) ? x.Amount.Equals(int.Parse(txtAmount.Text) * (-1)) : x.Amount.Equals(int.Parse(txtAmount.Text)))) &&
                           (string.IsNullOrEmpty(txtUnit.Text) || (x.UnitType.IndexOf(txtUnit.Text,0,StringComparison.CurrentCultureIgnoreCase)>-1))&&
                           (string.IsNullOrEmpty(txtDate.Text) || (x.DateOfMovement.ToString().IndexOf(txtDate.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1))).ToList();
            lstMovementsView.DataSource = lst;
            lstMovementsView.DataBind();

        }

        protected void txtPrCode_TextChanged(object sender, EventArgs e)
        {
            lstMovementsView.DataSource = new bllMovements().GetAll();
            lstMovementsView.DataBind();
        }

        protected void txtPrName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnListMovements_Click(object sender, EventArgs e)
        {

        }


    }
}