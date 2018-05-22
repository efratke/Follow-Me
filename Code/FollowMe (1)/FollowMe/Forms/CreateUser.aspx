<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/masterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="FollowMe.Forms.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <br />
<br />
<br />

    <asp:CreateUserWizard ID="CreateUserWizard1" TitleTextStyle-ForeColor="#1b105b" 
    TitleTextStyle-Font-Size="X-Large" 
     runat="server"
    LabelStyle-ForeColor="#1b105b" LabelStyle-Font-Size="X-Large"  TextBoxStyle-Width="120" TextBoxStyle-CssClass="textBox" 
     
        
     ContinueDestinationPageUrl="~/Home.aspx"
      CreateUserButtonStyle-CssClass="button" CreateUserButtonStyle-BackColor="#1b105b"
         CreateUserButtonStyle-Font-Size="X-Large" CreateUserButtonStyle-ForeColor="White">          
  <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1"  runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
