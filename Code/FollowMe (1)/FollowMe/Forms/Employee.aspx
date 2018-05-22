<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Employees.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="followMe.Forms.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnAllEmployees" runat="server" CssClass="button" Text="See all employees" OnClick="btnAllEmployees_Click" />
    <br />
    <br />
    <asp:GridView ID="gvAllEmployees" runat="server" Visible="False" PageSize="5"
        AllowPaging="True" AllowSorting="True" ForeColor="#333333" GridLines="None"
        AutoGenerateColumns="False" DataKeyNames="EmployeeId">
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <PagerStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True"
                ShowDeleteButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Pass" HeaderText="Pass" SortExpression="Pass" />
            <asp:BoundField DataField="TypeAuthorization" HeaderText="TypeAuthorization"
                ReadOnly="True" SortExpression="TypeAuthorization" />
           </Columns>
        <EditRowStyle CssClass="gridEditRowStyle" />
        <FooterStyle CssClass="gridFooterStyle" />
        <HeaderStyle CssClass="gridHeaderStyle" />
        <PagerStyle BackColor="White" />
        <RowStyle CssClass="gridRowStyle" />
        <SelectedRowStyle CssClass="gridSelectedRowStyle" BackColor="#4f81bd" />
    </asp:GridView>
           <%--     <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
         DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeId] = @EmployeeId" 
        SelectCommand="SELECT Employees.Name, Employees.Pass, Authorizations.TypeAuthorization, Employees.EmployeeId FROM Employees INNER JOIN Authorizations ON Employees.AuthorizationId = Authorizations.AuthorizationId"
         UpdateCommand="UPDATE [Employees] SET [Name] = @Name, [Pass] = @Pass WHERE [EmployeeId] = @EmployeeId"
          InsertCommand="INSERT INTO [Employees] ([Name], [Pass], [AuthorizationId]) VALUES (@Name, @Pass, @AuthorizationId)" >
            <UpdateParameters>
            <asp:Parameter Name="EmployeeId" />
        </UpdateParameters>
    </asp:SqlDataSource>--%>
    <br />
    <asp:Button ID="btnEmployee" runat="server" CssClass="button" Text="Add new Employee"
        OnClick="btnEmployee_Click" />
    <br />
    <br />
    <asp:Panel ID="pnlEmployee" Visible="false" runat="server">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPass" runat="server" Text="pass"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblAuthorization" runat="server" Text="Authorization"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList
                        ID="ddlAuthorization" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <br />
        <br />
        <asp:Button ID="btnOk" runat="server" CssClass="button" Text="Ok" OnClick="btnOk_Click" />
    </asp:Panel>
    <br />
    </asp:Content>
