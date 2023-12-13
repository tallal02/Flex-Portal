using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Add_Weightage : System.Web.UI.Page
{
    UserDetails userDetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set default values for input fields
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Total weightage should be equal to 100.');", true);

            txtAssignments.Value = "0";
            txtQuizzes.Value = "0";
            txtSessional1.Value = "0";
            txtSessional2.Value = "0";
            txtFinalExam.Value = "0";

            //CalculateTotalWeightage();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        double total = 0, assignments = 0, quizzes = 0, s1 = 0, s2 = 0, final = 0;

        //assignments = Convert.ToDouble(Request.Form["txtAssignments"]);
        //total += assignments;

        //quizzes = Convert.ToDouble(Request.Form["txtAssignments"]);
        //total += quizzes;


        //s1 = Convert.ToDouble(Request.Form["txtAssignments"]);
        //total += s1;


        //s2 = Convert.ToDouble(Request.Form["txtAssignments"]);
        //total += s2;


        //final = Convert.ToDouble(Request.Form["txtAssignments"]);
        //total += final;


        total += Convert.ToDouble(Request.Form["txtAssignments"]);
        total += Convert.ToDouble(Request.Form["txtQuizzes"]);
        total += Convert.ToDouble(Request.Form["txtSessional1"]);
        total += Convert.ToDouble(Request.Form["txtSessional2"]);
        total += Convert.ToDouble(Request.Form["txtFinalExam"]);

        Response.Cookies["assignments"].Value = txtAssignments.Value;
        Response.Cookies["quizzes"].Value = txtQuizzes.Value;
        Response.Cookies["sessional1"].Value = txtSessional1.Value;
        Response.Cookies["sessional2"].Value = txtSessional2.Value;
        Response.Cookies["finalexam"].Value = txtFinalExam.Value;

        lblTotalWeightage.InnerText = total.ToString();
        double totalWeightage = Convert.ToDouble(lblTotalWeightage.InnerText);

        if (total != 100)
        {
            // Display an error message and reset the input fields
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Total weightage should be equal to 100.');", true);
             Response.Redirect("Add_Weightage.aspx");

        }
        else if (totalWeightage == 100)
        {
            //userDetails.assignments(Request.Form["txtAssignments"], );
            //userDetails = (UserDetails)Session["UserDetails"];
            //Response.Redirect("WeightTable.aspx?assignments=" + assignments + "&quizzes=" + quizzes + "&sessional1=" + s1 + "&sessional2=" + s2 + "&finalexam=" + final);

            Response.Redirect("WeightTable.aspx", true);
        }
    }
}