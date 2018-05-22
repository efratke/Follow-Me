<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Customer.Master" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="FollowMe.Forms.PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<br />
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" TextBoxStyle-CssClass="textBox" 
    LabelStyle-CssClass="Label" SubmitButtonStyle-CssClass="button" 
   InstructionTextStyle-CssClass="Titel" TitleTextStyle-CssClass="Titel" SuccessPageUrl="~/Home.aspx" >
    </asp:PasswordRecovery>
</asp:Content>
