using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDetails userDetails;

        if (Session["UserDetails"] != null)
        {
            // Display the user's name
            userDetails = (UserDetails)Session["UserDetails"];

            System.Diagnostics.Debug.WriteLine(userDetails.Name);
            System.Diagnostics.Debug.WriteLine("HEYYYY");

            //Label1.Text = "Welcome, " + userDetails.FName + "<br>" + userDetails.Email;
            _name.Text = userDetails.Name.ToString();
            _dob.Text = userDetails.DOB.ToString();
            _cnic.Text = userDetails.CNIC.ToString();
            _gender.Text= userDetails.Gender.ToString();
            _email.Text = userDetails.Email.ToString();
            _address.Text = userDetails.Address.ToString();
            _phone.Text = userDetails.Phone.ToString();
            _role.Text = userDetails.Role.ToString();
        }

        userDetails = (UserDetails)Session["UserDetails"];
        string cnic_val = userDetails.CNIC;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True");
        SqlCommand c = new SqlCommand("select RegID,Salary from Faculty where CNIC = @cnic", con);
        c.Parameters.AddWithValue("@cnic", cnic_val);
        con.Open();
        SqlDataReader reader = c.ExecuteReader();
        if (reader.Read())
        {
            userDetails.ID = reader.GetString(0);
            userDetails.Salary = reader.GetInt32(1);
        }

        // Close the reader and the connection
        reader.Close();
        con.Close();

        _id.Text = userDetails.ID.ToString();
        _salary.Text = (userDetails.Salary.ToString()) + " PKR";

    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
}
