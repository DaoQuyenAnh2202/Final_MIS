using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Final_MIS.User
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = Connection.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["schoolID"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            string schoolID = GetSchoolID(email, phone);

            if (!string.IsNullOrEmpty(schoolID))
            {
                // Lưu thông tin đăng nhập vào Session
                Session["schoolID"] = schoolID;

                // Chuyển hướng về trang Default.aspx
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid email or phone number. Please try again.";
                lblMsg.Visible = true;
            }
        }

        private string GetSchoolID(string email, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SchoolID FROM AffiliatedSchool WHERE Email = @Email AND Phone = @Phone";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }
    }
}