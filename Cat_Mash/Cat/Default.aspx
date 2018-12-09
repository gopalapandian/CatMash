<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/customstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="jumbotron">
        <h1>Cat Mash</h1>
        <p class="lead">Which is the most beautiful cat ?</p>
        <p><%:  nbVotes %> vote(s)</p>
    </div>
    <div class="row">
        <div class="col-md-6 parent"> 
            <h3>1</h3>
            <asp:ImageButton Width="40%" runat="server" ID="btnLeftCat" CssClass="parent img" OnClick="leftCat_Click" />
            <asp:HiddenField runat="server" ID="leftCatId" />            
        </div>
        <div class="col-md-6 parent">  
            <h3>2</h3>
            <asp:ImageButton Width="40%" runat="server" ID="btnRightCat" CssClass="parent img" OnClick="rightCat_Click" />
            <asp:HiddenField runat="server" ID="rightCatId" />            
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 txtaligncenter">
            <asp:Button runat="server" Text="Neither" ID="nextCats" OnClick="nextCats_Click" />
        </div>
    </div>
       
        <div class="row txtmarg">
            <div class="col-md-12 txtaligncenter">
                <asp:Button runat="server" Text="View Results" ID="btnViewResults" OnClick="btnViewResults_Click" />
            </div>
        </div>
    </form>      
</body>
</html>
