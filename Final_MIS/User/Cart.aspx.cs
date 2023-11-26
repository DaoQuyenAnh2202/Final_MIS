using Final_MIS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_MIS.User
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cart"] != null)
                {
                    List<Final_MIS.Models.Cart> carts = (List<Final_MIS.Models.Cart>)Session["cart"];
                    Decimal sumMoney = 0;
                    foreach (Final_MIS.Models.Cart cart in carts)
                    {
                        sumMoney += cart.money;
                    }
                    sumPrice.Text = sumMoney.ToString("C0");
                    rCarts.DataSource = carts;
                    rCarts.DataBind();
                }
            }
        }
    }
}