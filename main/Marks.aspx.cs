using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
//using static UserDetails;
public partial class Marks : System.Web.UI.Page
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

        //phMarks.Controls.Clear();


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

    //event handler for the course button click event
    protected void btnCourse_Click(object sender, EventArgs e, string rollnum)
    {

        // get the course code from the button's text property
        Button btn = sender as Button;
        string courseCode = btn.Text;



        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Quiz'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }

        query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Assignment'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView2.DataSource = reader;
            GridView2.DataBind();

            reader.Close();
        }

        query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Mid'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView3.DataSource = reader;
            GridView3.DataBind();

            reader.Close();
        }

        query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Finals'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView4.DataSource = reader;
            GridView4.DataBind();

            reader.Close();
        }


    }

   

    protected void btnAss_Click(object sender, EventArgs e, string rollnum, string courseCode)
    {
        string connectionString = kulsum_connection;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Quiz'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum);
            command.Parameters.AddWithValue("@courseCode", courseCode);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView gv = new GridView();
                gv.DataSource = dt;
                gv.DataBind();
                //phMarksTable.Controls.Add(gv);
            }
            //else
            //{
            //    Label lbl = new Label();
            //    lbl.Text = "No data found.";
            //    phMarksTable.Controls.Add(lbl);
            //}
        }
    }


    protected void btnQuiz_Click(object sender, EventArgs e, string rollnum, string courseCode)
    {
       


        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Quiz'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }
    }

    protected void btnMids_Click(object sender, EventArgs e, string rollnum, string courseCode)
    {

        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Mid'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }
    }

    protected void btnFinal_Click(object sender, EventArgs e, string rollnum, string courseCode)
    {


        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = @courseCode AND m.Rollnum = @rollnum AND ai.Type = 'Finals'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }
    }

    protected void btnProj_Click(object sender, EventArgs e, string rollnum, string courseCode)
    {
        string connectionString = kulsum_connection;
        string query = "SELECT ROW_NUMBER() OVER (ORDER BY ai.ID) AS SerialNo, ai.Type, ai.T_Marks, ai.Weightage, m.Obtained_Marks FROM Assessment_Items ai INNER JOIN Marks m ON ai.ID = m.Marks_ID WHERE ai.Course_Code = 'CL1000' AND m.Rollnum = 'i212487' AND ai.Type = 'Quiz'";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rollnum", rollnum); // assuming you have the roll number stored in a variable
            command.Parameters.AddWithValue("@courseCode", courseCode);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // bind the fetched data to a ListView control
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();
        }
    }

}
