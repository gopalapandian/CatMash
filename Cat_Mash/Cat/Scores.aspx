<%@ Page Title="About" Language="C#"  AutoEventWireup="true" CodeFile="Scores.aspx.cs" Inherits="Scores" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/CustomStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h3>The scores in details :&nbsp;<asp:Label runat="server" ID="lblVotesCount"></asp:Label></h3>  
        <asp:Repeater runat="server" ID="rptCats" DataMember="Cat" OnItemDataBound="rptCats_ItemDataBound">
            <HeaderTemplate>
                <div>
                    <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="liRpt">
                    <strong>&nbsp; <%# Container.ItemIndex + 1 %>&nbsp;</strong>
                    <asp:Image runat="server" Width="70px" ID="imgCat" />
                    <span class="spR">&nbsp;Score&nbsp;<asp:Label runat="server" Font-Bold="true" ID="lblCatScore"></asp:Label></span>
                    <span class="spR">&nbsp;no of winning votes&nbsp;<asp:Label runat="server" Font-Bold="true" ID="lblWinningVotes"></asp:Label></span>
                    <span class="spR">&nbsp;no of losing votes&nbsp;<asp:Label runat="server" ID="lblLosingVotes" Font-Bold="true"></asp:Label></span>
                    <span class="spR">&nbsp;no of invalid votes&nbsp;<asp:Label runat="server" ID="lblInvalidVotes" Font-Bold="true"></asp:Label></span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></div>      
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
