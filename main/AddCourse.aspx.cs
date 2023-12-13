using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Runtime.InteropServices;
using System.Net;
using System.Web.Security;
using System.Xml.Linq;

public partial class AddCourse : System.Web.UI.Page
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
        SqlCommand cmd =new SqlCommand("SELECT [Course_Code], [Course_Name], [Credit_Hours], [Pre_Req], [CoordinatorID], [TYPE] FROM [dbo].[Courses]",conn);
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;

        CourseDetails crsdetails = new CourseDetails();
        StringBuilder str = new StringBuilder();

        int i = 0;
        int a = 1;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            crsdetails.Course_Code = reader.GetString(0);
            crsdetails.Course_Name = reader.GetString(1);
            crsdetails.Credit_Hrs = reader.GetInt32(2);

            string value = "";
            if (!reader.IsDBNull(reader.GetOrdinal("Pre_Req")))
            {
                value = reader.GetString(reader.GetOrdinal("Pre_Req"));
            }

            crsdetails.Pre_Req = value;
            crsdetails.CoordinatorID = reader.GetString(4);
            crsdetails.TYPE = reader.GetString(5);
 
            str.AppendFormat(" <div class=\"container-fluid flex-grow-1 p-4 rounded-3\" >");
            str.AppendFormat(" <div class=\"container-fluid d-flex bg-primary rounded-2\"><h2 style=\"color:white\">{0}</h2></div>", crsdetails.Course_Code);
            str.AppendFormat(" <div class=\"container-fluid d-flex bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">Course Name:   </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div>", crsdetails.Course_Name);
            str.AppendFormat(" <div class=\"container-fluid d-flex  bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">Credit Hours:   </h5><p class=\"d-inline-block text-white m-2 p-1 \">{0} hrs</p><br /></div>", crsdetails.Credit_Hrs);
            str.AppendFormat(" <div class=\"container-fluid d-flex  bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">Type: </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div><br/><br/>", crsdetails.TYPE);
            str.AppendFormat("</div>");

            a++;
        }
        _cdata.Controls.Add(new LiteralControl(str.ToString()));

        conn.Close();
    }

    protected void button_Click1(object sender, EventArgs e)
    {        
        Label1.Visible = false;
        CourseDetails tmp = new CourseDetails();


        tmp.Course_Code = _ccode.Value.ToString();
        tmp.Course_Name = _cname.Value.ToString();
        tmp.TYPE = _ctype.Value.ToString();
        tmp.Pre_Req = _pre_req.Value.ToString();
        tmp.CoordinatorID = _CID.Value.ToString();

        string a = _crd.Value.ToString();
        System.Diagnostics.Debug.WriteLine(a);
        int var = 0;
        if (int.TryParse(a, out var))
        {
            // Conversion successful
            tmp.Credit_Hrs = var;
        }
        else
        {
            // Conversion failed
            System.Diagnostics.Debug.WriteLine("Failed");
        }

        if(tmp.Credit_Hrs == 0 || tmp.Course_Code=="" || tmp.CoordinatorID == "" || tmp.Course_Name == "")
        {
            Label1.Text = "Please fill all the required * Fields";
            Label1.Visible = true;
            return;
        }

        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "INSERT INTO [Courses] (Course_Code, Course_Name, Credit_Hours,Pre_Req,CoordinatorID,TYPE) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Value1", tmp.Course_Code);
                command.Parameters.AddWithValue("@Value2", tmp.Course_Name);
                command.Parameters.AddWithValue("@Value3", tmp.Credit_Hrs);
                command.Parameters.AddWithValue("@Value4", tmp.Pre_Req);
                command.Parameters.AddWithValue("@Value5", tmp.CoordinatorID);
                command.Parameters.AddWithValue("@Value6", tmp.TYPE);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        Response.Redirect("/AddCourse.aspx");

    }
}