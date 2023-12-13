<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance</title>
    <style>
        /* Set font styles */
body {
    font-family: Arial, sans-serif;
    font-size: 14px;
}

/* Set styles for the label and gridview */
#form1 {
    margin: 0 auto;
    width: 80%;
}

#Label1 {
    font-weight: bold;
    font-size: 18px;
}

#GridView1 {
    margin-top: 20px;
    border-collapse: collapse;
    width: 100%;
}

#GridView1 th, #GridView1 td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: center;
}

#GridView1 th {
    background-color: #f2f2f2;
    color: #333;
    font-weight: bold;
}

#lblAttendancePercentage {
    font-size: 16px;
    font-weight: bold;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Label ID="lblAttendancePercentage" runat="server"></asp:Label>
        <br />
        <br />
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="SerialNo" HeaderText="Serial No." />
        <asp:BoundField DataField="Date" HeaderText="Date" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>
</asp:GridView>
    </form>
</body>
</html>
