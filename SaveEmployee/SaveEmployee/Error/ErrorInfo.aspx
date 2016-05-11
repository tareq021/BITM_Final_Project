<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorInfo.aspx.cs" Inherits="Certification_System.Error.ErrorInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
     <link rel="shortcut icon" href="../Images/error.gif" />
    <link href="../StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="centers" style="padding-top: 15%">
            <asp:Label runat="server" style="font-family: 'Microsoft JhengHei UI';font-size:70px;font-weight:bolder; color: #808080 " Text="ERROR!"></asp:Label>
            <h3 style="font-family:'Microsoft YaHei UI';color:#5b5353">An unexpected error has been occurred. We will fix this error as early as possible.</h3>
            <h2><asp:Label ID="errorDetailLabel" runat="server" class="labelStyle" /></h2>
        </div>
    </form>
</body>
</html>
