<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Manager.Master" AutoEventWireup="true" CodeBehind="Station.aspx.cs" Inherits="FollowMe.Forms.Station" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select a setting you want to edit / delete   "></asp:Label>
    <br />
    <br />
    <br />
    <br />

    <asp:DropDownList ID="ddlReaders" runat="server"
        OnSelectedIndexChanged="ddlReaders_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:LinkButton ID="btnEdit" runat="server" CssClass="LinkButton" OnClick="btnEdit_Click">Edit</asp:LinkButton>

    <asp:LinkButton ID="btnDel" runat="server" CssClass="LinkButton" OnClick="btnDel_Click">Delete</asp:LinkButton>

    <asp:LinkButton ID="lnkNew" runat="server" CssClass="LinkButton" OnClick="lnkNew_Click">New station</asp:LinkButton>

    <asp:Panel ID="pnlNew" runat="server" Visible="false">
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblName" runat="server" Text="station name:"></asp:Label>
                    <br />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="You must enter data!"></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="You must use only English letters" ValidationExpression="[A-Z]?([a-z]*)"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
        <%--   <ContentTemplate >--%>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Select reader and antennas for this operation">
        </asp:Label>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"
                        Style="direction: ltr">
                    </asp:CheckBoxList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:PlaceHolder ID="phActiveAnt" runat="server"></asp:PlaceHolder>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="button" OnClick="btnOk_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"
            OnClick="btnCancel_Click" />
        <%--</ContentTemplate>--%>
        <%-- </asp:UpdatePanel>--%>
    </asp:Panel>
</asp:Content>
