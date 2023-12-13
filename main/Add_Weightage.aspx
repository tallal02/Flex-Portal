<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Weightage.aspx.cs" Inherits="Add_Weightage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: medium;margin-left: 340px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table>
                <tr>
                    <th>Task</th>
                    <th>Weightage (%)</th>
                    <th></th>
                </tr>
                <tr>
                    <td>Assignments</td>
                    <td>
                        <input type="number" min="0" max="100" step="0.1" runat="server" id="txtAssignments"></td>
                    <td><i class="fas fa-plus" onclick="addRow('Assignments')"></i></td>
                </tr>
                <tr>
                    <td>Quizzes</td>
                    <td>
                        <input type="number" min="0" max="100" step="0.1" runat="server" id="txtQuizzes"></td>
                    <td><i class="fas fa-plus" onclick="addRow('Quizzes')"></i></td>
                </tr>
                <tr>
                    <td>Sessional-1</td>
                    <td>
                        <input type="number" min="0" max="100" step="0.1" runat="server" id="txtSessional1"></td>
                    <td><i class="fas fa-plus" onclick="addRow('Sessional1')"></i></td>
                </tr>
                <tr>
                    <td>Sessional-2</td>
                    <td>
                        <input type="number" min="0" max="100" step="0.1" runat="server" id="txtSessional2"></td>
                    <td><i class="fas fa-plus" onclick="addRow('Sessional2')"></i></td>
                </tr>
                <tr>
                    <td>Final Exam</td>
                    <td>
                        <input type="number" min="0" max="100" step="0.1" runat="server" id="txtFinalExam"></td>
                    <td><i class="fas fa-plus" onclick="addRow('FinalExam')"></i></td>
                </tr>
                <tr>
                   <%-- <td>Total Weightage:</td>
                    <td></td>--%>
                    <td><span runat="server" id="lblTotalWeightage"></span></td>
                </tr>
            </table>
            

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" BackColor="White" BorderColor="Black" Font-Underline="False" OnClick="LinkButton1_Click" style="color: #000000; font-size: medium; text-align: center; margin-left: 0px;" BorderWidth="1px" Height="28px" Width="84px">Submit</asp:LinkButton>

        </div>
        
        <p>
            &nbsp;</p>
        
    </form>
</body>
</html>
