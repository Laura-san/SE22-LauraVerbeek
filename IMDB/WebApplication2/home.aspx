<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.cs" Inherits="IMDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style type="text/css">
        #body {
            height: 686px;
        }
        #form1 {
            height: 737px;
            width: 977px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="left" style="width: 121px; height: 267px; float: left;">
        <div id="logo" style="width: 121px; height: 101px;">
            <asp:Image ID="Logo" runat="server" Height="271px" Width="121px" />
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
        
        <div style="float: right; width: 616px; margin-top: 0px; height: 243px;" id="Body">
            
            <div id="top5" style="height: 121px; width: 616px">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Top 5"></asp:Label>
                </div>
                <asp:ImageButton ID="Film1" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Film2" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="film3" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Film4" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Film5" runat="server" Height="104px" Width="120px" />
            <div id="Birthday" style="height: 121px; width: 616px">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Happy Birthday!"></asp:Label>
                </div>
                <asp:ImageButton ID="Actor1" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Actor2" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Actor3" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Actor4" runat="server" Height="104px" Width="120px" />
                <asp:ImageButton ID="Actor5" runat="server" Height="104px" Width="120px" />
            </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
