using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class YeniKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(Session["User"] == null )
            {
                Response.Redirect("Login.aspx");
            }
                if (!IsPostBack)
                {
                    ddlstDep.DataSource = new bllDepartment().GetAll();
                    ddlstDep.DataTextField = "DepartmentName";
                    ddlstDep.DataValueField = "Id";
                    ddlstDep.DataBind();
                    ddlstRole.DataSource = new bllRole().GetAll();
                    ddlstRole.DataTextField = "UserType";
                    ddlstRole.DataValueField = "Id";
                    ddlstRole.DataBind();
                }
        }


        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            bllAuthentication userAuthentication = new bllAuthentication();
            List<UserTable> userList = userAuthentication.GetAllUsers();
   
            UserTable usr = new UserTable()
            {
                DepartmentId = int.Parse(ddlstDep.SelectedValue),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Username = txtUsername.Text,
                Password = txtPass.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNum.Text,
                Comment = txtComment.Text,
                RoleID = int.Parse(ddlstRole.SelectedValue)
            };
            if (!userAuthentication.UNameContains(usr))
            {
                bool flag = userAuthentication.Insert(usr);
                if (flag)
                    Response.Redirect("users.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Bu kullanıcı adı kullanımda.Lütfen tekrar deneyiniz\");", true);
                txtUsername.Text = "";
            }
            

            

        }
    }
}