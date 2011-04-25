<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SolrAspNet.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtSearch" runat="server" /><asp:Button runat="server" Text="Search" OnClick="Search" />
        <asp:ListView ID="lvResult" runat="server" ItemPlaceholderID="plhItems">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder ID="plhItems" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <%# Eval("Name") %>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
