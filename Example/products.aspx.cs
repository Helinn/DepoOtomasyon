using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                fillGrid();

            }
        }
        private void fillGrid()
        {
            List<Products> lstProducts = new bllProducts().GetAllProducts();
            lstProductsView.DataSource = lstProducts;
            lstProductsView.DataBind();
        }
        protected void UrunEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/YeniUrun.aspx");
        }

        protected void lstProducts_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "cmdSil")
                {
                    bool flag = new bllStock().SearchInStock(int.Parse(e.CommandArgument.ToString()));
                    if (!flag)
                        new bllProducts().Delete(int.Parse(e.CommandArgument.ToString()));
                    else
                        throw new StockException();
                }
                else if (e.CommandName == "Update")
                {
                    Products newProduct = new Products();
                    newProduct.Id = int.Parse(e.CommandArgument.ToString());
                    newProduct.ProductCode = (e.Item.FindControl("lblpcode") as Label).Text;
                    newProduct.ProductName = (e.Item.FindControl("txtPName") as TextBox).Text;
                    newProduct.UnitType = (e.Item.FindControl("lblUnitType") as Label).Text;
                    newProduct.Title = (e.Item.FindControl("lblTitle") as Label).Text;
                    newProduct.SerialNum = int.Parse((e.Item.FindControl("lblSerialNum") as Label).Text);
                    newProduct.StatusType = (e.Item.FindControl("lblStatus") as Label).Text;
                    newProduct.CategoryType = (e.Item.FindControl("lblCategory") as Label).Text;
                    newProduct.Comment = (e.Item.FindControl("txtComment") as TextBox).Text;
                    if (new bllProducts().Update(newProduct))
                    {
                        lstProductsView.EditIndex = -1;
                        // lstProductsView.DataBind();
                    }
                }
               /* else if (e.CommandName == "Cancel")
                {
                    lstProductsView.EditIndex = -1;
                    
                }*/
                fillGrid();
            }
            catch (StockException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Stokta bulunan ürünü silemezsiniz\");", true);

            }
        }

        protected void lstProductsView_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lstProductsView.EditIndex = e.NewEditIndex;
            fillGrid();
        }

        protected void lstProductsView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            
                lstProductsView.EditIndex = -1;
                fillGrid();
            

        }

        protected void lstProductsView_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lstProductsView.EditIndex = -1;
            fillGrid();
        }

    }
}
class StockException : Exception
{
    public StockException()
        : base()
    {

    }
}