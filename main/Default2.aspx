<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div style="margin-left: 340px">
        <br />
        <table>
            <tr>
                <td>
                    <img src="https://flex.nu.edu.pk/Content/Images/Flex-Login-3.png" alt="Flex logo" height="50" width="auto" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    <div style="display: inline-block; margin-left: 240px;">
        <asp:Button ID="btnAddColumn" runat="server" Height="50px" OnClick="btnAdd_Click_Click" Text="New +" Width="134px" BackColor="#0066FF" ForeColor="White" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </div>
    <div style="display: inline-block; margin-left: 1px;">
        <asp:Button ID="btnAddColumn0" runat="server" Height="50px" OnClick="Save" Text="Save" Width="134px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style1" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </div>

    <div style="margin-left: 400px">
    </div>
    <div style="margin-left: 240px">
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="411px" Width="584px" >
            <Columns>
                <asp:BoundField DataField="RollNo" HeaderText="Roll No" />
                <asp:TemplateField HeaderText =" Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value="P">P</asp:ListItem>
                            <asp:ListItem Value="A">A</asp:ListItem>
                            <asp:ListItem Value="L">L</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="#CCCCCC" />
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
       <div>
           <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
       </div>
</form>

</body>
</html>
