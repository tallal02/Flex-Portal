using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static System.Collections.Specialized.BitVector32;

public partial class Default2 : System.Web.UI.Page
{
	string courseCode = string.Empty;
	string regID = string.Empty;
	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
           
            if (Request.QueryString["CourseCode"] != null)
            {
                courseCode = Request.QueryString["CourseCode"];
               // Label1.Text = "Attendance " + courseCode;
				regID = Request.QueryString["regID"];
				Label1.Text = "RegID " + regID;

				// Use the course code value as needed
			}
            // Get the RollNumbers from the SQL query
            DataTable dtRollNumbers = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["FinalConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Student.Rollnum FROM Student JOIN Section ON Student.SectionID = Section.SectionID JOIN Teaches ON Section.SectionID = Teaches.SectionID JOIN Courses ON Teaches.Course_Code = Courses.Course_Code JOIN Faculty ON Teaches.InstructorID = Faculty.RegID JOIN [User] ON Student.CNIC = [User].CNIC WHERE Section.SectionID LIKE '%Sc%' AND Faculty.RegID = @val", connection);
				cmd.Parameters.AddWithValue("@val", regID);
				SqlDataReader reader = cmd.ExecuteReader();
                dtRollNumbers.Load(reader);
            }

            // Create the DataTable with initial columns and rows
            DataTable dt = new DataTable();
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            dt.Columns.Add("RollNo", typeof(string));
            dt.Columns.Add(date, typeof(string));
            GridView1.Columns[1].HeaderText = DateTime.Now.ToString("yyyy-MM-dd");

            foreach (DataRow row in dtRollNumbers.Rows)
            {
                dt.Rows.Add(row["Rollnum"].ToString(), "P");
            }

            // Bind the initial data to GridView
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // Store the initial column count
            ViewState["columnCount"] = dt.Columns.Count;

            // Store the DataTable in ViewState
            ViewState["DataTable"] = dt;
            
        }

    }

    protected void btnAdd_Click_Click(object sender, EventArgs e)
    {
        // Get the DataTable from ViewState
        DataTable dt = (DataTable)ViewState["DataTable"];

        // Add a new column to the DataTable
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        string newColumnName = date + "(" + (dt.Columns.Count - 1) + ")";
        dt.Columns.Add(newColumnName, typeof(string));
        GridView1.Columns[1].HeaderText = DateTime.Now.ToString("yyyy-MM-dd");

        // Bind the updated DataTable to GridView
        GridView1.DataSource = dt;
        GridView1.DataBind();

        // Update the column count in ViewState
        ViewState["columnCount"] = dt.Columns.Count;

        foreach (DataControlField column in GridView1.Columns)
        {
            column.ItemStyle.Width = 100;
        }
    }


    protected void Save(object sender, EventArgs e)
    {
        int x = 0;
        List<string> rollNumbers = new List<string>();

        ////////////
        string rollNo = "";
        string course = courseCode;
		string connectionString = ConfigurationManager.ConnectionStrings["FinalConnectionString"].ConnectionString;
		using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string queries = "SELECT DISTINCT Student.Rollnum FROM Student JOIN Section ON Student.SectionID = Section.SectionID JOIN Teaches ON Section.SectionID = Teaches.SectionID JOIN Courses ON Teaches.Course_Code = Courses.Course_Code JOIN Faculty ON Teaches.InstructorID = Faculty.RegID JOIN [User] ON Student.CNIC = [User].CNIC WHERE Section.SectionID = 'Sc105' AND Faculty.RegID = 'F115';"; // Replace with the actual CNIC value

            using (SqlCommand command = new SqlCommand(queries, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rollNumbers.Add(reader["Rollnum"].ToString());
                    Console.WriteLine("Rollnum: " + rollNumbers.Count);
                }
                reader.Close();
            }

            connection.Close();
        }

        // Prepare the SQL INSERT statement with parameters
        string sqlInsert = @"INSERT INTO Attendance (Date, T_ID, S_ID, Course_Code, SectionID, status)
                    VALUES (@Date, @T_ID, @S_ID, @Course_Code, @SectionID, @Status)";
        string status = "";
        using (SqlConnection connections = new SqlConnection(connectionString))
        {
            connections.Open();
            // Create a SQL command with the INSERT statement and connection
            using (SqlCommand command1 = new SqlCommand(sqlInsert, connections))
            {
                // Add parameters to the command


                // Iterate over the rollNumbers list and execute the command for each roll number
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {

                    GridViewRow row = GridView1.Rows[i];

                    DropDownList ddlStatus = row.FindControl("ddlStatus") as DropDownList;

                    status = ddlStatus.SelectedValue;



                    command1.Parameters.Add("@Date", SqlDbType.DateTime).Value = "3333-05-04 00:00:00.000";
                    command1.Parameters.Add("@T_ID", SqlDbType.VarChar, 10).Value = regID;
                    command1.Parameters.Add("@Course_Code", SqlDbType.VarChar, 10).Value = course; // Replace with the actual course code
                    command1.Parameters.Add("@SectionID", SqlDbType.VarChar, 10).Value = "Sc105";
                    command1.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = status;
                    command1.Parameters.Add("@S_ID", SqlDbType.VarChar, 10).Value = rollNumbers[i];

                    // Execute the SQL command
                    command1.ExecuteNonQuery();

                    // Clear the parameter for the next iteration
                    command1.Parameters.Clear();
                }
            }
            connections.Close();
        }


        //Audit Trail
        using (SqlConnection connectionss = new SqlConnection(connectionString))
        {
            connectionss.Open();
            string sqlInsert1 = @"INSERT INTO AuditTrail (ID, _Time, Type) VALUES (@ID, @_Time, @Type)";
            SqlCommand cmd = new SqlCommand(sqlInsert1, connectionss);
            cmd.Parameters.AddWithValue("@ID", regID);
            cmd.Parameters.AddWithValue("@_Time", DateTime.Now);
            cmd.Parameters.AddWithValue("@Type", "Attendance");

            cmd.ExecuteNonQuery();
            connectionss.Close();

        }


    }






            // Fetch existing roll numbers from the Attendance table
            //List<string> existingRollNumbers = new List<string>();
            ////for( int i = 0; i< rollNumbers.Count; i++) existingRollNumbers.Add(rollNumbers[i]);

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    GridViewRow row = GridView1.Rows[i];

            //    string status = row.Cells[1].Text;

            //    //// Check if the roll number already exists in the fetched list
            //    if (existingRollNumbers.Contains(rollNumbers[x]))
            //    {
            //        // Skip insertion for existing roll number
            //        continue;
            //    }

            //    else existingRollNumbers.Add(rollNumbers[x]);

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        string query = "INSERT INTO Attendance (Date, T_ID, S_ID, Course_Code, SectionID, status) VALUES (@Date, @T_ID, @S_ID, @Course_Code, @SectionID, @status)";
            //        SqlCommand cmd = new SqlCommand(query, connection);
            //        cmd.Parameters.AddWithValue("@Date", "8777-04-04 00:00:00.000");
            //        cmd.Parameters.AddWithValue("@T_ID", "F115");
            //        cmd.Parameters.AddWithValue("@S_ID", rollNumbers[x]);
            //        cmd.Parameters.AddWithValue("@Course_Code", course);
            //        cmd.Parameters.AddWithValue("@SectionID", "Sc105");
            //        cmd.Parameters.AddWithValue("@status", "A");

            //        cmd.ExecuteNonQuery();

            //        connection.Close();
            //    }
            //    //rollNumbers.Remove(rollNumbers[x]);
            //    x++;
            //}
            //lblWelcome.Text = existingRollNumbers.Count.ToString();




    //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    // Set the width of all cells in the row to 100
    //    foreach (TableCell cell in e.Row.Cells)
    //    {
    //        cell.Width = 100;
    //    }
    //}

    protected void AddColumn()
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DateBox_TextChanged(object sender, EventArgs e)
    {
        //string selectedDate = DateBox.Text;
    }



}

