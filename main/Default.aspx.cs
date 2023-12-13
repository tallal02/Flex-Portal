using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static UserDetails;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string CNIC = Request.QueryString["reg"];

		System.Diagnostics.Debug.WriteLine(CNIC);

		if (!IsPostBack)
        {
            // Fetch the name and number from the database using SQL query
            string name = string.Empty;
            string number = string.Empty;
            string regID = string.Empty;    

			string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"; // Replace with the actual connection string
			using (SqlConnection connection = new SqlConnection(connectionString))
            {
				connection.Open();

				string query = "SELECT RegID\r\nFROM Faculty\r\nWHERE CNIC = @cnic;"; // Replace with the actual CNIC value
				using (SqlCommand command = new SqlCommand(query, connection))
				{
                    command.Parameters.AddWithValue("@cnic", CNIC);
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						regID = reader["RegID"].ToString();
		
					}
					reader.Close();
				}

				connection.Close();
			}

			System.Diagnostics.Debug.WriteLine(regID);

			connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"; // Replace with the actual connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name,RegID FROM Faculty INNER JOIN [USER] ON [USER].CNIC = Faculty.CNIC WHERE RegID = @val"; // Replace with the actual CNIC value
                using (SqlCommand command = new SqlCommand(query, connection))
                {
					command.Parameters.AddWithValue("@val", regID);
					SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        name = reader["Name"].ToString();
                        number = reader["RegID"].ToString();
                    }
                    reader.Close();
                }

                connection.Close();
            }

            lblWelcome.Text = "Welcome " + name + ", " + number;

            ///////////////
            ///

            connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"; // Replace with your actual connection string
     

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT c.Course_Code, c.Course_Name FROM Courses c INNER JOIN Teaches t ON c.Course_Code = t.Course_Code WHERE t.InstructorID = @val";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@val", regID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable coursesTable = new DataTable();
                        adapter.Fill(coursesTable);

                        GridViewCourses.DataSource = coursesTable;
                        GridViewCourses.DataBind();

                    }
                }
            }
            // Add hyperlink to each row in the grid
            foreach (GridViewRow row in GridViewCourses.Rows)
            {
                HyperLink courseLink = new HyperLink();
                courseLink.Text = row.Cells[1].Text; // Assuming the course name is in the second column (index 1)
                 // Assuming the course code is in the first column (index 0)
				courseLink.NavigateUrl = "Default2.aspx?CourseCode=" + row.Cells[0].Text + "&regID=" + regID;
				// Add the hyperlink control to the appropriate cell
				TableCell cell = row.Cells[1]; // Assuming the course name is in the second column (index 1)
                cell.Controls.Clear(); // Remove any existing controls in the cell
                cell.Controls.Add(courseLink);
            }

            //////////////
        }


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"); //Connection String
        conn.Open();
        SqlCommand cm;
        string query = "Select Count(*) from [User]";
        cm = new SqlCommand(query, conn);
        cm.ExecuteNonQuery();
        cm.Dispose();
        conn.Close();
    }

    protected void SetDistribution(object sender, EventArgs e)
    {
        Response.Redirect("Add_Weightage.aspx");

    }

    protected void btnSetDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default2.aspx");
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

    }
}