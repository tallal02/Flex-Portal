<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 280px;
        }
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            font-size: medium;
        }
        .myButtonClass {}
        .auto-style5 {
            margin-left: 1160px;
        }
        .auto-style7 {}
        .auto-style8 {
            margin-left: 360px;
        }
        .auto-style9 {
            margin-left: 2px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
	 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
	 <link href="Ad.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container vh-100 m-0" style="background-image: url('https://wallpaperaccess.com/full/6802.jpg'); background-position: center; background-size: cover; background-repeat: no-repeat; height:auto">
        <div class="auto-style5" style="margin-left: 10px">
            <asp:Label ID="lblWelcome" CssClass="text-white" runat="server" Text=""></asp:Label>
        </div>
        <div class="auto-style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" CssClass="auto-style2" Font-Names="Times New Roman">Campus</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" CssClass="auto-style2" Font-Names="Times New Roman">Semester</asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style3" Font-Names="Times New Roman" Height="37px" Width="206px">
                <asp:ListItem>Lahore</asp:ListItem>
                <asp:ListItem>Islamabad</asp:ListItem>
                <asp:ListItem>Chiniot-Faisalabad</asp:ListItem>
                <asp:ListItem>Karachi</asp:ListItem>
                <asp:ListItem>Multan</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style3" Font-Names="Times New Roman" Height="37px" Width="206px">
                <asp:ListItem>Spring 2023</asp:ListItem>
                <asp:ListItem>Fall 2022</asp:ListItem>
                <asp:ListItem>Spring 2022</asp:ListItem>
                <asp:ListItem>Fall 2021</asp:ListItem>
                <asp:ListItem>Spring 2021</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString %>" SelectCommand="SELECT  c.Course_Name
FROM Courses c
INNER JOIN Teaches t ON c.Course_Code = t.Course_Code
WHERE t.InstructorID = 'F108'"></asp:SqlDataSource>
            <br />
        </div>
        
    <div style="overflow: auto;margin-left: 1px">
        <div style="float: left;">
            <br />
            <br />
            <asp:Button ID="btnSetDistribution" runat="server" Text="Manage Attendance" CssClass="myButtonClass" OnClick="btnSetDistribution_Click" Height="34px" Width="231px" />
            <br />
            <br />

            <asp:Button ID="ManageAttendance" runat="server" Text="Set Distribution" CssClass="myButtonClass" OnClick="SetDistribution" Height="33px" Width="231px" />
        </div>
        <div style="margin-left: 360px;">
            <div class="auto-style9">
&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style7" ForeColor="Black" GridLines="Vertical" Height="322px" Width="777px">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="Course_Code" HeaderText="Course Code" />
                        <asp:BoundField DataField="Course_Name" HeaderText="Course Name" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </div>
            <br />
        </div>
    </div>
    <br />
    <br />
        <div class="auto-style8">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    <br />
    <div>
    </div>

       

      
    </form>
</body>
</html>
