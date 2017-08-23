using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;


namespace Example
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(!IsPostBack) 
            {
                UserTable user = (UserTable)Session["User"];
                if (user.Role == "user")
                {
                    YeniKayit.Enabled = false;
                }

                fillGrid();     
            }
            
        }

        private void fillGrid()
        {
            List<UserTable> userList = new bllAuthentication().GetAllUsers();
            lstUsers.DataSource = userList;
            lstUsers.DataBind();
           
        }

        protected void YeniKayıtClick(object sender, EventArgs e)
        {
            Response.Redirect("~/YeniKayit.aspx");
        }

        protected void lstUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            UserTable currentUser = (UserTable)Session["User"];
            if (currentUser.Role == "user")
            {
                Button delete = (Button)e.Item.FindControl("btnSil");
                delete.Enabled = false;
            }
            else
            {
                if (e.CommandName == "cmdSil")
                {
                    new bllAuthentication().Delete(int.Parse(e.CommandArgument.ToString()));
                }
                else if(e.CommandName == "Update")
                {
                    UserTable CurrentUser = (UserTable)Session["User"];
                    if (CurrentUser.Role != "user")
                    {
                        UserTable user = new UserTable();
                        user.Id = int.Parse(e.CommandArgument.ToString());
                        user.Name = (e.Item.FindControl("txtname") as TextBox).Text;
                        user.Surname = (e.Item.FindControl("txtsurname") as TextBox).Text;
                        user.Username = (e.Item.FindControl("txtuname") as TextBox).Text;
                        user.Email = (e.Item.FindControl("txtEmail") as TextBox).Text;
                        user.PhoneNumber = (e.Item.FindControl("txtPhone") as TextBox).Text;
                        user.Comment = (e.Item.FindControl("txtComment") as TextBox).Text;
                        if(new bllAuthentication().Update(user))
                        {
                            lstUsers.EditIndex = -1;
                        }
                    }
                }
                fillGrid();
            }
        }

        protected void lstUsers_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lstUsers.EditIndex = e.NewEditIndex;
            fillGrid();
        }

        protected void lstUsers_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            lstUsers.EditIndex = -1;
            fillGrid();
        }

        protected void lstUsers_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lstUsers.EditIndex = -1;
            fillGrid();
        }
    }
}