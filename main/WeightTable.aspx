<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeightTable.aspx.cs" Inherits="WeightTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 400px;
        }

        .auto-style3 {
        }

        .auto-style4 {
            margin-left: 80px;
        }

        .auto-style5 {
        }

        .auto-style6 {
            margin-left: 80px;
        }
        .auto-style7 {
            margin-left: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <%-- <asp:Button ID="btnSubmit" runat="server" Text="Retrieve" PostBackUrl="Add_Weightage.aspx" />--%>
            <table>
                <tr>
                    <%-- <td>Total Weightage:</td>
                    <td></td>--%>
                    <td><span runat="server" id="lblTotalWeightage"></span>
                        <asp:Button ID="Save1" runat="server" Height="26px" OnClick="Save" Text="Save" Width="58px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" Style="margin-left: 1040px" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="auto-style4">
            <asp:Button ID="btnAddColumn" runat="server" Height="60px" OnClick="btnAdd_Click_Assignment" Text="New Assignment +" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn0" runat="server" Height="60px" OnClick="btnAdd_Click_Quiz" Text="New Quiz +" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn1" runat="server" Height="60px" OnClick="btnAdd_Click_S1" Text="Sessional 1 +" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn2" runat="server" Height="60px" OnClick="btnAdd_Click_S2" Text="Sessional 2 +" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn3" runat="server" Height="60px" OnClick="btnAdd_Click_Final" Text="Final Exam +" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            <br />
            <br />
        </div>
        <div class="auto-style6">

            <asp:Button ID="btnAddColumn4" runat="server" Height="60px" OnClick="Show_Assignments" Text="Assignments" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn5" runat="server" Height="60px" OnClick="Show_Quizzes" Text="Quizzes" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn6" runat="server" Height="60px" OnClick="Show_S1" Text="Sessional 1 " Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn7" runat="server" Height="60px" OnClick="Show_S2" Text="Sessional 2 " Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddColumn8" runat="server" Height="60px" OnClick="Show_Final" Text="Final Exam" Width="162px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" />

        </div>
        <div style="display: inline-block; margin-left: 240px;">
            &nbsp;&nbsp;&nbsp;
        <br />
            <br />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="margin-left: 40px">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style5" DataKeyNames="Rollnum" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="194px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="173px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />

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


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:FinalConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT s.Rollnum, u.Name FROM Teaches t INNER JOIN Student s ON t.SectionID = s.SectionID 
INNER JOIN [User] u ON u.CNIC = s.CNIC
WHERE t.InstructorID = 'F115'"></asp:SqlDataSource>
        <br />

    </div>
        <div style="margin-left: 40px">
            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style5" DataKeyNames="Rollnum" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="194px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="173px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />

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


            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:FinalConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT s.Rollnum, u.Name FROM Teaches t INNER JOIN Student s ON t.SectionID = s.SectionID 
INNER JOIN [User] u ON u.CNIC = s.CNIC
WHERE t.InstructorID = 'F115'"></asp:SqlDataSource>
            <br />

        </div>
        <div style="margin-left: 40px">
            <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style5" DataKeyNames="Rollnum" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="194px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="173px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />

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


            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:FinalConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT s.Rollnum, u.Name FROM Teaches t INNER JOIN Student s ON t.SectionID = s.SectionID 
INNER JOIN [User] u ON u.CNIC = s.CNIC
WHERE t.InstructorID = 'F115'"></asp:SqlDataSource>
            <br />

        </div>
        <div style="margin-left: 40px">
            <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style5" DataKeyNames="Rollnum" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="194px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="173px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />

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


            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:FinalConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT s.Rollnum, u.Name FROM Teaches t INNER JOIN Student s ON t.SectionID = s.SectionID 
INNER JOIN [User] u ON u.CNIC = s.CNIC
WHERE t.InstructorID = 'F115'"></asp:SqlDataSource>
            <br />

        </div>
        <div style="margin-left: 40px">
            
            <asp:GridView ID="GridView5" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style5" DataKeyNames="Rollnum" DataSourceID="SqlDataSource5" ForeColor="Black" GridLines="Vertical" Height="194px" OnSelectedIndexChanged="btnAdd_Click_Final" Width="173px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Rollnum" HeaderText="Rollnum" ReadOnly="True" SortExpression="Rollnum" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:TemplateField HeaderText="Final Marks">
                    <ItemTemplate>
                        <asp:TextBox ID="txtNewColumn" runat="server" Text='<%# Bind("N_Marks") %>'></asp:TextBox>
                    </ItemTemplate>
                 </asp:TemplateField>

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



            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:FinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:FinalConnectionString2.ProviderName %>" 
SelectCommand="SELECT DISTINCT s.Rollnum, u.Name,r.N_Marks FROM Teaches t INNER JOIN Student s ON t.SectionID = s.SectionID 
INNER JOIN [User] u ON u.CNIC = s.CNIC INNER JOIN Assessment_Items r ON r.T_ID = InstructorID WHERE t.InstructorID = 'F115'"></asp:SqlDataSource>
            <br />

        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            



        <p class="auto-style7">
                        <asp:Button ID="Save2" runat="server" Height="26px" OnClick="Save_Final" Text="Save" Width="58px" BackColor="#0066FF" ForeColor="White" CssClass="auto-style3" Style="margin-left: 1040px" />
                    </p>
            



    </form>
</body>
</html>

<FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />