using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Final_MIS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("MyApiRoute", "api/cart", "~/Api/CartApi.aspx");
            RouteTable.Routes.MapPageRoute("Delete", "api/cart/delete", "~/Api/DeleteCart.aspx");
            RouteTable.Routes.MapPageRoute("Update", "api/cart/update", "~/Api/UpdateCart.aspx");
            RouteTable.Routes.MapPageRoute("Checkout", "api/checkout", "~/Api/Checkout.aspx");
        }
    }
}