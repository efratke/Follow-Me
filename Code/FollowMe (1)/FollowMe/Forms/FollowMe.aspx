<%@ Page Title="FollowMe" Language="C#" MasterPageFile="~/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="FollowMe.aspx.cs" Inherits="FollowMe.Forms.FollowMe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <br /><br />
    <asp:Panel ID="pnlCustomers" Visible="false" runat="server">
         <br />  <br /> <asp:Label ID="Label5" runat="server" Text="Choose customer to see his laundry"></asp:Label>
        <br />  <br />  <br />
        <asp:GridView ID="gvShowOwners" runat="server" AllowPaging="True" PageIndex="5" ForeColor="#333333"
            GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
            DataSourceID="SqlDataSource1" OnSelectedIndexChanging="gvSohw_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OwnerId" HeaderText="OwnerId" SortExpression="OwnerId" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Pass" HeaderText="Pass" SortExpression="Pass" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            </Columns>
            <EditRowStyle CssClass="gridEditRowStyle" />
            <FooterStyle CssClass="gridFooterStyle" />
            <HeaderStyle CssClass="gridHeaderStyle" />
            <PagerStyle BackColor="White" />
            <RowStyle CssClass="gridRowStyle" />
            <SelectedRowStyle CssClass="gridSelectedRowStyle" BackColor="#4f81bd" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Owners]"></asp:SqlDataSource>
    </asp:Panel>
       <asp:Label ID="Label4" runat="server" Text="To see you put your laundry"></asp:Label>
    <br />
    <br />
    <br />
    <asp:PlaceHolder ID="phEnter" runat="server">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter data!"
                        ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="You must use only English letters" ValidationExpression="[A-Z]?([a-z]*)"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Enter your password"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter data!"
                        ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
    </asp:PlaceHolder>
    <asp:Button ID="btnEnter" runat="server" Text="Enter" CssClass="button" OnClick="btnEnter_Click" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="מחשב נתונים...   אנא המתן" Visible="false"></asp:Label>
    <asp:GridView ID="gvSohw" runat="server" Visible="false" AllowPaging="true" AllowSorting="true"
         AutoGenerateColumns="false"
        ForeColor="#333333" GridLines="None" Width="1200px"><%--OnSelectedIndexChanging="gvSohw_SelectedIndexChanging"--%>
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <%--<asp:CommandField ShowSelectButton="true" SelectText="Details of all stations" />--%>
            <asp:BoundField DataField="process" HeaderText="Type of laundry" />
            <asp:BoundField DataField="color" HeaderText="Color" />
            <asp:BoundField DataField="timeStart" HeaderText="Start time" />
            <%--<asp:BoundField DataField="timeEnd" HeaderText="שעת סיום משוערת" />--%>
            <asp:BoundField DataField="minutePast" HeaderText="Last time" />
            <%--<asp:BoundField DataField="minuteEnd" HeaderText=" Minutes left in the current process " />--%>
            <%--  <asp:BoundField DataField="totalTime" HeaderText="זמן כולל" />--%>
            <asp:BoundField DataField="station" HeaderText="Current Process" />
            <%--<asp:BoundField DataField="nextStation" HeaderText="Next process" />--%>
            <asp:BoundField DataField="status" HeaderText="Status" />
        </Columns>
        <EditRowStyle CssClass="gridEditRowStyle" />
        <FooterStyle CssClass="gridFooterStyle" />
        <HeaderStyle CssClass="gridHeaderStyle" />
        <PagerStyle BackColor="White"/>
        <RowStyle CssClass="gridRowStyle" />
        <SelectedRowStyle CssClass="gridSelectedRowStyle" BackColor="#4f81bd" />
    </asp:GridView>
    <br />
    <br />
    <br />
    <asp:GridView ID="gvStation" runat="server" Visible="false" SelectedRowStyle-BackColor="#4f81bd"
        BackColor="#4f81bd" ForeColor="#333333"
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <HeaderStyle ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle CssClass="gridSelectedRowStyle" BackColor="#4f81bd" />
    </asp:GridView>

    <asp:Timer ID="tmrTime" Enabled="false" OnTick="tmrTime_Tick" runat="server">
    </asp:Timer>
    
    <br />
    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Visible="false" Text="Back" CssClass="button" OnClick="btnBack_Click"/>
</asp:Content>
