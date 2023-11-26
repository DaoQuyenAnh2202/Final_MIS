using Final_MIS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_MIS.Api
{
    public partial class UpdateCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    Response.Clear();
                    Response.ContentType = "application/json";
                    List<Cart> carts = null;
                    if (Session["cart"] == null)
                    {
                        carts = new List<Cart>();
                    }
                    else
                    {
                        carts = (List<Cart>)Session["cart"];
                    }
                    if (carts == null || carts.Count == 0)
                        Response.End();
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string requestBody = reader.ReadToEnd();
                        Cart cart = JsonConvert.DeserializeObject<Cart>(requestBody);
                        foreach (Cart c in carts)
                        {
                            if (c.productID == cart.productID)
                            {
                                c.quantity = cart.quantity;
                                c.money = c.price * c.quantity;
                                break;
                            }
                        }
                    }
                    Session["cart"] = carts;
                    Response.StatusCode = 200;
                    Response.Write("success");
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    return;
                }
                catch
                {
                    Response.Clear();
                    Response.ContentType = "application/json";
                    Response.End();
                }
            }
        }
    }
}