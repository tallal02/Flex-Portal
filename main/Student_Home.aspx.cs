using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Data;
using System.Reflection.Emit;

public partial class Student_Home : System.Web.UI.Page
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

			System.Diagnostics.Debug.WriteLine(userDetails.Name);
			System.Diagnostics.Debug.WriteLine("HEYYYY");

			//Label1.Text = "Welcome, " + userDetails.FName + "<br>" + userDetails.Email

			Label1.Text = "Welcome, " + userDetails.Name + "<br>" + userDetails.Email;
			Label1.Visible = true;
		}


		userDetails = (UserDetails)Session["UserDetails"];
		string cnic_val = userDetails.CNIC;
		string rollnum = GetRollNumber(cnic_val);

		//displaying gpa
		SqlConnection con = new SqlConnection(kulsum_connection);
		SqlCommand c1 = new SqlCommand("SELECT Sem1, Sem2, Sem3, Sem4, Sem5, Sem6, Sem7, Sem8 FROM GPA where Rollnum = @rollnum", con);
		c1.Parameters.AddWithValue("@Rollnum", rollnum);
		con.Open();
		SqlDataReader reader1 = c1.ExecuteReader();

		if (reader1.HasRows)
		{
			while (reader1.Read())
			{
				for (int i = 0; i < reader1.FieldCount; i++)
				{
					string columnName = reader1.GetName(i);
					object value = reader1.GetValue(i);

					if (value != DBNull.Value)
					{
						Series series = Chart1.Series["Series1"];
						series.Points.AddXY(columnName, Convert.ToDouble(value));
					}
					else
					{
						Series series = Chart1.Series["Series1"];
						series.Points.AddXY(columnName, 0);
					}

				}
			}
		}
		Chart1.ChartAreas[0].AxisX.Title = "Semester";
		Chart1.ChartAreas[0].AxisY.Title = "GPA";
		Chart1.ChartAreas[0].AxisY.Maximum = 4;
		Chart1.ChartAreas[0].AxisY.Minimum = 0;
		Chart1.Series["Series1"].BorderWidth = 3;
		Chart1.ChartAreas[0].BackColor = Color.LightGray;
		Chart1.DataBind();
		Chart1.Visible = true;
		con.Close();

		//displaying personal info
		con = new SqlConnection(kulsum_connection);
		SqlCommand c = new SqlCommand("select * from [User] where CNIC = @cnic", con);
		c.Parameters.AddWithValue("@CNIC", cnic_val);
		con.Open();
		SqlDataReader reader = c.ExecuteReader();
		GridView2.DataSource = reader;
		GridView2.DataBind();
		con.Close();

		//displaying uni info
		con = new SqlConnection(kulsum_connection);
		c = new SqlCommand("select * from Student where Rollnum = @rollnum", con);
		c.Parameters.AddWithValue("@Rollnum", rollnum);
		con.Open();
		reader = c.ExecuteReader();
		GridView1.DataSource = reader;
		GridView1.DataBind();
		con.Close();


		//displaying attendance graph
		string query = @"SELECT
                    pc.Course_Code,
                    COUNT(a.status) AS Total,
                    SUM(CASE WHEN a.status LIKE 'P%' THEN 1 ELSE 0 END) AS Attended,
                    (SUM(CASE WHEN a.status LIKE 'P%' THEN 1 ELSE 0 END) * 100 / COUNT(a.status))  AS AttendancePercentage
                FROM
                    PassedCourses pc
                JOIN
                    Attendance a ON pc.Rollnum = a.S_ID AND pc.Course_Code = a.Course_Code
                WHERE
                    pc.Rollnum = @rollnum
                GROUP BY
                    pc.Course_Code";

		using (SqlConnection connection = new SqlConnection(kulsum_connection))
		{
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@rollnum", rollnum);

			connection.Open();
			reader = command.ExecuteReader();

			// Create a DataTable to store the data
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);

			reader.Close();

			// Bind the DataTable to the Chart control
			attendanceChart.DataSource = dataTable;

			// Set the X-axis and Y-axis data fields
			attendanceChart.Series["Series1"].XValueMember = "Course_Code";
			attendanceChart.Series["Series1"].YValueMembers = "AttendancePercentage";

			// Set the chart type (e.g., column chart, bar chart, etc.)
			attendanceChart.Series["Series1"].ChartType = SeriesChartType.Bar;

			// Bind the data to the chart
			attendanceChart.DataBind();
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


	protected void Attendance_Button_Click(object sender, EventArgs e)
	{
		Response.Redirect("Attendance.aspx");
	}

	protected void Marks_Button_Click(object sender, EventArgs e)
	{
		Response.Redirect("Marks.aspx");
	}

	protected void Trans_Button_Click(object sender, EventArgs e)
	{
		Response.Redirect("Transcript.aspx");
	}
	protected void Feed_Button_Click(object sender, EventArgs e)
	{
		Response.Redirect("Feedback.aspx");
	}

}