<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Home.aspx.cs" Inherits="Student_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Home.aspx.cs" Inherits="Student_Home" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
/* body styles */
body {
  font-family: Arial, sans-serif;
  font-size: 16px;
  line-height: 1.5;
}

/* grid view styles */
#GridView1, #GridView2 {
  border-collapse: collapse;
  margin-bottom: 20px;
}

#GridView1 th, #GridView2 th {
  padding: 10px;
  background-color: #f2f2f2;
  text-align: left;
  font-weight: bold;
}

#GridView1 td, #GridView2 td {
  padding: 10px;
  border: 1px solid #ddd;
}

/* chart styles */
#Chart1, #attendanceChart {
  width: 100%;
  height: 400px;
  margin-bottom: 20px;
}

.button-column {
  position: fixed;
  top: 0;
  right: 0;
  padding: 10px;
  background-color: #f2f2f2;
}

.button-column button {
  display: block;
  margin-bottom: 10px;
}


    </style>
</head>
<body>
   

    <form id="form1" runat="server">
         <div class="button-column">
  <asp:Button ID="Button1" runat="server" Text="Attendance" OnClick="Attendance_Button_Click" />
  <asp:Button ID="Button2" runat="server" Text="Marks" OnClick="Marks_Button_Click" />
  <asp:Button ID="Button3" runat="server" Text="Transcript" OnClick="Trans_Button_Click" />
  <asp:Button ID="Button4" runat="server" Text="Feedback" OnClick="Feed_Button_Click" />

</div>
    <p>
       <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </p>
        <h2>
            Personal Information</h2>
        <p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="CNIC">
                <Columns>
                    <asp:BoundField DataField="CNIC" HeaderText="CNIC" ReadOnly="True" SortExpression="CNIC" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="Blood_Group" HeaderText="Blood_Group" SortExpression="Blood_Group" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                </Columns>
            </asp:GridView>
        </p>
        <h2>
            University Information</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Rollnum">
            <Columns>
                <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                <asp:BoundField DataField="CNIC" HeaderText="CNIC" SortExpression="CNIC" />
                <asp:BoundField DataField="Campus" HeaderText="Campus" SortExpression="Campus" />
                <asp:BoundField DataField="SectionID" HeaderText="SectionID" SortExpression="SectionID" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
        <h2>
            Attendance</h2>
         <p>
             <asp:Chart ID="attendanceChart" runat="server">
                 <Series>
                     <asp:Series ChartType="Bar" Name="Series1">
                     </asp:Series>
                 </Series>
                 <ChartAreas>
                     <asp:ChartArea Name="ChartArea1">
                     </asp:ChartArea>
                 </ChartAreas>
             </asp:Chart>
         </p>
        <h2>
            Semester GPA</h2>
        <asp:Chart ID="Chart1" runat="server">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </form>
    </body>
</html>

