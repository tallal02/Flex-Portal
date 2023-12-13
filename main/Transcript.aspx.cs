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
using System.Data;
//using System.Collections.Specialized;
//// ...

//BitVector32.Section section;
//BitVector32 vector = new BitVector32();
//section = BitVector32.CreateSection(1);
//vector[section] = 1;

// Access the section value using the section mask



public partial class Transcript : System.Web.UI.Page
{
    string hassan_connection = "Data Source=DESKTOP-CBVGRRL\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
    string kulsum_connection = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";


    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CreditHours { get; set; }
        public double GradePoints { get; set; }
    }
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

        double SGPA = 0;
        double CGPA = 0;

        string connectionString = kulsum_connection;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Sem1 FROM GPA WHERE rollnum = @rollnum";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                SGPA = reader.GetDouble(0); // Assuming the sem1 column is of type float/double in the database
                CGPA = SGPA;                      // Use the sem1GPA value as needed
            }

            reader.Close();
        }

        Label2.Text = "SGPA " + SGPA.ToString() ;
        Label3.Text = "CGPA " + CGPA.ToString();


        List<Course> courses = GetCourseInformation(rollnum);

        // Bind the data to the grid control
        courseGrid.DataSource = courses;
        courseGrid.DataBind();
    }

    private List<Course> GetCourseInformation(string rollnum)
    {
        List<string> courseCodes = GetCourseCodes(rollnum);
        List<Course> courses = new List<Course>();

        // Retrieve course information for the specific course codes
        string connectionString = kulsum_connection;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach (string courseCode in courseCodes)
            {
                string query = "SELECT Course_Code, Course_Name, Credit_Hours FROM Courses WHERE Course_Code = @CourseCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseCode", courseCode);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Course course = new Course();
                    course.CourseCode = reader["Course_Code"].ToString();
                    course.CourseName = reader["Course_Name"].ToString();
                    course.CreditHours = Convert.ToInt32(reader["Credit_Hours"]);
                    courses.Add(course);
                }
                reader.Close();
            }
        }

        // Calculate the grade points for each course
        foreach (Course course in courses)
        {
            course.GradePoints = CalculateGradePoints(course.CourseCode, rollnum); // Implement this method to calculate grade points from the Absolutes table
        }

        return courses;
    }

    private static double CalculateGradePoints(string courseCode, string rollNum)
    {

        int absolutes = -1;
        string columnName = courseCode.ToUpper();

    string kulsum_connection = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";


        string connectionString = kulsum_connection;


        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT " + columnName + " FROM Absolutes WHERE Rollnum=@rollnum", conn);
            cmd.Parameters.AddWithValue("@rollnum", rollNum);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                absolutes = reader.GetInt32(0);
            }
            reader.Close();
        }


        double gradePoints = 0.0;

        if (absolutes >= 90)
        {
            gradePoints = 4.00;
        }
        else if (absolutes >= 86 && absolutes <= 89)
        {
            gradePoints = 4.00;
        }
        else if (absolutes >= 82 && absolutes <= 85)
        {
            gradePoints = 3.67;
        }
        else if (absolutes >= 78 && absolutes <= 81)
        {
            gradePoints = 3.33;
        }
        else if (absolutes >= 74 && absolutes <= 77)
        {
            gradePoints = 3.00;
        }
        else if (absolutes >= 70 && absolutes <= 73)
        {
            gradePoints = 2.67;
        }
        else if (absolutes >= 66 && absolutes <= 69)
        {
            gradePoints = 2.33;
        }
        else if (absolutes >= 62 && absolutes <= 65)
        {
            gradePoints = 2.00;
        }
        else if (absolutes >= 58 && absolutes <= 61)
        {
            gradePoints = 1.67;
        }
        else if (absolutes >= 54 && absolutes <= 57)
        {
            gradePoints = 1.33;
        }
        else if (absolutes >= 50 && absolutes <= 53)
        {
            gradePoints = 1.00;
        }
        else
        {
            gradePoints = 0.00;
        }

        return gradePoints;
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

}