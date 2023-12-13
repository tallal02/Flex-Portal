using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeightTable : System.Web.UI.Page
{
    DataTable addedValues = new DataTable();


    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        //double assignments = Convert.ToDouble(Request.QueryString["assignments"]);
    //        //double quizzes = Convert.ToDouble(Request.QueryString["quizzes"]);
    //        //double sessional1 = Convert.ToDouble(Request.QueryString["sessional1"]);
    //        //double sessional2 = Convert.ToDouble(Request.QueryString["sessional2"]);
    //        //double finalexam = Convert.ToDouble(Request.QueryString["finalexam"]);

    //        double assignments = Convert.ToDouble(Request.Cookies["assignments"].Value);
    //        double quizzes = Convert.ToDouble(Request.Cookies["quizzes"].Value);
    //        double sessional1 = Convert.ToDouble(Request.Cookies["sessional1"].Value);
    //        double sessional2 = Convert.ToDouble(Request.Cookies["sessional2"].Value);
    //        double finalexam = Convert.ToDouble(Request.Cookies["finalexam"].Value);


    //        //txtAssignments.Value = assignments.ToString();
    //        //txtQuizzes.Value = quizzes.ToString();
    //        //txtSessional1.Value = sessional1.ToString();
    //        //txtSessional2.Value = sessional2.ToString();
    //        //txtFinalExam.Value = finalexam.ToString();
    //        //lblTotalWeightage.Text = totalWeightage.ToString();




    //        //GridView1.DataSource = dt;
    //        GridView1.DataBind();


    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;

        addedValues = new DataTable();
        addedValues.Columns.Add("Rollnum", typeof(string));
        addedValues.Columns.Add("Name", typeof(string));
        addedValues.Columns.Add("FinalMarks", typeof(string));

        // Bind the DataTable to the GridView
        //GridView5.DataSource = addedValues;
        //GridView5.DataBind();

    }

    protected void btnAdd_Click_Assignment(object sender, EventArgs e)
    {
        GridView1.Visible = true;

        // Get the current column count of the GridView
        int colCount = GridView1.Columns.Count - 1;

        // Create a new TemplateField for the new column
        TemplateField newColumn = new TemplateField();

        // Set the HeaderText of the new column to "Assignment {colCount}"
        newColumn.HeaderText = "Assignment " + colCount;

        // Add the new column to the GridView
        GridView1.Columns.Add(newColumn);

        // Loop through the rows of the GridView and add a new cell to each row for the new column
        foreach (GridViewRow row in GridView1.Rows)
        {
            TableCell newCell = new TableCell();

            // Add a TextBox control to the new cell
            TextBox textBox = new TextBox();
            textBox.ID = "txtAssignment" + colCount.ToString() + "_" + row.RowIndex.ToString();
            textBox.MaxLength = 3; // Limit the maximum length of the input to 3 characters
            textBox.ReadOnly = false; // Set the ReadOnly property to false to allow editing
            newCell.Controls.Add(textBox);

            // Set the default value of the TextBox to 0
            textBox.Text = "0";

            // Add a RangeValidator control to the new cell
            RangeValidator rangeValidator = new RangeValidator();
            rangeValidator.ControlToValidate = textBox.ID;
            rangeValidator.MinimumValue = "0"; // Set the minimum value to 0
            rangeValidator.MaximumValue = "100"; // Set the maximum value to 100
            rangeValidator.Type = ValidationDataType.Integer;
            rangeValidator.ErrorMessage = "Please enter a value between 0 and 100.";
            newCell.Controls.Add(rangeValidator);

            row.Cells.Add(newCell);
        }


        // Re-bind the data to the GridView to preserve ViewState
        GridView1.DataSource = GridView1.DataSource;
        GridView1.DataBind();
    }



    protected void Save(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView1.DataSource = GridView1.DataSource;
        GridView1.DataBind();

        GridView2.Visible = false;
        GridView2.DataSource = GridView2.DataSource;
        GridView2.DataBind();

        GridView3.Visible = false;
        GridView3.DataSource = GridView3.DataSource;
        GridView3.DataBind();

        GridView4.Visible = false;
        GridView4.DataSource = GridView4.DataSource;
        GridView4.DataBind();

        GridView5.Visible = false;
        GridView5.DataSource = GridView5.DataSource;
        GridView5.DataBind();
    }


    protected void btnAdd_Click_Quiz(object sender, EventArgs e)
    {
        GridView2.Visible = true;

        // Get the current column count of the GridView
        int colCount_quiz = GridView2.Columns.Count - 1;

        // Create a new TemplateField for the new column
        TemplateField newColumn_quiz = new TemplateField();

        // Set the HeaderText of the new column to "Assignment {colCount}"
        newColumn_quiz.HeaderText = "Quiz " + colCount_quiz;

        // Add the new column to the GridView
        GridView2.Columns.Add(newColumn_quiz);

        // Loop through the rows of the GridView and add a new cell to each row for the new column
        foreach (GridViewRow row in GridView2.Rows)
        {
            TableCell QuizCell = new TableCell();

            // Add a TextBox control to the new cell
            TextBox textBox_quiz = new TextBox();
            textBox_quiz.ID = "txtQuiz" + colCount_quiz.ToString() + "_" + row.RowIndex.ToString();
            textBox_quiz.MaxLength = 2; // Limit the maximum length of the input to 3 characters
            textBox_quiz.ReadOnly = false; // Set the ReadOnly property to false to allow editing
            QuizCell.Controls.Add(textBox_quiz);

            // Set the default value of the TextBox to 0
            textBox_quiz.Text = "0";

            // Add a RangeValidator control to the new cell
            RangeValidator rangeValidator_quiz = new RangeValidator();
            rangeValidator_quiz.ControlToValidate = textBox_quiz.ID;
            rangeValidator_quiz.MinimumValue = "0"; // Set the minimum value to 0
            rangeValidator_quiz.MaximumValue = "100"; // Set the maximum value to 100
            rangeValidator_quiz.Type = ValidationDataType.Integer;
            rangeValidator_quiz.ErrorMessage = "Please enter a value between 0 and 100.";
            QuizCell.Controls.Add(rangeValidator_quiz);

            row.Cells.Add(QuizCell);
        }

        // Re-bind the data to the GridView to preserve ViewState
        GridView2.DataSource = GridView2.DataSource;
        GridView2.DataBind();

    }
    protected void btnAdd_Click_S1(object sender, EventArgs e)
    {
        GridView3.Visible = true;
        if (GridView3.Columns.Count <= 2)
        {

            // Get the current column count of the GridView
            int colCount_quiz = GridView3.Columns.Count - 1;

            // Create a new TemplateField for the new column
            TemplateField newColumn_quiz = new TemplateField();

            // Set the HeaderText of the new column to "Assignment {colCount}"
            newColumn_quiz.HeaderText = "Sessional-1 ";

            // Add the new column to the GridView
            GridView3.Columns.Add(newColumn_quiz);

            // Loop through the rows of the GridView and add a new cell to each row for the new column
            foreach (GridViewRow row in GridView3.Rows)
            {
                TableCell QuizCell = new TableCell();

                // Add a TextBox control to the new cell
                TextBox textBox_s1 = new TextBox();
                textBox_s1.ID = "txtSessional_1" + colCount_quiz.ToString() + "_" + row.RowIndex.ToString();
                textBox_s1.MaxLength = 2; // Limit the maximum length of the input to 3 characters
                textBox_s1.ReadOnly = false; // Set the ReadOnly property to false to allow editing
                QuizCell.Controls.Add(textBox_s1);

                // Set the default value of the TextBox to 0
                textBox_s1.Text = "0";

                // Add a RangeValidator control to the new cell
                RangeValidator rangeValidator_s1 = new RangeValidator();
                rangeValidator_s1.ControlToValidate = textBox_s1.ID;
                rangeValidator_s1.MinimumValue = "0"; // Set the minimum value to 0
                rangeValidator_s1.MaximumValue = "100"; // Set the maximum value to 100
                rangeValidator_s1.Type = ValidationDataType.Integer;
                rangeValidator_s1.ErrorMessage = "Please enter a value between 0 and 100.";
                QuizCell.Controls.Add(rangeValidator_s1);

                row.Cells.Add(QuizCell);
            }

            // Re-bind the data to the GridView to preserve ViewState
            GridView3.DataSource = GridView3.DataSource;
            GridView3.DataBind();
        }


    }
    protected void btnAdd_Click_S2(object sender, EventArgs e)
    {
        GridView4.Visible = true;
        if (GridView4.Columns.Count <= 2)
        {

            // Get the current column count of the GridView
            int colCount_quiz = GridView4.Columns.Count - 1;

            // Create a new TemplateField for the new column
            TemplateField newColumn_quiz = new TemplateField();

            // Set the HeaderText of the new column to "Assignment {colCount}"
            newColumn_quiz.HeaderText = "Sessional-2 ";

            // Add the new column to the GridView
            GridView4.Columns.Add(newColumn_quiz);

            // Loop through the rows of the GridView and add a new cell to each row for the new column
            foreach (GridViewRow row in GridView4.Rows)
            {
                TableCell QuizCell = new TableCell();

                // Add a TextBox control to the new cell
                TextBox textBox_s2 = new TextBox();
                textBox_s2.ID = "txtSessional_1" + colCount_quiz.ToString() + "_" + row.RowIndex.ToString();
                textBox_s2.MaxLength = 2; // Limit the maximum length of the input to 3 characters
                textBox_s2.ReadOnly = false; // Set the ReadOnly property to false to allow editing
                QuizCell.Controls.Add(textBox_s2);

                // Set the default value of the TextBox to 0
                textBox_s2.Text = "0";

                // Add a RangeValidator control to the new cell
                RangeValidator rangeValidator_s2 = new RangeValidator();
                rangeValidator_s2.ControlToValidate = textBox_s2.ID;
                rangeValidator_s2.MinimumValue = "0"; // Set the minimum value to 0
                rangeValidator_s2.MaximumValue = "100"; // Set the maximum value to 100
                rangeValidator_s2.Type = ValidationDataType.Integer;
                rangeValidator_s2.ErrorMessage = "Please enter a value between 0 and 100.";
                QuizCell.Controls.Add(rangeValidator_s2);

                row.Cells.Add(QuizCell);
            }

            // Re-bind the data to the GridView to preserve ViewState
            GridView4.DataSource = GridView4.DataSource;
            GridView4.DataBind();
        }

    }
    protected void btnAdd_Click_Final(object sender, EventArgs e)
    {
        GridView5.Visible = true;



    }

    protected void Save_Final(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView5.Rows)
        {
            string rollnum = row.Cells[0].Text;
            string name = row.Cells[1].Text;
            TextBox txtNewColumn = (TextBox)row.FindControl("txtNewColumn");
            string finalMarks = txtNewColumn.Text;

            // Perform processing or display the values
            // ...
        }
    }





    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void Show_Assignments(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView1.DataSource = GridView1.DataSource;
        GridView1.DataBind();
    }

    protected void Show_Quizzes(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        GridView2.DataSource = GridView2.DataSource;
        GridView2.DataBind();
    }

    protected void Show_S1(object sender, EventArgs e)
    {
        GridView3.Visible = true;
        GridView3.DataSource = GridView3.DataSource;
        GridView3.DataBind();
    }

    protected void Show_S2(object sender, EventArgs e)
    {
        GridView4.Visible = true;
        GridView4.DataSource = GridView4.DataSource;
        GridView4.DataBind();

    }

    protected void Show_Final(object sender, EventArgs e)
    {
        GridView5.Visible = true;
        GridView5.DataSource = GridView5.DataSource;
        GridView5.DataBind();


    }
}














        
