<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="WebApplication2.AddMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 310px;
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
            <asp:Button ID="btn_logon" runat="server" Text="Log on" Width="117px" OnClick="btn_logon_Click" />
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
        <div id="AddMovie" style="float: left; width: 616px; height:246px;">
            <div id="label" style="float:left;">
                <div id="Title" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
                </div>
                <div id="releaseDate" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblReleaseDate" runat="server" Text="Release Date: "></asp:Label>
                </div>
                <div id="description" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lbldescription" runat="server" Text="Description:"></asp:Label>
                </div>
                <div id="genre" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblgenre" runat="server" Text="Genre:"></asp:Label>
                </div>
                <div id="prevMovie" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblPrevMovie" runat="server" Text="Previous Movie:"></asp:Label>
                </div>
                <div id="nextMovie" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblNextMovie" runat="server" Text="Next Movie:"></asp:Label>
                </div>
                <div id="age" style="clear: both; float:left; width: 100px; padding: 3px;">
                    <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
                </div>
                <div id="sex" style="clear: both; float:left; width: 100px;">
                    <asp:Label ID="lblSex" runat="server" Text="Sex:"></asp:Label>
                </div>
                <div id="violence" style="clear: both; float:left; width: 100px;">
                    <asp:Label ID="lblViolence" runat="server" Text="Violence:"></asp:Label>
                </div>
                <div id="fear" style="clear: both; float:left; width: 100px;">
                    <asp:Label ID="lblFear" runat="server" Text="Fear:"></asp:Label>
                </div>
                <div id="discrimination" style="clear: both; float:left; width: 100px;">
                    <asp:Label ID="lblDiscrimination" runat="server" Text="Discrimination:"></asp:Label>
                </div>
                <div id="drugsAlcoholAbuse" style="clear: both; float:left; width: 100px;">
                    <asp:Label ID="lblDrugsAlcoholAbuse" runat="server" Text="Drugs of Alcoholabuse:"></asp:Label>
                </div>
                </div>
                <div id="textbox" style="float:left; width: 350px;">
                    <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbReleaseDateDay" runat="server" Width="34px"></asp:TextBox> <asp:Label ID="lblDateMonth" runat="server" Text="/"></asp:Label>
                    <asp:TextBox ID="tbReleaseDateMonth" runat="server" Width="34px"></asp:TextBox><asp:Label ID="lblMonthYear" runat="server" Text="/"></asp:Label>
                    <asp:TextBox ID="tbReleaseDateYear" runat="server" Width="34px"></asp:TextBox> <br />
                    <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbDescription"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DDGenre" runat="server">
                        <asp:ListItem>Adventure</asp:ListItem>
                        <asp:ListItem>Comedy</asp:ListItem>
                        <asp:ListItem>Drama</asp:ListItem>
                        <asp:ListItem>Humor</asp:ListItem>
                    </asp:DropDownList> <br />
                    <asp:TextBox ID="tbPrevMovie" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbPrevMovie"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="tbNextMovie" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="This textbox can not be empty" ControlToValidate="tbNextMovie"></asp:RequiredFieldValidator>
                    <div id="radiobutton" style="float: left; width: 180px;">
                    <div id="radiobuttonAge" style="float: left; width: 180px;">
                        <asp:RadioButton ID="RBnone" runat="server" Text="None"/>
                        <asp:RadioButton ID="RBsixteen" runat="server" Text="16+"/>
                        <asp:RadioButton ID="RBeightteen" runat="server" Text="18+"/>
                    </div>
                    <div id="radiobuttonOverig" style="float: left; width: 100px;">
                        <div id="rbsex" style="clear: both; float:left; width: 100px; padding: 1px;">
                        <asp:RadioButton ID="RBYesSex" runat="server" Text="Yes"/>
                        <asp:RadioButton ID="RBNoSex" runat="server" Text="No"/>
                        </div>
                        <div id="rbviolence" style="clear: both; float:left; width: 100px; padding: 1px;">
                        <asp:RadioButton ID="RBYesViolence" runat="server" Text="Yes"/>
                        <asp:RadioButton ID="RBNoViolence" runat="server" Text="No"/>
                        </div>
                        <div id="rbfear" style="clear: both; float:left; width: 100px; padding: 1px;">
                        <asp:RadioButton ID="RBYesFear" runat="server" Text="Yes"/>
                        <asp:RadioButton ID="RBNoFear" runat="server" Text="No"/>
                        </div>
                        <div id="rbdiscrimination" style="clear: both; float:left; width: 100px; padding: 1px;">
                        <asp:RadioButton ID="RBYesDiscrimination" runat="server" Text="Yes"/>
                        <asp:RadioButton ID="RBNoDiscrimination" runat="server" Text="No"/>
                        </div>
                        <div id="rbdrugsalcohol" style="clear: both; float:left; width: 100px; padding: 1px;">
                        <asp:RadioButton ID="RBYesDrugsAlcohol" runat="server" Text="Yes"/>
                        <asp:RadioButton ID="RBNoDrugsAlcohol" runat="server" Text="No"/>
                        </div>
                    </div>
                </div>
                </div>
                <div id="addbutton" style="float: left; width: 450px;">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Width="450px" />
                </div>
        </div>
        </div>
    </form>
</body>
</html>
