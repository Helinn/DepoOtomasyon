using Data;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Example
{
    public partial class reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                ReportStock.ProcessingMode = ProcessingMode.Local;
                ReportStock.LocalReport.DataSources.Clear();
                ReportStock.LocalReport.ReportPath = "StockReport.rdlc";
                ReportDataSource datasource = new ReportDataSource("StockReport", new bllStock().GetAll());
                ReportStock.LocalReport.DataSources.Add(datasource);

                
            }
        }
    }
}