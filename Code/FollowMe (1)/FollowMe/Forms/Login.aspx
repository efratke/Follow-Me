<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/masterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="followMe.Forms.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <asp:Login ID="Login1"   runat="server" DestinationPageUrl="~/Enter.aspx"  BackColor="#f7f6f3"
     BorderColor="#e6e2d8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px"  
     Font-Names="verdana" Font-Size="0.8em" 
       PasswordRecoveryUrl="~/PasswordRecovery.aspx"
      CreateUserUrl="~/CreateUser.aspx" LabelStyle-CssClass="Label"
       TextBoxStyle-CssClass="textBox" LoginButtonStyle-CssClass="button" CheckBoxStyle-CssClass="Label" 
       TitleTextStyle-CssClass="Titel" TitleTextStyle-ForeColor="#1b105b" >
    </asp:Login>
</asp:Content>
