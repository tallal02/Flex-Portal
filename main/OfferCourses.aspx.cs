using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class OfferCourses : System.Web.UI.Page
{
    UserDetails userDetails;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserDetails"] != null)
        {
            // Display the user's name
            userDetails = (UserDetails)Session["UserDetails"];
            System.Diagnostics.Debug.WriteLine(userDetails.Name);
            System.Diagnostics.Debug.WriteLine("HEYYYY");
            //Label1.Text = "Welcome, " + userDetails.FName + "<br>" + userDetails.Email;

        }

       
        //Connect to database
        string connstr = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();

        //Creating a fetch command
        SqlCommand cmd = new SqlCommand("select o.Course_Code, course_name , year from OfferedCourses as o Inner Join Courses as c on o.Course_Code = c.Course_Code;", conn);
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;

        StringBuilder str1 = new StringBuilder();
        StringBuilder str2 = new StringBuilder();
        StringBuilder str3 = new StringBuilder();


        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            string cCode = "";
            string cName = "";
            string cYear = "";

            cCode = reader.GetString(0);
            cName = reader.GetString(1);
            cYear = reader.GetString(2);

           
            if(cYear == "2021")
            {
                str1.AppendFormat("<div class=\"container-fluid flex-grow-1 m-2 p-4 rounded-3 \" style=\"width:900px;\">\";\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-success rounded-2\"><h2 style=\"color:white\">{0}</h2></div>\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-success m-2\">{1}</h5><br /></div>\r\n\t\t\t\t\t\t</div>",cCode,cName);
            }

            if(cYear == "2022")
            {
                str2.AppendFormat("<div class=\"container-fluid flex-grow-1 m-2 p-4 rounded-3 \" style=\"width:900px;\">\";\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-success rounded-2\"><h2 style=\"color:white\">{0}</h2></div>\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-success m-2\">{1}</h5><br /></div>\r\n\t\t\t\t\t\t</div>", cCode, cName);
            }

            if(cYear == "2023")
            {
                str3.AppendFormat("<div class=\"container-fluid flex-grow-1 m-2 p-4 rounded-3 \" style=\"width:900px;\">\";\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-success rounded-2\"><h2 style=\"color:white\">{0}</h2></div>\r\n\t\t\t\t\t\t<div class=\"container-fluid d-flex bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-success m-2\">{1}</h5><br /></div>\r\n\t\t\t\t\t\t</div>", cCode, cName);
            }
            
        }
        _y1data.Controls.Add(new LiteralControl(str1.ToString()));
        _y2data.Controls.Add(new LiteralControl(str2.ToString()));
        _y3data.Controls.Add(new LiteralControl(str3.ToString()));



        conn.Close();
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;

        CourseDetails tmp = new CourseDetails();
        string c;
        string y;
        c = _ccode.Value.ToString();
        y = _cyear.Value.ToString();
 

        if (c == "" || y=="")
        {
            Label1.Text = "Please fill all the required * Fields";
            Label1.Visible = true;
            return;
        }

        // ----------------------  Offering Courses ---------------------------------

        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "INSERT INTO [dbo].[OfferedCourses] ([Year],[Course_Code])VALUES (@year,@code)";
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@year", y);
                    command.Parameters.AddWithValue("@code", c);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
        catch (SqlException ex)
        {
            if (ex.Number == 547) //Foreign Key Violation
            {
                Label1.Text = "Course Does not Exist";
                Label1.Visible = true;
                return;
            }
            else
            {
                Label1.Text = "Invalid Data";
                Label1.Visible = true;
                return;
            }
        }

        // ----------------------------------------- Update OfferCourses table ----------------------------

       
        string selectQuery = "select rollnum from Student s inner join section se on  s.SectionID = se.SectionID where batch = @Val ";
        Queue<string> Rollnum = new Queue<string>();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Val", y);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Rollnum.Enqueue(reader.GetString(0));

                    }
                    connection.Close();
                }
            }

        }
        catch (SqlException ex)
        {
         

                Label1.Text = "Invalid Data";
                Label1.Visible = true;
                return;
        }

        // ------------------- insert student in register course ------------------------------------------
        insertQuery = "insert into RegisteredCourses (StudentID,Course_Code,Batch,Status) VALUES (@Val1,@Val2,@Val3,@Val4); ";
        try
        {
            while(Rollnum.Any())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        

                        command.Parameters.AddWithValue("@Val1", Rollnum.Dequeue());
                        command.Parameters.AddWithValue("@Val2", c);
                        command.Parameters.AddWithValue("@Val3", y);
                        command.Parameters.AddWithValue("@Val4", "O");

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
           

        }
        catch (SqlException ex)
        {
            
                Label1.Text = "Invalid Data";
                Label1.Visible = true;
                return;
          
        }


        Response.Redirect("/OfferCourses.aspx");
    }

    protected void DropButton_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;

        CourseDetails tmp = new CourseDetails();
        string c;
        string y;
        c = _ccode.Value.ToString();
        y = _cyear.Value.ToString();


        if (c == "" || y == "")
        {
            Label1.Text = "Please fill all the required * Fields";
            Label1.Visible = true;
            return;
        }

        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "DELETE FROM [dbo].[OfferedCourses] WHERE Course_Code=@code AND Year=@year";
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@year", y);
                    command.Parameters.AddWithValue("@code", c);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
        catch (SqlException ex)
        {
           
                Label1.Text = "Invalid Data";
                Label1.Visible = true;
                return;
         
        }


        // -------------------  get roll number of all students in the offered course

        string selectQuery = "select rollnum from Student s inner join section se on  s.SectionID = se.SectionID where batch = @Val ";
        Queue<string> Rollnum = new Queue<string>();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Val", y);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Rollnum.Enqueue(reader.GetString(0));

                    }
                    connection.Close();
                }
            }

        }
        catch (SqlException ex)
        {


            Label1.Text = "Invalid Data";
            Label1.Visible = true;
            return;
        }


        // Remove all those students
        string remquery = "DELETE FROM [dbo].[RegisteredCourses] WHERE StudentID=@Val1 AND Course_Code = @Val2 AND Batch = @Val3;";
        try
        {
            while (Rollnum.Any())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(remquery, connection))
                    {


                        command.Parameters.AddWithValue("@Val1", Rollnum.Dequeue());
                        command.Parameters.AddWithValue("@Val2", c);
                        command.Parameters.AddWithValue("@Val3", y);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }


        }
        catch (SqlException ex)
        {

            Label1.Text = "Invalid Data";
            Label1.Visible = true;
            return;

        }


        Response.Redirect("/OfferCourses.aspx");
    }
}