<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="FollowMe.Forms.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br /><br /><br />

    <asp:Button ID="linkBtnReader" runat="server" Text="Definition readers" CssClass="button" Width="500px"
        onclick="linkBtnReader_Click"></asp:Button>
    <br /><br />
    <asp:Button ID="linkBtnReaders" runat="server"  Text="Managing and setting laundering stations" CssClass="button" Width="500px"
        onclick="linkBtnReaders_Click"></asp:Button>
    <br /><br />
    <asp:Button ID="linkBtnNewProcess" runat="server" Text="Washing process" CssClass="button" Width="500px"
        onclick="linkBtnNewProcess_Click" ></asp:Button>
    <br /><br />
              <br />
</asp:Content>
