using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
//using static UserDetails;
public partial class Attendance : System.Web.UI.Page
{
    string hassan_connection = "Data Source=DESKTOP-CBVGRRL\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
    string kulsum_connection = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        UserDetails userDetails;

        if (Session["UserDetails"] != null)
        {
            // Display the user's name
            userDetails = (UserDetails)Session["UserDetails"];
            Label1.Text = "Welcome, " + userDetails.Name + "<br>" + userDetails.Email;
            Label1.Visible = true;

        }

        userDetails = (UserDetails)Session["UserDetails"];
        string cnic_val = userDetails.CNIC;
        string rollnum = GetRollNumber(cnic_val);
        List<string> courseCodesList = GetCourseCodes(rollnum);

        foreach (string courseCode in courseCodesList)
        {
            Button btnCourse = new Button();
            btnCourse.Text = courseCode;
            // set other properties of the button, such as ID, class, etc.
            // add an event handler to the button to handle the click event
            // btnCourse.Click += new EventHandler(btnCourse_Click);
            btnCourse.Click += new EventHandler((s, ev) => btnCourse_Click(s, ev, rollnum));
            // add the button to the container, such as a panel or a placeholder
            // assuming you have a placeholder called PlaceHolder1 in the HTML markup
            PlaceHolder1.Controls.Add(btnCourse);
        }



    }
    public string GetRollNumber(string cnic)
    {
        string rollNumber = "";
        string connectionString = kulsum_connection;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT s.RollNum FROM Student s INNER JOIN[User] u ON u.CNIC = s.CNIC WHERE u.CNIC = @cnic";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@cnic", cnic);

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    rollNumber = reader.GetString(0);
                }
            }

            connection.Close();
        }

        return rollNumber;
    }

    public List<string> GetCourseCodes(string rollnum)
    {
        List<string> courseCodesList = new List<string>();

        string query = "SELECT Course_Code FROM PassedCourses WHERE Rollnum=@rollnum";

        using (SqlConnection connection = new SqlConnection(kulsum_connection))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@rollnum", rollnum);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string courseCode = reader.GetString(0);
                        courseCodesList.Add(courseCode);
                    }
                }
            }
        }

        return courseCodesList;
    }

    // event handler for the course button click event
    protected void btnCourse_Click(object sender, EventArgs e, string rollnum)
    {


        // get the course code from the button's text property
        Button btn = sender as Button;
        string courseCode = btn.Text;


        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY Date) AS SerialNo, Date, status FROM Attendance WHERE S_ID = @rollnum AND Course_Code = @courseCode";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }

        // get the total number of classes for the course
        int totalClasses = 0;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Attendance WHERE Course_Code = @courseCode and S_ID = @rollnum", con);
            cmd.Parameters.AddWithValue("@courseCode", courseCode);
            cmd.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            totalClasses = (int)cmd.ExecuteScalar();
        }

        // get the total number of attended classes for the student
        int attendedClasses = 0;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Attendance WHERE S_ID = @rollNum AND Course_Code = @courseCode AND status LIKE 'P%'", con);
            cmd.Parameters.AddWithValue("@rollNum", rollnum);
            cmd.Parameters.AddWithValue("@courseCode", courseCode);
            attendedClasses = (int)cmd.ExecuteScalar();
        }

        // calculate the attendance percentage
        double attendancePercentage = 0;
        if (totalClasses > 0)
        {
            attendancePercentage = (double)attendedClasses / totalClasses * 100;
        }
        // assuming you have a label called lblAttendancePercentage in your web page
        lblAttendancePercentage.Text = "Attendance Percentage: " + attendancePercentage.ToString("0.00") + "%";

    }


}