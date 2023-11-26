using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Final_MIS.User
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Sử dụng lớp Connection để lấy chuỗi kết nối
                string connectionString = Connection.GetConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng Product
                    string query = "SELECT ProductNumber, ProductName, ProductDescription, Price FROM Product";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong Repeater
                    rProducts.DataSource = dataTable;
                    rProducts.DataBind();
                }
            }
        }


    }

}
