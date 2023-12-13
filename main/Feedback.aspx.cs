using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    string hassan_connection = "Data Source=DESKTOP-CBVGRRL\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";
    string kulsum_connection = "Data Source=DESKTOP-O0HK97I\\SQLEXPRESS;Initial Catalog=Final_Project;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        CalculatePercentage();
    }
    protected void CalculatePercentage()
    {
        // Retrieve the selected radio button value for the first question
        string selectedValue;
        int feedbackValue = 0;
        int total_sum = 0;

        for(int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    string fieldName = "q11_appearanceAnd11["+j.ToString()+"]";
                    selectedValue = Request.Form[fieldName];
                    if (selectedValue != null)
                    {
                        feedbackValue = int.Parse(selectedValue);
                        if (feedbackValue == 1)
                        {
                            total_sum += 10;
                        }
                        else if (feedbackValue == 2)
                        {
                            total_sum += 20;
                        }
                        else if (feedbackValue == 3)
                        {
                            total_sum += 30;
                        }
                        else if (feedbackValue == 4)
                        {
                            total_sum += 40;
                        }
                        else if (feedbackValue == 5)
                        {
                            total_sum += 50;
                        }
                    }
                }
            }
            else if (i == 1)
            {
                for (int j = 0; j < 6; j++)
                {
                    string fieldName = "q12_professionalPractices[" + j.ToString() + "]";

					selectedValue = Request.Form[fieldName];
                    if (selectedValue != null)
                    {
                        feedbackValue = int.Parse(selectedValue);
                        if (feedbackValue == 1)
                        {
                            total_sum += 10;
                        }
                        else if (feedbackValue == 2)
                        {
                            total_sum += 20;
                        }
                        else if (feedbackValue == 3)
                        {
                            total_sum += 30;
                        }
                        else if (feedbackValue == 4)
                        {
                            total_sum += 40;
                        }
                        else if (feedbackValue == 5)
                        {
                            total_sum += 50;
                        }

                    }
                }
            }
            else if (i == 2)
            {
                for (int j = 0; j < 5; j++)
                {
                    string fieldName = "q13_teachingMethods[" + j.ToString() + "]";

					selectedValue = Request.Form[fieldName];
                    if (selectedValue != null)
                    {
                        feedbackValue = int.Parse(selectedValue);
                        if (feedbackValue == 1)
                        {
                            total_sum += 10;
                        }
                        else if (feedbackValue == 2)
                        {
                            total_sum += 20;
                        }
                        else if (feedbackValue == 3)
                        {
                            total_sum += 30;
                        }
                        else if (feedbackValue == 4)
                        {
                            total_sum += 40;
                        }
                        else if (feedbackValue == 5)
                        {
                            total_sum += 50;
                        }
                    }
                }
            }
            else if (i == 3)
            {
                for (int j = 0; j < 4; j++)
                {
                    string fieldName = "q14_dispositionTowards[" + j.ToString() + "]";

					selectedValue = Request.Form[fieldName];
                    if (selectedValue != null)
                    {
                        feedbackValue = int.Parse(selectedValue);
                        if (feedbackValue == 1)
                        {
                            total_sum += 10;
                        }
                        else if (feedbackValue == 2)
                        {
                            total_sum += 20;
                        }
                        else if (feedbackValue == 3)
                        {
                            total_sum += 30;
                        }
                        else if (feedbackValue == 4)
                        {
                            total_sum += 40;
                        }
                        else if (feedbackValue == 5)
                        {
                            total_sum += 50;
                        }
                    }
                }
            }
        }

        // Evaluation percentage is stored in ans
        float ans;
        ans = total_sum / 10; //where 1000 is the total score

        string comments = Request.Form["q15_comments"];

        string ins_id = Request.Form["INS_ID"];
        string Cor_Code = Request.Form["course_code"];
        string secid = Request.Form["Section"];
        string stu_id = Request.Form["stu_name"];

    



        // Display the percentages or use them as needed
        lblSection1Percentage.Text = "Total Obtained Score " + total_sum.ToString();
        lblSection2Percentage.Text = "Final Answer:" + ans.ToString() +" %";
        //lblSection3Percentage.Text = $"Section 3 Percentage: {section3Percentage}%";
        //lblSection4Percentage.Text = $"Section 4 Percentage: {section4Percentage}%";

        // Step 1: Create a connection to the database
        string connectionString = kulsum_connection;
        string query = "INSERT INTO Feedback (StudentID, Course_Code, SectionID, InstructorID, Comment, Evaluation_Perc) VALUES (@StudentID, @Course_Code, @SectionID, @InstructorID, @Comment, @Evaluation_Perc)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", stu_id);
            command.Parameters.AddWithValue("@Course_Code", Cor_Code);
            command.Parameters.AddWithValue("@SectionID", secid);
            command.Parameters.AddWithValue("@InstructorID", ins_id);
            command.Parameters.AddWithValue("@Comment", comments);
            command.Parameters.AddWithValue("@Evaluation_Perc", ans);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log the error, show an error message)
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        CalculatePercentage();
    }
}