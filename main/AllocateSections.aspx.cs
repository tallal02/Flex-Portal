using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using System;
public partial class AllocateSections : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("select S.SectionID,S.SectionName,Batch,Count(*) as numSt from Section as S inner join Student as St on S.SectionID=St.SectionID Group by S.SectionID,S.SectionName,S.Batch;", conn);
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;

        StringBuilder str1 = new StringBuilder();

        string Id = "";
        string Name = "";
        string Year = "";
        int count;


        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            
            Id = reader.GetString(0);
            Name = reader.GetString(1);
            Year = reader.GetString(2);
            count = reader.GetInt32(3);

            str1.AppendFormat("<div class=\"container-fluid flex-grow-1 p-4 rounded-3 \" style=\"width:1000px;\">\" <div class=\"container-fluid d-flex bg-primary rounded-2\"><h2 style=\"color:white\">{0}</h2></div>    <div class=\"container-fluid d-flex bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">Section Name:   </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div><div class=\"container-fluid d-flex  bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">Batch:   </h5><p class=\"d-inline-block text-white m-2 p-1 \">{2}</p><br /></div><div class=\"container-fluid d-flex  bg-dark bg-opacity-50\"><h5 class=\"d-inline-block text-primary m-2\">No of Students: </h5><p class=\"d-inline-block text-white m-2 p-1\">{3}</p><br /></div><br/><br/></div>",Id,Name,Year,count);
       
        
        }
        _ydata.Controls.Add(new LiteralControl(str1.ToString()));

        conn.Close();
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {

        Label1.Visible = false;

        string id = _secid.Value.ToString();
        string name = _name.Value.ToString();
        string batch = _batch.Value.ToString();
        string degree = _deg.Value.ToString();

        if (id=="" || name== "" || batch=="" || degree=="")
        {
            Label1.Text = "Please fill all the required * Fields";
            Label1.Visible = true;
            return;
        }


        string connectionString = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
        string insertQuery = "INSERT INTO [dbo].[Section] ([SectionID],[SectionName],[Batch],[Degree])VALUES (@Val1,@Val2,@Val3,@Val4);";
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Val1", id);
                    command.Parameters.AddWithValue("@Val2", name);
                    command.Parameters.AddWithValue("@Val3", batch);
                    command.Parameters.AddWithValue("@Val4", degree);

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



    }

    protected void ViewSt(object sender, EventArgs e)
    {

        Label3.Visible = false;

        string secID =_scID.Value.ToString();
        //Creating a fetch command
        try
        {

            string connstr = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select S.Rollnum,U.Name,U.email from Student as S inner join [User] as U On S.CNIC=U.CNIC where S.SectionID= @Val;", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            StringBuilder str1 = new StringBuilder();

            string rollnum = "";
            string name = "";
            string email = "";

            cmd.Parameters.AddWithValue("@Val", secID);
            SqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {

                rollnum = reader.GetString(0);
                name = reader.GetString(1);
                email = reader.GetString(2);

                str1.AppendFormat("<div class=\"container-fluid d-flex flex-row justify-content-around bg-dark bg-opacity-50 text-primary \" style=\"border:dashed\"><div class=\"flex-grow-1 d-flex flex-column\" >\r\n\r\n\t\t\t\t\t\t\t\t<div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Roll-number:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{0}</p><br /></div><div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Name:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{1}</p><br /></div><div class=\"flex-grow-1\"><h5 class=\"d-inline-block text-primary m-2\">Email:  </h5><p class=\"d-inline-block text-white m-2 p-1\">{2}</p><br /></div></div></div><br />", rollnum, name, email);


            }
            _stdata.Controls.Add(new LiteralControl(str1.ToString()));

            conn.Close();

        }
        catch
        {
            Label3.Text = "Section does not exist";
            Label3.Visible = true;
        }        
       
    }

      
}