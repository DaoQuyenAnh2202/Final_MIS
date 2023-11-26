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
using Final_MIS.Models;
using System.Security.Policy;
using System.Drawing;

namespace Final_MIS.Api
{
    public partial class Checkout : System.Web.UI.Page
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
                    if(Session["schoolID"] == null)
                    {
                        Response.StatusCode = 401;
                        Response.End();
                    }
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
                    string connectionString = Connection.GetConnectionString();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = $"SELECT * FROM AffiliatedSchool WHERE SchoolID = '{Session["schoolID"]}'";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        string latestSchoolID;
                        using (SqlCommand latestIdCmd = new SqlCommand("SELECT TOP 1 OrderNumber FROM Order1 ORDER BY OrderNumber DESC", connection))
                        {
                            latestSchoolID = latestIdCmd.ExecuteScalar() as string;
                        }

                        // Increment the schoolID for the new registration
                        int latestNumber = int.Parse(latestSchoolID.Substring(2));
                        string newSchoolID = "OR" + (latestNumber + 1).ToString("D2");

                        Decimal sumMoney = 0;
                        foreach (Final_MIS.Models.Cart cart in carts)
                        {
                            sumMoney += cart.money;
                        }

                        if (dataTable.Rows.Count == 1)
                        {
                            query = $"SET DATEFORMAT MDY INSERT INTO Order1 VALUES('{newSchoolID}',N'đã đặt hàng','{DateTime.Now.ToShortDateString()}','{DateTime.Now.AddDays(1).ToShortDateString()}','{Math.Round(sumMoney)}','NV01','{Session["schoolID"]}')";
                            SqlCommand latestIdCmd = new SqlCommand(query , connection);
                            latestIdCmd.ExecuteNonQuery();
                        }
                        foreach (Final_MIS.Models.Cart cart in carts)
                        {
                            string orderDetailID;
                            using (SqlCommand latestIdCmd2 = new SqlCommand("SELECT TOP 1 OrderDetailID FROM OrderDetail ORDER BY OrderDetailID DESC", connection))
                            {
                                orderDetailID = latestIdCmd2.ExecuteScalar() as string;
                            }

                            // Increment the schoolID for the new registration
                            int orderDetailNumber = int.Parse(orderDetailID.Substring(2));
                            string orderDetailIDNew = "OD" + (orderDetailNumber + 1).ToString("D2");
                            query = $"INSERT INTO OrderDetail VALUES('{orderDetailIDNew}','{newSchoolID}','{cart.productID}','{cart.quantity}')";
                            SqlCommand latestIdCmd = new SqlCommand(query, connection);
                            latestIdCmd.ExecuteNonQuery();
                        }
                    }

                    Session["cart"] = null;
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