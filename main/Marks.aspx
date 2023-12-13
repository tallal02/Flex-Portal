<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Marks.aspx.cs" Inherits="Marks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marks</title>
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
        border-collapse: collapse;
        width: 100%;
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

    .p-heading {
        font-size: 16px;
        font-weight: bold;
        margin-top: 20px;
    }

    .p-subheading {
        font-size: 14px;
        font-weight: bold;
        margin-bottom: 5px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phMarks" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>


        <p>
            Quiz</p>


      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="SerialNo" HeaderText="Serial No." />
        <asp:BoundField DataField="Type" HeaderText="Type" />
        <asp:BoundField DataField="T_Marks" HeaderText="Total Marks" />
        <asp:BoundField DataField="Weightage" HeaderText="Weightage" />
        <asp:BoundField DataField="Obtained_Marks" HeaderText="Obtained Marks" />
    </Columns>
</asp:GridView>



        <p>
            Assignments</p>
        <p>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </p>
        <p>
            Mids</p>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <br />
        Finals<br />
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>



    </form>
</body>
</html>
