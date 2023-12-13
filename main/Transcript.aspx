<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transcript.aspx.cs" Inherits="Transcript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transcript</title>
    <style>
        body {
        font-family: Arial, sans-serif;
        background-color: #f2f2f2;
        margin: 0;
        padding: 0;
    }

    .container {
        max-width: 800px;
        margin: 0 auto;
        padding: 20px;
    }

    .label {
        font-size: 18px;
        font-weight: bold;
        margin-bottom: 10px;
    }

    .grid {
        margin-top: 20px;
    }

    .grid th,
    .grid td {
        padding: 8px;
        text-align: left;
        border: 1px solid #ccc;
    }

    .grid th {
        background-color: #f2f2f2;
        font-weight: bold;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="SGPA"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="CGPA"></asp:Label>
            <br />
            <asp:GridView ID="courseGrid" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
        <asp:BoundField DataField="CreditHours" HeaderText="Credit Hours" />
        <asp:BoundField DataField="GradePoints" HeaderText="Grade Points" />
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
