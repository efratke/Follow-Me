<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Customer.Master" AutoEventWireup="true" CodeBehind="ArchiveOrders.aspx.cs" Inherits="FollowMe.Forms.ArchiveOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Table ID="tblDates" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="200px">
                <asp:Button ID="btnAll" runat="server" Text="View All orders" CssClass="button" OnClick="btnAll_Click" />
            </asp:TableCell>
            
            <asp:TableCell Width="200px">
                <asp:Button ID="btnDate" runat="server" Text="Select a range of processes" CssClass="button" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ID="TableCell1" runat="server" Width="300px" HorizontalAlign="Left">
                <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
                <asp:TextBox ID="txtFrom" runat="server" Width="120"></asp:TextBox>
                <asp:Button ID="btnFrom" runat="server" Text="..." />
            </asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server" Width="300px" HorizontalAlign="Right">
                <asp:Label ID="Label3" runat="server" Text="To:"></asp:Label>
                <asp:TextBox ID="txtTo" runat="server" Width="120"></asp:TextBox>
                <asp:Button ID="btnTo" runat="server" Text="..." />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Calendar ID="clnStart" runat="server" Visible="false" OnSelectionChanged="clnStart_OnSelectionChanged" BackColor="White" BorderColor="Black"
                    DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="#1b105b"
                    Height="220px" NextPrevFormat="FullMonth" TitleFormat="MonthYear" Width="300px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt" ForeColor="#1b105b"
                        Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="12pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#1b105b" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="#1b105b" Font-Bold="True" Font-Size="18pt" ForeColor="White"
                        Height="14pt" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="clnEnd" runat="server" Visible="false" OnSelectionChanged="clnEnd_OnSelectionChanged" BackColor="White" BorderColor="Black"
                    DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="#1b105b"
                    Height="220px" NextPrevFormat="FullMonth" TitleFormat="MonthYear" Width="300px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="10pt" ForeColor="#1b105b"
                        Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="12pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#1b105b" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                        ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="#1b105b" Font-Bold="True" Font-Size="18pt" ForeColor="White"
                        Height="14pt" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
     <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="button" Visible="false" OnClick="btnOk_Click" />
    <br />
     <br />
     <asp:Panel ID="pnlShow" runat="server" Visible="false">
      <%--  <asp:Label ID="Label2" runat="server" Text="Please choose laundry type to view the order of that type"></asp:Label>
     <asp:DropDownList  runat="server" ID="ddlProcess" AutoPostBack="true" 
        onselectedindexchanged="ddlProcess_SelectedIndexChanged"  >
    </asp:DropDownList>
 <br />
     <br />
     <br />--%>
      <asp:Label ID="Label4" runat="server" Text="Please choose customer to view the order of that customer"></asp:Label>

        <asp:DropDownList ID="ddlCustomer" runat="server"  AutoPostBack="true"
         onselectedindexchanged="ddlCustomer_SelectedIndexChanged" >
        </asp:DropDownList>

     <br />
     <br />
  
    <asp:GridView ID="gvShow" runat="server" Width="800px" 
    AllowPaging="true" PageSize="5"  ForeColor="#333333" 
             onpageindexchanging="gvShow_PageIndexChanging"> 
      <AlternatingRowStyle BackColor="White" />
    <HeaderStyle ForeColor="White" />
    <RowStyle BackColor="#EFF3FB"/>
    <FooterStyle CssClass="gridFooterStyle" />
<HeaderStyle CssClass ="gridHeaderStyle" />
<PagerStyle BackColor="White" />
<RowStyle CssClass ="gridRowStyle" />

    </asp:GridView>
    </asp:Panel>

</asp:Content>
