using Final_MIS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_MIS.Api
{
    public partial class CartApi : System.Web.UI.Page
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
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string requestBody = reader.ReadToEnd();
                        Cart cart = JsonConvert.DeserializeObject<Cart>(requestBody);
                        bool check = false;
                        foreach (Cart c in carts)
                        {
                            if(c.productID == cart.productID)
                            {
                                c.quantity++;
                                c.money = c.price * c.quantity;
                                check = true;
                                break;
                            }
                        }
                        if (!check)
                        {
                            string connectionString = Connection.GetConnectionString();

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Truy vấn dữ liệu từ bảng Product
                                string query = $"SELECT ProductNumber, ProductName, Price FROM Product WHERE ProductNumber='{cart.productID}'";
                                SqlCommand command = new SqlCommand(query, connection);
                                SqlDataAdapter adapter = new SqlDataAdapter(command);
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                if(dataTable.Rows.Count > 0)
                                {
                                    cart.price = Decimal.Parse(dataTable.Rows[0][2].ToString());
                                    cart.productName = dataTable.Rows[0][1].ToString();
                                    cart.money = cart.price * cart.quantity;
                                    carts.Add(cart);
                                }
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
            Response.Clear();
            Response.ContentType = "application/json";
            Response.StatusCode = 404;
            Response.End();
        }
    }
}