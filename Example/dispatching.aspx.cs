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
    
    public partial class dispatching : System.Web.UI.Page
    {
        public const int constMoveType = 1;              //sevkiyat için move type 1 
        public static int totalAmount = 0;
        private List<int> IDlist = new List<int>();
        private bool Amountflag = false;              //miktarın dolduğunu kontrol etmek için flag
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                txtSevk.Text = CalculateTotal(false, 0).ToString();
                totalAmount = 0;
                ddlstPCode.DataSource = new bllProducts().GetAllProducts();
                ddlstPCode.AppendDataBoundItems = true;
                ddlstPCode.DataTextField = "ProductCode";
                ddlstPCode.DataValueField = "Id";
                ddlstPCode.DataBind();
                ddlstPCode.Items.Insert(0, new ListItem("", "-1"));
            }   
        }
        private void fillGrid(List<Stock> lstDispatching)
        {
            lstDispatching.Sort((a, b) => a.ExpirationDate.Date.CompareTo(b.ExpirationDate.Date));
            lstDispatchsView.DataSource = lstDispatching;
            lstDispatchsView.DataBind();
        }
        private void fillGrid()
        {
            List<Stock> lstDispatching = new bllStock().GetAll();
            lstDispatching.Sort((a, b) => a.ExpirationDate.Date.CompareTo(b.ExpirationDate.Date));
            lstDispatchsView.DataSource = lstDispatching;
            lstDispatchsView.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            txtSevk.Text = "";
            totalAmount = 0;
            if (!txtAmount.Text.Any() || ddlstPCode.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "Scripts", "alert(\"Ürün kodu ve miktarını giriniz\");", true);
            }
            else
            {

                Search();
                txtSevk.Visible = true;
                lblSevk.Visible = true;
                btnSevk.Visible = true;
            }
        }
        public string getColor(int amount)
        {
            int newamount;
            if (!txtAmount.Text.Any())
                newamount = 0;
            else
                newamount = int.Parse(txtAmount.Text);
            if (amount < newamount)
                return "red";
            else
                return "";
        }
        private bool Search()
        {
            List<Stock> lst = new bllStock().GetAll();
            List<Stock> found = new List<Stock>();
            int amount;
            if (!txtAmount.Text.Any())
                amount = 0;
            else
                amount = int.Parse(txtAmount.Text);
            string pcode = ddlstPCode.SelectedItem.Text;
            bool flag=false;
            foreach (Stock element in lst)
            {
                if (element.ProductCode.Equals(pcode) && element.Amount>0)
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

         protected void chckAmount_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if ((totalAmount != 0) && (chk.Checked==true) &&(string.IsNullOrEmpty(txtSevk.Text) || (int.Parse(txtSevk.Text) > int.Parse(txtAmount.Text))))
            {
                chk.Checked = false;

                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "Scripts", "alert(\"Yeterli ürün seçtiniz. Lütfen Sevk Et butonuna basınız\");", true);
                Amountflag = true;
                
            }
            if(chk.Checked && Amountflag == false)      //checkbox işaretlendiyse 
            {
                if (totalAmount < int.Parse(txtAmount.Text) && (totalAmount < (totalAmount + int.Parse(chk.Text))))    //istenen miktar toplanan mitardan büyük ise 
                {                                                                                                     //ve toplanan miktar check edilen miktardan küçük ise 
                    totalAmount += int.Parse(chk.Text);         //toplananmiktar += istenen miktar
                    txtSevk.Text = totalAmount.ToString();
                }    
            }
            else
            {

                if (Amountflag != true && ((int.Parse(txtSevk.Text) - int.Parse(chk.Text)) >= 0) && 
                    ((((totalAmount > (totalAmount - (int.Parse(chk.Text)))) || //toplanan miktar 
                    (totalAmount > int.Parse(txtAmount.Text)) || 
                    (int.Parse(chk.Text)) < int.Parse(txtAmount.Text))) ||
                    (int.Parse(txtSevk.Text) - int.Parse(chk.Text)) > int.Parse(txtAmount.Text)))
                {
                    totalAmount -= int.Parse(chk.Text);
                    txtSevk.Text = totalAmount.ToString();
                }
            }
            
                
        }
        protected int CalculateTotal(bool Calcflag,int amount)
        {
            if (Calcflag)
                totalAmount += amount;
            else if(!Calcflag && (totalAmount-amount <= totalAmount))
            {
                totalAmount -= amount;
            }
            return totalAmount;
        }
        protected void btnSevk_Click(object sender, EventArgs e)
        {
            UserTable user = (UserTable)Session["User"];
            txtSevk.Text = "0";
            List<Stock> lstStock = new List<Stock>();
            bllStock stock = new bllStock();
            bool Sevkflag =false;      //sevk başarılı mı kontrolü için

            if (user != null)
            {
                foreach (ListViewItem item in lstDispatchsView.Items)
                {

                    if ((item.FindControl("chckAmount") as CheckBox).Checked == true)
                    {
                        int ID = (int.Parse((item.FindControl("lblID") as Label).Text.Trim()));
                        int StockAmount = int.Parse((item.FindControl("chckAmount") as CheckBox).Text.Trim());
                        lstStock.Add(new Stock()
                        {
                            Id = ID,
                            Amount = StockAmount
                        });
                      
                        int a = item.DisplayIndex;


                    }
                }
                    int newAmount = int.Parse(txtAmount.Text), controlAmount = 0;
                    if (lstStock.Count > 0)
                    {
                        for (int i = 0; i < lstStock.Count; i++)
                        {
                            controlAmount += lstStock[i].Amount;
                            if (newAmount > lstStock[i].Amount)
                                newAmount -= lstStock[i].Amount;

                            if (newAmount > lstStock[i].Amount)
                            {
                                Sevkflag = stock.Order(lstStock[i].Id, controlAmount);

                                if (Sevkflag)
                                    new bllMovements().Insert(lstStock[i].Id, DateTime.Now, constMoveType, (-controlAmount), user.Id);
                            }
                            else
                            {
                                Sevkflag = stock.Order(lstStock[i].Id, newAmount);
                                if (Sevkflag)
                                    new bllMovements().Insert(lstStock[i].Id, DateTime.Now, constMoveType, (-newAmount), user.Id);
                            }
                        }
                    }

                    fillGrid();
                
            }
        }

        protected void ddlstPCode_TextChanged(object sender, EventArgs e)
        {
            List<Products> lst = new bllProducts().GetAllProducts();
            if (ddlstPCode.SelectedItem.Text != "")
            {
                string unitType = lst.Find(x => x.Id.Equals(int.Parse(ddlstPCode.SelectedValue.ToString()))).UnitType;
                lblamount.Text = unitType.ToString();
            }
            else lblamount.Text = "  ";
        }
    }
}