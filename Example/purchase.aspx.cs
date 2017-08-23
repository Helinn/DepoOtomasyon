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
    public partial class purchase : System.Web.UI.Page
    {
        public const int constMoveType = 2;              //mal kabul için move type 2 
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                ddlstProduct.DataSource = new bllProducts().GetAllProducts();
                ddlstProduct.AppendDataBoundItems = true;
                ddlstProduct.DataTextField = "ProductCode";
                ddlstProduct.DataValueField = "Id";
                ddlstProduct.Items.Insert(0, new ListItem("", "-1"));
                ddlstProduct.DataBind();
                ddlstLocHall.DataSource = new bllHall().getAll();
                ddlstLocHall.DataTextField = "HallName";
                ddlstLocHall.DataValueField = "Id";
                ddlstLocHall.DataBind();
                ddlstLocStore.DataSource = new bllStore().getAll();
                ddlstLocStore.DataTextField = "StoreType";
                ddlstLocStore.DataValueField = "Id";
                ddlstLocStore.DataBind();
                ddlstStatus.DataSource = new bllStatus().GetAll();
                ddlstStatus.DataTextField = "StatusType";
                ddlstStatus.DataValueField = "Id";
                ddlstStatus.DataBind();
                List<Location> lstLocation = new bllLocation().GetAll();
                ddlstColon.DataSource = lstLocation.Select(x => x.Column).Distinct().ToList();
                ddlstColon.DataBind();
                ddlstShelf.DataSource = lstLocation.Select(x => x.Shelf).Distinct().ToList();
                ddlstShelf.DataBind();
                Calendar1.Visible = false;
            }
        }
        private void fillGrid(List<Stock> lstDispatching)
        {
            lstPurchaseView.DataSource = lstDispatching;
            lstPurchaseView.DataBind();
        }

        /*
         * Girilen değerlere ait bir stock Listede var mı kontrol edilecek
         * 
         * **/
        private bool FillGridByPCode(string pCode)
        {
            List<Stock> lst = new bllStock().GetAll();
            List<Stock> found = new List<Stock>();
            //string pcode = ddlstProduct.SelectedItem.Text.ToString();
            bool flag = false;
            foreach (Stock element in lst)
            {
                if (element.ProductCode.Equals(pCode) && element.Amount > 0)
                {
                    found.Add(element);
                    flag = true;
                }
                else
                    flag = false;
            }
            fillGrid(found);
            return flag;
        }
        private int FindProductID(string pCode)
        {
            List<Products> lstproducts = new bllProducts().GetAllProducts();
            int pid=-1;
            foreach(Products element in lstproducts)
            {
                if (element.ProductCode.Equals(pCode))
                {
                    pid = element.Id;
                }
            }
            return pid;
        }
        /*
         * Stock tablosu icinde aranan ürünü bulur.
         * **/
        private int SearchStock(Stock stock)
        {
            List<Stock> lst = new bllStock().GetAll();

            foreach (Stock element in lst)
            {
                if (element.ProductCode.Equals(stock.ProductCode) &&
                    element.StockStatuType.Equals(stock.StockStatuType) && element.ExpirationDate.Date.Equals(stock.ExpirationDate.Date) &&
                    element.Location.Equals(stock.Location))
                    return element.Id;
            }
            return -1;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bllStock stockTable = new bllStock();
            Stock _stock = new Stock();
           
            bool flag = false;  //Mal alımı başarılı mı kontrolü için
            Calendar1.Visible = false;
            try
            {
                int pID = (FindProductID(ddlstProduct.SelectedItem.Text));
                int amount = int.Parse(txtAmount.Text);
                DateTime dt1, dt2;

                int locId = stockTable.GetLocationID(ddlstLocStore.SelectedValue, ddlstLocHall.SelectedValue, ddlstColon.SelectedItem.Text, ddlstShelf.SelectedItem.Text);
                string LocStr = ddlstLocStore.SelectedItem.Text + " " + ddlstLocHall.SelectedItem.Text + "-" + ddlstColon.SelectedItem.Text + "-" + ddlstShelf.SelectedItem.Text;
                int statusId = int.Parse(ddlstStatus.SelectedValue);
                dt1 = DateTime.Now;
                dt2 = Calendar1.SelectedDate.Date.Add(DateTime.Now.TimeOfDay);
                if (dt2.CompareTo(dt1) < 0)
                {
                    throw new DateException();
                }
                _stock.Location = LocStr;
                _stock.ProductCode = ddlstProduct.SelectedItem.Text;
                _stock.ExpirationDate = dt2;
                _stock.RegistrationDate = dt1;
                _stock.StockStatuType = ddlstStatus.SelectedItem.Text;

                int StockID = SearchStock(_stock);
                if (StockID != -1)
                {
                    flag = stockTable.Purchase(StockID, amount);
                }
                else
                {
                    if ((stockTable.LocationControl(locId, pID)))
                        flag = stockTable.Insert(pID, amount, dt1, dt2, locId, statusId);
                    else
                        throw new LocationException();
                    StockID = SearchStock(_stock);
                }
                if (flag)
                {
                    UserTable user = (UserTable)Session["User"];
                  
                    new bllMovements().Insert(StockID, DateTime.Now, constMoveType, amount,user.Id);
                }
                FillGridByPCode(_stock.ProductCode);
            }
            catch (FormatException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Yanlış bilgi girdiniz.Tekrar deneyiniz\");", true);

            }
            catch (DateException)
            {
                txtExpDate.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"son kullanma tarihi kayıt tarihinden önce olamaz.Lütfen tekrar deneyiniz.\");", true);
            }
            catch (LocationException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Seçtiğiniz lokasyon dolu.Lütfen tekrar deneyiniz\");", true);
            }
           


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else if (Calendar1.Visible == true)
            {
                Calendar1.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtExpDate.Text = Convert.ToString(Calendar1.SelectedDate.Date.Add(DateTime.Now.TimeOfDay));
            Calendar1.Visible = false;
        }

        protected void ddlstProduct_TextChanged(object sender, EventArgs e)
        {
            List<Products> lst = new bllProducts().GetAllProducts();
            if (ddlstProduct.SelectedItem.Text != "")
            {
                string unitType = lst.Find(x => x.Id.Equals(int.Parse(ddlstProduct.SelectedValue.ToString()))).UnitType;
                lblUnit.Text = unitType.ToString();
            }
            else lblUnit.Text = "  ";
        }
    }
    class LocationException : Exception
    {
        public LocationException()
            : base()
        {

        }
    }
    class DateException : Exception
    {
        public DateException()
            : base()
        {

        }
    }

}