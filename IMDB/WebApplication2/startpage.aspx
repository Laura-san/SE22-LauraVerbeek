<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startpage.aspx.cs" Inherits="WebApplication2.startpage" %>

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
            
            <asp:ImageButton ID="BtnLogo" runat="server" Height="98px" Width="118px" OnClick="BtnLogo_Click" src="pictures\movies.jpg"/>
            
        </div>
        <div style="height: 168px; width: 121px; " id="Menu">
            <asp:Button ID="btn_logon" runat="server" Text="Log on" Width="117px" OnClick="btn_logon_Click1"/>
            <asp:Button ID="btn_createAccount" runat="server" Text="Create Account!" Width="117px" OnClick="btn_createAccount_Click" />
            <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <Items>
                    <asp:MenuItem Text="Movies" Value="Movies" NavigateUrl="~/Movies.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Actors" Value="Actors" NavigateUrl="~/Actors.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Genre" Value="Genre" NavigateUrl="~/Genre.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Users" Value="Users"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#5D7B9D" />
            </asp:Menu>
            <asp:Button ID="btn_AddMovie" runat="server" Text="Add a Movie" Width="117px" />
            <asp:Button ID="btn_AddActor" runat="server" Text="Add a Actor" Width="117px" />
        </div>
        </div>

        <div id="right" style="float: left; width: 616px; height:268px;">
        <div  id="search" style =" float:left;">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="129px">
                <asp:ListItem>Movies</asp:ListItem>
                <asp:ListItem>Actors</asp:ListItem>
                <asp:ListItem>Genre</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="tb_search" runat="server" Width="316px" style="margin-left: 1px"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="Search" Width="149px" />
        </div>
        
        <div style="float: right; width: 616px; margin-top: 0px; height: 500px;" id="Body">
            
            <div id="top5" style="height: 250px; width: 616px">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Top 5"></asp:Label>
                </div>
                <asp:ImageButton ID="Film1" runat="server" Height="180px" Width="120px" src="pictures\Movies\CoverSniper.jpg" />
                <asp:ImageButton ID="Film2" runat="server" Height="180px" Width="120px" src="pictures\Movies\CoverGamer.jpg"/>
                <asp:ImageButton ID="film3" runat="server" Height="180px" Width="120px" src="pictures\Movies\CoverNarnia.jpg"/>
                <asp:ImageButton ID="Film4" runat="server" Height="180px" Width="120px" src="pictures\Movies\CoverHungerGames.jpg"/>
                <asp:ImageButton ID="Film5" runat="server" Height="180px" Width="120px" src="pictures\Movies\CoverEndGame.jpg"/>
            <div id="Birthday" style="height: 250px; width: 616px">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Happy Birthday!"></asp:Label>
                </div>
                <asp:ImageButton ID="Actor1" runat="server" Height="160px" Width="120px" src="pictures\actors\PaulWalker.jpg"/>
                <asp:ImageButton ID="Actor2" runat="server" Height="160px" Width="120px" src="pictures\actors\TaylorKitsch.jpg"/>
                <asp:ImageButton ID="Actor3" runat="server" Height="160px" Width="120px" src="pictures\actors\AnnaHopkins.jpg"/>
                <asp:ImageButton ID="Actor4" runat="server" Height="160px" Width="120px" src="pictures\actors\BrendanGleeson.jpg"/>
                <asp:ImageButton ID="Actor5" runat="server" Height="160px" Width="120px" src="pictures\actors\BonnieWright.jpg"/>
            </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
