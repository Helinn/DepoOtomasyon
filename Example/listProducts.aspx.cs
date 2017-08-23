using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class listProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lstProducts.DataSource = new bllProducts().GetAllProducts();
                lstProducts.DataBind();
            }
        }

        protected void btnListUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("listUsers.aspx");
        }

        protected void btnListLocations_Click(object sender, EventArgs e)
        {
            Response.Redirect("listLocations.aspx");
        }

        protected void btnListMovements_Click(object sender, EventArgs e)
        {
            Response.Redirect("listOperations.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                List<Products> lst = new bllProducts().GetAllProducts();
                lst = lst.Where(x => (string.IsNullOrEmpty(txtPrCode.Text) || (x.ProductCode.IndexOf(txtPrCode.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtPrName.Text) || (x.ProductName.IndexOf(txtPrName.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtBirim.Text) || (x.UnitType.IndexOf(txtBirim.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtTitle.Text) || (x.Title.IndexOf(txtTitle.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtStatus.Text) || (x.Title.IndexOf(txtTitle.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtCategory.Text) || (x.CategoryType.IndexOf(txtCategory.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtComment.Text) || (x.Comment.IndexOf(txtComment.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                                (string.IsNullOrEmpty(txtSerialNo.Text) || (x.SerialNum.Equals(int.Parse(txtSerialNo.Text))))
                    ).ToList();
                lstProducts.DataSource = lst;
                lstProducts.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", ex.Message, true);
                Response.Write(ex.Message);
            }

        }

        protected void txtPrCode_TextChanged(object sender, EventArgs e)
        {
            lstProducts.DataSource = new bllProducts().GetAllProducts();
            lstProducts.DataBind();
        }

    }
}