using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.Reporting.Map.WebForms.BingMaps;

public partial class LogIn : System.Web.UI.Page
{
	UserDetails userDetails = new UserDetails();
	protected void Page_Load(object sender, EventArgs e)
    {

    }

 

    private bool AuthenticateUser(string email, string password)
    {
        bool isValid = false;
        string constr = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE email = @Email AND password=@Password"))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection = con;
                con.Open();
                isValid = (int)cmd.ExecuteScalar() > 0;
             
            }
        }
        return isValid;
    }

    private UserDetails GetUserDetails(string email)
    {
       
        // Create a SqlConnection object to connect to the database
        using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"))
        {
            // Create a SqlCommand object to execute the SQL query
            string query = "SELECT CNIC, Name, DOB, Address, Blood_Group, email, Gender, Phone, Role, password FROM [User] WHERE Email = @email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);

            // Open the database connection
            connection.Open();

            // Execute the SQL query and retrieve the user details
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                userDetails.CNIC = reader.GetString(0);
                userDetails.Name = reader.GetString(1);
                userDetails.DOB = reader.GetDateTime(2);
                userDetails.Address = reader.GetString(3);
                userDetails.BloodGroup = reader.GetString(4);
                userDetails.Email = reader.GetString(5);
                userDetails.Gender = reader.GetString(6);
                userDetails.Phone = reader.GetString(7);
                userDetails.Role = reader.GetString(8);
                userDetails.Password = reader.GetString(9);
            }

            // Close the reader and the connection
            reader.Close();
            connection.Close();
        }

        return userDetails;
    }

    protected void Unnamed3_Click(object sender, EventArgs e)
    {

		string email = Email.Text;
		string password = Password.Text;
		//Console.WriteLine(regnum);
		//Console.WriteLine(password);
		//System.Diagnostics.Debug.WriteLine(regnum);
		//System.Diagnostics.Debug.Write(password);

		//// Check if the username and password are valid
		bool isValidUser = AuthenticateUser(email, password);
		string is_admin = "T";

		if (isValidUser)
		{
			// Save the user's name in a session variable
			//string name = GetName(regnum);
			//Session["Name"] = name;

			UserDetails userDetails = GetUserDetails(email);
			// Save the user's details in a session variable
			Session["UserDetails"] = userDetails;


			// Check for role
			using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True"))
			{
				string query = "select is_Admin from[User] as u inner join faculty as f on u.CNIC = f.CNIC where u.CNIC = @val;";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@val", userDetails.CNIC);

				// Open the database connection
				connection.Open();

				// Execute the SQL query and retrieve the user details
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					is_admin = reader.GetString(0);

				}

				// Close the reader and the connection
				reader.Close();
				connection.Close();
			}


			if (userDetails.Role == "Student")
			{

				System.Diagnostics.Debug.WriteLine(userDetails.Name);
				System.Diagnostics.Debug.WriteLine(userDetails.Role);
				System.Diagnostics.Debug.WriteLine(userDetails.Email);
				Response.Redirect("Student_Home.aspx");
			}
			// Redirect to Home.aspx\
			if (is_admin == "T")
			{
				Response.Redirect("ADashBoard.aspx");
			}
			else if (is_admin == "F")
			{
				Response.Redirect("Default.aspx?reg=" + userDetails.CNIC);
			}

		}
        else
        {
			System.Diagnostics.Debug.WriteLine("Error ");
		}


		



	}

}

//Data Source = DESKTOP - O0HK97I\SQLEXPRESS; Initial Catalog = Final_Project; Integrated Security = True

