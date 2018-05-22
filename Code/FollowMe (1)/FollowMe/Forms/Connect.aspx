<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="Connect.aspx.cs" Inherits="FollowMe.Forms.Connect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br /><br /><br />
        <asp:Label ID="lblinitReader" runat="server" Text="Connect the tag Reader and reading click connect:"></asp:Label>
   
     <asp:Timer ID="tmrCount" runat="server" Interval="2000" Enabled="False" 
        ontick="tmrCount_Tick">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <br /><br /><br />
 <asp:Button ID="initReader" runat="server" CssClass="button" Text="Connect"  onclick="initReader_Click"  />
        <br /> 
          <img id="Img1"  src="../Images/refresh.gif" visible="false" runat="server" height="30" width="30"/>
   
     <asp:Label ID="lblTags" runat="server" Visible="false" ></asp:Label>
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger  ControlID="tmrCount" EventName="tick" />
    </Triggers>
    </asp:UpdatePanel>

    <asp:GridView ID="gvTags" runat="server">
    </asp:GridView>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
      <br /><br />
    <asp:Label ID="lblReaders" runat="server" Visible="false" Text="Readers connected:"></asp:Label>
     <br /><br />
    <asp:GridView ID="gvReaders" runat="server" Visible="false" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
        </Columns>
       </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [Name], [Area] FROM [Readers]"></asp:SqlDataSource></ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger  ControlID="initReader" EventName="click" />
        </Triggers>
    </asp:UpdatePanel>
             <br />
   

</asp:Content>
