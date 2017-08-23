using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class listUsers : System.Web.UI.Page
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
            lstUsersView.DataSource = new bllAuthentication().GetAllUsers();
            lstUsersView.DataBind();
        }

        protected void btnListProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("listProducts.aspx");
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
            List<UserTable> lst = new bllAuthentication().GetAllUsers();
            lst = lst.Where(x => ((txtUserName == null && txtUserName.Text == "") || (x.Username.IndexOf(txtUserName.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtName == null && txtName.Text == "") || (x.Name.IndexOf(txtName.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtSurname == null && txtSurname.Text == "") || (x.Surname.IndexOf(txtSurname.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtDepartment == null && txtDepartment.Text == "") || (x.Department.IndexOf(txtDepartment.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtEmail == null && txtEmail.Text == "") || (x.Email.IndexOf(txtEmail.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtPhoneNum == null && txtPhoneNum.Text == "") || (x.PhoneNumber.IndexOf(txtPhoneNum.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1)) &&
                ((txtComment == null && txtComment.Text == "") || (x.Comment.IndexOf(txtComment.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1))
                ).ToList();
            lstUsersView.DataSource = lst;
            lstUsersView.DataBind();
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            lstUsersView.DataSource = new bllAuthentication().GetAllUsers();
            lstUsersView.DataBind();
        }
    }
}