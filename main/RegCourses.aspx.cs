using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class RegCourses : System.Web.UI.Page
{
    UserDetails userDetails;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserDetails"] != null)
        {
            // Display the user's name
            userDetails = (UserDetails)Session["UserDetails"];
            System.Diagnostics.Debug.WriteLine(userDetails.Name);
           
        }

        //Connect to database
        string connstr = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connstr);
        conn.Open();

        //Creating a fetch command
        SqlCommand cmd = new SqlCommand("select StudentID,name,Course_Code,Batch,R.Status from RegisteredCourses as R inner join Student as S\r\non R.StudentID = S.Rollnum inner join [User] as U on S.CNIC=U.CNIC;", conn);
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;

        StringBuilder str1 = new StringBuilder();
        StringBuilder str2 = new StringBuilder();
        StringBuilder str3 = new StringBuilder();
        StringBuilder str4 = new StringBuilder();
        StringBuilder str5 = new StringBuilder();
        StringBuilder str6 = new StringBuilder();
        StringBuilder str7 = new StringBuilder();
        StringBuilder str8 = new StringBuilder();
        StringBuilder str9 = new StringBuilder();

        string rollnum = "";
        string name = "";
        string code = "";
        string batch = "";
        string status = "";

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            

            rollnum = reader.GetString(0);
            name = reader.GetString(1);
            code = reader.GetString(2);
            batch = reader.GetString(3);
            status= reader.GetString(4);

            if(status=="R")
            {
                if (batch == "2021")
                {
                    str1.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }

                if (batch == "2022")
                {
                    str2.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);

                }

                if (batch == "2023")
                {
                    str3.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }
            }

            if (status == "P")
            {
                if (batch == "2021")
                {
                    str4.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }

                if (batch == "2022")
                {
                    str5.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div> </div><br />", rollnum, name, code);

                }

                if (batch == "2023")
                {
                    str6.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }
            }

            if(status == "O")
            {
                if (batch == "2021")
                {
                    str7.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }

                if (batch == "2022")
                {
                    str8.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div> </div><br />", rollnum, name, code);

                }

                if (batch == "2023")
                {
                    str9.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\">\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div>\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Course Code:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, code);
                }
            }



        }
        _y1data.Controls.Add(new LiteralControl(str1.ToString()));
        _y2data.Controls.Add(new LiteralControl(str2.ToString()));
        _y3data.Controls.Add(new LiteralControl(str3.ToString()));
        PlaceHolder1.Controls.Add(new LiteralControl(str4.ToString()));
        PlaceHolder2.Controls.Add(new LiteralControl(str5.ToString()));
        PlaceHolder3.Controls.Add(new LiteralControl(str6.ToString()));
        PlaceHolder4.Controls.Add(new LiteralControl(str7.ToString()));
        PlaceHolder5.Controls.Add(new LiteralControl(str8.ToString()));
        PlaceHolder6.Controls.Add(new LiteralControl(str9.ToString()));


        conn.Close();

    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }

    protected void RegAccept(object sender, EventArgs e)
    {
        string parameter = ((Button)sender).CommandArgument;
        System.Diagnostics.Debug.WriteLine(parameter);

        Label1.Visible = false;

        string c = "";
        string r = "";
        string y = "";

        c = _ccode.Value.ToString();
        r = _rollnum.Value.ToString();
        y = _cyear.Value.ToString();

        if (c=="" || r=="" || y=="")
        {
            Label1.Text = "Please fill all the required * Fields";
            Label1.Visible = true;
            return;
        }

        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "UPDATE [dbo].[RegisteredCourses]   SET [Status] = @Val WHERE StudentID = @Val1 AND Course_Code = @Val2 AND Batch=@Val3;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Val", "R");
                command.Parameters.AddWithValue("@Val1", r );
                command.Parameters.AddWithValue("@Val2", c);
                command.Parameters.AddWithValue("@Val3", y);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        Response.Redirect("/RegCourses.aspx");
    }

    protected void RegP(object sender, EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "UPDATE [dbo].[RegisteredCourses]   SET [Status] = @Val1 WHERE Status = @Val2;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Val1", "R");
                command.Parameters.AddWithValue("@Val2", "P");

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        Response.Redirect("/RegCourses.aspx");
    }

    protected void RegN(object sender, EventArgs e)
    {
        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "UPDATE [dbo].[RegisteredCourses]   SET [Status] = @Val1 WHERE Status = @Val2;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Val1", "R");
                command.Parameters.AddWithValue("@Val2", "O ");

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        Response.Redirect("/RegCourses.aspx");
    }
}