<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApplication2.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create an account</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="left" style="width: 121px; height: 267px; float: left;">
        <div id="logo" style="width: 121px; height: 101px;">
            <asp:ImageButton ID="BtnLogo" runat="server" Height="101px" Width="121px" src="pictures\movies.jpg"/>
        </div>
        <div style="height: 168px; width: 121px; " id="Menu">
            <asp:Button ID="btn_logon" runat="server" Text="Log on" Width="117px" />
            <asp:Button ID="btn_createAccount" runat="server" Text="Create Account!" Width="117px" />
            <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <Items>
                    <asp:MenuItem Text="Movies" Value="google" NavigateUrl="~/Movies.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Actors" Value="Actors" NavigateUrl="~/Actors.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Genre" Value="Genre" NavigateUrl="~/Genre.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Users" Value="Users"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#5D7B9D" />
            </asp:Menu>
        </div>
        </div>

        <div id="right" style="float: left; width: 616px; height:268px;">
        <div  id="search" style =" float:left;">
            <asp:TextBox ID="tb_search" runat="server" Width="457px"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="Search" Width="149px" />
        </div>
            <div id="logon" style="height: 150px; width: 250px; margin-left: 158px; margin-top: 60px;">
                <div id="label" style="float:left;">
                <div id="username" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                </div>
                <div id="password" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                </div>
                <div id="name" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                </div>
                <div id="mail" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblMail" runat="server" Text="Email:"></asp:Label>
                </div>
                </div>
                <div id="textbox" style="float:left; width: 100px;">
                    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    <asp:TextBox ID="tbMail" runat="server"></asp:TextBox>
                </div>
                <div id="createbutton" style="float: right;">
                    <asp:Button ID="btnCreate" runat="server" Text="Create" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
