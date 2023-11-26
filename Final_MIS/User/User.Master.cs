using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_MIS.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.AbsolutePath.ToString().Contains("Default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");
            }
            else
            {
                form1.Attributes.Remove("class");
                Control sliderUserControl = (Control)Page.LoadControl("SliderUserControl1.ascx");

                pnlSliderUC.Controls.Add(sliderUserControl);
            }
            if (Session["SchoolID"] != null)
            {
                lbLoginOrLogout.Text = "Logout";
            }
            else
            {
                lbLoginOrLogout.Text = "Login";
            }
        }
        protected void lbLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (Session["SchoolID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Remove("SchoolID");
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}