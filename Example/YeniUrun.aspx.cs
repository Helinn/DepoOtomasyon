using Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class YeniUrun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ddlstCategory.DataSource = new bllCategories().GetAll();
                ddlstCategory.DataTextField = "CategoryName";
                ddlstCategory.DataValueField = "Id";
                ddlstCategory.DataBind();
                ddlstUnit.DataSource = new bllUnits().GetAll();
                ddlstUnit.DataTextField = "UnitType";
                ddlstUnit.DataValueField = "Id";
                ddlstUnit.DataBind();
               
                ddlstStatus.DataSource = new bllStatus().GetAll();
                ddlstStatus.DataTextField = "StatusType";
                ddlstStatus.DataValueField = "Id";
                ddlstStatus.DataBind();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            bllProducts productLib = new bllProducts();
            List<Products> productList = productLib.GetAllProducts();
            bool control=true;
            
            Products product = new Products()
            {
                ProductName = txtPName.Text,
                ProductCode = txtPcode.Text,
                ProductCategoryID = int.Parse(ddlstCategory.SelectedValue),
                Comment = txtComm.Text,
                UnitID = int.Parse(ddlstUnit.SelectedValue),
                Title = txtTitle.Text,
                SerialNum = int.Parse(txtSerialNo.Text),
                StatusID = int.Parse(ddlstStatus.SelectedValue)
            };
            if (control == true)
            {
                try
                {
                    if (!productLib.PCodeContains(product))
                    {
                        bool flag = productLib.Insert(product);
                        if (flag)
                        {
                            Response.Redirect("products.aspx");
                        }
                    }

                    else
                    {
                        throw new StockException();
                        
                    }
                }
                catch(StockException)
                {
                    txtPcode.Text = "";
                    txtPName.Text = "";
                    txtSerialNo.Text = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Seri numarası veya ürün kodu bulunan ürün ekleyemezsiniz.Tekrar deneyiniz\");", true);
                }
            }
        }
    }
}