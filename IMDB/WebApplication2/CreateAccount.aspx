<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="WebApplication2.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create an account</title>
    <style type="text/css">
        #form1 {
            height: 281px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="left" style="width: 121px; height: 267px; float: left;">
        <div id="logo" style="width: 121px; height: 101px;">
            <asp:ImageButton ID="BtnLogo" runat="server" Height="101px" Width="121px" src="pictures\movies.jpg" OnClick="BtnLogo_Click"/>
        </div>
        <div style="height: 168px; width: 121px; " id="Menu">
            <asp:Button ID="btn_logon" runat="server" Text="Log on" Width="117px" OnClick="btn_logon_Click" style="height: 26px" />
            <asp:Button ID="btn_createAccount" runat="server" Text="Create Account!" Width="117px" OnClick="btn_createAccount_Click" />
            <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
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
            <asp:Button ID="btn_AddMovie" runat="server" Text="Add a Movie" Width="117px" OnClick="btn_AddMovie_Click" />
            <asp:Button ID="btn_AddActor" runat="server" Text="Add a Actor" Width="117px" OnClick="btn_AddActor_Click" />
        </div>
        </div>

        <div id="right" style="float: left; width: 616px; height:268px;">
        <div id="search" style="float: left; width: 616px; height:22px;">
            <asp:DropDownList ID="DDSearch" runat="server" Height="22px" Width="129px">
                <asp:ListItem>Movies</asp:ListItem>
                <asp:ListItem>Actors</asp:ListItem>
                <asp:ListItem>Genre</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="tb_search" runat="server" Width="316px" style="margin-left: 1px"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="Search" Width="149px" OnClick="btn_search_Click" />
        </div>
            <div id="logon" style="height: 150px; width: 500px; margin-left: 158px; margin-top: 60px;">
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
                <div id="letter" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblLetter" runat="server" Text="Get Letter:"></asp:Label>
                </div>
                </div>
                <div id="textbox" style="float:left; width: 350px;">
                    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbUsername"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbName"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbMail" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbMail"></asp:RequiredFieldValidator>
                    <asp:RadioButton ID="Yes" runat="server" Text="Yes"/>
                    <asp:RadioButton ID="No" runat="server" Text="No"/>
                </div>
                <div id="createbutton" style="float: left; width: 450px;">
                    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" Width="450px" />
                </div>
                
                
                
            </div>
        </div>
    </form>
</body>
</html>
