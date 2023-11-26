using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_MIS.User
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["schoolID"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = Connection.GetConnectionString();
                using (con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Retrieve the latest schoolID from the database
                    string latestSchoolID;
                    using (SqlCommand latestIdCmd = new SqlCommand("SELECT TOP 1 SchoolID FROM AffiliatedSchool ORDER BY SchoolID DESC", con))
                    {
                        latestSchoolID = latestIdCmd.ExecuteScalar() as string;
                    }

                    // Increment the schoolID for the new registration
                    int latestNumber = int.Parse(latestSchoolID.Substring(2));
                    string newSchoolID = "SC" + (latestNumber + 1).ToString("D2");

                    using (cmd = new SqlCommand("INSERT INTO AffiliatedSchool (SchoolID, SchoolName, Phone, Email, Address, NumberOfStudents) VALUES (@SchoolID, @SchoolName, @Phone, @Email, @Address, @NumberOfStudents)", con))
                    {
                        cmd.Parameters.AddWithValue("@SchoolID", newSchoolID);
                        cmd.Parameters.AddWithValue("@SchoolName", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                        int numberOfStudents;
                        if (int.TryParse(txtNumofStu.Text, out numberOfStudents))
                        {
                            cmd.Parameters.AddWithValue("@NumberOfStudents", numberOfStudents);
                        }
                        else
                        {
                            lblMsg.Text = "Invalid input for Number of Students";
                            lblMsg.Visible = true;
                            return;
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Lưu thông tin đăng nhập vào Session
                            Session["schoolID"] = newSchoolID;

                            lblMsg.Text = "Registration successful!";
                            lblMsg.Visible = true;
                            string registrationUrl = $"Registration.aspx?SchoolID={newSchoolID}";
                            Response.Redirect("Default.aspx", true);
                            Context.ApplicationInstance.CompleteRequest();
                            ClearFormFields();
                        }
                        else
                        {
                            lblMsg.Text = "Registration failed. Please try again.";
                            lblMsg.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "An error occurred during registration. Please try again.";
                lblMsg.Visible = true;
            }
        }

        private void ClearFormFields()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtNumofStu.Text = string.Empty;
        }

    }
}